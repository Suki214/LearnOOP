using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace PrismTwitterReader.TwitterAccesss
{
    public class TwitterHttpClientHandler : HttpClientHandler
    {
        private string _authorizationHeader;

        public TwitterHttpClientHandler(string authorizationHeader)
        {
            UseCookies = false;
            UseDefaultCredentials = false;

            _authorizationHeader = authorizationHeader;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("User-Agent", "TwitterPlay/1.1.0.0");
            request.Headers.ExpectContinue = false;
            request.Headers.CacheControl = new CacheControlHeaderValue { NoCache = true };
            request.Headers.Add("Authorization", _authorizationHeader);
            request.Version = new Version("1.1");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("image/jpeg"));
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return base.SendAsync(request, cancellationToken);
        }
    }
}
