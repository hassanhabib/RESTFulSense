// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using RESTFulSense.Models.Foundations.StringContents.Exceptions;

namespace RESTFulSense.Services.Foundations.StringContents
{
    internal partial class StringContentService : IStringContentService
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
