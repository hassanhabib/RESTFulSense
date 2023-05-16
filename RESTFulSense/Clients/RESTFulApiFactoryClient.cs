// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RESTFulSense.Models.Client.Exceptions;
using RESTFulSense.Models.Coordinations.Forms.Exceptions;
using RESTFulSense.Services;
using RESTFulSense.Services.Coordinations.Forms;
using Xeptions;

namespace RESTFulSense.Clients
{
    public partial class RESTFulApiFactoryClient : IRESTFulApiFactoryClient
    {
        private readonly HttpClient httpClient;
        private IFormCoordinationService formCoordinationService;

        public RESTFulApiFactoryClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;             
            IServiceProvider serviceProvider = RegisterFormServices();

            this.formCoordinationService =
                serviceProvider.GetRequiredService<IFormCoordinationService>();
        }

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
            PostContentAsync<T, T>(relativeUrl, content, cancellationToken, mediaType, ignoreDefaultValues);

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

        public async ValueTask<TResult> PostFormAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            CancellationToken cancellationToken = default(CancellationToken))
            where TContent : class
        {
            try
            {
                MultipartFormDataContent multipartFormDataContent =
                    this.formCoordinationService.ConvertToMultipartFormDataContent(content);

                HttpResponseMessage responseMessage =
                   await this.httpClient.PostAsync(relativeUrl, multipartFormDataContent, cancellationToken);

                await ValidationService.ValidateHttpResponseAsync(responseMessage);

                return await DeserializeResponseContent<TResult>(responseMessage);
            }
            catch (FormCoordinationValidationException formCoordinationValidationException)
            {
                throw new RESTFulApiClientValidationException(
                    formCoordinationValidationException.InnerException as Xeption);
            }
            catch (FormCoordinationDependencyException formCoordinationDependencyException)
            {
                throw new RESTFulApiClientDependencyException(
                    formCoordinationDependencyException.InnerException as Xeption);
            }
            catch (FormCoordinationServiceException formCoordinationServiceException)
            {
                throw new RESTFulApiClientServiceException(
                    formCoordinationServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<T> PutContentAsync<T>(string relativeUrl, T content, string mediaType = "text/json", bool ignoreDefaultValues = false)
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

        public async ValueTask<T> PatchContentAsync<T>(string relativeUrl, T content, string mediaType = "text/json", bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage =
               await this.httpClient.PatchAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> PatchContentAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage =
               await this.httpClient.PatchAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<TResult> PatchContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage =
               await this.httpClient.PatchAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public async ValueTask<TResult> PatchContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage =
               await this.httpClient.PatchAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public async ValueTask<T> PatchContentAsync<T>(string relativeUrl)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.PatchAsync(relativeUrl, content: default);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> PatchContentAsync<T>(string relativeUrl, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage =
                await this.httpClient.PatchAsync(relativeUrl, content: default, cancellationToken);

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
