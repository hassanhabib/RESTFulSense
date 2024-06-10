// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using RESTFulSense.Models.Foundations.Properties.Exceptions;

namespace RESTFulSense.Services.Properties
{
    internal partial class PropertyService
    {
        private void ValidateTypeIsNotNullOnRetrieveProperties(Type type)
        {
            if (type is null)
            {
                throw new NullTypeException(
                    message: "Type is null.");
            }
        }
    }
}
