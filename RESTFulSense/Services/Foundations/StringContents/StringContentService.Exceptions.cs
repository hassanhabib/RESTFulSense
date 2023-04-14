// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.StringContents.Exceptions;

namespace RESTFulSense.Services.Foundations.StringContents
{
    internal partial class StringContentService : IStringContentService
    {
        private delegate RESTFulStringContentAttribute ReturningRESTFulStringContentAttributeFunction();

        private static RESTFulStringContentAttribute 
            TryCatch(ReturningRESTFulStringContentAttributeFunction returningRESTFulStringContentAttributeFunction)
        {
            try
            {
                return returningRESTFulStringContentAttributeFunction();
            }
            catch (NullPropertyInfoException nullPropertyInfoException)
            {
                throw new StringContentValidationException(nullPropertyInfoException);
            }
        }
    }
}
