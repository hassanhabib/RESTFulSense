// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
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
        private async Task ShouldPostContentWithNoResponseAndDeserializeContentAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedTEntity = randomTEntity;
            string mediaType = "application/json";
            bool ignoreDefaultValues = false;

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingPost())
                    .RespondWith(Response.Create()
                        .WithStatusCode(200));

            // when
            Action actualResponseResult = async () =>
                await this.restfulApiClient.PostContentWithNoResponseAsync<TEntity>(
                    relativeUrl,
                    content: expectedTEntity,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction);

            // then
            actualResponseResult.Should().NotBeNull();
        }

        [Fact]
        private async Task ShouldCancelPostContentWithNoResponseAndDeserializationWhenCancellationInvokedAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            var expectedPostContentCanceledException = new TaskCanceledException();

            this.wiremockServer.Given(Request.Create()
               .WithPath(relativeUrl)
               .UsingPost())
                   .RespondWith(Response.Create()
                       .WithHeader("Content-Type", "application/json")
                       .WithBodyAsJson(randomTEntity));

            // when
            var taskCanceledToken = new CancellationToken(canceled: true);

            var actualPostContentCanceledTask =
                await Assert.ThrowsAsync<TaskCanceledException>(async () =>
                    await this.restfulApiClient.PostContentWithNoResponseAsync<TEntity>(
                        relativeUrl,
                        content: randomTEntity,
                        cancellationToken: taskCanceledToken,
                        mediaType: "application/json",
                        ignoreDefaultValues: true,
                        serializationFunction: SerializationContentFunction));

            // then
            actualPostContentCanceledTask.Should().NotBeNull();

            actualPostContentCanceledTask.Should().BeEquivalentTo(
                expectedPostContentCanceledException);
        }

        [Fact]
        public async Task ShouldPostContentReturnsContentWithCustomSerializationAndDeserializationAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedTEntity = randomTEntity;
            string mediaType = "application/json";
            bool ignoreDefaultValues = false;

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingPost())
                    .RespondWith(Response.Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(expectedTEntity));

            // when
            var result =
                await this.restfulApiClient.PostContentAsync<TEntity>(
                    relativeUrl,
                    content: expectedTEntity,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction,
                    deserializationFunction: DeserializationContentFunction);

            // then
            Assert.Equal(expectedTEntity.TEntityName, result.TEntityName);
        }

        [Fact]
        private async Task ShouldCancelPostContentWhenCancellationIsInvokedAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            string mediaType = "application/json";
            bool ignoreDefaultValues = false;

            var expectedPostContentCanceledException = new TaskCanceledException();


            this.wiremockServer.Given(Request.Create()
               .WithPath(relativeUrl)
               .UsingPost())
                   .RespondWith(Response.Create()
                       .WithHeader("Content-Type", mediaType)
                       .WithBodyAsJson(randomTEntity));

            // when
            var taskCanceledToken = new CancellationToken(canceled: true);

            var actualCanceledTaskResult =
                await Assert.ThrowsAsync<TaskCanceledException>(async () =>
                    await this.restfulApiClient.PostContentAsync<TEntity>(
                        relativeUrl,
                        content: randomTEntity,
                        cancellationToken: taskCanceledToken,
                        mediaType: mediaType,
                        ignoreDefaultValues: ignoreDefaultValues));

            // then
            actualCanceledTaskResult.Should().BeEquivalentTo(
                expectedPostContentCanceledException);
        }

        [Fact]
        private async Task ShouldPostContentWithStreamResponseAsync()
        {
            // given
            string randomContent = CreateRandomContent();
            var cancellationToken = new CancellationToken();
            string mediaType = "text/json";
            bool ignoreDefaultValues = false;

            this.wiremockServer.Given(
                Request.Create()
                .WithPath(relativeUrl)
                .UsingPost())
                    .RespondWith(
                        Response.Create()
                            .WithStatusCode(200)
                            .WithHeader("Content-Type", mediaType)
                            .WithBody(randomContent));

            // when
            var result =
                await this.restfulApiClient.PostContentWithStreamResponseAsync(
                    relativeUrl,
                    content: randomContent,
                    cancellationToken: cancellationToken,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction);

            var resultReadContent = await ReadStreamToEndAsync(result);

            // then
            Assert.Equal(randomContent, resultReadContent);
        }

        [Fact]
        private async Task ShouldPostContentWithTContentReturnsTResultAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            string mediaType = "text/json";
            bool ignoreDefaultValues = false;

            this.wiremockServer.Given(
                Request.Create()
                    .WithPath(relativeUrl)
                    .UsingPost())
                        .RespondWith(
                            Response.Create()
                                .WithStatusCode(200)
                                .WithHeader("Content-Type", mediaType)
                                .WithBody(JsonConvert.SerializeObject(randomTEntity)));

            // when
            var result =
                await this.restfulApiClient.PostContentAsync<TEntity, TEntity>(
                    relativeUrl,
                    content: randomTEntity,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    SerializationContentFunction,
                    DeserializationContentFunction);

            // then
            Assert.Equal(randomTEntity.TEntityId, result.TEntityId);
            Assert.Equal(randomTEntity.TEntityName, result.TEntityName);
            Assert.Equal(randomTEntity.TEntityCreateDate, result.TEntityCreateDate);
        }

        [Fact]
        private async Task ShouldPostContentWithTContentReturnsTResultCancellationTokenAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            var cancellationToken = new CancellationToken();
            string mediaType = "text/json";
            bool ignoreDefaultValues = false;

            this.wiremockServer.Given(
                Request.Create()
                    .WithPath(relativeUrl)
                    .UsingPost())
                        .RespondWith(
                            Response.Create()
                                .WithStatusCode(200)
                                .WithHeader("Content-Type", mediaType)
                                .WithBody(JsonConvert.SerializeObject(randomTEntity)));

            // when
            var result =
                await this.restfulApiClient.PostContentAsync<TEntity, TEntity>(
                    relativeUrl,
                    content: randomTEntity,
                    cancellationToken: cancellationToken,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    SerializationContentFunction,
                    DeserializationContentFunction);

            // then
            Assert.Equal(randomTEntity.TEntityId, result.TEntityId);
            Assert.Equal(randomTEntity.TEntityName, result.TEntityName);
            Assert.Equal(randomTEntity.TEntityCreateDate, result.TEntityCreateDate);
        }

        [Fact]
        private async Task ShouldPostFormWithTContentReturnsTResultAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            var cancellationToken = new CancellationToken();

            this.wiremockServer.Given(
                Request.Create()
                    .WithPath(relativeUrl)
                    .UsingPost())
                        .RespondWith(
                            Response.Create()
                                .WithStatusCode(200)
                                .WithBody(JsonConvert.SerializeObject(randomTEntity)));

            // when
            var result =
                await this.restfulApiClient.PostFormAsync(
                    relativeUrl,
                    content: randomTEntity,
                    cancellationToken: cancellationToken,
                    deserializationFunction: DeserializationContentFunction);

            // then
            Assert.Equal(randomTEntity.TEntityId, result.TEntityId);
            Assert.Equal(randomTEntity.TEntityName, result.TEntityName);
            Assert.Equal(randomTEntity.TEntityCreateDate, result.TEntityCreateDate);
        }
    }
}