// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;

namespace RESTFulSense.Services.Foundations.Values
{
    internal interface IValueService
    {
        object RetrievePropertyValue(object @object, PropertyInfo propertyInfo);
    }
}
