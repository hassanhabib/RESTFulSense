// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Properties.Exceptions
{
    public class PropertyDependencyValidationException : Xeption
    {
        public PropertyDependencyValidationException(Xeption innerException)
            : base(message: "Property dependency validation occurred, fix errors and try again.", innerException)
        { }
    }
}
