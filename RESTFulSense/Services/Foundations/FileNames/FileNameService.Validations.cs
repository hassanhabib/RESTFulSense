// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Reflection;
using RESTFulSense.Models.Foundations.FileNames.Exceptions;

namespace RESTFulSense.Services.Foundations.FileNames
{
    internal partial class FileNameService
    {
        private static void ValidatePropertyInfo(PropertyInfo propertyInfo)
        {
            ValidateObjectNotNull(propertyInfo);
        }

        private static void ValidateObjectNotNull(PropertyInfo propertyInfo)
        {
            if (propertyInfo is null)
            {
                throw new NullPropertyInfoException();
            }
        }
    }
}
