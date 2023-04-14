// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RESTFulSense.Models.Foundations.Properties;

namespace RESTFulSense.Brokers.Reflections
{
    internal partial class ReflectionBroker : IReflectionBroker
    {
        public IEnumerable<PropertyValue> GetPropertyValues<T>(T @object)
            where T : class
        {
            var properties = @object.GetType()
                .GetProperties();

            return properties.Select(propertyInfo => GetPropertyValue(@object, propertyInfo));
        }

        private static PropertyValue GetPropertyValue<T>(T @object, PropertyInfo propertyInfo)
            where T : class
        {
            return new PropertyValue
            {
                PropertyInfo = propertyInfo,
                Value = propertyInfo.GetValue(@object)
            };
        }
    }
}
