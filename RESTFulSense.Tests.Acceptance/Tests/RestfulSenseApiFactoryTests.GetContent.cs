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
    public partial class RestfulSenseApiFactoryTests
    {

        [Fact]
        private async Task ShouldGetContentWithDeserializationFunctionAsync()
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
                await this.factoryClient.GetContentAsync<TEntity>(
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

            wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                        .WithBodyAsJson(someContent));

            // when
            var actualCanceledTask =
                await Assert.ThrowsAsync<TaskCanceledException>(async () =>
                    await this.factoryClient.GetContentAsync<TEntity>(
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

            wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                        .WithBody(stringContent));

            // when
            var actualContentResponse =
                await this.factoryClient.GetContentStringAsync(relativeUrl);

            // then
            actualContentResponse.Should().BeEquivalentTo(stringContent);
        }

        [Fact]
        private async Task ShouldReturnStreamOnGetContentStreamAsync()
        {
            // given
            string stringContent = CreateRandomContent();

            wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                    .WithBody(stringContent));

            // when
            var expectedContentStream =
                await this.factoryClient.GetContentStreamAsync(relativeUrl);

            var actualReadStream = await ReadStreamToEndAsync(expectedContentStream);

            // then
            actualReadStream.Should().BeEquivalentTo(stringContent);
        }
    }
}