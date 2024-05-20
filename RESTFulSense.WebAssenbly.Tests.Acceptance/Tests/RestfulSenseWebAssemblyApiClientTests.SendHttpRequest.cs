// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using RESTFulSense.WebAssenbly.Tests.Acceptance.Models;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;

namespace RESTFulSense.WebAssenbly.Tests.Acceptance.Tests
{
    public partial class RestfulSenseWebAssemblyApiClientTests
    {
        [Fact]
        private void ShouldSendContentWithNoResponseAndDeserializeContent()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity inputTEntity = randomTEntity;
            TEntity expectedTEntity = inputTEntity;
            string mediaType = "application/json";
            bool ignoreDefaultValues = false;
            string randomHttpMethodName = GetRandomHttpMethodName();

            this.wiremockServer.Given(Request.Create()
                .WithPath(relativeUrl)
                .UsingMethod(randomHttpMethodName))
                    .RespondWith(Response.Create()
                        .WithStatusCode(200));

            // when
            Action actualResponseResult = async () =>
                await this.restfulWebAssemblyApiClient.SendHttpRequestAsync<TEntity>(
                    method: randomHttpMethodName,
                    relativeUrl: relativeUrl,
                    content: inputTEntity,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction);

            // then
            actualResponseResult.Should().NotBeNull();
        }

        [Fact]
        private async Task ShouldSendContentWithTContentReturnsTResultAsync()
        {
            // given
            TEntity randomTEntity = GetRandomTEntity();
            TEntity inputTEntity = randomTEntity;
            TEntity expectedTEntity = inputTEntity;
            string mediaType = "text/json";
            bool ignoreDefaultValues = false;
            string randomHttpMethodName = GetRandomHttpMethodName();

            string expectedBody =
               JsonConvert.SerializeObject(randomTEntity);

            this.wiremockServer.Given(
                Request.Create()
                .WithPath(relativeUrl)
                .UsingMethod(randomHttpMethodName))
                    .RespondWith(
                        Response.Create()
                            .WithStatusCode(200)
                            .WithHeader("Content-Type", mediaType)
                            .WithBody(expectedBody));

            // when
            TEntity actualTEntity =
                await this.restfulWebAssemblyApiClient.SendHttpRequestAsync<TEntity, TEntity>(
                    method: randomHttpMethodName,
                    relativeUrl: relativeUrl,
                    content: inputTEntity,
                    mediaType: mediaType,
                    ignoreDefaultValues: ignoreDefaultValues,
                    serializationFunction: SerializationContentFunction,
                    deserializationFunction: DeserializationContentFunction);

            // then
            actualTEntity.Should().BeEquivalentTo(expectedTEntity);
        }
    }
}