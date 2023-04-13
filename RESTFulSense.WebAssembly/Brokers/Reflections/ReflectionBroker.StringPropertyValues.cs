// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;

namespace RESTFulSense.WebAssembly.Brokers.Reflections
{
    internal partial class ReflectionBroker
    {
        public string GetStringPropertyValue(object @object, PropertyInfo property) =>
            this.GetPropertyValue<string>(@object, property);
    }
}
