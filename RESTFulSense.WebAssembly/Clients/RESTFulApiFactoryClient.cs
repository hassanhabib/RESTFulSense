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
    public partial class RESTFulApiFactoryClient : IRESTFulApiFactoryClient
    {
        private readonly HttpClient httpClient;

        public RESTFulApiFactoryClient(HttpClient httpClient) =>
            this.httpClient = httpClient;

        public async ValueTask<T> GetContentAsync<T>(
            string relativeUrl,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.GetAsync(relativeUrl);

            await ValidationService.ValidateHttpResponseAsync(
                responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage,
                deserializationFunction);
        }

        public async ValueTask<T> GetContentAsync<T>(
            string relativeUrl,
            CancellationToken cancellationToken,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.GetAsync(
                    relativeUrl,
                    cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(
                responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage,
                deserializationFunction);
        }

        public async ValueTask<string> GetContentStringAsync(string relativeUrl) =>
            await this.httpClient.GetStringAsync(relativeUrl);

        public async ValueTask PostContentWithNoResponseAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null)
        {
            HttpContent contentString =
                await ConvertToHttpContent(
                    content,
                    mediaType,
                    ignoreDefaultValues,
                    serializationFunction);

            HttpResponseMessage responseMessage =
                await this.httpClient.PostAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask<Stream> GetContentStreamAsync(string relativeUrl) =>
            await this.httpClient.GetStreamAsync(relativeUrl);

        public async ValueTask<byte[]> GetContentByteArrayAsync(string relativeUrl)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.GetAsync(relativeUrl);

            if (responseMessage.IsSuccessStatusCode is false)
            {
                await ValidationService.ValidateHttpResponseAsync(responseMessage);
            }

            return await responseMessage.Content.ReadAsByteArrayAsync();
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
                await ConvertToHttpContent(
                    content,
                    mediaType,
                    ignoreDefaultValues,
                    serializationFunction);

            HttpResponseMessage responseMessage =
                await this.httpClient.PostAsync(
                    relativeUrl,
                    contentString,
                    cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(
                responseMessage);
        }

        public ValueTask<T> PostContentAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            return PostContentAsync<T, T>(
                relativeUrl,
                content,
                mediaType,
                ignoreDefaultValues,
                serializationFunction,
                deserializationFunction);
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
            return PostContentAsync<T, T>(
                relativeUrl,
                content,
                cancellationToken,
                mediaType,
                ignoreDefaultValues,
                serializationFunction,
                deserializationFunction);
        }

        public async ValueTask<Stream> PostContentWithStreamResponseAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null)
        {
            HttpContent contentString =
                await ConvertToHttpContent(
                    content,
                    mediaType,
                    ignoreDefaultValues,
                    serializationFunction);

            HttpResponseMessage responseMessage =
                await this.httpClient.PostAsync(
                    relativeUrl,
                    contentString,
                    cancellationToken);

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
                await ConvertToHttpContent(
                    content,
                    mediaType,
                    ignoreDefaultValues,
                    serializationFunction);

            HttpResponseMessage responseMessage =
               await this.httpClient.PostAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(
                responseMessage,
                deserializationFunction);
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
            HttpContent contentString =
                await ConvertToHttpContent(
                    content,
                    mediaType,
                    ignoreDefaultValues,
                    serializationFunction);

            HttpResponseMessage responseMessage =
               await this.httpClient.PostAsync(
                   relativeUrl,
                   contentString,
                   cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(
                responseMessage,
                deserializationFunction);
        }

        public async ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpContent contentString =
                await ConvertToHttpContent(
                    content,
                    mediaType,
                    ignoreDefaultValues,
                    serializationFunction);

            HttpResponseMessage responseMessage =
               await this.httpClient.PutAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage,
                deserializationFunction);
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
            HttpContent contentString =
                await ConvertToHttpContent(
                    content,
                    mediaType,
                    ignoreDefaultValues,
                    serializationFunction);

            HttpResponseMessage responseMessage =
               await this.httpClient.PutAsync(
                   relativeUrl,
                   contentString,
                   cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(
                responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage,
                deserializationFunction);
        }

        public async ValueTask<TResult> PutContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<TContent, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<TResult>> deserializationFunction = null)
        {
            HttpContent contentString =
                await ConvertToHttpContent(
                    content,
                    mediaType,
                    ignoreDefaultValues,
                    serializationFunction);

            HttpResponseMessage responseMessage =
               await this.httpClient.PutAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(
                responseMessage,
                deserializationFunction);
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
            HttpContent contentString =
                await ConvertToHttpContent(
                    content,
                    mediaType,
                    ignoreDefaultValues,
                    serializationFunction);

            HttpResponseMessage responseMessage =
               await this.httpClient.PutAsync(
                   relativeUrl,
                   contentString,
                   cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(
                responseMessage,
                deserializationFunction);
        }

        public async ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.PutAsync(
                    relativeUrl,
                    content: default);

            await ValidationService.ValidateHttpResponseAsync(
                responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage,
                deserializationFunction);
        }

        public async ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            CancellationToken cancellationToken,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.PutAsync(
                    relativeUrl,
                    content: default,
                    cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(
                responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage,
                deserializationFunction);
        }

        public async ValueTask DeleteContentAsync(string relativeUrl)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.DeleteAsync(relativeUrl);

            await ValidationService.ValidateHttpResponseAsync(
                responseMessage);
        }

        public async ValueTask DeleteContentAsync(
            string relativeUrl,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.DeleteAsync(
                    relativeUrl,
                    cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(
                responseMessage);
        }

        public async ValueTask<T> DeleteContentAsync<T>(
            string relativeUrl,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.DeleteAsync(relativeUrl);

            await ValidationService.ValidateHttpResponseAsync(
                responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage,
                deserializationFunction);
        }

        public async ValueTask<T> DeleteContentAsync<T>(
            string relativeUrl,
            CancellationToken cancellationToken,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage = await
                this.httpClient.DeleteAsync(
                    relativeUrl,
                    cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(
                responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage,
                deserializationFunction);
        }

        private static async ValueTask<T> DeserializeResponseContent<T>(
             HttpResponseMessage responseMessage,
             Func<string, ValueTask<T>> deserializationFunction = null)
        {
            string responseString =
                await responseMessage.Content.ReadAsStringAsync();

            return deserializationFunction == null
                ? JsonConvert.DeserializeObject<T>(responseString)
                : await deserializationFunction(responseString);
        }

        public async ValueTask<HttpResponseMessage> ExecuteHttpCallAsync(
            Task<HttpResponseMessage> function)
        {
            HttpResponseMessage httpResponseMessage =
                await function;

            await ValidationService.ValidateHttpResponseAsync(httpResponseMessage);

            return httpResponseMessage;
        }

        public async ValueTask<T> SendHttpRequestAsync<T>(
            string method,
            string relativeUrl,
            CancellationToken cancellationToken,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            var httpMethod = new HttpMethod(method);

            HttpResponseMessage responseMessage =
                await this.httpClient.SendAsync(
                    request: new HttpRequestMessage(httpMethod, relativeUrl),
                    cancellationToken: cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage, deserializationFunction);
        }

        public async ValueTask<T> SendHttpRequestAsync<T>(
            string method,
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpContent contentString =
                await ConvertToHttpContent(
                    content,
                    mediaType,
                    ignoreDefaultValues,
                    serializationFunction);

            var httpMethod = new HttpMethod(method);

            HttpResponseMessage responseMessage =
                await this.httpClient.SendAsync(
                    request: new HttpRequestMessage
                    {
                        Method = httpMethod,
                        RequestUri = new Uri(relativeUrl),
                        Content = contentString
                    });

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage,
                deserializationFunction);
        }

        public async ValueTask<TResult> SendHttpRequestAsync<TContent, TResult>(
            string method,
            string relativeUrl,
            TContent content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<TContent, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<TResult>> deserializationFunction = null)
        {
            HttpContent contentString =
                await ConvertToHttpContent(
                    content,
                    mediaType,
                    ignoreDefaultValues,
                    serializationFunction);

            var httpMethod = new HttpMethod(method);

            HttpResponseMessage responseMessage =
                await this.httpClient.SendAsync(
                    request: new HttpRequestMessage(httpMethod, relativeUrl)
                    {
                        Content = contentString
                    });

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent(
                responseMessage,
                deserializationFunction);
        }
    }
}