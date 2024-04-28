// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using RESTFulSense.WebAssenbly.Tests.Acceptance.Models;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace RESTFulSense.WebAssenbly.Tests.Acceptance.Tests
{
    public partial class RestfulSenseWebAssemblyFactoryApiClientTests
    {
        [Fact]
        private async Task ShouldExecuteHttpCallAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity expectedTEntity = randomTEntity;
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(this.wiremockServer.Urls[0]);

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingGet())
                    .RespondWith(Response.Create()
                    .WithStatusCode(200)
                    .WithBodyAsJson(expectedTEntity));

            // when
            HttpResponseMessage httpResponseMessage =
                await this.webAssemblyApiFactoryClient.ExecuteHttpCallAsync(
                    httpClient.GetAsync("/tests"));

            TEntity actualTEntityEntity =
                JsonConvert.DeserializeObject<TEntity>(
                    await httpResponseMessage.Content.ReadAsStringAsync());

            // then
            actualTEntityEntity.Should().BeEquivalentTo(expectedTEntity);
        }
    }
}