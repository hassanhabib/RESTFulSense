// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using System.Net.Http;
using System.Xml.Linq;
using RESTFulSense.Brokers.MultipartFormDataContents;

namespace RESTFulSense.Services.Foundations.Forms
{
    internal partial class FormService : IFormService
    {
        private readonly IMultipartFormDataContentBroker multipartFormDataContentBroker;

        public FormService(IMultipartFormDataContentBroker multipartFormDataContentBroker) =>
            this.multipartFormDataContentBroker = multipartFormDataContentBroker;

        public MultipartFormDataContent AddByteArrayContent(
            MultipartFormDataContent multipartFormDataContent,
            byte[] content,
            string name) =>
        TryCatch(() =>
        {
            ValidateOnAddByteContent(multipartFormDataContent, byteArrayContent: content, name);

            MultipartFormDataContent returnedMultipartFormDataContent =
                this.multipartFormDataContentBroker
                    .AddByteArrayContent(multipartFormDataContent, content, name);

            return returnedMultipartFormDataContent;
        });

        public MultipartFormDataContent AddByteArrayContent(
            MultipartFormDataContent multipartFormDataContent,
            byte[] content,
            string name,
            string fileName) =>
        TryCatch(() =>
        {
            ValidateOnAddByteContent(multipartFormDataContent, byteArrayContent: content, name, fileName);

            MultipartFormDataContent returnedMultipartFormDataContent =
                this.multipartFormDataContentBroker
                    .AddByteArrayContent(multipartFormDataContent, content, name, fileName);

            return returnedMultipartFormDataContent;
        });

        public MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            Stream content,
            string name) =>
        TryCatch(() =>
        {
            ValidateOnAddStreamContent(multipartFormDataContent, streamContent: content, name);

            MultipartFormDataContent returnedMultipartFormDataContent =
                this.multipartFormDataContentBroker
                    .AddStreamContent(multipartFormDataContent, content, name);

            return returnedMultipartFormDataContent;
        });

        public MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            Stream content,
            string name,
            string fileName)
        {
            MultipartFormDataContent returnedMultipartFormDataContent =
                this.multipartFormDataContentBroker
                    .AddStreamContent(multipartFormDataContent, content, name, fileName);

            return returnedMultipartFormDataContent;
        }
    }
}
