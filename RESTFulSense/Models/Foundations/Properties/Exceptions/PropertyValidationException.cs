// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Properties.Exceptions
{
    internal class PropertyValidationException : Xeption
    {
        public PropertyValidationException(Xeption innerException)
            : base(
                message: "Property validation errors occurred, fix errors and try again.",
                innerException)
        { }
    }
}