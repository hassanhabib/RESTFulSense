// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Properties.Exceptions
{
    public class PropertyValidationException : Xeption
    {
        public PropertyValidationException(Xeption innerException)
            : base(message: "Property validation error occurred, fix errors and try again.",
                  innerException)
        { }
    }
}
