// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using RESTFulSense.Models.Orchestrations.Forms;
using RESTFulSense.Services.Foundations.Attributes;
using RESTFulSense.Services.Foundations.Forms;
using RESTFulSense.Services.Foundations.Values;

namespace RESTFulSense.Services.Orchestrations.Forms
{
    internal partial class FormOrchestrationService : IFormOrchestrationService
    {
        private readonly IAttributeService attributeService;
        private readonly IValueService valueService;
        private readonly IFormService formService;

        public FormOrchestrationService(
            IAttributeService attributeService,
            IValueService valueService,
            IFormService formService)
        {
            this.attributeService = attributeService;
            this.valueService = valueService;
            this.formService = formService;
        }

        public FormModel BuildFormModel(FormModel formModel) =>
            throw new System.NotImplementedException();
    }
}
