using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Umbrella.Enums;
using Umbrella.Models;
using Umbrella.RestClient;
using Umbrella.Utilities;
using System.Threading;

namespace Umbrella.Services
{
    public class AuthenticationService
    {
        private UserClientService _userClientService;

        public AuthenticationService()
        {
            _userClientService = new UserClientService();
        }

        public async Task<AuthenticationResult> AuthenticateUser(string username, string password)
        {
            var result = new AuthenticationResult();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                result.Status = AuthenticationStatus.CredentialsRequired;
            }
            else
            {
                User user = null;

                if (!IsEmailAddress(username))
                {
                    user = await _userClientService.AuthenticateToAPI(username, password, AuthenticationType.Username);
                }
                else
                {
                    user = await _userClientService.AuthenticateToAPI(username, password, AuthenticationType.Email);
                }

                if (user != null)
                {
                    result.Status = user.AuthenticationStatus;
                    Global.SetUserId(user.Id.ToString());
                    Global.SetUserEmail(user.Email);
                    result.User = new User()
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Nickname = user.Nickname,
                        DisplayName = user.DisplayName,
                        Description = user.Description,
                        Registered = user.Registered
                    };
                }
                else
                {
                    result.Status = AuthenticationStatus.AuthenticationFailed;
                }
            }
            System.Diagnostics.Debug.WriteLine("Returned #2 from AuthenticateUser" );
            return result;
        }

        private bool IsEmailAddress(string text)
        {
            return Regex.IsMatch(text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
