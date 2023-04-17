// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Processings.Properties.Exceptions
{
    public class PropertyProcessingServiceException : Xeption
    {
        public PropertyProcessingServiceException(Exception innerException)
            : base(message: "Property processing service error occurred, contact support.",
                  innerException)
        { }
    }
}
