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
using RESTFulSense.Services.Foundations.Attributes;
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
            invalidPropertyInfoMock.Setup(propertyInfo => propertyInfo.PropertyType).Returns(typeof(object));
            var someRESTFulStringContentAttribute = new RESTFulStringContentAttribute(name: "", ignoreDefaultValues: false);

            FormModel invalidFormModel = new FormModel
            {
                Properties = new PropertyInfo[] { invalidPropertyInfoMock.Object }
            };

            var nullStringContentException = new NullStringContentException();

            var expectedFormOrchestrationValidationException =
                new FormOrchestrationValidationException(nullStringContentException);

            this.attributeServiceMock.Setup(service =>
                service.RetrieveAttribute<RESTFulStringContentAttribute>(It.IsAny<PropertyInfo>()))
                    .Returns(someRESTFulStringContentAttribute);

            this.valueServiceMock.Setup(service =>
                service.RetrievePropertyValue(It.IsAny<object>() ,It.IsAny<PropertyInfo>()))
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
                service.RetrieveAttribute<RESTFulStringContentAttribute>(It.IsAny<PropertyInfo>()),
                    Times.Once);

            this.valueServiceMock.Verify(service =>
                service.RetrievePropertyValue(It.IsAny<object>(), It.IsAny<PropertyInfo>()),
                    Times.Once);

            attributeServiceMock.VerifyNoOtherCalls();
            valueServiceMock.VerifyNoOtherCalls();
            formServiceMock.VerifyNoOtherCalls();
        }
    }
}
