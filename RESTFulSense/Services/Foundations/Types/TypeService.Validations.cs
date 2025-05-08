// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using RESTFulSense.Models.Foundations.Types.Exceptions;

namespace RESTFulSense.Services.Foundations.Types
{
    internal partial class TypeService : ITypeService
    {
        private void ValidateObjectIsNotNullOnRetrieve(object @object)
        {
            if (@object is null)
            {
                throw new NullObjectException(
                    message: "Object is null.");
            }
        }
    }
}
