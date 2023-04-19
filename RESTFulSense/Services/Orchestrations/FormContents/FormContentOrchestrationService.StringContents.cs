// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StringContents;

namespace RESTFulSense.Services.Orchestrations.FormContents
{
    internal partial class FormContentOrchestrationService
    {
        private List<NamedStringContent> FilterStringContents(List<PropertyValue> propertyValues) =>
            this.stringContentProcessingService.FilterStringContents(propertyValues).ToList();
    }
}
