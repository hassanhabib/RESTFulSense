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

        public IEnumerable<NamedStringContent> FilterStringContents(List<PropertyValue> propertyValues)
        {
            foreach (var propertyValue in propertyValues)
            {
                RESTFulStringContentAttribute rESTFulStringContentAttribute =
                    this.stringContentService.RetrieveStringContent(propertyValue.PropertyInfo);

                if (rESTFulStringContentAttribute != null)
                {
                    NamedStringContent namedStringContent = new NamedStringContent
                    {
                        Name = rESTFulStringContentAttribute.Name,
                        StringContent = new StringContent((string)propertyValue.Value)
                    };

                    yield return namedStringContent;
                }
            }
        }
    }
}
