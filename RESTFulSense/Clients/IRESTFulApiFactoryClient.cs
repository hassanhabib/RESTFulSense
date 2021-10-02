// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading.Tasks;

namespace RESTFulSense.Clients
{
    public interface IRESTFulApiFactoryClient
    {
        ValueTask<T> GetContentAsync<T>(string relativeUrl);
        ValueTask<string> GetContentStringAsync(string relativeUrl);
        ValueTask<T> PostContentAsync<T>(string relativeUrl, T content, string mediaType);
        
        ValueTask<TResult> PostContentAsync<TContent, TResult>(
            string relativeUrl, 
            TContent content, 
            string mediaType);
        
        ValueTask<T> PutContentAsync<T>(string relativeUrl, T content, string mediaType);
        
        ValueTask<TResult> PutContentAsync<TContent, TResult>(
            string relativeUrl, 
            TContent content,
            string mediaType);
        
        ValueTask<T> PutContentAsync<T>(string relativeUrl);
        ValueTask DeleteContentAsync(string relativeUrl);
        ValueTask<T> DeleteContentAsync<T>(string relativeUrl);
    }
}
