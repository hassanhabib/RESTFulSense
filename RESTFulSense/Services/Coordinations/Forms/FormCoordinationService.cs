// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Net.Http;
using RESTFulSense.Models.Orchestrations.Forms;
using RESTFulSense.Models.Orchestrations.Properties;
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

        public MultipartFormDataContent ConvertToMultipartFormDataContent<T>(T @object) where T : class
        {
            PropertyModel propertyModel = new PropertyModel
            {
                Object = @object
            };

            PropertyModel returnPropertyModel = this.propertyOrchestrationService.RetrieveProperties(propertyModel);

            FormModel formModel = new FormModel
            {
                MultipartFormDataContent = new MultipartFormDataContent(),
                Object = @object,
                Properties = returnPropertyModel.Properties
            };

            FormModel returnedFormModel = this.formOrchestrationService.BuildFormModel(formModel);

            return returnedFormModel.MultipartFormDataContent;
        }
    }
}
