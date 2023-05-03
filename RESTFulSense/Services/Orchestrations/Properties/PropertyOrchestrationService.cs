// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using RESTFulSense.Models.Orchestrations.Properties;
using RESTFulSense.Services.Foundations.Properties;
using RESTFulSense.Services.Foundations.Types;

namespace RESTFulSense.Services.Orchestrations.Properties
{
    internal partial class PropertyOrchestrationService : IPropertyOrchestrationService
    {
        private readonly ITypeService typeService;
        private readonly IPropertyService propertyService;

        public PropertyOrchestrationService(ITypeService typeService, IPropertyService propertyService)
        {
            this.typeService = typeService;
            this.propertyService = propertyService;
        }

        public PropertyModel RetrieveProperties(PropertyModel propertyModel) =>
            throw new System.NotImplementedException();
    }
}
