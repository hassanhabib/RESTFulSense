// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;

namespace RESTFulSense.Services.Foundations.Forms
{
    internal interface IFormService
    {
        MultipartFormDataContent AddByteArrayContent(
            MultipartFormDataContent multipartFormDataContent,
            byte[] content,
            string name);

        MultipartFormDataContent AddByteArrayContent(
            MultipartFormDataContent multipartFormDataContent,
            byte[] content,
            string name,
            string fileName);
    }
}
