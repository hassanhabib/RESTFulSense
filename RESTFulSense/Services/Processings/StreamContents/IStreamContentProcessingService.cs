// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StreamContents;

namespace RESTFulSense.Services.Processings.StreamContents
{
    internal interface IStreamContentProcessingService
    {
        IEnumerable<NamedStreamContent> FilterStringContents(List<PropertyValue> propertyValues);
    }
}
