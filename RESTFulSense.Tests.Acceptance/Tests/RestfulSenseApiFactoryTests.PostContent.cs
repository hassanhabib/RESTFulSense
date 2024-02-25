// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RESTFulSense.Exceptions;
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

            wiremockServer.Given(Request.Create()
               .WithPath(relativeUrl)
               .UsingPost())
                   .RespondWith(Response.Create()
                       .WithHeader("Content-Type", "application/json")
                       .WithBodyAsJson(randomTEntity));

            // when
            var taskCanceledToken = new CancellationToken(canceled: true);

            var actualPostContentCanceledTask =
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
            TEntity randomContent = GetRandomTEntity();
            TEntity expectedContent = randomContent;
            var mediaType = "application/json";
            var ignoreDefaultValues = false;

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingPost())
                    .RespondWith(Response.Create()
                        .WithStatusCode(200));

            // when
            Action actualResponseResult = async () =>
                await this.factoryClient.PostContentWithNoResponseAsync<TEntity>(
                    relativeUrl,
                    content: expectedContent,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction);

            // then
            actualResponseResult.Should().NotBeNull();
        }

        [Fact]
        private async Task ShouldPostContentAndGetExpectedResponse()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            var mediaType = "application/json";

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingPost())
                    .RespondWith(Response.Create()
                        .WithStatusCode(201)
                        .WithHeader("Content-Type", mediaType)
                        .WithBodyAsJson(randomTEntity));

            // when
            var actualTEntity =
                await this.factoryClient.PostContentAsync<TEntity>(
                    relativeUrl,
                    content: randomTEntity,
                    mediaType: mediaType);

            // then
            actualTEntity.Should().BeEquivalentTo(randomTEntity);
        }

        [Fact]
        private async Task ShouldCancelPostContentWhenCancellationIsInvokedAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            var mediaType = "application/json";
            var ignoreDefaultValues = false;

            var expectedPostContentCanceledException = new TaskCanceledException();


            this.wiremockServer.Given(Request.Create()
               .WithPath(relativeUrl)
               .UsingPost())
                   .RespondWith(Response.Create()
                       .WithHeader("Content-Type", mediaType)
                       .WithBodyAsJson(randomTEntity));

            // when
            var taskCanceledToken = new CancellationToken(canceled: true);

            var actualPostContentCanceledTask =
                await Assert.ThrowsAsync<TaskCanceledException>(async () =>
                    await this.factoryClient.PostContentAsync<TEntity>(
                        relativeUrl,
                        content: randomTEntity,
                        cancellationToken: taskCanceledToken,
                        mediaType: mediaType,
                        ignoreDefaultValues: ignoreDefaultValues));

            // then
            actualPostContentCanceledTask.Should().BeEquivalentTo(
                expectedPostContentCanceledException);
        }

        [Fact]
        public async Task ShouldPostContentAsyncAndReturnPostedContentWithCustomSerializationAndDeserializationAsync()
        {
            // given
            var expectedContent = GetRandomTEntity();
            var mediaType = "application/json";
            var ignoreDefaultValues = false;

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingPost())
                    .RespondWith(Response.Create()
                        .WithStatusCode(200)
                        .WithBodyAsJson(expectedContent));

            // when
            var actualContent =
                await this.factoryClient.PostContentAsync<TEntity>(
                    relativeUrl,
                    content: expectedContent,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction,
                    deserializationFunction: DeserializationContentFunction);

            // then
            Assert.Equal(expectedContent.TEntityName, actualContent.TEntityName);
        }

        [Fact]
        public async Task ShouldPostContentAsyncAndReturnProblemDetailsIf403ForbiddenErrorOccursAsync()
        {
            // given
            var expectedContent = GetRandomTEntity();
            var mediaType = "application/json";
            var ignoreDefaultValues = false;

            var problemDetails = new ProblemDetails
            {
                Status = 403,
                Title = "Forbidden"
            };

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingPost())
                    .RespondWith(Response.Create()
                        .WithStatusCode(403)
                        .WithHeader("Content-Type", mediaType)
                        .WithBodyAsJson(problemDetails));

            // when
            var responseException =
                await Assert.ThrowsAsync<HttpResponseForbiddenException>(() =>
                    this.factoryClient.PostContentAsync<TEntity>(
                        relativeUrl,
                        content: expectedContent,
                        mediaType: mediaType,
                        ignoreDefaultValues: ignoreDefaultValues,
                        serializationFunction: SerializationContentFunction,
                        deserializationFunction: DeserializationContentFunction).AsTask());

            var actualProblemDetails =
                JsonConvert.DeserializeObject<ProblemDetails>(responseException.Message);

            // then
            Assert.IsType<HttpResponseForbiddenException>(responseException);
            Assert.Equal(problemDetails.Status, actualProblemDetails.Status);
            Assert.Equal(problemDetails.Title, actualProblemDetails.Title);
        }

        [Fact]
        private async Task ShouldPostContentWithStreamResponseAsync()
        {
            // given
            var someContent = CreateRandomContent();
            var cancellationToken = new CancellationToken();
            var mediaType = "text/json";
            var ignoreDefaultValues = false;

            this.wiremockServer.Given(
                Request.Create()
                .WithPath(relativeUrl)
                .UsingPost())
                    .RespondWith(
                        Response.Create()
                            .WithStatusCode(200)
                            .WithHeader("Content-Type", mediaType)
                            .WithBody(someContent));

            // when
            var result =
                await this.factoryClient.PostContentWithStreamResponseAsync(
                    relativeUrl,
                    content: someContent,
                    cancellationToken: cancellationToken,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction);

            var reader = new StreamReader(result);
            var resultContent = await reader.ReadToEndAsync();

            // then
            Assert.Equal(someContent, resultContent);
        }

        [Fact]
        private async Task ShouldPostContentWithTContentReturnsTResultAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            var mediaType = "text/json";
            var ignoreDefaultValues = false;

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
                await this.factoryClient.PostContentAsync<TEntity, TEntity>(
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
                await this.factoryClient.PostFormAsync(
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