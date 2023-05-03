// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using RESTFulSense.Brokers.Properties;

namespace RESTFulSense.Services.Properties
{
    internal partial class PropertyService : IPropertyService
    {
        private readonly IPropertyBroker propertyBroker;

        public PropertyService(IPropertyBroker propertyBroker) =>
            this.propertyBroker = propertyBroker;

        public PropertyInfo[] RetrieveProperties(Type type) =>
            this.propertyBroker.GetProperties(type);
    }
}
