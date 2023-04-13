// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.IO;
using System.Reflection;

namespace RESTFulSense.Brokers.Reflections
{
    internal partial class ReflectionBroker
    {
        public Stream GetStreamPropertyValue(object @object, PropertyInfo property) =>
            this.GetPropertyValue<Stream>(@object, property);
    }
}
