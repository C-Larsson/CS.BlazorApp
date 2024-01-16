using SocialApp.Shared.Models;
using System.ComponentModel.DataAnnotations;


namespace SocialApp.Test.Models
{
    public class LoginRequest_Tests
    {
    
        [InlineData("abc@gmail.com", "12345678", true, true)] // Valid login request
        [InlineData("abcgmail.com", "12345678", true, false)] // Invalid email
        [InlineData("abc@gmail.com", "1234567", true, false)] // Invalid password
        [InlineData("abc@gmail", "12345678", false, false)] // Invalid email
        [Theory]
        public void LoginRequest_ExpectedResult(string email, string password, bool signedIn, bool result)
        {
            var loginRequest = new UserLogin()
            {
                Email = email,
                Password = password,
                StaySignedIn = signedIn
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(loginRequest, new ValidationContext(loginRequest), validationResults, result);
            Assert.True(actual);

        }
    }
}
