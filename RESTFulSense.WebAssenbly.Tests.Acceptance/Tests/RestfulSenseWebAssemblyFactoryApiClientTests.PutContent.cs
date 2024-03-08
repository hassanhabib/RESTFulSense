// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using RESTFulSense.WebAssenbly.Tests.Acceptance.Models;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace RESTFulSense.WebAssenbly.Tests.Acceptance.Tests
{
    public partial class RestfulSenseWebAssemblyFactoryApiClientTests
    {
        [Fact]
        private async Task ShouldPutContentReturnsExpectedWithSerializedAndDeserializedContentAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedTEntity = randomTEntity;
            string mediaType = "text/json";
            bool ignoreDefaultValues = false;

            this.wiremockServer
                .Given(Request.Create()
                    .WithPath(relativeUrl)
                    .UsingPut())
                        .RespondWith(Response.Create()
                            .WithStatusCode(200)
                            .WithBodyAsJson(randomTEntity));

            // when
            TEntity actualTEntity =
                await this.webAssemblyApiFactoryClient.PutContentAsync<TEntity>(
                    relativeUrl: relativeUrl,
                    content: randomTEntity,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction<TEntity>,
                    deserializationFunction: ContentDeserializationFunction);

            // then
            actualTEntity.Should().BeEquivalentTo(expectedTEntity);
        }

        [Fact]
        private async Task ShouldCancelTaskOnPutContentReturnsContentIfCancellationInvokedAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            string mediaType = "text/json";
            bool ignoreDefaultValues = false;
            var expectedCanceledTaskException = new TaskCanceledException();
            var taskCancelInvoked = new CancellationToken(canceled: true);

            wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingPut())
                    .RespondWith(Response.Create()
                        .WithBodyAsJson(randomTEntity));

            // when
            TaskCanceledException actualCanceledTask =
                await Assert.ThrowsAsync<TaskCanceledException>(async () =>
                    await this.webAssemblyApiFactoryClient.PutContentAsync<TEntity>(
                        relativeUrl: relativeUrl,
                        content: randomTEntity,
                        cancellationToken: taskCancelInvoked,
                        mediaType: mediaType,
                        ignoreDefaultValues: ignoreDefaultValues,
                        serializationFunction: SerializationContentFunction<TEntity>,
                        deserializationFunction: ContentDeserializationFunction));

            // then
            actualCanceledTask.Should().BeEquivalentTo(expectedCanceledTaskException);
        }

        [Fact]
        private async Task ShouldPutContentWithTContentReturnsTResultAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedTEntity = randomTEntity;
            string expectedBody = JsonSerializer.Serialize(randomTEntity);
            string mediaType = "text/json";
            bool ignoreDefaultValues = false;

            this.wiremockServer.Given(
                Request.Create()
                    .WithPath(relativeUrl)
                    .UsingPut())
                        .RespondWith(
                            Response.Create()
                                .WithStatusCode(200)
                                .WithHeader("Content-Type", mediaType)
                                .WithBody(expectedBody));

            // when
            TEntity actualTEntity =
                await this.webAssemblyApiFactoryClient.PutContentAsync<TEntity, TEntity>(
                    relativeUrl: relativeUrl,
                    content: randomTEntity,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction<TEntity>,
                    deserializationFunction: ContentDeserializationFunction);

            // then
            actualTEntity.Should().BeEquivalentTo(expectedTEntity);
        }

        [Fact]
        private async Task ShouldPutContentWithTContentReturnsTResultWithCancellationTokenAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedTEntity = randomTEntity;
            string expectedBody = JsonSerializer.Serialize(randomTEntity);

            CancellationToken cancellationToken =
                new CancellationToken(canceled: false);

            string mediaType = "text/json";
            bool ignoreDefaultValues = false;

            this.wiremockServer.Given(
                Request.Create()
                    .WithPath(relativeUrl)
                    .UsingPut())
                        .RespondWith(
                            Response.Create()
                                .WithStatusCode(200)
                                .WithHeader("Content-Type", mediaType)
                                .WithBody(expectedBody));

            // when
            TEntity actualTEntity =
                await this.webAssemblyApiFactoryClient.PutContentAsync<TEntity, TEntity>(
                    relativeUrl: relativeUrl,
                    content: randomTEntity,
                    cancellationToken: cancellationToken,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction,
                    deserializationFunction: ContentDeserializationFunction);

            // then
            actualTEntity.Should().BeEquivalentTo(expectedTEntity);
        }

        [Fact]
        private async Task ShouldPutContentReturnsContentWithDeserializationAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedTEntity = randomTEntity;
            string expectedBody = JsonSerializer.Serialize(randomTEntity);

            this.wiremockServer.Given(
                Request.Create()
                    .WithPath(relativeUrl)
                    .UsingPut())
                        .RespondWith(
                            Response.Create()
                                .WithStatusCode(200)
                                .WithBody(expectedBody));

            // when
            TEntity actualTEntity =
                await this.webAssemblyApiFactoryClient.PutContentAsync<TEntity>(
                    relativeUrl: relativeUrl,
                    deserializationFunction: ContentDeserializationFunction);

            // then
            actualTEntity.Should().BeEquivalentTo(expectedTEntity);
        }

        [Fact]
        private async Task ShouldPutContentReturnsContentWithCancellationTokenDeserializationAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedTEntity = randomTEntity;
            string expectedBody = JsonSerializer.Serialize(randomTEntity);
            var cancellationToken = new CancellationToken(canceled: false);

            this.wiremockServer.Given(
                Request.Create()
                    .WithPath(relativeUrl)
                    .UsingPut())
                        .RespondWith(
                            Response.Create()
                                .WithStatusCode(200)
                                .WithBody(expectedBody));

            // when
            TEntity actualTEntity =
                await this.webAssemblyApiFactoryClient.PutContentAsync<TEntity>(
                    relativeUrl: relativeUrl,
                    cancellationToken: cancellationToken,
                    deserializationFunction: ContentDeserializationFunction);

            // then
            actualTEntity.Should().BeEquivalentTo(expectedTEntity);
        }
    }
}