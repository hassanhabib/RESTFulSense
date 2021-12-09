// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Linq;
using System.Net.Http;
using FluentAssertions;
using Moq;
using RESTFulSense.WebAssembly.Clients;
using RESTFulSense.WebAssembly.Services;
using Xunit;

namespace RESTFulSense.WebAssembly.Tests.Services
{
    public partial class RESTFulApiClientFactoryTests
    {

        [Fact]
        public void ShouldCreateRESTFulApiFactoryClientWhenNameIsNotEmpty()
        {
            // given
            string someClientName = GetRandomClientName();
            var httpClient = new HttpClient();
            var expectedHttpClient = httpClient;

            this.httpClientFactoryMock.Setup(service =>
               service.CreateClient(someClientName)).Returns(expectedHttpClient);

            // when
            RESTFulApiFactoryClient client =
                this.rESTFulApiClientFactory.CreateClient(someClientName);

            // then
            Assert.NotNull(client);

            this.httpClientFactoryMock.Verify(service =>
                service.CreateClient(someClientName), Times.Once);
        }

        [Fact]
        public void ShouldCreateRESTFulApiFactoryClientWhenNameIsEmpty()
        {
            // given
            var someHttpClient = new HttpClient();
            var expectedHttpClient = someHttpClient;

            this.httpClientFactoryMock.Setup(service =>
               service.CreateClient(string.Empty)).Returns(expectedHttpClient);

            // when
            RESTFulApiFactoryClient client =
                this.rESTFulApiClientFactory.CreateClient();

            // then
            Assert.NotNull(client);

            this.httpClientFactoryMock.Verify(service =>
                service.CreateClient(string.Empty), Times.Once);
        }
    }
}



