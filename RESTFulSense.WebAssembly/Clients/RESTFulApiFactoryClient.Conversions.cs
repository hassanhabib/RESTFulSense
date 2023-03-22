// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;

namespace RESTFulSense.WebAssembly.Clients
{
    public partial class RESTFulApiFactoryClient
    {
        private static HttpContent ConvertToHttpContent<T>(T content, string mediaType, bool ignoreDefaultValues)
        {
            return mediaType switch
            {
                "text/json" => ConvertToJsonStringContent(content, mediaType, ignoreDefaultValues),
                "application/json" => ConvertToJsonStringContent(content, mediaType, ignoreDefaultValues),
                "text/plain" => ConvertToStringContent(content, mediaType),
                "application/octet-stream" => ConvertToStreamContent(content as Stream, mediaType),
                _ => ConvertToStringContent(content, mediaType)
            };
        }

        private static StringContent ConvertToStringContent<T>(T content, string mediaType)
        {
            return new StringContent(
                content: content.ToString(),
                encoding: Encoding.UTF8,
                mediaType);
        }

        private static StringContent ConvertToJsonStringContent<T>(T content, string mediaType, bool ignoreDefaultValues)
        {
            JsonSerializerSettings jsonSerializerSettings = CreateJsonSerializerSettings(ignoreDefaultValues);

            string serializedRestrictionRequest = JsonConvert.SerializeObject(
                content,
                formatting: Formatting.None,
                settings: jsonSerializerSettings);

            var contentString =
                new StringContent(
                    content: serializedRestrictionRequest,
                    encoding: Encoding.UTF8,
                    mediaType);

            return contentString;
        }

        private static StreamContent ConvertToStreamContent<T>(T content, string mediaType)
            where T : Stream
        {
            var contentStream = new StreamContent(content);
            contentStream.Headers.ContentType = new MediaTypeHeaderValue(mediaType);

            return contentStream;
        }

        private static JsonSerializerSettings CreateJsonSerializerSettings(bool ignoreDefaultValues)
        {
            DefaultValueHandling defaultValueHandling = ignoreDefaultValues ? DefaultValueHandling.Ignore : DefaultValueHandling.Include;
            var jsonSerializerSettings = new JsonSerializerSettings { DefaultValueHandling = defaultValueHandling };
            return jsonSerializerSettings;
        }
    }
}
