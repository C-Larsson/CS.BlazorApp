using Microsoft.EntityFrameworkCore;
using Stripe;
using Stripe.Checkout;

namespace SocialApp.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        private readonly IEventService _eventService;
        private readonly IReservationService _reservationService;

        const string secret = "whsec_f9a6022bbe7f17b3f7a079be3c33d7059c0f02eb333e36d5898a497c4ec8d03f";

        public PaymentService(DataContext context, IAuthService authService, IEventService eventService, IReservationService reservationService ) 
        {
            StripeConfiguration.ApiKey = "sk_test_51Nd46MHLdpLWsDNhY8QG6kRnn8WrHnn5ivtH7QbiN7TmEO9FGb98K1wmraE3s4Ok3KUnjXdNdKzwlsfbdn44Wb1400hgoC4Zov";

            _context = context;
            _authService = authService;
            _eventService = eventService;
            _reservationService = reservationService;
        }


        public async Task<Session> CreateCheckoutSession()
        {
            // TODO: find a way to only get reservations for this payment
            var reservations = (await _reservationService.GetUnpaidReservations()).Data;
            reservations.ForEach(reservation => reservation.PaymentStatus = PaymentStatus.Pending);

            var userId = reservations[0].UserId;
            var lineItems = new List<SessionLineItemOptions>();

            foreach (var reservation in reservations)
            {
                if (String.IsNullOrEmpty(reservation.Event.ImageUrl))
                {
                    lineItems.Add(new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmountDecimal = reservation.Event.Price * 100,
                            Currency = reservation.CurrencyCode.ToString(),
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = reservation.Event.Title
                            }
                        },
                        Quantity = reservation.AttendeeCount
                    });
                } else
                {
                    lineItems.Add(new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmountDecimal = reservation.Event.Price * 100,
                            Currency = reservation.CurrencyCode.ToString(),
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = reservation.Event.Title,
                                Images = new List<string> { reservation.Event.ImageUrl }
                            }
                        },
                        Quantity = reservation.AttendeeCount
                    });
                }
            }
            
            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                ShippingAddressCollection =
                    new SessionShippingAddressCollectionOptions
                    {
                        AllowedCountries = new List<string> { "SE", "TH" }
                    },
                PaymentMethodTypes = new List<string>
                {
                    "card",
                    "klarna"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = $"https://localhost:7248/payment-success",
                CancelUrl = "https://localhost:7248/reservation"
            };

            var service = new SessionService();
            Session session = service.Create(options);
            _context.Reservations.UpdateRange(reservations);
            await _context.SaveChangesAsync();
            return session;
        }

        public async Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request)
        {
            var json = await new StreamReader(request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                        json,
                        request.Headers["Stripe-Signature"],
                        secret
                    );

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _authService.GetUserByEmail(session.CustomerEmail);
                    // TODO: unclear when to confirm payment
                    session.ClientReferenceId = user.Id.ToString();
                    await _reservationService.ConfirmPayment(session.CustomerEmail);
                }

                return new ServiceResponse<bool> { Data = true };
            }
            catch (StripeException e)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = e.Message };
            }
        }

        public async Task<ServiceResponse<List<Reservation>>> ConfirmPayment(List<int> reservations)
        {
            //var reservations = (await _reservationService.GetUnpaidReservations()).Data;
            var dbReservations = await _context.Reservations
                .Where(r => reservations.Contains(r.Id))
                .Include(r => r.Event)
                .ToListAsync();

            foreach (var reservation in dbReservations)
            {
                reservation.ReservationStatus = ReservationStatus.Confirmed;
                reservation.PaymentStatus = PaymentStatus.Paid;
                reservation.PaymentDate = DateTime.UtcNow;
            }
            await _context.SaveChangesAsync();

            return new ServiceResponse<List<Reservation>> { Data = dbReservations };
        }
    }
}

