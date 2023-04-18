// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StreamContents;
using RESTFulSense.Services.Foundations.StreamContents;

namespace RESTFulSense.Services.Processings.StreamContents
{
    internal partial class StreamContentProcessingService : IStreamContentProcessingService
    {
        private readonly IStreamContentService streamContentService;

        public StreamContentProcessingService(IStreamContentService streamContentService) =>
            this.streamContentService = streamContentService;

        public IEnumerable<NamedStreamContent> FilterStreamContents(List<PropertyValue> propertyValues) =>
        TryCatch(() =>
        {
            var namedStreamContents = new List<NamedStreamContent>();

            foreach (var propertyValue in propertyValues)
            {
                RESTFulFileContentStreamAttribute rESTFulFileContentStreamAttribute =
                    this.streamContentService.RetrieveStreamContent(propertyValue.PropertyInfo);

                if (rESTFulFileContentStreamAttribute != null)
                {
                    NamedStreamContent namedStreamContent = new NamedStreamContent
                    {
                        Name = rESTFulFileContentStreamAttribute.Name,
                        StreamContent = new StreamContent((Stream)propertyValue.Value)
                    };

                    namedStreamContents.Add(namedStreamContent);
                }
            }

            return namedStreamContents;
        });
    }
}
