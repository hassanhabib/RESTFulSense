// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RESTFulSense.Brokers.Reflections;
using RESTFulSense.Services;
using RESTFulSense.Services.Foundations.FileNames;
using RESTFulSense.Services.Foundations.Properties;
using RESTFulSense.Services.Foundations.StreamContents;
using RESTFulSense.Services.Foundations.StringContents;
using RESTFulSense.Services.Orchestrations.FormContents;
using RESTFulSense.Services.Processings.FileNames;
using RESTFulSense.Services.Processings.Properties;
using RESTFulSense.Services.Processings.StreamContents;
using RESTFulSense.Services.Processings.StringContents;

namespace RESTFulSense.Clients
{
    public partial class RESTFulApiClient : HttpClient, IRESTFulApiClient
    {
        public async ValueTask<T> GetContentAsync<T>(string relativeUrl)
        {
            HttpResponseMessage responseMessage = await GetAsync(relativeUrl);
            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> GetContentAsync<T>(string relativeUrl, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage = await GetAsync(relativeUrl, cancellationToken);
            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<string> GetContentStringAsync(string relativeUrl) =>
            await GetStringAsync(relativeUrl);

        public async ValueTask PostContentWithNoResponseAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false)
        {
            HttpContent contentString = ConvertToHttpContent(content, mediaType, ignoreDefaultValues);

            HttpResponseMessage responseMessage =
                await PostAsync(relativeUrl, contentString);

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
                await PostAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);
        }

        public ValueTask<T> PostContentAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false) => PostContentAsync<T, T>(relativeUrl, content, mediaType, ignoreDefaultValues);

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

            HttpResponseMessage responseMessage = await PostAsync(relativeUrl, contentString);

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

            HttpResponseMessage responseMessage = await PostAsync(relativeUrl, contentString);

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
               await PostAsync(relativeUrl, contentString, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<TResult>(responseMessage);
        }

        public ValueTask<TResult> PostFormAsync<TResult, TContent>(
            string relativeUrl,
            TContent content)
            where TContent : class =>
            PostFormAsync<TResult, TContent>(relativeUrl, content, CancellationToken.None);

        public async ValueTask<TResult> PostFormAsync<TResult, TContent>(
            string relativeUrl,
            TContent content,
            CancellationToken cancellationToken)
            where TContent : class
        {
            IServiceProvider serviceProvider = RegisterServices();

            IFormContentOrchestrationService formContentOrchestrationService =
                serviceProvider.GetRequiredService<IFormContentOrchestrationService>();

            MultipartFormDataContent multipartFormDataContent =
                formContentOrchestrationService.ConvertToMultipartFormDataContent(content);

            HttpResponseMessage responseMessage =
                  await this.PostAsync(relativeUrl, multipartFormDataContent, cancellationToken);

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
               await PutAsync(relativeUrl, contentString);

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
               await PutAsync(relativeUrl, contentString, cancellationToken);

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
               await PutAsync(relativeUrl, contentString);

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
               await PutAsync(relativeUrl, contentString, cancellationToken);

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

        public async ValueTask<T> PutContentAsync<T>(string relativeUrl, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage =
                await PutAsync(relativeUrl, content: default, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
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

        public async ValueTask<T> DeleteContentAsync<T>(string relativeUrl)
        {
            HttpResponseMessage responseMessage = await DeleteAsync(relativeUrl);
            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        public async ValueTask<T> DeleteContentAsync<T>(string relativeUrl, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage =
                await DeleteAsync(relativeUrl, cancellationToken);

            await ValidationService.ValidateHttpResponseAsync(responseMessage);

            return await DeserializeResponseContent<T>(responseMessage);
        }

        private static async ValueTask<T> DeserializeResponseContent<T>(HttpResponseMessage responseMessage)
        {
            string responseString = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseString);
        }

        private static IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();

            AddBroker(services);
            AddFoundationServices(services);
            AddProcessingServices(services);
            AddOrchestrationService(services);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }

        private static void AddBroker(ServiceCollection services) =>
            services.AddTransient<IReflectionBroker, ReflectionBroker>();

        private static void AddFoundationServices(ServiceCollection services)
        {
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<IStringContentService, StringContentService>();
            services.AddTransient<IFileNameService, FileNameService>();
            services.AddTransient<IStreamContentService, StreamContentService>();
        }

        private static void AddProcessingServices(ServiceCollection services)
        {
            services.AddTransient<IStringContentProcessingService, StringContentProcessingService>();
            services.AddTransient<IStreamContentProcessingService, StreamContentProcessingService>();
            services.AddTransient<IFileNameProcessingService, FileNameProcessingService>();
            services.AddTransient<IPropertyProcessingService, PropertyProcessingService>();
        }

        private static void AddOrchestrationService(ServiceCollection services) =>
            services.AddTransient<IFormContentOrchestrationService, FormContentOrchestrationService>();
    }
}