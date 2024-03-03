// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using RESTFulSense.Tests.Acceptance.Models;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace RESTFulSense.Tests.Acceptance.Tests
{
    public partial class RestfulSenseApiFactoryTests
    {

        [Fact]
        private async Task ShouldDeleteContentAsync()
        {
            // given
            this.wiremockServer
                .Given(Request.Create()
                    .WithPath(relativeUrl)
                    .UsingDelete())
                        .RespondWith(Response.Create()
                            .WithStatusCode(200));

            // when
            await this.factoryClient.DeleteContentAsync(relativeUrl);

            // then
            bool deletedContentResult = GetDeleteContentVerification();
            Assert.True(deletedContentResult);
        }

        [Fact]
        private async Task ShouldDeleteContentCancellationTokenAsync()
        {
            // given
            var cancellationToken = new CancellationToken(canceled: false);

            this.wiremockServer
                .Given(Request.Create()
                    .WithPath(relativeUrl)
                    .UsingDelete())
                        .RespondWith(Response.Create()
                            .WithStatusCode(200));

            // when
            await this.factoryClient.DeleteContentAsync(
                relativeUrl,
                cancellationToken: cancellationToken);

            // then
            bool deletedContentResult = GetDeleteContentVerification();
            Assert.True(deletedContentResult);
        }

        [Fact]
        public async Task ShouldDeleteContentReturnsExpectedContentDeserializeAsync()
        {
            // given
            TEntity randomContent = GetRandomTEntity();

            this.wiremockServer
                .Given(Request.Create()
                    .WithPath(relativeUrl)
                    .UsingDelete())
                        .RespondWith(Response.Create()
                            .WithStatusCode(200)
                            .WithBodyAsJson(randomContent));

            // when
            TEntity result =
                await this.factoryClient.DeleteContentAsync<TEntity>(
                    relativeUrl,
                    deserializationFunction: DeserializationContentFunction);

            // then
            Assert.Equal(randomContent.TEntityId, result.TEntityId);
            Assert.Equal(randomContent.TEntityName, result.TEntityName);
            Assert.Equal(randomContent.TEntityCreateDate, result.TEntityCreateDate);
        }

        [Fact]
        public async Task ShouldDeleteContentReturnsExpectedContentCancellationTokenAsync()
        {
            // given
            TEntity randomContent = GetRandomTEntity();
            var cancellationToken = new CancellationToken(canceled: false);

            this.wiremockServer
                .Given(Request.Create()
                    .WithPath(relativeUrl)
                    .UsingDelete())
                        .RespondWith(Response.Create()
                            .WithStatusCode(200)
                            .WithBodyAsJson(randomContent));

            // when
            TEntity result =
                await this.factoryClient.DeleteContentAsync<TEntity>(
                    relativeUrl,
                    cancellationToken: cancellationToken);

            // then
            Assert.Equal(randomContent.TEntityId, result.TEntityId);
            Assert.Equal(randomContent.TEntityName, result.TEntityName);
            Assert.Equal(randomContent.TEntityCreateDate, result.TEntityCreateDate);
        }
    }
}
