// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Foundations.Properties.Exceptions;
using RESTFulSense.Models.Processings.Properties.Exceptions;
using System.Collections.Generic;

namespace RESTFulSense.Services.Processings.Properties
{
    internal partial class PropertyProcessingService
    {
        private delegate IEnumerable<PropertyValue> ReturningPropertyValuesFunction();

        private static IEnumerable<PropertyValue> TryCatch(
            ReturningPropertyValuesFunction returningPropertyValuesFunction)
        {
            try
            {
                return returningPropertyValuesFunction();
            }
            catch (PropertyValidationException propertyValidationException)
            {
                throw new PropertyProcessingDependencyValidationException(propertyValidationException);
            }
            catch (PropertyServiceException propertyServiceException)
            {
                throw new PropertyProcessingDependencyException(propertyServiceException);
            }
        }
    }
}
