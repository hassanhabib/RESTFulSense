// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using RESTFulSense.WebAssembly.Models.Attributes;

namespace RESTFulSense.WebAssembly.Brokers.Reflections
{
    internal partial interface IReflectionBroker
    {
        RESTFulFileContentNameAttribute GetFileContentNameAttribute(PropertyInfo propertyInfo);
    }
}
