// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using RESTFulSense.Models.Foundations.Attributes.Exceptions;
using RESTFulSense.Models.Foundations.Properties.Exceptions;

namespace RESTFulSense.Services.Foundations.Attributes
{
    internal partial class AttributeService : IAttributeService
    {
        private delegate TAttribute ReturningAttributeFunction<TAttribute>()
            where TAttribute : Attribute;

        private TAttribute TryCatch<TAttribute>(ReturningAttributeFunction<TAttribute> returningAttributeFunction)
            where TAttribute : Attribute
        {
            try
            {
                return returningAttributeFunction();
            }
            catch (ArgumentNullException argumentNullException)
            {
                var nullPropertyInfoException =
                    new NullPropertyInfoException(argumentNullException);

                var attributeValidationException =
                    new AttributeValidationException(nullPropertyInfoException);

                throw attributeValidationException;
            }
        }
    }
}
