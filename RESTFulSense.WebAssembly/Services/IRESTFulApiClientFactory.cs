// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using RESTFulSense.WebAssembly.Clients;

namespace RESTFulSense.WebAssembly.Services
{
    public interface IRESTFulApiClientFactory
    {
        RESTFulApiFactoryClient CreateClient(string name);
    }
}
