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
    internal interface IReflectionBroker
    {
        IEnumerable<PropertyInfo> GetProperties(object @object);
        TAttribute GetCustomAttribute<TAttribute>(PropertyInfo property) where TAttribute : Attribute;
        TResult GetPropertyValue<TResult>(object @object, PropertyInfo property);
    }
}
