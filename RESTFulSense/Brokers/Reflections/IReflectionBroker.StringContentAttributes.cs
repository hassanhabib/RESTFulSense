// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using RESTFulSense.Models.Attributes;
using System.Reflection;

namespace RESTFulSense.Brokers.Reflections
{
    public partial interface IReflectionBroker
    {
        RESTFulStringContentAttribute GetStringContentAttribute(PropertyInfo propertyInfo);
    }
}
