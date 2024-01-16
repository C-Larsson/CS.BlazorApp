using System.ComponentModel.DataAnnotations;

namespace SocialApp.Shared.DataAnnotations
{
    /// <summary>
    /// 
    /// </summary>
    public class NotNullOrWhiteSpaceValidatorAttribute : ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public NotNullOrWhiteSpaceValidatorAttribute() : base("Invalid Field") { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Message"></param>
        public NotNullOrWhiteSpaceValidatorAttribute(string Message) : base(Message) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            if (string.IsNullOrWhiteSpace(value.ToString())) return false;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult? IsValid(Object? value, ValidationContext validationContext)
        {
            if (IsValid(value)) return ValidationResult.Success;
            return new ValidationResult("Value cannot be empty or white space.");
        }
    }
    
}
