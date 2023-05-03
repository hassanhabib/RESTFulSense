// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;

namespace RESTFulSense.Brokers.Values
{
    internal interface IValueBroker
    {
        object GetPropertyValue(object @object, PropertyInfo propertyInfo);
    }
}
