using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace EvanPlayHouse.Core.Infrastructure.HttpTools
{
    public class HttpAuthenticationHandler : DelegatingHandler
    {
        public HttpAuthenticationHandler(HttpMessageHandler innerHandler = null)
            : base(innerHandler ?? new HttpClientHandler())
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await Task.Delay(1).ConfigureAwait(false);


            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            return response;
        }

    }
}