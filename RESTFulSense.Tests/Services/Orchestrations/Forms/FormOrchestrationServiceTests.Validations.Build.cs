// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Orchestrations.Forms;
using RESTFulSense.Models.Orchestrations.Forms.Exceptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Orchestrations.Forms
{
    public partial class FormOrchestrationServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnBuildFormModelIfModelIsInvalid()
        {
            // given
            FormModel nullFormModel = null;

            var nullFormModelException = new NullFormModelException();

            var expectedFormOrchestrationValidationException =
                new FormOrchestrationValidationException(nullFormModelException);

            // when
            Action buildFormModelAction = () =>
                formOrchestrationService.BuildFormModel(nullFormModel);

            FormOrchestrationValidationException actualFormOrchestrationValidationException =
                Assert.Throws<FormOrchestrationValidationException>(buildFormModelAction);

            // then
            actualFormOrchestrationValidationException.Should()
                .BeEquivalentTo(expectedFormOrchestrationValidationException);

            attributeServiceMock.VerifyNoOtherCalls();
            valueServiceMock.VerifyNoOtherCalls();
            formServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowValidationExceptionOnBuildFormModelIfStringContentValueIsNull()
        {
            // given
            Mock<PropertyInfo> invalidPropertyInfoMock = new Mock<PropertyInfo>();
            PropertyInfo inputPropertyInfo = invalidPropertyInfoMock.Object;
            var someRESTFulStringContentAttribute = new RESTFulStringContentAttribute(name: "", ignoreDefaultValues: false);

            FormModel invalidFormModel = new FormModel
            {
                Properties = new PropertyInfo[] { inputPropertyInfo }
            };

            var argumentException = new ArgumentException(message: "String Content is null.");
            var nullStringContentException = new NullStringContentException(argumentException);

            var expectedFormOrchestrationValidationException =
                new FormOrchestrationValidationException(nullStringContentException);

            invalidPropertyInfoMock.Setup(propertyInfo =>
                propertyInfo.PropertyType)
                    .Returns(typeof(object));

            this.attributeServiceMock.Setup(service =>
                service.RetrieveAttribute<RESTFulFileNameAttribute>(inputPropertyInfo))
                    .Returns((RESTFulFileNameAttribute)null);

            this.attributeServiceMock.Setup(service =>
                service.RetrieveAttribute<RESTFulStringContentAttribute>(inputPropertyInfo))
                    .Returns(someRESTFulStringContentAttribute);

            this.valueServiceMock.Setup(service =>
                service.RetrievePropertyValue(It.IsAny<object>(), It.IsAny<PropertyInfo>()))
                    .Returns(null);

            // when
            Action buildFormModelAction = () =>
                formOrchestrationService.BuildFormModel(invalidFormModel);

            FormOrchestrationValidationException actualFormOrchestrationValidationException =
                Assert.Throws<FormOrchestrationValidationException>(buildFormModelAction);

            // then
            actualFormOrchestrationValidationException.Should()
                .BeEquivalentTo(expectedFormOrchestrationValidationException);

            this.attributeServiceMock.Verify(service =>
                service.RetrieveAttribute<RESTFulFileNameAttribute>(inputPropertyInfo),
                    Times.Once);

            this.attributeServiceMock.Verify(service =>
                service.RetrieveAttribute<RESTFulStringContentAttribute>(inputPropertyInfo),
                    Times.Once);

            this.valueServiceMock.Verify(service =>
                service.RetrievePropertyValue(It.IsAny<object>(), It.IsAny<PropertyInfo>()),
                    Times.Once);

            this.attributeServiceMock.VerifyNoOtherCalls();
            this.valueServiceMock.VerifyNoOtherCalls();
            this.formServiceMock.VerifyNoOtherCalls();
        }
    }
}
