// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Reflection;

namespace RESTFulSense.WebAssembly.Brokers.Reflections
{
    public partial class ReflectionBroker : IReflectionBroker
    {
        public IEnumerable<PropertyInfo> GetProperties(object @object) =>
            @object.GetType().GetProperties();
    }
}
