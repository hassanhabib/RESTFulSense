// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Net.Http;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StringContents;
using RESTFulSense.Services.Foundations.StringContents;

namespace RESTFulSense.Services.Processings.StringContents
{
    internal partial class StringContentProcessingService : IStringContentProcessingService
    {
        private readonly IStringContentService stringContentService;

        public StringContentProcessingService(IStringContentService stringContentService) =>
            this.stringContentService = stringContentService;

        public IEnumerable<NamedStringContent> FilterStringContents(List<PropertyValue> propertyValues) =>
            throw new System.NotImplementedException();
    }
}
