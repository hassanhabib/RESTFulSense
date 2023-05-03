// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Orchestrations.Forms;
using RESTFulSense.Models.Orchestrations.Forms.Exceptions;
using Xeptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Orchestrations.Forms
{
    public partial class FormOrchestrationServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyValidationExceptions))]
        public void ShouldThrowDependencyValidationExceptionOnBuildIfDependValidationErrorOccurs(
            Xeption dependancyValidationException)
        {
            // given
            FormModel someFormModel = CreateRandomFormModel();
            FormModel inputFormModel = someFormModel;
            dynamic[] randomTestData = CreateTestData();

            dynamic[] randomFileNameData =
                randomTestData.Where(a => a.Attribute is RESTFulFileNameAttribute).ToArray();

            dynamic[] randomStringContentData =
                randomTestData.Where(a => a.Attribute is RESTFulStringContentAttribute).ToArray();

            dynamic[] randomByteArrayContentData =
                randomTestData.Where(a => a.Attribute is RESTFulByteArrayContentAttribute).ToArray();

            dynamic[] randomStreamContentData =
                randomTestData.Where(a => a.Attribute is RESTFulStreamContentAttribute).ToArray();

            dynamic[] randomPropertyContents = randomFileNameData
                .Union(randomStringContentData)
                .Union(randomByteArrayContentData)
                .Union(randomStreamContentData)
                .ToArray();

            dynamic[] inputPropertyContents = randomPropertyContents;
            PropertyInfo[] randomProperties = CreateRandomProperties(inputPropertyContents);
            PropertyInfo[] inputProperties = randomProperties;
            someFormModel.Properties = inputProperties;

            var expectedFormOrchestrationDependencyValidationException =
                new FormOrchestrationDependencyValidationException(dependancyValidationException);

            this.attributeServiceMock.Setup(service =>
                service.RetrieveAttribute<RESTFulFileNameAttribute>(It.IsAny<PropertyInfo>()))
                    .Throws(dependancyValidationException);

            // when
            Action buildFormModelAction = () =>
                this.formOrchestrationService.BuildFormModel(inputFormModel);

            FormOrchestrationDependencyValidationException actualFormOrchestrationDependencyValidationException =
                Assert.Throws<FormOrchestrationDependencyValidationException>(buildFormModelAction);

            // then
            actualFormOrchestrationDependencyValidationException.Should()
                .BeEquivalentTo(expectedFormOrchestrationDependencyValidationException);

            this.attributeServiceMock.Verify(service =>
                service.RetrieveAttribute<RESTFulFileNameAttribute>(It.IsAny<PropertyInfo>()),
                Times.Once);

            this.attributeServiceMock.VerifyNoOtherCalls();
            this.valueServiceMock.VerifyNoOtherCalls();
            this.formServiceMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnBuildIfDependencyErrorOccurs(
            Xeption dependancyException)
        {
            // given
            FormModel someFormModel = CreateRandomFormModel();
            FormModel inputFormModel = someFormModel;
            dynamic[] randomTestData = CreateTestData();

            dynamic[] randomFileNameData =
                randomTestData.Where(a => a.Attribute is RESTFulFileNameAttribute).ToArray();

            dynamic[] randomStringContentData =
                randomTestData.Where(a => a.Attribute is RESTFulStringContentAttribute).ToArray();

            dynamic[] randomByteArrayContentData =
                randomTestData.Where(a => a.Attribute is RESTFulByteArrayContentAttribute).ToArray();

            dynamic[] randomStreamContentData =
                randomTestData.Where(a => a.Attribute is RESTFulStreamContentAttribute).ToArray();

            dynamic[] randomPropertyContents = randomFileNameData
                .Union(randomStringContentData)
                .Union(randomByteArrayContentData)
                .Union(randomStreamContentData)
                .ToArray();

            dynamic[] inputPropertyContents = randomPropertyContents;
            PropertyInfo[] randomProperties = CreateRandomProperties(inputPropertyContents);
            PropertyInfo[] inputProperties = randomProperties;
            someFormModel.Properties = inputProperties;

            var expectedFormOrchestrationDependencyException =
                new FormOrchestrationDependencyException(dependancyException);

            this.attributeServiceMock.Setup(service =>
                service.RetrieveAttribute<RESTFulFileNameAttribute>(It.IsAny<PropertyInfo>()))
                    .Throws(dependancyException);

            // when
            Action buildFormModelAction = () =>
                this.formOrchestrationService.BuildFormModel(inputFormModel);

            FormOrchestrationDependencyException actualFormOrchestrationDependencyException =
                Assert.Throws<FormOrchestrationDependencyException>(buildFormModelAction);

            // then
            actualFormOrchestrationDependencyException.Should()
                .BeEquivalentTo(expectedFormOrchestrationDependencyException);

            this.attributeServiceMock.Verify(service =>
                service.RetrieveAttribute<RESTFulFileNameAttribute>(It.IsAny<PropertyInfo>()),
                Times.Once);

            this.attributeServiceMock.VerifyNoOtherCalls();
            this.valueServiceMock.VerifyNoOtherCalls();
            this.formServiceMock.VerifyNoOtherCalls();
        }
    }
}
