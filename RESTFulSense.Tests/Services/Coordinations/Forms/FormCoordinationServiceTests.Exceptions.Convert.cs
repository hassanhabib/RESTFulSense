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
        public void ShouldThrowDependencyValidationExceptionOnConvertIfDependencyValidationErrorOccurs(
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
                new FormCoordinationDependencyValidationException(dependancyValidationException);

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
        public void ShouldThrowDependencyExceptionOnConvertIfDependencyErrorOccurs(
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
                new FormCoordinationDependencyException(dependancyException);

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
        public void ShouldThrowServiceExceptionOnConvertIfServiceErrorOccurs()
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
                new FailedFormCoordinationServiceException(serviceException);

            var expectedFormCoordinationServiceException =
                new FormCoordinationServiceException(failedFormCoordinationServiceException);

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
