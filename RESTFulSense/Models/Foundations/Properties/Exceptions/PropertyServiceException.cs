// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Properties.Exceptions
{
    public class PropertyServiceException : Xeption
    {
        public PropertyServiceException(Xeption innerException)
            : base(message: "Property service error occurred, contact support.",
                  innerException)
        { }
    }
}
