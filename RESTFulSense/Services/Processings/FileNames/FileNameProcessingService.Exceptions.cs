﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using RESTFulSense.Models.Foundations.FileNames.Exceptions;
using RESTFulSense.Models.Processings.FileNames.Exceptions;

namespace RESTFulSense.Services.Processings.FileNames
{
    internal partial class FileNameProcessingService
    {
        private delegate void ReturningVoidFileNameFunction();

        private static void TryCatch(
            ReturningVoidFileNameFunction returningVoidFileNameFunction)
        {
            try
            {
                returningVoidFileNameFunction();
            }
            catch(FileNameValidationException fileNameValidationException)
            {
                throw new FileNameProcessingDependencyValidationException(fileNameValidationException);
            }
            catch(FileNameServiceException fileNameServiceException)
            {
                throw new FileNameProcessingDependencyException(fileNameServiceException);
            }
            catch(Exception exception)
            {
                var failedFileNameProcessingServiceException =
                    new FailedFileNameProcessingServiceException(exception);

                throw new FileNameProcessingServiceException(failedFileNameProcessingServiceException);
            }
        }
    }
}
