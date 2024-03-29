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
    public partial class RESTFulApiClient : HttpClient, IRESTFulApiClient
    {
        private IFormCoordinationService formCoordinationService;
        
        public RESTFulApiClient()
        {
            IServiceProvider serviceProvider = RegisterFormServices();

            this.formCoordinationService =
                serviceProvider.GetRequiredService<IFormCoordinationService>();
        }

        public async ValueTask<T> GetContentAsync<T>(
            string relativeUrl,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage = await GetAsync(relativeUrl);
            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage, deserializationFunction);
        }

        public async ValueTask<T> GetContentAsync<T>(
            string relativeUrl,
            CancellationToken cancellationToken,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage = 
                await GetAsync(relativeUrl, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage, deserializationFunction);
        }

        public async ValueTask<string> GetContentStringAsync(string relativeUrl) =>
            await GetStringAsync(relativeUrl);

        public async ValueTask<Stream> GetContentStreamAsync(string relativeUrl) =>
            await GetStreamAsync(relativeUrl);

        public async ValueTask<byte[]> GetContentByteArrayAsync(string relativeUrl)
        {
            HttpResponseMessage responseMessage =
                await GetAsync(relativeUrl);

            return responseMessage.IsSuccessStatusCode
                ? await responseMessage.Content.ReadAsByteArrayAsync()
                : await ValidateAndReturnInvalidResponse(responseMessage);
        }

        public async ValueTask PostContentWithNoResponseAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null)
        {
            HttpContent contentString = await ConvertToHttpContent(
                content, 
                mediaType, 
                ignoreDefaultValues, 
                serializationFunction);

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
            HttpContent contentString = await ConvertToHttpContent(
                content, 
                mediaType, 
                ignoreDefaultValues, 
                serializationFunction);

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
                await PostAsync(relativeUrl, contentString);

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
                await PostAsync(relativeUrl, contentString);
           
            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(
                responseMessage, deserializationFunction);
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
               await PostAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(
                responseMessage, deserializationFunction);
        }

        public async ValueTask<TResult> PostFormAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            CancellationToken cancellationToken = default(CancellationToken),
            Func<string, ValueTask<TResult>> deserializationFunction = null)
            where TContent : class
        {
            try
            {
                MultipartFormDataContent multipartFormDataContent =
                    this.formCoordinationService.ConvertToMultipartFormDataContent(content);

                HttpResponseMessage responseMessage =
                   await PostAsync(relativeUrl, multipartFormDataContent, cancellationToken);

                await ValidationService.ValidateHttpResponseAsync(responseMessage);

                return await DeserializeResponseContent<TResult>(
                    responseMessage, deserializationFunction);
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
                await PutAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync
                (responseMessage);

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
                await PutAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage, deserializationFunction);
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
                await PutAsync(relativeUrl, contentString);
            
            await ValidationService.ValidateHttpResponseAsync(
                responseMessage);

            return await DeserializeResponseContent<TResult>(
                responseMessage, deserializationFunction);
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
               await PutAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(
                responseMessage, deserializationFunction);
        }

        public async ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage =
                await PutAsync(relativeUrl, content: default);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage, deserializationFunction);
        }

        public async ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            CancellationToken cancellationToken,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage =
                await PutAsync(relativeUrl, content: default, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage, deserializationFunction);
        }

        public async ValueTask DeleteContentAsync(string relativeUrl)
        {
            HttpResponseMessage responseMessage = await DeleteAsync(relativeUrl);
            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask DeleteContentAsync(
            string relativeUrl,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage =
                await DeleteAsync(relativeUrl, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask<T> DeleteContentAsync<T>(
            string relativeUrl, 
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage = await DeleteAsync(relativeUrl);
            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage, deserializationFunction);
        }

        public async ValueTask<T> DeleteContentAsync<T>(
            string relativeUrl,
            CancellationToken cancellationToken,
            Func<string, ValueTask<T>> deserializationFunction = null)
        {
            HttpResponseMessage responseMessage =
                await DeleteAsync(relativeUrl, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(
                responseMessage, deserializationFunction);
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

        private async static ValueTask<byte[]> ValidateAndReturnInvalidResponse(
            HttpResponseMessage httpResponseMessage)
        {
            await ValidationService.ValidateHttpResponseAsync(httpResponseMessage);

            return null;
        }
    }
}