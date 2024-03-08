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
    public partial class RestfulSenseWebAssemblyFactoryApiClientTests
    {
        [Fact]
        private async Task ShouldGetContentWithDeserializationFunctionAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedReponseEntity = randomTEntity;

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                    .WithStatusCode(200)
                    .WithBodyAsJson(expectedReponseEntity));

            // when
            TEntity actualTEntity =
                await this.webAssemblyApiFactoryClient.GetContentAsync<TEntity>(
                    relativeUrl: relativeUrl,
                    deserializationFunction: ContentDeserializationFunction);

            // then
            actualTEntity.Should().BeEquivalentTo(expectedReponseEntity);
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
                    await this.webAssemblyApiFactoryClient.GetContentAsync<TEntity>(
                        relativeUrl: relativeUrl,
                        cancellationToken: taskCancelInvoked,
                        deserializationFunction: ContentDeserializationFunction));

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
                await this.webAssemblyApiFactoryClient.GetContentStringAsync(
                    relativeUrl: relativeUrl);

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
                await this.webAssemblyApiFactoryClient.GetContentStreamAsync(
                    relativeUrl: relativeUrl);

            var actualReadStream = await ReadStreamToEndAsync(
                expectedContentStream);

            // then
            actualReadStream.Should().BeEquivalentTo(expectedContent);
        }
    }
}