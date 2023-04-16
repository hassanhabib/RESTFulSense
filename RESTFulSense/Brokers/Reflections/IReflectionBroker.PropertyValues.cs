// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using RESTFulSense.Models.Foundations.Properties;

namespace RESTFulSense.Brokers.Reflections
{
    internal partial interface IReflectionBroker
    {
        IEnumerable<PropertyValue> GetPropertyValues<T>(T @object)
            where T : class;
    }
}
