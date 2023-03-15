// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using RESTFulSense.WebAssembly.Services;

namespace RESTFulSense.WebAssembly.Clients
{
    public class RESTFulApiFactoryClient : IRESTFulApiFactoryClient
    {
        private readonly HttpClient httpClient;

        public RESTFulApiFactoryClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async ValueTask<T> GetContentAsync<T>(string relativeUrl)
        {
            HttpResponseMessage responseMessage =
                await httpClient.GetAsync(relativeUrl);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> GetContentAsync<T>(string relativeUrl, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage =
                await httpClient.GetAsync(relativeUrl, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<string> GetContentStringAsync(string relativeUrl) =>
            await httpClient.GetStringAsync(relativeUrl);

        public ValueTask<T> PostContentAsync<T>(string relativeUrl, T content, string mediaType = "text/json") =>
            PostContentAsync<T, T>(relativeUrl, content, mediaType);


        public async ValueTask PostContentWithNoResponseAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json")
        {
            StringContent contentString = StringifyJsonifyContent(content, mediaType);

            HttpResponseMessage responseMessage =
                await httpClient.PostAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask PostContentWithNoResponseAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json")
        {
            StringContent contentString = StringifyJsonifyContent(content, mediaType);

            HttpResponseMessage responseMessage =
                await httpClient.PostAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public ValueTask<T> PostContentAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json") =>
            PostContentAsync<T, T>(relativeUrl, content, cancellationToken, mediaType);

        public async ValueTask<TResult> PostContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            string mediaType = "text/json")
        {
            StringContent contentString = StringifyJsonifyContent(content, mediaType);

            HttpResponseMessage responseMessage =
               await httpClient.PostAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public async ValueTask<TResult> PostContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            CancellationToken cancellationToken,
            string mediaType = "text/json")
        {
            StringContent contentString = StringifyJsonifyContent(content, mediaType);

            HttpResponseMessage responseMessage =
               await httpClient.PostAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public async ValueTask<T> PutContentAsync<T>(string relativeUrl, T content, string mediaType = "text/json")
        {
            StringContent contentString = StringifyJsonifyContent(content, mediaType);

            HttpResponseMessage responseMessage =
               await httpClient.PutAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json")
        {
            StringContent contentString = StringifyJsonifyContent(content, mediaType);

            HttpResponseMessage responseMessage =
               await httpClient.PutAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<TResult> PutContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            string mediaType = "text/json")
        {
            StringContent contentString = StringifyJsonifyContent(content, mediaType);

            HttpResponseMessage responseMessage =
               await httpClient.PutAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public async ValueTask<TResult> PutContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            CancellationToken cancellationToken,
            string mediaType = "text/json")
        {
            StringContent contentString = StringifyJsonifyContent(content, mediaType);

            HttpResponseMessage responseMessage =
               await httpClient.PutAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public async ValueTask<T> PutContentAsync<T>(string relativeUrl)
        {
            HttpResponseMessage responseMessage =
                await httpClient.PutAsync(relativeUrl, content: default);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> PutContentAsync<T>(string relativeUrl, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage =
                await httpClient.PutAsync(relativeUrl, content: default, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask DeleteContentAsync(string relativeUrl)
        {
            HttpResponseMessage responseMessage =
                await httpClient.DeleteAsync(relativeUrl);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask DeleteContentAsync(string relativeUrl, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage =
                await httpClient.DeleteAsync(relativeUrl, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask<T> DeleteContentAsync<T>(string relativeUrl)
        {
            HttpResponseMessage responseMessage = await
                httpClient.DeleteAsync(relativeUrl);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> DeleteContentAsync<T>(string relativeUrl, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage = await
                httpClient.DeleteAsync(relativeUrl, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        private static async ValueTask<T> DeserializeResponseContent<T>(HttpResponseMessage responseMessage)
        {
            string responseString = await responseMessage.Content.ReadAsStringAsync();
            JsonSerializerOptions options = ConfigureJsonDeserializeCaseInSensitive();

            return JsonSerializer.Deserialize<T>(responseString, options);
        }
        private static JsonSerializerOptions ConfigureJsonDeserializeCaseInSensitive()
        {
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(item: new JsonStringEnumConverter());
            return options;
        }

        private static StringContent StringifyJsonifyContent<T>(T content, string mediaType)
        {
            string serializedRestrictionRequest = JsonSerializer.Serialize(content);

            var contentString =
                new StringContent(
                    content: serializedRestrictionRequest,
                    encoding: Encoding.UTF8,
                    mediaType);

            return contentString;
        }
    }
}