// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Net.Http;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Foundations.Forms.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Foundations.Forms
{
    public partial class FormServiceTests
    {
        [Theory]
        [InlineData(data: null)]
        [InlineData(data: "")]
        [InlineData(data: "   ")]
        private void ShouldThrowFormValidationExceptionOnAddByteContentWithNoFileNameIfArgumentsIsInvalid(
            string invalidInput)
        {
            // given
            MultipartFormDataContent nullMultipartFormDataContent =
                CreateNullMultipartFormDataContent();
            
            byte[] nullContent = null;
            string invalidName = invalidInput;

            var invalidFormArgumentException =
                new InvalidFormArgumentException(
                    message: "Invalid form arguments. Please fix the errors and try again.");

            invalidFormArgumentException.AddData(
                key: "MultipartFormDataContent",
                values: "Form data content is required");

            invalidFormArgumentException.AddData(
                key: "ByteArrayContent",
                values: "Content is required");

            invalidFormArgumentException.AddData(
                key: "Name",
                values: "Text is required");

            var expectedFormValidationException =
                new FormValidationException(
                    message: "Form validation error occurred, fix errors and try again.",
                    innerException: invalidFormArgumentException);

            // when
            Action addByteContentAction =
                () => formService.AddByteArrayContent(
                    nullMultipartFormDataContent, nullContent, invalidName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteArrayContent(
                    nullMultipartFormDataContent, nullContent, invalidName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(data: null)]
        [InlineData(data: "")]
        [InlineData(data: "   ")]
        private void ShouldThrowFormValidationExceptionOnAddByteContentWithFileNameIfArgumentsIsInvalid(
            string invalidInput)
        {
            // given
            MultipartFormDataContent nullMultipartFormDataContent =
                CreateNullMultipartFormDataContent();
            
            byte[] nullContent = null;
            string invalidName = invalidInput;
            string invalidFileName = invalidInput;

            var invalidFormArgumentException =
                new InvalidFormArgumentException(
                    message: "Invalid form arguments. Please fix the errors and try again.");

            invalidFormArgumentException.AddData(
                key: "MultipartFormDataContent",
                values: "Form data content is required");

            invalidFormArgumentException.AddData(
                key: "ByteArrayContent",
                values: "Content is required");

            invalidFormArgumentException.AddData(
                key: "Name",
                values: "Text is required");

            invalidFormArgumentException.AddData(
                key: "FileName",
                values: "Text is required");

            var expectedFormValidationException =
                new FormValidationException(
                    message: "Form validation error occurred, fix errors and try again.",
                    innerException: invalidFormArgumentException);

            // when
            Action addByteContentAction =
                () => formService.AddByteArrayContent(
                    nullMultipartFormDataContent, nullContent, invalidName, invalidFileName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddByteArrayContent(
                    nullMultipartFormDataContent, nullContent, invalidName, invalidFileName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }
    }
}
