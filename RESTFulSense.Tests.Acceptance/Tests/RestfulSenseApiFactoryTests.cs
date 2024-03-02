// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RESTFulSense.Clients;
using RESTFulSense.Tests.Acceptance.Models;
using Tynamix.ObjectFiller;
using WireMock.Server;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RESTFulSense.Tests.Acceptance.Tests
{
    public partial class RestfulSenseApiFactoryTests : IDisposable
    {
        private readonly IRESTFulApiFactoryClient factoryClient;
        private readonly HttpClient httpClient;
        private readonly WireMockServer wiremockServer;
        private const string relativeUrl = "/tests";

        public RestfulSenseApiFactoryTests()
        {
            this.wiremockServer = WireMockServer.Start();

            this.httpClient =
                new HttpClient { BaseAddress = new Uri(wiremockServer.Urls[0]) };

            this.factoryClient = new RESTFulApiFactoryClient(httpClient);
        }

        private async Task<string> ReadStreamToEndAsync(Stream result)
        {
            var reader = new StreamReader(result, leaveOpen: false);
            return await reader.ReadToEndAsync();
        }

        private bool GetDeleteContentVerification()
        {
            var requestLogs = this.wiremockServer.LogEntries;

            var deleteContentResult =
                requestLogs.FirstOrDefault(
                    request => request.RequestMessage.Path == relativeUrl);

            return deleteContentResult != null;
        }

        private static ValueTask<string> SerializationContentFunction<TEntity>(TEntity entityContent)
        {
            string jsonContent = JsonSerializer.Serialize(entityContent);

            return new ValueTask<string>(jsonContent);
        }

        private static string CreateRandomContent()
        {
            var randomContent = new Lipsum(LipsumFlavor.LoremIpsum, minWords: 3, maxWords: 10);

            return randomContent.ToString();
        }

        private static Func<string, ValueTask<TEntity>> DeserializationContentFunction =>
            async (entityContent) =>
                await Task.FromResult(JsonSerializer.Deserialize<TEntity>(entityContent));

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