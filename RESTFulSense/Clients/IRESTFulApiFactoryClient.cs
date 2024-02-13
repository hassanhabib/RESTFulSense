// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RESTFulSense.Clients
{
    public interface IRESTFulApiFactoryClient
    {
        ValueTask<T> GetContentAsync<T>(string relativeUrl, Func<string, ValueTask<T>> deserializationFunction = null);
        ValueTask<T> GetContentAsync<T>(
            string relativeUrl,
            CancellationToken cancellationToken,
            Func<string, ValueTask<T>> deserializationFunction = null);

        ValueTask<string> GetContentStringAsync(string relativeUrl);
        ValueTask<Stream> GetContentStreamAsync(string relativeUrl);

        ValueTask PostContentWithNoResponseAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null);

        ValueTask PostContentWithNoResponseAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null);

        ValueTask<T> PostContentAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<T>> deserializationFunction = null);

        ValueTask<T> PostContentAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<T>> deserializationFunction = null);

        ValueTask<Stream> PostContentWithStreamResponseAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null);

        ValueTask<TResult> PostContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<TContent, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<TResult>> deserializationFunction = null);

        ValueTask<TResult> PostFormAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            CancellationToken cancellationToken = default(CancellationToken),
            Func<string, ValueTask<TResult>> deserializationFunction = null)
            where TContent : class;

        ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            T content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<T>> deserializationFunction = null);

        ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            T content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<T, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<T>> deserializationFunction = null);

        ValueTask<TResult> PutContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<TContent, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<TResult>> deserializationFunction = null);

        ValueTask<TResult> PutContentAsync<TContent, TResult>(
            string relativeUrl,
            TContent content,
            CancellationToken cancellationToken,
            string mediaType = "text/json",
            bool ignoreDefaultValues = false,
            Func<TContent, ValueTask<string>> serializationFunction = null,
            Func<string, ValueTask<TResult>> deserializationFunction = null);

        ValueTask<T> PutContentAsync<T>(string relativeUrl, Func<string, ValueTask<T>> deserializationFunction = null);
        ValueTask<T> PutContentAsync<T>(
            string relativeUrl,
            CancellationToken cancellationToken,
            Func<string, ValueTask<T>> deserializationFunction = null);

        ValueTask DeleteContentAsync(string relativeUrl);
        ValueTask DeleteContentAsync(string relativeUrl, CancellationToken cancellationToken);
        ValueTask<T> DeleteContentAsync<T>(string relativeUrl, Func<string, ValueTask<T>> deserializationFunction = null);

        ValueTask<T> DeleteContentAsync<T>(
            string relativeUrl,
            CancellationToken cancellationToken,
            Func<string, ValueTask<T>> deserializationFunction = null);
    }
}
