// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RESTFulSense.Tests.Acceptance.Models;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace RESTFulSense.Tests.Acceptance.Tests
{
    public partial class RestfulApiClientTests
    {
        [Fact]
        private async Task ShouldPutContentReturnsExpectedWithSerializedAndDeserializedContentAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            var mediaType = "text/json";
            var ignoreDefaultValues = false;

            this.wiremockServer
                .Given(Request.Create()
                    .WithPath(relativeUrl)
                    .UsingPut())
                        .RespondWith(Response.Create()
                            .WithStatusCode(200)
                            .WithBodyAsJson(randomTEntity));

            // when
            TEntity result =
                await this.restfulApiClient.PutContentAsync<TEntity>(
                    relativeUrl,
                    content: randomTEntity,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    SerializationContentFunction<TEntity>,
                    DeserializationContentFunction);

            // then
            Assert.Equal(randomTEntity.TEntityId, result.TEntityId);
            Assert.Equal(randomTEntity.TEntityName, result.TEntityName);
            Assert.Equal(randomTEntity.TEntityCreateDate, result.TEntityCreateDate);
        }

        [Fact]
        private async Task ShouldPutContentWithTContentReturnsTResultAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            var mediaType = "text/json";
            var ignoreDefaultValues = false;

            this.wiremockServer.Given(
                Request.Create()
                    .WithPath(relativeUrl)
                    .UsingPut())
                        .RespondWith(
                            Response.Create()
                                .WithStatusCode(200)
                                .WithHeader("Content-Type", mediaType)
                                .WithBody(
                                    JsonConvert.SerializeObject(randomTEntity)));

            // when
            var result =
                await this.restfulApiClient.PutContentAsync<TEntity, TEntity>(
                    relativeUrl,
                    content: randomTEntity,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction<TEntity>,
                    deserializationFunction: DeserializationContentFunction);

            // then
            Assert.Equal(randomTEntity.TEntityId, result.TEntityId);
            Assert.Equal(randomTEntity.TEntityName, result.TEntityName);
            Assert.Equal(randomTEntity.TEntityCreateDate, result.TEntityCreateDate);
        }

        [Fact]
        private async Task ShouldPutContentWithTContentReturnsTResultWithCancellationTokenAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();

            CancellationToken cancellationToken =
                new CancellationToken(canceled: false);

            var mediaType = "text/json";
            var ignoreDefaultValues = false;

            this.wiremockServer.Given(
                Request.Create()
                    .WithPath(relativeUrl)
                    .UsingPut())
                        .RespondWith(
                            Response.Create()
                                .WithStatusCode(200)
                                .WithHeader("Content-Type", mediaType)
                                .WithBody(
                                    JsonConvert.SerializeObject(randomTEntity)));

            // when
            var result =
                await this.restfulApiClient.PutContentAsync<TEntity, TEntity>(
                    relativeUrl,
                    content: randomTEntity,
                    cancellationToken: cancellationToken,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction,
                    deserializationFunction: DeserializationContentFunction);

            // then
            Assert.Equal(randomTEntity.TEntityId, result.TEntityId);
            Assert.Equal(randomTEntity.TEntityName, result.TEntityName);
            Assert.Equal(randomTEntity.TEntityCreateDate, result.TEntityCreateDate);
        }

        [Fact]
        private async Task ShouldPutContentReturnsContentWithDeserializationAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();

            this.wiremockServer.Given(
                Request.Create()
                    .WithPath(relativeUrl)
                    .UsingPut())
                        .RespondWith(
                            Response.Create()
                                .WithStatusCode(200)
                                .WithBody(JsonConvert.SerializeObject(randomTEntity)));

            // when
            var result =
                await this.restfulApiClient.PutContentAsync<TEntity>(
                    relativeUrl,
                    deserializationFunction: DeserializationContentFunction);

            // then
            Assert.Equal(randomTEntity.TEntityId, result.TEntityId);
            Assert.Equal(randomTEntity.TEntityName, result.TEntityName);
            Assert.Equal(randomTEntity.TEntityCreateDate, result.TEntityCreateDate);
        }

        [Fact]
        private async Task ShouldPutContentReturnsContentWithCancellationTokenDeserializationAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            var cancellationToken = new CancellationToken(canceled: false);

            this.wiremockServer.Given(
                Request.Create()
                    .WithPath(relativeUrl)
                    .UsingPut())
                        .RespondWith(
                            Response.Create()
                                .WithStatusCode(200)
                                .WithBody(JsonConvert.SerializeObject(randomTEntity)));

            // when
            var result =
                await this.restfulApiClient.PutContentAsync<TEntity>(
                    relativeUrl,
                    cancellationToken: cancellationToken,
                    deserializationFunction: DeserializationContentFunction);

            // then
            Assert.Equal(randomTEntity.TEntityId, result.TEntityId);
            Assert.Equal(randomTEntity.TEntityName, result.TEntityName);
            Assert.Equal(randomTEntity.TEntityCreateDate, result.TEntityCreateDate);
        }
    }
}