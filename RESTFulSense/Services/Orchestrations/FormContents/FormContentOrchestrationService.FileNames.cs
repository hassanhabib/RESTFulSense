// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StreamContents;

namespace RESTFulSense.Services.Orchestrations.FormContents
{
    internal partial class FormContentOrchestrationService
    {
        private void UpdateFileNames(
            IEnumerable<NamedStreamContent> namedStreamContents,
            IEnumerable<PropertyValue> propertyValues) =>
            this.fileNameProcessingService.UpdateFileNames(namedStreamContents, propertyValues);
    }
}
