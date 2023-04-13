// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;

namespace RESTFulSense.Brokers.Reflections
{
    internal class ReflectionBroker : IReflectionBroker
    {
        public IEnumerable<PropertyInfo> GetProperties(object @object) =>
            @object.GetType().GetProperties();

        public TAttribute GetCustomAttribute<TAttribute>(PropertyInfo property)
            where TAttribute : Attribute =>
            property.GetCustomAttribute<TAttribute>();

        public TResult GetPropertyValue<TResult>(object @object, PropertyInfo property) =>
            (TResult)property.GetValue(@object);
    }
}
