// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

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

            // when . then
            await this.restfulApiClient.DeleteContentAsync(relativeUrl);
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
            await this.restfulApiClient.DeleteContentAsync(
                relativeUrl,
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
                await this.restfulApiClient.DeleteContentAsync<TEntity>(
                    relativeUrl,
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
                await this.restfulApiClient.DeleteContentAsync<TEntity>(
                    relativeUrl,
                    cancellationToken: cancellationToken);

            // then
            actualDeletedTEntity.Should().BeEquivalentTo(expectedDeletedTEntity);
        }
    }
}