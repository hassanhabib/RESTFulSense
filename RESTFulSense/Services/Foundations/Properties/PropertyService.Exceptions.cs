// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Foundations.Properties.Exceptions;

namespace RESTFulSense.Services.Foundations.Properties
{
    internal partial class PropertyService
    {
        private delegate IEnumerable<PropertyValue> ReturningPropertyValuesFunction();

        private static IEnumerable<PropertyValue> TryCatch(ReturningPropertyValuesFunction returningPropertyValuesFunction)
        {
            try
            {
                return returningPropertyValuesFunction();
            }
            catch (NullObjectException nullObjectException)
            {
                throw new PropertyValidationException(nullObjectException);
            }
        }
    }
}
