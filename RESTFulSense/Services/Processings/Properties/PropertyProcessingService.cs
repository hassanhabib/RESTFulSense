// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Services.Foundations.Properties;

namespace RESTFulSense.Services.Processings.Properties
{
    internal partial class PropertyProcessingService : IPropertyProcessingService
    {
        private readonly IPropertyService propertyService;

        public PropertyProcessingService(IPropertyService propertyService) =>
            this.propertyService = propertyService;

        public IEnumerable<PropertyValue> RetrieveProperties<T>(T @object)
            where T : class => TryCatch(() =>
        {
            return this.propertyService.RetrieveProperties<T>(@object);
        });
    }
}
