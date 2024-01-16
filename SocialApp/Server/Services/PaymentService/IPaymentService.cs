using Stripe.Checkout;

namespace SocialApp.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
        Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request);

        Task<ServiceResponse<List<Reservation>>> ConfirmPayment(List<int> reservations);
    }
}
