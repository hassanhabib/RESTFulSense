// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Net.Http;
using Moq;
using RESTFulSense.WebAssembly.Services;
using Tynamix.ObjectFiller;

namespace RESTFulSense.WebAssembly.Tests.Services
{
    public partial class RESTFulApiClientFactoryTests
    {
        private readonly Mock<IHttpClientFactory> httpClientFactoryMock;
        private readonly RESTFulApiClientFactory rESTFulApiClientFactory;

        public RESTFulApiClientFactoryTests()
        {
            this.httpClientFactoryMock =
                new Mock<IHttpClientFactory>();

            this.rESTFulApiClientFactory =
                new RESTFulApiClientFactory(httpClientFactoryMock.Object);
        }

        private static string GetRandomClientName() =>
           new MnemonicString().GetValue();
    }
}
