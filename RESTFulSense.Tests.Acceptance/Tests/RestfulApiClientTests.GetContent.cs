// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.IO;
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
        private async Task ShouldGetContentWithDeserializationFunctionAsync()
        {
            // given
            TEntity expectedReponseEntity = GetRandomTEntity();

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                    .WithStatusCode(200)
                    .WithBodyAsJson(expectedReponseEntity));

            // when
            TEntity actualResponseEntity =
                await this.restfulApiClient.GetContentAsync<TEntity>(
                    relativeUrl,
                    deserializationFunction: DeserializationContentFunction);

            // then
            actualResponseEntity.Should().BeEquivalentTo(expectedReponseEntity);
        }

        [Fact]
        private async Task ShouldCancelGetContentDeserializationIfCancellationInvokedAsync()
        {
            // given
            TEntity someContent = GetRandomTEntity();
            var expectedCanceledTaskException = new TaskCanceledException();
            var taskCancelInvoked = new CancellationToken(canceled: true);

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                        .WithBodyAsJson(someContent));

            // when
            TaskCanceledException actualCanceledTask =
                await Assert.ThrowsAsync<TaskCanceledException>(async () =>
                    await this.restfulApiClient.GetContentAsync<TEntity>(
                        relativeUrl,
                        cancellationToken: taskCancelInvoked,
                        deserializationFunction: DeserializationContentFunction));

            // then
            actualCanceledTask.Should().BeEquivalentTo(expectedCanceledTaskException);
        }

        [Fact]
        private async Task ShouldReturnStringOnGetContentStringAsync()
        {
            // given
            string stringContent = CreateRandomContent();

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                        .WithBody(stringContent));

            // when
            string actualContentResponse =
                await this.restfulApiClient.GetContentStringAsync(relativeUrl);

            // then
            actualContentResponse.Should().BeEquivalentTo(stringContent);
        }

        [Fact]
        private async Task ShouldReturnStreamOnGetContentStreamAsync()
        {
            // given
            string stringContent = CreateRandomContent();

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                    .WithBody(stringContent));

            // when
            Stream expectedContentStream =
                await this.restfulApiClient.GetContentStreamAsync(relativeUrl);

            string actualReadStream = await ReadStreamToEndAsync(expectedContentStream);

            // then
            actualReadStream.Should().BeEquivalentTo(stringContent);
        }
    }
}