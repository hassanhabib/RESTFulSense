// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;
using System.Reflection;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using RESTFulSense.Models.Orchestrations.Forms;
using RESTFulSense.Models.Orchestrations.Properties;
using Xunit;

namespace RESTFulSense.Tests.Services.Coordinations.Forms
{
    public partial class FormCoordinationServiceTests
    {
        [Fact]
        public void ShouldConvertToMultipartFormDataContent()
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

            this.propertyOrchestrationServiceMock.Setup(service =>
                service.RetrieveProperties(It.Is<PropertyModel>(propertyModel => propertyModel.Object == inputObject)))
                    .Returns(expectedPropertyModel);

            this.formOrchestrationServiceMock.Setup(service =>
                service.BuildFormModel(It.Is<FormModel>(formModel => IsEquivalent(formModel, expectedPropertyModel))))
                    .Returns(inputFormModel);

            // when
            MultipartFormDataContent actualMultipartFormDataContent =
                this.formCoordinationService.ConvertToMultipartFormDataContent(inputObject);

            // then
            actualMultipartFormDataContent.Should().BeSameAs(expectedMultipartFormDataContent);

            this.propertyOrchestrationServiceMock.Verify(service =>
                service.RetrieveProperties(It.IsAny<PropertyModel>()),
                    Times.Once());

            this.formOrchestrationServiceMock.Verify(service =>
                service.BuildFormModel(It.IsAny<FormModel>()),
                    Times.Once());

            this.propertyOrchestrationServiceMock.VerifyNoOtherCalls();
            this.formOrchestrationServiceMock.VerifyNoOtherCalls();
        }
    }
}
