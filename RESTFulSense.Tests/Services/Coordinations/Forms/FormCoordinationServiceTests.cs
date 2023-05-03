// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Net.Http;
using System.Reflection;
using FluentAssertions;
using Moq;
using RESTFulSense.Models.Orchestrations.Forms;
using RESTFulSense.Models.Orchestrations.Forms.Exceptions;
using RESTFulSense.Models.Orchestrations.Properties;
using RESTFulSense.Models.Orchestrations.Properties.Exceptions;
using RESTFulSense.Services.Coordinations.Forms;
using RESTFulSense.Services.Orchestrations.Forms;
using RESTFulSense.Services.Orchestrations.Properties;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace RESTFulSense.Tests.Services.Coordinations.Forms
{
    public partial class FormCoordinationServiceTests
    {
        private readonly Mock<IPropertyOrchestrationService> propertyOrchestrationServiceMock;
        private readonly Mock<IFormOrchestrationService> formOrchestrationServiceMock;
        private readonly IFormCoordinationService formCoordinationService;

        public FormCoordinationServiceTests()
        {
            propertyOrchestrationServiceMock = new Mock<IPropertyOrchestrationService>();
            formOrchestrationServiceMock = new Mock<IFormOrchestrationService>();

            formCoordinationService = new FormCoordinationService(
                propertyOrchestrationServiceMock.Object,
                formOrchestrationServiceMock.Object);
        }

        private static MultipartFormDataContent CreateNewMultipartFormDataContent() =>
            new MultipartFormDataContent();

        private static PropertyModel CreateSomePropertyModel(object someObject)
        {
            return new PropertyModel
            {
                Object = someObject,
                Properties = null
            };
        }

        private static PropertyInfo[] CreateRandomProperties()
        {
            return Enumerable.Range(start: 0, count: GetRandomNumber())
                .Select(i => new Mock<PropertyInfo>().Object)
                    .ToArray();
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 3, max: 10).GetValue();

        private static FormModel CreateSomeFormModel(object inputObject, MultipartFormDataContent inputMultipartFormDataContent)
        {
            return new FormModel
            {
                Object = inputObject,
                MultipartFormDataContent = inputMultipartFormDataContent
            };
        }
        private static bool IsEquivalent(FormModel formModel, PropertyModel propertyModel)
        {
            formModel.Properties.Should().BeEquivalentTo(propertyModel.Properties);
            return true;
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        public static TheoryData DependencyValidationExceptions()
        {
            string randomMessage = GetRandomString();
            string exceptionMessage = randomMessage;
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Xeption>
            {
                new FormOrchestrationValidationException(innerException),
                new FormOrchestrationDependencyValidationException(innerException),
                new PropertyOrchestrationValidationException(innerException),
                new PropertyOrchestrationDependencyValidationException(innerException)
            };
        }

        public static TheoryData DependencyExceptions()
        {
            string randomMessage = GetRandomString();
            string exceptionMessage = randomMessage;
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Xeption>
            {
                new FormOrchestrationDependencyException(innerException),
                new FormOrchestrationServiceException(innerException),
                new PropertyOrchestrationDependencyException(innerException),
                new PropertyOrchestrationServiceException(innerException)
            };
        }
    }
}
