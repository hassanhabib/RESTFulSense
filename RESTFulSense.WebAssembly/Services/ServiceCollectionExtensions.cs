// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Net.Http;

namespace RESTFulSense.WebAssembly.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IHttpClientBuilder AddRESTFulApiClient(
            this IServiceCollection services,
            string name,
            Action<HttpClient> configureHttpClient)
        {
            services.TryAddSingleton<IRESTFulApiClientFactory, RESTFulApiClientFactory>();

            return services.AddHttpClient(name, configureHttpClient);
        }
    }
}
