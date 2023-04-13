// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Reflection;

namespace RESTFulSense.WebAssembly.Brokers.Reflections
{
    internal partial interface IReflectionBroker
    {
        IEnumerable<PropertyInfo> GetProperties(object @object);
    }
}
