// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RESTFulSense.WebAssembly.Clients;
using RESTFulSense.WebAssenbly.Tests.Acceptance.Models;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace RESTFulSense.WebAssenbly.Tests.Acceptance.Tests
{
    public partial class RestfulSenseWebAssemblyFactoryApiClientTests : IDisposable
    {
        private readonly IRESTFulApiFactoryClient webAssemblyApiFactoryClient;
        private readonly HttpClient httpClient;
        private readonly WireMockServer wiremockServer;
        private const string relativeUrl = "/tests";

        public RestfulSenseWebAssemblyFactoryApiClientTests()
        {
            this.wiremockServer = WireMockServer.Start();

            this.httpClient =
                new HttpClient { BaseAddress = new Uri(wiremockServer.Urls[0]) };

            this.webAssemblyApiFactoryClient = new RESTFulApiFactoryClient(httpClient);
        }

        private async Task<string> ReadStreamToEndAsync(Stream result)
        {
            var reader = new StreamReader(result, leaveOpen: false);

            return await reader.ReadToEndAsync();
        }

        private static ValueTask<string> SerializationContentFunction<TEntity>(TEntity entityContent)
        {
            string jsonContent = JsonSerializer.Serialize(entityContent);

            return new ValueTask<string>(jsonContent);
        }

        private static string CreateRandomContent()
        {
            var randomContent = new Lipsum(
                LipsumFlavor.LoremIpsum,
                minWords: 3,
                maxWords: 10);

            return randomContent.ToString();
        }

        private static Func<string, ValueTask<TEntity>> ContentDeserializationFunction
        {
            get
            {
                return async (entityContent) =>
                    await Task.FromResult(JsonSerializer.Deserialize<TEntity>(
                        entityContent));
            }
        }

        private static TEntity GetRandomTEntity() =>
            CreateTEntityFiller(GetTestDateTimeOffset()).Create();

        private static DateTimeOffset GetTestDateTimeOffset() =>
            new DateTimeOffset(DateTime.Now);

        private static Filler<TEntity> CreateTEntityFiller(DateTimeOffset dates)
        {
            var filler = new Filler<TEntity>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates);

            return filler;
        }

        public void Dispose() => this.wiremockServer.Stop();
    }
}