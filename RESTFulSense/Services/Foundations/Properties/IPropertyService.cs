// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using RESTFulSense.Models.Foundations.PropertyValues;

namespace RESTFulSense.Services.Foundations.Properties
{
    internal interface IPropertyService
    {
        IEnumerable<PropertyValue> RetrieveProperties<T>(T @object) where T : class;
    }
}
