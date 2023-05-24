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
        public void ShouldThrowFormValidationExceptionOnAddStringContentIfArgumentsIsInvalid(string invalidInput)
        {
            // given
            MultipartFormDataContent nullMultipartFormDataContent = CreateNullMultipartFormDataContent();
            string invalidContent = invalidInput;
            string invalidName = invalidInput;

            var invalidFormArgumentException =
                new InvalidFormArgumentException();

            invalidFormArgumentException.AddData(
                key: "MultipartFormDataContent",
                values: "Form data content is required");

            invalidFormArgumentException.AddData(
                key: "StringContent",
                values: "Content is required");

            invalidFormArgumentException.AddData(
                key: "Name",
                values: "Text is required");

            var expectedFormValidationException =
                new FormValidationException(invalidFormArgumentException);

            // when
            Action addByteContentAction =
                () => formService.AddStringContent(nullMultipartFormDataContent, content: invalidContent, name: invalidName);

            FormValidationException actualFormValidationException =
                Assert.Throws<FormValidationException>(addByteContentAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStringContent(nullMultipartFormDataContent, invalidContent, invalidName),
                    Times.Never);

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }
    }
}
