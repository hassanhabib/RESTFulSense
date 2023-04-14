// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using RESTFulSense.Models.Attributes;

namespace RESTFulSense.Services.Foundations.StringContents
{
    internal interface IStringContentService
    {
        RESTFulStringContentAttribute RetrieveStringContent(PropertyInfo propertyInfo);
    }
}
