// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StreamContents;
using RESTFulSense.Services.Foundations.StreamContents;

namespace RESTFulSense.Services.Processings.StreamContents
{
    internal class StreamContentProcessingService : IStreamContentProcessingService
    {
        private readonly IStreamContentService streamContentService;

        public StreamContentProcessingService(IStreamContentService streamContentService) =>
            this.streamContentService = streamContentService;

        public IEnumerable<NamedStreamContent> FilterStringContents(List<PropertyValue> propertyValues) =>
            throw new System.NotImplementedException();
    }
}
