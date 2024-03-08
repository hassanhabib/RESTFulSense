// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using RESTFulSense.WebAssenbly.Tests.Acceptance.Models;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace RESTFulSense.WebAssenbly.Tests.Acceptance.Tests
{
    public partial class RestfulSenseWebAssemblyApiClient
    {
        [Fact]
        private async Task ShouldGetContentWithDeserializationFunctionAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedTEntity = randomTEntity;

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                    .WithStatusCode(200)
                    .WithBodyAsJson(expectedTEntity));

            // when
            TEntity actualTEntityEntity =
                await this.restfulWebAssemblyApiClient.GetContentAsync<TEntity>(
                    relativeUrl: relativeUrl,
                    deserializationFunction: DeserializationContentFunction);

            // then
            actualTEntityEntity.Should().BeEquivalentTo(expectedTEntity);
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
                    await this.restfulWebAssemblyApiClient.GetContentAsync<TEntity>(
                        relativeUrl: relativeUrl,
                        cancellationToken: taskCancelInvoked,
                        deserializationFunction: DeserializationContentFunction));

            // then
            actualCanceledTask.Should().BeEquivalentTo(expectedCanceledTaskException);
        }

        [Fact]
        private async Task ShouldReturnStringOnGetContentStringAsync()
        {
            // given
            string someContent = CreateRandomContent();

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                        .WithBody(someContent));

            // when
            string actualContent =
                await this.restfulWebAssemblyApiClient.GetContentStringAsync(relativeUrl);

            // then
            actualContent.Should().BeEquivalentTo(someContent);
        }

        [Fact]
        private async Task ShouldReturnStreamOnGetContentStreamAsync()
        {
            // given
            string expectedContent = CreateRandomContent();

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                    .WithBody(expectedContent));

            // when
            Stream expectedContentStream =
                await this.restfulWebAssemblyApiClient.GetContentStreamAsync(
                    relativeUrl: relativeUrl);

            string actualReadStream =
                await ReadStreamToEndAsync(expectedContentStream);

            // then
            actualReadStream.Should().BeEquivalentTo(expectedContent);
        }
    }
}
