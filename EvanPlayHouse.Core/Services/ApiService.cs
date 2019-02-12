using System;
using System.Net.Http;
using EvanPlayHouse.Common;
using EvanPlayHouse.Core.Infrastructure.HttpTools;
using Fusillade;
using Newtonsoft.Json;
using Refit;

namespace EvanPlayHouse.Core.Services
{
    public class ApiService : IApiService
    {
        private static string _ApiBaseAddress => Constant.ApiEndpoint;

        public ApiService(string apiBaseAddress = null)
        {
           
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            };
            IProjectApi createClient(HttpMessageHandler messageHandler)
            {
                var client = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(apiBaseAddress ?? _ApiBaseAddress),
                    //Timeout = Constant.ApiTimeout
                };
                return RestService.For<IProjectApi>(client);
            }

            _Background = new Lazy<IProjectApi>(() =>
            {
#if DEBUG
                return createClient(new RateLimitedHttpMessageHandler(new HttpLoggingAndAuthenticationHandler(), Priority.Background));
#else
                return createClient(new RateLimitedHttpMessageHandler(new HttpAuthenticationHandler(), Priority.Background));
#endif
            });

            _UserInitiated = new Lazy<IProjectApi>(() =>
            {
#if DEBUG
                return createClient(new RateLimitedHttpMessageHandler(new HttpLoggingAndAuthenticationHandler(), Priority.UserInitiated));
#else
                return createClient(new RateLimitedHttpMessageHandler(new HttpAuthenticationHandler(), Priority.UserInitiated));
#endif
            });

            _Speculative = new Lazy<IProjectApi>(() =>
            {
#if DEBUG
                return createClient(new RateLimitedHttpMessageHandler(new HttpLoggingAndAuthenticationHandler(), Priority.Speculative));
#else
                return createClient(new RateLimitedHttpMessageHandler(new HttpAuthenticationHandler(), Priority.Speculative));
#endif
            });
        }

        private readonly Lazy<IProjectApi> _Background;
        private readonly Lazy<IProjectApi> _UserInitiated;
        private readonly Lazy<IProjectApi> _Speculative;

        public IProjectApi Speculative => _Speculative.Value;
        public IProjectApi UserInitiated => _UserInitiated.Value;
        public IProjectApi Background => _Background.Value;
    }
}
