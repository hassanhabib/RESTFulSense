// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using RESTFulSense.WebAssembly.Clients;
using System.Net.Http;

namespace RESTFulSense.WebAssembly.Services
{
    public class RESTFulApiClientFactory : IRESTFulApiClientFactory
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RESTFulApiClientFactory(IHttpClientFactory httpClientFactory) =>
            this.httpClientFactory = httpClientFactory;

        public RESTFulApiFactoryClient CreateClient(string name)
        {
            var httpClient = httpClientFactory.CreateClient(name);

            return new RESTFulApiFactoryClient(httpClient);
        }
    }
}
