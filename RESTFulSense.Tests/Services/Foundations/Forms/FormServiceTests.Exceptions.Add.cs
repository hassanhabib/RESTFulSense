// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.IO;
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
        [MemberData(nameof(GetAddExceptions))]
        private void ShouldThrowFormDependencyValidationExceptionOnAddIfDependencyValidationExceptionErrorOccurs(
            Exception dependencyValidationException)
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var expectedMultipartFormDataContent = new MultipartFormDataContent();
            Stream someContent = CreateSomeStreamContent();
            string randomName = CreateRandomString();

            var formDependencyValidationException =
                new FormDependencyValidationException(
                    message: "Form dependency validation error occurred, fix errors and try again.",
                    innerException: dependencyValidationException);

            var expectedFormValidationException =
                new FormValidationException(
                    message: "Form validation error occurred, fix errors and try again.",
                    innerException: formDependencyValidationException);

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddStreamContent(It.IsAny<MultipartFormDataContent>(),
                    It.IsAny<Stream>(),
                    It.IsAny<string>()))
                    .Throws(dependencyValidationException);

            // when
            Action retrieveAttributeAction =
                () => this.formService.AddStreamContent(
                    multipartFormDataContent, someContent, randomName);

            FormValidationException actualFormValidationException =
                  Assert.Throws<FormValidationException>(retrieveAttributeAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStreamContent(It.IsAny<MultipartFormDataContent>(),
                    It.IsAny<Stream>(),
                    It.IsAny<string>()),
                    Times.Once());

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Fact]
        private void ShouldThrowFormServiceExceptionIfExceptionOccurs()
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var expectedMultipartFormDataContent = new MultipartFormDataContent();
            Stream someContent = CreateSomeStreamContent();
            string randomName = CreateRandomString();

            var someException = new Exception();

            var failedFormServiceException =
                new FailedFormServiceException(
                    message: "Failed Form Service Exception occurred, please contact support for assistance.",
                    innerException: someException);


            // Type exception: FormServiceException
            // INNER Exception: FailedFormServiceException

            // Current Inner Exception: SYSTEM.EXCEPTION
            var expectedFormServiceException =
                new FormServiceException(
                    message: "Form service error occurred, contact support.",
                    innerException: failedFormServiceException);

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddStreamContent(It.IsAny<MultipartFormDataContent>(),
                    It.IsAny<Stream>(),
                    It.IsAny<string>()))
                    .Throws(someException);

            // when
            Action retrieveAttributeAction =
                () => this.formService.AddStreamContent(
                    multipartFormDataContent, someContent, randomName);

            FormServiceException actualFormServiceException =
                  Assert.Throws<FormServiceException>(retrieveAttributeAction);

            // then
            actualFormServiceException.Should()
                .BeEquivalentTo(expectedFormServiceException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStreamContent(It.IsAny<MultipartFormDataContent>(),
                    It.IsAny<Stream>(),
                    It.IsAny<string>()),
                    Times.Once());

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }
    }
}
