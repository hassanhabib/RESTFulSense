// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Microsoft.Extensions.Options;
using RESTFulSense.WebAssembly.Clients;

namespace RESTFulSense.WebAssembly.Services
{
    public static class RESTFulApiClientFactoryExtensions
    {
        public static RESTFulApiFactoryClient CreateClient(this RESTFulApiClientFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(paramName: nameof(factory));
            }

            return factory.CreateClient(Options.DefaultName);
        }
    }
}
