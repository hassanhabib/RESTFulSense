// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;
using RESTFulSense.Services.Orchestrations.Forms;
using RESTFulSense.Services.Orchestrations.Properties;

namespace RESTFulSense.Services.Coordinations.Forms
{
    internal partial class FormCoordinationService : IFormCoordinationService
    {
        private readonly IPropertyOrchestrationService propertyOrchestrationService;
        private readonly IFormOrchestrationService formOrchestrationService;

        public FormCoordinationService(
            IPropertyOrchestrationService propertyOrchestrationService,
            IFormOrchestrationService formOrchestrationService)
        {
            this.propertyOrchestrationService = propertyOrchestrationService;
            this.formOrchestrationService = formOrchestrationService;
        }

        public MultipartFormDataContent ConvertToMultipartFormDataContent<T>(T @object) where T : class =>
            throw new System.NotImplementedException();
    }
}
