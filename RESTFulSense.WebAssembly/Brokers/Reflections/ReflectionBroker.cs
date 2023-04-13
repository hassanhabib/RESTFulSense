// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using System;

namespace RESTFulSense.WebAssembly.Brokers.Reflections
{
    internal partial class ReflectionBroker : IReflectionBroker
    {
        private TAttribute GetCustomAttribute<TAttribute>(PropertyInfo property)
            where TAttribute : Attribute =>
            property.GetCustomAttribute<TAttribute>();

        private TValue GetPropertyValue<TValue>(object @object, PropertyInfo property) =>
            (TValue)property.GetValue(@object);
    }
}
