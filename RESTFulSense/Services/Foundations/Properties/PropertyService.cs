// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using RESTFulSense.Brokers.Reflections;
using RESTFulSense.Models.Foundations.Properties;

namespace RESTFulSense.Services.Foundations.Properties
{
    internal partial class PropertyService : IPropertyService
    {
        private readonly IReflectionBroker reflectionBroker;

        public PropertyService(IReflectionBroker reflectionBroker) =>
            this.reflectionBroker = reflectionBroker;

        public IEnumerable<PropertyValue> RetrieveProperties<T>(T @object) where T : class =>
        TryCatch(() =>
        {
            ValidateObject(@object);
            return this.reflectionBroker.GetPropertyValues(@object);
        });
    }
}
