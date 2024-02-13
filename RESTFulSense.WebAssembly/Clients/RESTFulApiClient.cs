// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RESTFulSense.WebAssembly.Services;

namespace RESTFulSense.WebAssembly.Clients
{
    public partial class RESTFulApiClient : HttpClient, IRESTFulApiClient
    {
        public async ValueTask<T> GetContentAsync<T>(string relativeUrl, Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage = await GetAsync(relativeUrl);
            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> GetContentAsync<T>(
            string relativeUrl,
            CancellationToken cancellationToken,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage = await GetAsync(relativeUrl, cancellationToken);
            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<string> GetContentStringAsync(string relativeUrl) =>
            await GetStringAsync(relativeUrl);

        public async ValueTask<Stream> GetContentStreamAsync(string relativeUrl) =>
            await GetStreamAsync(relativeUrl);

        public async ValueTask PostContentWithNoResponseAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null)
        {
            HttpContent contentString =
                await ConvertToHttpContent(content, mediaType, ignoreDefaultValues, serializationFunction);

            HttpResponseMessage responseMessage =
                await PostAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask PostContentWithNoResponseAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null)
        {
            HttpContent contentString =
                await ConvertToHttpContent(content, mediaType, ignoreDefaultValues, serializationFunction);

            HttpResponseMessage responseMessage =
                await PostAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public ValueTask<T> PostContentAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            return PostContentAsync<T, T>(relativeUrl, content, mediaType, ignoreDefaultValues, serializationFunction, deserializationFunction);
        }

        public ValueTask<T> PostContentAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            return PostContentAsync<T, T>(relativeUrl, content, cancellationToken, mediaType, ignoreDefaultValues, serializationFunction, deserializationFunction);
        }

        public async ValueTask<Stream> PostContentWithStreamResponseAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null)
        {
            HttpContent contentString = await ConvertToHttpContent(content, mediaType, ignoreDefaultValues, serializationFunction);

            HttpResponseMessage responseMessage = await PostAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await responseMessage.Content.ReadAsStreamAsync();
        }

        public async ValueTask<TResult> PostContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<TContent, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<TResult>> deserializationFunction = null)
        {
            HttpContent contentString =
                await ConvertToHttpContent(content, mediaType, ignoreDefaultValues, serializationFunction);

            HttpResponseMessage responseMessage =
               await PostAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage, deserializationFunction);
        }

        public async ValueTask<TResult> PostContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
			Func<TContent, ValueTask<string>> serializationFunction = null,
			Func<string, ValueTask<TResult>> deserializationFunction = null)
        {
            HttpContent contentString = await ConvertToHttpContent(content, mediaType, ignoreDefaultValues, serializationFunction);

            HttpResponseMessage responseMessage =
               await PostAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage, deserializationFunction);
        }

        public async ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpContent contentString = await ConvertToHttpContent(content, mediaType, ignoreDefaultValues, serializationFunction);

            HttpResponseMessage responseMessage =
               await PutAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpContent contentString = await ConvertToHttpContent(content, mediaType, ignoreDefaultValues, serializationFunction);

            HttpResponseMessage responseMessage =
               await PutAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage, deserializationFunction);
        }

        public async ValueTask<TResult> PutContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<TContent, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<TResult>> deserializationFunction = null)
        {
            HttpContent contentString = await ConvertToHttpContent(content, mediaType, ignoreDefaultValues, serializationFunction);

            HttpResponseMessage responseMessage =
               await PutAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage, deserializationFunction);
        }

        public async ValueTask<TResult> PutContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<TContent, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<TResult>> deserializationFunction = null)
        {
            HttpContent contentString = await ConvertToHttpContent(content, mediaType, ignoreDefaultValues, serializationFunction);

            HttpResponseMessage responseMessage =
               await PutAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage, deserializationFunction);
        }

        public async ValueTask<T> PutContentAsync<T>(string relativeUrl, Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage =
                await PutAsync(relativeUrl, content: default);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage, deserializationFunction);
        }

        public async ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            CancellationToken cancellationToken,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage =
                await PutAsync(relativeUrl, content: default, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage, deserializationFunction);
        }

        public async ValueTask DeleteContentAsync(string relativeUrl)
        {
            HttpResponseMessage responseMessage = await DeleteAsync(relativeUrl);
            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask DeleteContentAsync(string relativeUrl, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage =
                await DeleteAsync(relativeUrl, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask<T> DeleteContentAsync<T>(string relativeUrl, Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage = await DeleteAsync(relativeUrl);
            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage, deserializationFunction);
        }

        public async ValueTask<T> DeleteContentAsync<T>(string relativeUrl, CancellationToken cancellationToken, Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage =
                await DeleteAsync(relativeUrl, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage, deserializationFunction);
        }

        private static async ValueTask<T> DeserializeResponseContent<T>(
            HttpResponseMessage responseMessage,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            string responseString = await responseMessage.Content.ReadAsStringAsync();

            return deserializationFunction == null
                ? JsonConvert.DeserializeObject<T>(responseString)
                : await deserializationFunction(responseString);
        }
    }
}