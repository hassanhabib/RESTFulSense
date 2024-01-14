// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace RESTFulSense.Clients
{
    public partial class RESTFulApiClient
    {
        private static HttpContent ConvertToHttpContent<T>(
            T content,
            string mediaType,
            bool ignoreDefaultValues,
            Func<T, string> serializationFunction = null)
        {
            return mediaType switch
            {
                "text/json" => ConvertToJsonStringContent(content, mediaType, ignoreDefaultValues, serializationFunction),
                "application/json" => ConvertToJsonStringContent(content, mediaType, ignoreDefaultValues, serializationFunction),
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

        private static StringContent ConvertToJsonStringContent<T>(
            T content,
            string mediaType,
            bool ignoreDefaultValues,
            Func<T, string> serializationFunction = null)
        {
            string serializedRestrictionRequest = serializationFunction == null
                    ? ConvertToJsonNewtonSoftStringContent<T>(content, ignoreDefaultValues)
                    : serializationFunction(content);

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
    }
}