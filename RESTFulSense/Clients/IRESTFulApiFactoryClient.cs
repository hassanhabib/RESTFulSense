// ---------------------------------------------------------------
// Copyright (c) Hassan Habib & Alice Luo  All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Threading.Tasks;

namespace RESTFulSense.Clients
{
    public interface IRESTFulApiFactoryClient
    {
        ValueTask<T> GetContentAsync<T>(string relativeUrl);
        ValueTask<T> PostContentAsync<T>(string relativeUrl, T content);
        ValueTask<T> PutContentAsync<T>(string relativeUrl, T content);
        ValueTask<T> PutContentAsync<T>(string relativeUrl);
        ValueTask DeleteContentAsync(string relativeUrl);
        ValueTask<T> DeleteContentAsync<T>(string relativeUrl);
    }
}
