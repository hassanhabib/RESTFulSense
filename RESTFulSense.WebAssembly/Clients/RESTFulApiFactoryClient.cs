﻿// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        public async ValueTask<T> GetContentAsync<T>(string relativeUrl)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.GetAsync(relativeUrl);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> GetContentAsync<T>(string relativeUrl, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.GetAsync(relativeUrl, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<string> GetContentStringAsync(string relativeUrl) =>
            await this.httpClient.GetStringAsync(relativeUrl);

        public async ValueTask PostContentWithNoResponseAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage =
                await this.httpClient.PostAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask PostContentWithNoResponseAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage =
                await this.httpClient.PostAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask<HttpResponseMessage> PostContentAsync(
            string relativeUrl,
            HttpContent content,
            CancellationToken cancellationToken = default)
        {
            HttpResponseMessage responseMessage =
               await this.httpClient.PostAsync(relativeUrl, content, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return responseMessage;
        }

        public async ValueTask<TResult> PostContentAsync<TResult>(
            string relativeUrl,
            HttpContent content,
            CancellationToken cancellationToken = default)
        {
            HttpResponseMessage responseMessage =
               await this.httpClient.PostAsync(relativeUrl, content, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public ValueTask<T> PostContentAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false) =>
            PostContentAsync<T, T>(relativeUrl, content, mediaType, ignoreDefaultValues);

        public ValueTask<T> PostContentAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false) =>
            PostContentAsync<T, T>(relativeUrl, content, cancellationToken, mediaType);

        public async ValueTask<Stream> PostContentWithStreamResponseAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage = await this.httpClient.PostAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await responseMessage.Content.ReadAsStreamAsync();
        }

        public async ValueTask<TResult> PostContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage =
               await this.httpClient.PostAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public async ValueTask<TResult> PostContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage =
               await this.httpClient.PostAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public async ValueTask<HttpResponseMessage> PutContentAsync(
            string relativeUrl,
            HttpContent content,
            CancellationToken cancellationToken = default)
        {
            HttpResponseMessage responseMessage =
               await this.httpClient.PutAsync(relativeUrl, content, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return responseMessage;
        }

        public async ValueTask<TResult> PutContentAsync<TResult>(
            string relativeUrl,
            HttpContent content,
            CancellationToken cancellationToken = default)
        {
            HttpResponseMessage responseMessage =
               await this.httpClient.PutAsync(relativeUrl, content, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public async ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage =
               await this.httpClient.PutAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage =
               await this.httpClient.PutAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<TResult> PutContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage =
               await this.httpClient.PutAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public async ValueTask<TResult> PutContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage =
               await this.httpClient.PutAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public async ValueTask<T> PutContentAsync<T>(string relativeUrl)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.PutAsync(relativeUrl, content: default);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> PutContentAsync<T>(string relativeUrl, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.PutAsync(relativeUrl, content: default, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask DeleteContentAsync(string relativeUrl)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.DeleteAsync(relativeUrl);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask DeleteContentAsync(string relativeUrl, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.DeleteAsync(relativeUrl, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask<T> DeleteContentAsync<T>(string relativeUrl)
        {
            HttpResponseMessage responseMessage = await
                this.httpClient.DeleteAsync(relativeUrl);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> DeleteContentAsync<T>(string relativeUrl, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage = await
                this.httpClient.DeleteAsync(relativeUrl, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        private static async ValueTask<T> DeserializeResponseContent<T>(HttpResponseMessage responseMessage)
        {
            string responseString = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}