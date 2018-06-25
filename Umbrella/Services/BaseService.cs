using Umbrella.Constants;
namespace Umbrella.Services
{
    public class BaseService
    {
        protected readonly string _scheme;
        protected readonly string _wp_host;
        protected readonly string _api_host;
        protected readonly string _port;
        protected readonly string _root;
        protected readonly string _username;
        protected readonly string _password;

        public BaseService()
        {
            _scheme = UmbrellaApi.SCHEME;
            _wp_host = UmbrellaApi.WP_HOST;
            _api_host = UmbrellaApi.API_HOST;
            _port = UmbrellaApi.PORT;
            _root = UmbrellaApi.ROOT;
            _username = UmbrellaApi.USERNAME;
            _password = UmbrellaApi.PASSKEY;
        }
    }
}
