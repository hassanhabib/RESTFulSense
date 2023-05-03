// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;

namespace RESTFulSense.Brokers.Values
{
    internal class ValueBroker : IValueBroker
    {
        public object GetPropertyValue(object @object, PropertyInfo propertyInfo) =>
            propertyInfo.GetValue(@object);
    }
}
