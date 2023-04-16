// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using RESTFulSense.Models.Foundations.StreamContents.Exceptions;

namespace RESTFulSense.Services.Foundations.StreamContents
{
    internal partial class StreamContentService
    {
        private static void ValidateObjectNotNull(PropertyInfo propertyInfo)
        {
            if (propertyInfo is null)
            {
                throw new NullPropertyInfoException();
            }
        }
    }
}
