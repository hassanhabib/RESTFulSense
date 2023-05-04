// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace RESTFulSense.Models.Coordinations.Forms.Exceptions
{
    public class FailedFormCoordinationServiceException : Xeption
    {
        public FailedFormCoordinationServiceException(Exception innerException)
            : base(message: "Form coordination service error occurred, contact support.", innerException)
        { }
    }
}
