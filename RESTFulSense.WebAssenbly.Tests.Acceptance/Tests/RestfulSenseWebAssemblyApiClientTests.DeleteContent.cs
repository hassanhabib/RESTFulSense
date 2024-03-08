// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using RESTFulSense.WebAssenbly.Tests.Acceptance.Models;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace RESTFulSense.WebAssenbly.Tests.Acceptance.Tests
{
    public partial class RestfulSenseWebAssemblyApiClientTests
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

            // when . then
            await this.restfulWebAssemblyApiClient.DeleteContentAsync(
                relativeUrl: relativeUrl);
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

            // when . then
            await this.restfulWebAssemblyApiClient.DeleteContentAsync(
                relativeUrl: relativeUrl,
                cancellationToken: cancellationToken);
        }

        [Fact]
        private async Task ShouldDeleteContentReturnsExpectedContentDeserializeAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedDeletedTEntity = randomTEntity;

            this.wiremockServer
                .Given(Request.Create()
                    .WithPath(relativeUrl)
                    .UsingDelete())
                        .RespondWith(Response.Create()
                            .WithStatusCode(200)
                            .WithBodyAsJson(randomTEntity));

            // when
            TEntity actualDeletedTEntity =
                await this.restfulWebAssemblyApiClient.DeleteContentAsync<TEntity>(
                    relativeUrl: relativeUrl,
                    deserializationFunction: DeserializationContentFunction);

            // then
            actualDeletedTEntity.Should().BeEquivalentTo(expectedDeletedTEntity);
        }

        [Fact]
        private async Task ShouldDeleteContentReturnsExpectedContentCancellationTokenAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedDeletedTEntity = randomTEntity;
            var cancellationToken = new CancellationToken(canceled: false);

            this.wiremockServer
                .Given(Request.Create()
                    .WithPath(relativeUrl)
                    .UsingDelete())
                        .RespondWith(Response.Create()
                            .WithStatusCode(200)
                            .WithBodyAsJson(randomTEntity));

            // when
            TEntity actualDeletedTEntity =
                await this.restfulWebAssemblyApiClient.DeleteContentAsync<TEntity>(
                    relativeUrl: relativeUrl,
                    cancellationToken: cancellationToken);

            // then
            actualDeletedTEntity.Should().BeEquivalentTo(expectedDeletedTEntity);
        }
    }
}