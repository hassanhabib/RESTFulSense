// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using RESTFulSense.Models.Attributes;

namespace RESTFulSense.Services.Foundations.StreamContents
{
    internal interface IStreamContentService
    {
        RESTFulFileContentStreamAttribute RetrieveStreamContent(PropertyInfo propertyInfo);
    }
}
