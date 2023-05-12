// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;
using Moq;
using RESTFulSense.Clients;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Controllers
{
    public partial class RESTFulApiFactoryClientTests
    {
        private readonly Mock<HttpMessageHandler> httpMessageHandlerMock;
        public readonly RESTFulApiFactoryClient apiClient;

        public RESTFulApiFactoryClientTests()
        {
            this.httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(this.httpMessageHandlerMock.Object)
            {
                BaseAddress = new System.Uri("http://localhost/")
            };

            this.apiClient = new RESTFulApiFactoryClient(
                httpClient: httpClient);
        }

        private static int GetRandomNumber() =>
            new SequenceGeneratorInt32().GetValue();

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static Money GetRandomMoney()
        {
            var randomAmount = GetRandomNumber();
            var randomCurrency = CreateRandomString();
            return new Money(randomAmount, randomCurrency);
        }
    }
}