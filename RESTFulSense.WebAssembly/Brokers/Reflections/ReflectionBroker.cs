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

        private T GetPropertyValue<T>(object @object, PropertyInfo property) =>
            (T)property.GetValue(@object);
    }
}
