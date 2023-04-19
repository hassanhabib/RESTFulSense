// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using RESTFulSense.Models.Foundations.Properties;

namespace RESTFulSense.Services.Orchestrations.FormContents
{
    internal partial class FormContentOrchestrationService
    {
        private List<PropertyValue> RetrieveProperties<T>(T @object) where T : class =>
            this.propertyProcessingService.RetrieveProperties(@object).ToList();
    }
}
