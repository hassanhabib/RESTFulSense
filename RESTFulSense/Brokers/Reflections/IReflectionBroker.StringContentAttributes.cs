// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using RESTFulSense.Models.Attributes;

namespace RESTFulSense.Brokers.Reflections
{
    internal partial interface IReflectionBroker
    {
        RESTFulStringContentAttribute GetStringContentAttribute(PropertyInfo propertyInfo);
    }
}
