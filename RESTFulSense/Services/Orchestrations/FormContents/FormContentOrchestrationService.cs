// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Net.Http;
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

        public MultipartFormDataContent ConvertToMultipartFormDataContent<T>(T @object) =>
            throw new System.NotImplementedException();
    }
}
