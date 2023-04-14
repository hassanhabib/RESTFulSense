// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using RESTFulSense.Models.Foundations.Properties.Exceptions;

namespace RESTFulSense.Services.Foundations.Properties
{
    internal partial class PropertyService
    {
        private static void ValidateObject(object @object)
        {
            ValidateObjectNotNull(@object);
        }

        private static void ValidateObjectNotNull(object @object)
        {
            if (@object is null)
            {
                throw new NullObjectException();
            }
        }
    }
}
