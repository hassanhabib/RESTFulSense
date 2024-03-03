// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.IO;
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
    public partial class RestfulSenseApiFactoryTests
    {
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

            TaskCanceledException actualPostContentCanceledTask =
                await Assert.ThrowsAsync<TaskCanceledException>(async () =>
                    await this.factoryClient.PostContentWithNoResponseAsync<TEntity>(
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
                await this.factoryClient.PostContentWithNoResponseAsync<TEntity>(
                    relativeUrl,
                    content: expectedTEntity,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction);

            // then
            actualResponseResult.Should().NotBeNull();
        }

        [Fact]
        private async Task ShouldPostContentReturnsContentWithCustomSerializationAndDeserializationAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            var expectedTEntity = randomTEntity;
            string mediaType = "application/json";
            bool ignoreDefaultValues = false;

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingPost())
                    .RespondWith(Response.Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(expectedTEntity));

            // when
            TEntity actualTEntity =
                await this.factoryClient.PostContentAsync<TEntity>(
                    relativeUrl,
                    content: expectedTEntity,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction,
                    deserializationFunction: ContentDeserializationFunction);

            // then
            actualTEntity.Should().BeEquivalentTo(expectedTEntity);
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

            TaskCanceledException actualCanceledTaskResult =
                await Assert.ThrowsAsync<TaskCanceledException>(async () =>
                    await this.factoryClient.PostContentAsync<TEntity>(
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
            Stream actualStream =
                await this.factoryClient.PostContentWithStreamResponseAsync(
                    relativeUrl,
                    content: randomContent,
                    cancellationToken: cancellationToken,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction);

            string actualReadContent = await ReadStreamToEndAsync(actualStream);

            // then
            actualReadContent.Should().BeEquivalentTo(randomContent);
        }

        [Fact]
        private async Task ShouldPostContentWithTContentReturnsTResultAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedTEntity = randomTEntity;
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
            TEntity actualTEntity =
                await this.factoryClient.PostContentAsync<TEntity, TEntity>(
                    relativeUrl,
                    content: randomTEntity,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    SerializationContentFunction,
                    ContentDeserializationFunction);

            // then
            actualTEntity.Should().BeEquivalentTo(expectedTEntity);
        }

        [Fact]
        private async Task ShouldPostFormWithTContentReturnsTResultAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedTEntity = randomTEntity;
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
            TEntity actualTEntity =
                await this.factoryClient.PostFormAsync(
                    relativeUrl,
                    content: randomTEntity,
                    cancellationToken: cancellationToken,
                    deserializationFunction: ContentDeserializationFunction);

            // then
            actualTEntity.Should().BeEquivalentTo(expectedTEntity);
        }
    }
}