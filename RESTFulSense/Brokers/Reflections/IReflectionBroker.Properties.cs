// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Reflection;

namespace RESTFulSense.Brokers.Reflections
{
    public partial interface IReflectionBroker
    {
        IEnumerable<PropertyInfo> GetProperties(object @object);
    }
}
