// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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
        private async Task ShouldReturnOkOnGetContentAsyncWithTEntityAsync()
        {
            // given
            TEntity expectedReponseEntity = GetRandomTEntity();

            wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                    .WithStatusCode(200)
                    .WithBodyAsJson(expectedReponseEntity));

            // when
            TEntity actualResponseEntity =
                await this.factoryClient.GetContentAsync<TEntity>(relativeUrl);

            // then
            actualResponseEntity.Should().BeEquivalentTo(expectedReponseEntity);
        }

        [Fact]
        private async Task ShouldValidateResponseMessageProblemDetailsOnGetContentIfNotFoundErrorOccurs()
        {
            // given
            var mediaType = "application/problem+json";

            var expectedProblemDetailResponse = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "Not Found",
                Status = 404,
                Detail = "The requested resource could not be found.",
                Instance = relativeUrl
            };

            wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                    .WithStatusCode(404)
                    .WithHeader("Content-Type", mediaType)
                    .WithBodyAsJson(expectedProblemDetailResponse));

            // when . then
            Func<Task> actualProblemDetailResponseTask = async () =>
                await this.factoryClient.GetContentAsync<ProblemDetails>(relativeUrl);

            // then
            await actualProblemDetailResponseTask.Should().ThrowAsync<HttpResponseNotFoundException>()
                .WithMessage("Not Found");
        }

        [Fact]
        private async Task ShouldCancelTaskOnGetContentAsyncIfCancellationInvokedAsync()
        {
            // given
            string someContent = CreateRandomContent();
            var expectedCanceledTaskException = new TaskCanceledException();
            var taskCancelInvoked = new CancellationToken(canceled: true);

            wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                    .WithBody(someContent));

            // when
            var actualCanceledTask =
                await Assert.ThrowsAsync<TaskCanceledException>(async () =>
                    await this.factoryClient.GetContentAsync<dynamic>(
                        relativeUrl,
                        taskCancelInvoked,
                        null));

            // then
            actualCanceledTask.Should().BeEquivalentTo(expectedCanceledTaskException);
        }

        [Fact]
        private async Task ShouldGetContentAsyncWithDeserializationFunctionAsync()
        {
            // given
            string someContent = CreateRandomContent();

            wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                    .WithBody(someContent));

            // when
            var actualContentResponse = await this.factoryClient.GetContentAsync<string>(
                relativeUrl,
                content => new ValueTask<string>(content));

            // then
            actualContentResponse.Should().BeEquivalentTo(someContent);
        }

        [Fact]
        private async Task ShouldReturnStringOnGetContentStringAsync()
        {
            // given
            var someContent = CreateRandomContent();

            wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                    .WithBody(someContent));

            // when
            var actualContentResponse =
                await this.factoryClient.GetContentStringAsync(relativeUrl);

            // then
            actualContentResponse.Should().BeEquivalentTo(someContent);
        }

        [Fact]
        private async Task ShouldGetContentStreamAsync()
        {
            // given
            var someContent = CreateRandomContent();

            wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                    .WithBody(someContent));

            // when
            var returnedContentStream =
                await this.factoryClient.GetContentStreamAsync(relativeUrl);

            using var reader = new StreamReader(returnedContentStream);
            var actualReadStream = await reader.ReadToEndAsync();

            // then
            actualReadStream.Should().BeEquivalentTo(someContent);
        }
    }
}