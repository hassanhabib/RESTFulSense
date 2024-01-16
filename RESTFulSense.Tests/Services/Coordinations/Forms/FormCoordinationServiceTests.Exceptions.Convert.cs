// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Reflection;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using RESTFulSense.Models.Coordinations.Forms.Exceptions;
using RESTFulSense.Models.Orchestrations.Forms;
using RESTFulSense.Models.Orchestrations.Properties;
using Xeptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Coordinations.Forms
{
    public partial class FormCoordinationServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyValidationExceptions))]
        private void ShouldThrowDependencyValidationExceptionOnConvertIfDependencyValidationErrorOccurs(
            Xeption dependancyValidationException)
        {
            // given
            object someObject = new object();
            object inputObject = someObject;
            PropertyModel somePropertyModel = CreateSomePropertyModel(inputObject);
            PropertyModel inputPropertyModel = somePropertyModel;
            PropertyModel expectedPropertyModel = somePropertyModel.DeepClone();
            PropertyInfo[] randomProperties = CreateRandomProperties();
            expectedPropertyModel.Properties = randomProperties;
            MultipartFormDataContent someMultipartFormDataContent = CreateNewMultipartFormDataContent();
            MultipartFormDataContent inputMultipartFormDataContent = someMultipartFormDataContent;
            MultipartFormDataContent expectedMultipartFormDataContent = inputMultipartFormDataContent;
            FormModel someFormModel = CreateSomeFormModel(inputObject, inputMultipartFormDataContent);
            FormModel inputFormModel = someFormModel;

            var expectedFormCoordinationDependencyValidationException =
                new FormCoordinationDependencyValidationException(
                    message: "Form coordination dependency validation error occurred, fix the errors and try again.",
                    innerException: dependancyValidationException);

            propertyOrchestrationServiceMock.Setup(service =>
                service.RetrieveProperties(It.IsAny<PropertyModel>()))
                    .Throws(dependancyValidationException);

            Action convertToMultipartFormDataContentAction = () =>
                formCoordinationService.ConvertToMultipartFormDataContent(inputObject);

            FormCoordinationDependencyValidationException actualFormCoordinationDependencyValidationException =
                Assert.Throws<FormCoordinationDependencyValidationException>(convertToMultipartFormDataContentAction);

            // then
            actualFormCoordinationDependencyValidationException.Should()
                .BeEquivalentTo(expectedFormCoordinationDependencyValidationException);

            propertyOrchestrationServiceMock.Verify(service =>
                service.RetrieveProperties(It.IsAny<PropertyModel>()),
                    Times.Once());

            propertyOrchestrationServiceMock.VerifyNoOtherCalls();
            formOrchestrationServiceMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        private void ShouldThrowDependencyExceptionOnConvertIfDependencyErrorOccurs(
            Xeption dependancyException)
        {
            // given
            object someObject = new object();
            object inputObject = someObject;
            PropertyModel somePropertyModel = CreateSomePropertyModel(inputObject);
            PropertyModel inputPropertyModel = somePropertyModel;
            PropertyModel expectedPropertyModel = somePropertyModel.DeepClone();
            PropertyInfo[] randomProperties = CreateRandomProperties();
            expectedPropertyModel.Properties = randomProperties;
            MultipartFormDataContent someMultipartFormDataContent = CreateNewMultipartFormDataContent();
            MultipartFormDataContent inputMultipartFormDataContent = someMultipartFormDataContent;
            MultipartFormDataContent expectedMultipartFormDataContent = inputMultipartFormDataContent;
            FormModel someFormModel = CreateSomeFormModel(inputObject, inputMultipartFormDataContent);
            FormModel inputFormModel = someFormModel;

            var expectedFormCoordinationDependencyException =
                new FormCoordinationDependencyException(
                    message: "Form coordination dependency error occurred, fix the errors and try again.",
                    innerException: dependancyException);

            this.propertyOrchestrationServiceMock.Setup(service =>
                service.RetrieveProperties(It.IsAny<PropertyModel>()))
                    .Throws(dependancyException);

            Action convertToMultipartFormDataContentAction = () =>
                this.formCoordinationService.ConvertToMultipartFormDataContent(inputObject);

            FormCoordinationDependencyException actualFormCoordinationDependencyException =
                Assert.Throws<FormCoordinationDependencyException>(convertToMultipartFormDataContentAction);

            // then
            actualFormCoordinationDependencyException.Should()
                .BeEquivalentTo(expectedFormCoordinationDependencyException);

            this.propertyOrchestrationServiceMock.Verify(service =>
                service.RetrieveProperties(It.IsAny<PropertyModel>()),
                    Times.Once());

            this.propertyOrchestrationServiceMock.VerifyNoOtherCalls();
            this.formOrchestrationServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        private void ShouldThrowServiceExceptionOnConvertIfServiceErrorOccurs()
        {
            // given
            object someObject = new object();
            object inputObject = someObject;
            PropertyModel somePropertyModel = CreateSomePropertyModel(inputObject);
            PropertyModel inputPropertyModel = somePropertyModel;
            PropertyModel expectedPropertyModel = somePropertyModel.DeepClone();
            PropertyInfo[] randomProperties = CreateRandomProperties();
            expectedPropertyModel.Properties = randomProperties;
            MultipartFormDataContent someMultipartFormDataContent = CreateNewMultipartFormDataContent();
            MultipartFormDataContent inputMultipartFormDataContent = someMultipartFormDataContent;
            MultipartFormDataContent expectedMultipartFormDataContent = inputMultipartFormDataContent;
            FormModel someFormModel = CreateSomeFormModel(inputObject, inputMultipartFormDataContent);
            FormModel inputFormModel = someFormModel;
            var serviceException = new Exception();

            var failedFormCoordinationServiceException =
                new FailedFormCoordinationServiceException(
                    message: "Form coordination service error occurred, contact support.",
                    innerException: serviceException);

            var expectedFormCoordinationServiceException =
                new FormCoordinationServiceException(
                    message: "Form coordination service error occurred, contact support.",
                    innerException: failedFormCoordinationServiceException);

            this.propertyOrchestrationServiceMock.Setup(service =>
                service.RetrieveProperties(It.IsAny<PropertyModel>()))
                    .Throws(serviceException);

            Action convertToMultipartFormDataContentAction = () =>
                this.formCoordinationService.ConvertToMultipartFormDataContent(inputObject);

            FormCoordinationServiceException actualFormCoordinationServiceException =
                Assert.Throws<FormCoordinationServiceException>(convertToMultipartFormDataContentAction);

            // then
            actualFormCoordinationServiceException.Should()
                .BeEquivalentTo(expectedFormCoordinationServiceException);

            this.propertyOrchestrationServiceMock.Verify(service =>
                service.RetrieveProperties(It.IsAny<PropertyModel>()),
                    Times.Once());

            this.propertyOrchestrationServiceMock.VerifyNoOtherCalls();
            this.formOrchestrationServiceMock.VerifyNoOtherCalls();
        }
    }
}
