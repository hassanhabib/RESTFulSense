// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using RESTFulSense.Tests.Acceptance.Models;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace RESTFulSense.Tests.Acceptance.Tests
{
    public partial class RestfulApiClientTests
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
            await this.restfulApiClient.DeleteContentAsync(relativeUrl);
            var requestLogs = this.wiremockServer.LogEntries;

            var deleteContentRequest =
                requestLogs.FirstOrDefault(
                    request => request.RequestMessage.Path == relativeUrl);

            // then
            deleteContentRequest.Should().NotBeNull();
            deleteContentRequest.RequestMessage.Path.Should().Be(relativeUrl);
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
            await this.restfulApiClient.DeleteContentAsync(
                relativeUrl,
                cancellationToken: cancellationToken);

            var requestLogs = this.wiremockServer.LogEntries;

            var deleteContentRequest =
                requestLogs.FirstOrDefault(
                    request => request.RequestMessage.Path == relativeUrl);

            // then
            deleteContentRequest.Should().NotBeNull();
            deleteContentRequest.RequestMessage.Path.Should().Be(relativeUrl);
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
            var result =
                await this.restfulApiClient.DeleteContentAsync<TEntity>(
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
            var result =
                await this.restfulApiClient.DeleteContentAsync<TEntity>(
                    relativeUrl,
                    cancellationToken: cancellationToken);

            // then
            Assert.Equal(randomContent.TEntityId, result.TEntityId);
            Assert.Equal(randomContent.TEntityName, result.TEntityName);
            Assert.Equal(randomContent.TEntityCreateDate, result.TEntityCreateDate);
        }
    }
}
