// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.FileNames.Exceptions
{
    public class NullPropertyInfoException : Xeption
    {
        public NullPropertyInfoException()
            : base(message: "PropertyInfo is null.")
        { }
    }
}
