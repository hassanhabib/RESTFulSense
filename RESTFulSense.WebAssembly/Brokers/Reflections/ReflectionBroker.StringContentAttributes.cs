// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using RESTFulSense.WebAssembly.Models.Attributes;

namespace RESTFulSense.WebAssembly.Brokers.Reflections
{
    internal partial class ReflectionBroker : IReflectionBroker
    {
        public RESTFulStringContentAttribute GetStringContentAttribute(PropertyInfo propertyInfo) =>
            GetCustomAttribute<RESTFulStringContentAttribute>(propertyInfo);
    }
}
