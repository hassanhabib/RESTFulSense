// ---------------------------------------------------------------
// Copyright (c) Brian Parker & Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace RESTFulSense.WebAssembly.Clients
{
    public partial class RESTFulApiClient
    {
        private static JsonSerializerSettings jsonSerializerSettingsIgnore = null;
        private static JsonSerializerSettings jsonSerializerSettingsInclude = null;

        private static JsonSerializerSettings JsonSerializerSettingsIgnore
        {
            get
            {
                if (jsonSerializerSettingsIgnore == null)
                {
                    jsonSerializerSettingsIgnore = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore };
                }

                return jsonSerializerSettingsIgnore;
            }
        }

        private static JsonSerializerSettings JsonSerializerSettingsInclude
        {
            get
            {
                if (jsonSerializerSettingsInclude == null)
                {
                    jsonSerializerSettingsInclude = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Include };
                }

                return jsonSerializerSettingsInclude;
            }
        }

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
            return ignoreDefaultValues
                ? JsonSerializerSettingsIgnore
                : JsonSerializerSettingsInclude;
        }
    }
}