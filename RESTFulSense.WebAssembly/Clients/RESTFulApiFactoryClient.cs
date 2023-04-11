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

        public async ValueTask<TResult> PostFormAsync<TResult>(
            string relativeUrl,
            params object[] contentParameters) =>
            await PostFormAsync<TResult>(relativeUrl, CancellationToken.None, contentParameters);

        public async ValueTask<TResult> PostFormAsync<TResult>(
            string relativeUrl,
            CancellationToken cancellationToken,
            params object[] contentParameters)
        {
            ValidateContentParameters(contentParameters);

            MultipartFormDataContent multipartFormDataContent =
                ProcessContentParameters(contentParameters);

            HttpResponseMessage responseMessage =
                await this.httpClient.PostAsync(
                    requestUri: relativeUrl,
                    content: multipartFormDataContent,
                    cancellationToken);

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

        private static MultipartFormDataContent ProcessContentParameters(object[] contentParameters)
        {
            var multipartFormDataContent =
                 new MultipartFormDataContent();

            foreach (var contentParameter in contentParameters)
            {
                switch (contentParameter)
                {
                    case (string name, Stream stream, string fileName):
                        multipartFormDataContent.Add(
                            content: new StreamContent(stream),
                            name,
                            fileName);
                        break;

                    case (string name, string value):
                        multipartFormDataContent.Add(
                            content: new StringContent(value),
                            name);
                        break;

                    default:
                        throw new ArgumentException(
                            message: "Content parameter must be of supported type.");
                }
            }

            return multipartFormDataContent;
        }

        private static void ValidateContentParameters(object[] contentParams)
        {
            ValidateContentParamsNotNull(contentParams);
        }

        private static void ValidateContentParamsNotNull(object[] contentParams)
        {
            if (contentParams is null)
            {
                throw new ArgumentNullException(
                    paramName: nameof(contentParams),
                    message: "Content parameters cannot be null.");
            }
        }
    }
}