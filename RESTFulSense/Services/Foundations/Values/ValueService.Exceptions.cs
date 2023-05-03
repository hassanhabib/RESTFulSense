// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using RESTFulSense.Models.Foundations.Values.Exceptions;

namespace RESTFulSense.Services.Foundations.Values
{
    internal partial class ValueService
    {
        private delegate object ReturningObjectFunction();

        private object TryCatch(ReturningObjectFunction returningObjectFunction)
        {
            try
            {
                return returningObjectFunction();
            }
            catch (Exception exception)
            {
                var failedValueServiceException =
                    new FailedValueServiceException(exception);

                var valueServiceException =
                    new ValueServiceException(failedValueServiceException);

                throw valueServiceException;
            }
        }
    }
}
