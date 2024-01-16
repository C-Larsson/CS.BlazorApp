using System.ComponentModel.DataAnnotations;

namespace SocialApp.Shared.DataAnnotations
{
    /// <summary>
    /// Returns true if the date is at least 24 hours in the future
    /// </summary>
    public class FutureDateAttribute : ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object? value)
        {
            if (value == null || (value as string)?.Length == 0)
            {
                return false;
            }

            DateTime convertedValue;

            try
            {
                convertedValue = DateTime.Parse(value?.ToString() ?? "");
            }
            catch (FormatException)
            {
                return false;
            }
            catch (InvalidCastException)
            {
                return false;
            }
            catch (NotSupportedException)
            {
                return false;
            }


            return convertedValue > DateTime.Now.AddHours(24); // To handle Daylight saving time and other stuff

        }


    }
}
