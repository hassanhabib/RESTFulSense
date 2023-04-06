// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.IO;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace RESTFulSense.Clients
{
    public class MultipartFormDataContentBuilder
    {
        private readonly MultipartFormDataContent content;

        private MultipartFormDataContentBuilder()
        {
            content = new MultipartFormDataContent();
        }

        public static MultipartFormDataContentBuilder Create() =>
            new MultipartFormDataContentBuilder();

        public MultipartFormDataContentBuilder AddStream(
            Stream stream,
            string fileName)
        {
            StreamContent streamContent = new StreamContent(stream);
            this.content.Add(streamContent, name: "file", fileName);
            return this;
        }

        public MultipartFormDataContentBuilder AddFile(string filePath)
        {
            using Stream fileStream = File.OpenRead(filePath);
            return this.AddStream(fileStream, Path.GetFileName(filePath));
        }

        public MultipartFormDataContentBuilder AddStringContent<T>(
            T content,
            string name,
            string mediaType = "text/json")
        {
            var contentString =
                new StringContent(
                content: content.ToString(),
                encoding: Encoding.UTF8,
                mediaType);

            this.content.Add(contentString, name);

            return this;
        }

        public MultipartFormDataContent Build() => this.content;

        private static JsonSerializerSettings CreateJsonSerializerSettings(bool ignoreDefaultValues)
        {
            return new JsonSerializerSettings
            {
                DefaultValueHandling = ignoreDefaultValues ? DefaultValueHandling.Ignore : DefaultValueHandling.Include
            };
        }
    }
}
