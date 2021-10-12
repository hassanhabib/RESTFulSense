// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Services
{
    public partial class ValidationServiceTests
    {
        private HttpResponseMessage CreateHttpResponseMessage(HttpStatusCode statusCode, string content)
        {
            return new HttpResponseMessage(statusCode)
            {
                Content = CreateStreamContent(content)
            };
        }

        private string GetRandomContent() => new MnemonicString().GetValue();

        private StreamContent CreateStreamContent(string content)
        {
            byte[] contentBytes = Encoding.ASCII.GetBytes(content);
            var stream = new MemoryStream(contentBytes);

            return new StreamContent(stream);
        }
    }
}
