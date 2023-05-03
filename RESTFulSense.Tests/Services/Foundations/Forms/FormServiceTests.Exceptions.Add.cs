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
        public void ShouldThrowFormDependencyValidationExceptionOnAddIfDependencyValidationExceptionErrorOccurs(
            Exception dependencyValidationException)
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var expectedMultipartFormDataContent = new MultipartFormDataContent();
            Stream someContent = CreateSomeStreamContent();
            string randomName = CreateRandomString();

            var formDependencyValidationException =
                new FormDependencyValidationException(dependencyValidationException);

            var expectedFormValidationException =
                new FormValidationException(formDependencyValidationException);

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddStreamContent(It.IsAny<MultipartFormDataContent>(), It.IsAny<Stream>(), It.IsAny<string>()))
                    .Throws(dependencyValidationException);

            // when
            Action retrieveAttributeAction =
                () => this.formService.AddStreamContent(multipartFormDataContent, someContent, randomName);

            FormValidationException actualFormValidationException =
                  Assert.Throws<FormValidationException>(retrieveAttributeAction);

            // then
            actualFormValidationException.Should()
                .BeEquivalentTo(expectedFormValidationException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStreamContent(It.IsAny<MultipartFormDataContent>(), It.IsAny<Stream>(), It.IsAny<string>()),
                    Times.Once());

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowFormServiceExceptionIfExceptionOccurs()
        {
            // given
            var multipartFormDataContent = new MultipartFormDataContent();
            var expectedMultipartFormDataContent = new MultipartFormDataContent();
            Stream someContent = CreateSomeStreamContent();
            string randomName = CreateRandomString();

            var someException = new Exception();

            var failedFormServiceException =
                new FailedFormServiceException(someException);

            var expectedFormServiceException =
                new FormServiceException(failedFormServiceException);

            this.multipartFormDataContentBroker.Setup(broker =>
                broker.AddStreamContent(It.IsAny<MultipartFormDataContent>(), It.IsAny<Stream>(), It.IsAny<string>()))
                    .Throws(someException);

            // when
            Action retrieveAttributeAction =
                () => this.formService.AddStreamContent(multipartFormDataContent, someContent, randomName);

            FormServiceException actualFormServiceException =
                  Assert.Throws<FormServiceException>(retrieveAttributeAction);

            // then
            actualFormServiceException.Should()
                .BeEquivalentTo(expectedFormServiceException);

            this.multipartFormDataContentBroker.Verify(broker =>
                broker.AddStreamContent(It.IsAny<MultipartFormDataContent>(), It.IsAny<Stream>(), It.IsAny<string>()),
                    Times.Once());

            this.multipartFormDataContentBroker.VerifyNoOtherCalls();
        }
    }
}
