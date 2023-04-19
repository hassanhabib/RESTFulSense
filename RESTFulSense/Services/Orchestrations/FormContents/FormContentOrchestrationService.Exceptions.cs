// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Net.Http;
using RESTFulSense.Models.Orchestrations.FormContents.Exceptions;
using RESTFulSense.Models.Processings.FileNames.Exceptions;
using RESTFulSense.Models.Processings.Properties.Exceptions;
using RESTFulSense.Models.Processings.StreamContents.Exceptions;
using RESTFulSense.Models.Processings.StringContents.Exceptions;

namespace RESTFulSense.Services.Orchestrations.FormContents
{
    internal partial class FormContentOrchestrationService
    {
        private delegate MultipartFormDataContent ReturningMultipartFormDataContentFunction();

        private static MultipartFormDataContent TryCatch(
            ReturningMultipartFormDataContentFunction returningMultipartFormDataContentFunction)
        {
            try
            {
                return returningMultipartFormDataContentFunction();
            }
            catch (PropertyProcessingDependencyValidationException propertyProcessingDependencyValidationException)
            {
                throw new FormContentOrchestrationDependencyValidationException(
                    propertyProcessingDependencyValidationException);
            }
            catch (StringContentProcessingDependencyValidationException stringContentProcessingDependencyValidationException)
            {
                throw new FormContentOrchestrationDependencyValidationException(
                    stringContentProcessingDependencyValidationException);
            }
            catch (StreamContentProcessingDependencyValidationException streamContentProcessingDependencyValidationException)
            {
                throw new FormContentOrchestrationDependencyValidationException(
                    streamContentProcessingDependencyValidationException);
            }
            catch (FileNameProcessingDependencyValidationException fileNameProcessingDependencyValidationException)
            {
                throw new FormContentOrchestrationDependencyValidationException(
                    fileNameProcessingDependencyValidationException);
            }
            catch (PropertyProcessingDependencyException propertyProcessingDependencyException)
            {
                throw new FormContentOrchestrationDependencyException(propertyProcessingDependencyException);
            }
            catch (StringContentProcessingDependencyException stringContentProcessingDependencyException)
            {
                throw new FormContentOrchestrationDependencyException(stringContentProcessingDependencyException);
            }
            catch (StreamContentProcessingDependencyException streamContentProcessingDependencyException)
            {
                throw new FormContentOrchestrationDependencyException(streamContentProcessingDependencyException);
            }
            catch (FileNameProcessingDependencyException fileNameProcessingDependencyValidationException)
            {
                throw new FormContentOrchestrationDependencyException(fileNameProcessingDependencyValidationException);
            }
            catch (Exception exception)
            {
                var failedFormContentOrchestrationServiceException =
                    new FailedFormContentOrchestrationServiceException(exception);

                throw new FormContentOrchestrationServiceException(failedFormContentOrchestrationServiceException);
            }
        }
    }
}
