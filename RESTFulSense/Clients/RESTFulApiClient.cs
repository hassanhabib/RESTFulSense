// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RESTFulSense.Services;

namespace RESTFulSense.Clients
{
    public class RESTFulApiClient : HttpClient, IRESTFulApiClient
    {
        public async ValueTask<T> GetContentAsync<T>(string relativeUrl)
        {
            HttpResponseMessage responseMessage = await GetAsync(relativeUrl);
            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<string> GetContentStringAsync(string relativeUrl) =>
            await GetStringAsync(relativeUrl);

        public ValueTask<T> PostContentAsync<T>(
            string relativeUrl, 
            T content, 
            string mediaType = "text/json")
        {
            return PostContentAsync<T, T>(relativeUrl, content, mediaType);
        }

        public async ValueTask<TResult> PostContentAsync<TContent, TResult>(
            string relativeUrl, 
            TContent content,
            string mediaType = "text/json")
        {
            StringContent contentString = StringifyJsonifyContent(content, mediaType);

            HttpResponseMessage responseMessage =
               await PostAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public async ValueTask<T> PutContentAsync<T>(
            string relativeUrl, 
            T content,
            string mediaType = "text/json")
        {
            StringContent contentString = StringifyJsonifyContent(content, mediaType);

            HttpResponseMessage responseMessage =
               await PutAsync(relativeUrl, contentString);

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
               await PutAsync(relativeUrl, contentString);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public async ValueTask<T> PutContentAsync<T>(string relativeUrl)
        {
            HttpResponseMessage responseMessage =
                await PutAsync(relativeUrl, content: default);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask DeleteContentAsync(string relativeUrl)
        {
            HttpResponseMessage responseMessage = await DeleteAsync(relativeUrl);
            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public async ValueTask<T> DeleteContentAsync<T>(string relativeUrl)
        {
            HttpResponseMessage responseMessage = await DeleteAsync(relativeUrl);
            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        private static async ValueTask<T> DeserializeResponseContent<T>(HttpResponseMessage responseMessage)
        {
            string responseString = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseString);
        }

        private static StringContent StringifyJsonifyContent<T>(T content, string mediaType)
        {
            string serializedRestrictionRequest = JsonConvert.SerializeObject(content);

            var contentString =
                new StringContent(
                    content: serializedRestrictionRequest,
                    encoding: Encoding.UTF8,
                    mediaType);

            return contentString;
        }
    }
}