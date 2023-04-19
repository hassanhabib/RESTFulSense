// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StreamContents;
using RESTFulSense.Models.Processings.StringContents;
using RESTFulSense.Services.Processings.FileNames;
using RESTFulSense.Services.Processings.Properties;
using RESTFulSense.Services.Processings.StreamContents;
using RESTFulSense.Services.Processings.StringContents;

namespace RESTFulSense.Services.Orchestrations.FormContents
{
    internal partial class FormContentOrchestrationService : IFormContentOrchestrationService
    {
        private readonly IPropertyProcessingService propertyProcessingService;
        private readonly IStringContentProcessingService stringContentProcessingService;
        private readonly IStreamContentProcessingService streamContentProcessingService;
        private readonly IFileNameProcessingService fileNameProcessingService;

        public FormContentOrchestrationService(
            IPropertyProcessingService propertyProcessingService,
            IStringContentProcessingService stringContentProcessingService,
            IStreamContentProcessingService streamContentProcessingService,
            IFileNameProcessingService fileNameProcessingService)
        {
            this.propertyProcessingService = propertyProcessingService;
            this.stringContentProcessingService = stringContentProcessingService;
            this.streamContentProcessingService = streamContentProcessingService;
            this.fileNameProcessingService = fileNameProcessingService;
        }

        public MultipartFormDataContent ConvertToMultipartFormDataContent<T>(T @object)
            where T : class
        {
            List<PropertyValue> propertyValues = this.RetrieveProperties(@object);

            List<NamedStringContent> namedStringContents = this.FilterStringContents(propertyValues);

            List<NamedStreamContent> namedStreamContents = this.FilterStreamContents(propertyValues);

            this.UpdateFileNames(namedStreamContents, propertyValues);

            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();

            foreach (NamedStringContent namedStringContent in namedStringContents)
            {
                multipartFormDataContent.Add(namedStringContent.StringContent, namedStringContent.Name);
            }

            foreach (NamedStreamContent namedStreamContent in namedStreamContents)
            {
                if (String.IsNullOrWhiteSpace(namedStreamContent.FileName))
                {
                    multipartFormDataContent
                        .Add(namedStreamContent.StreamContent, namedStreamContent.Name);
                }
                else
                {
                    multipartFormDataContent
                        .Add(namedStreamContent.StreamContent, namedStreamContent.Name, namedStreamContent.FileName);
                }
            }

            return multipartFormDataContent;
        }
    }
}
