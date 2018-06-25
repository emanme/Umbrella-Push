using Umbrella.Enums;

namespace Umbrella.Models
{
    public class AuthenticationResult
    {
        public AuthenticationStatus Status { get; set; } 
        public User User { get; set; }
       public string userID { get; set; }
    }
}
