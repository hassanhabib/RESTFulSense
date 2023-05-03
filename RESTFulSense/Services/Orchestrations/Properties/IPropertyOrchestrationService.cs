// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using RESTFulSense.Models.Orchestrations.Properties;

namespace RESTFulSense.Services.Orchestrations.Properties
{
    internal interface IPropertyOrchestrationService
    {
        PropertyModel RetrieveProperties(PropertyModel propertyModel);
    }
}
