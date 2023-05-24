// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using System.Net.Http;
using RESTFulSense.Models.Foundations.Forms.Exceptions;

namespace RESTFulSense.Services.Foundations.Forms
{
    internal partial class FormService : IFormService
    {
        private static void ValidateOnAddByteContent(MultipartFormDataContent multipartFormDataContent, byte[] byteArrayContent, string name)
        {
            Validate(
                (Rule: IsInvalidContent(multipartFormDataContent), Parameter: "MultipartFormDataContent"),
                (Rule: IsInvalidContent(byteArrayContent), Parameter: "ByteArrayContent"),
                (Rule: IsInvalid(name), Parameter: "Name"));
        }

        private static void ValidateOnAddByteContent(MultipartFormDataContent multipartFormDataContent, byte[] byteArrayContent, string name, string fileName)
        {
            Validate(
                (Rule: IsInvalidContent(multipartFormDataContent), Parameter: "MultipartFormDataContent"),
                (Rule: IsInvalidContent(byteArrayContent), Parameter: "ByteArrayContent"),
                (Rule: IsInvalid(name), Parameter: "Name"),
                (Rule: IsInvalid(fileName), Parameter: "FileName"));
        }

        private static void ValidateOnAddStreamContent(MultipartFormDataContent multipartFormDataContent, Stream streamContent, string name)
        {
            Validate(
                (Rule: IsInvalidContent(multipartFormDataContent), Parameter: "MultipartFormDataContent"),
                (Rule: IsInvalidContent(streamContent), Parameter: "StreamContent"),
                (Rule: IsInvalid(name), Parameter: "Name"));
        }

        private static void ValidateOnAddStreamContent(MultipartFormDataContent multipartFormDataContent, Stream streamContent, string name, string fileName)
        {
            Validate(
                (Rule: IsInvalidContent(multipartFormDataContent), Parameter: "MultipartFormDataContent"),
                (Rule: IsInvalidContent(streamContent), Parameter: "StreamContent"),
                (Rule: IsInvalid(name), Parameter: "Name"),
                (Rule: IsInvalid(fileName), Parameter: "FileName"));
        }

        private static void ValidateOnAddStringContent(MultipartFormDataContent multipartFormDataContent, string stringContent, string name)
        {
            Validate(
                (Rule: IsInvalidContent(multipartFormDataContent), Parameter: "MultipartFormDataContent"),
                (Rule: IsInvalidContent(stringContent), Parameter: "StringContent"),
                (Rule: IsInvalid(name), Parameter: "Name"));
        }

        private static dynamic IsInvalidContent(byte[] content) => new
        {
            Condition = content is null,
            Message = "Content is required"
        };

        private static dynamic IsInvalidContent(Stream content) => new
        {
            Condition = content is null,
            Message = "Content is required"
        };

        private static dynamic IsInvalidContent(string text) => new
        {
            Condition = text is null,
            Message = "Content is required"
        };

        private static dynamic IsInvalidContent(MultipartFormDataContent multipartFormDataContent) => new
        {
            Condition = multipartFormDataContent is null,
            Message = "Form data content is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidFormArgumentException = new InvalidFormArgumentException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidFormArgumentException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidFormArgumentException.ThrowIfContainsErrors();
        }
    }
}
