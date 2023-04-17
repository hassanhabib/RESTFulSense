// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using RESTFulSense.Models.Foundations.Properties;
using RESTFulSense.Models.Processings.StringContents;
using System.Collections.Generic;

namespace RESTFulSense.Services.Processings.StringContents
{
    internal interface IStringContentProcessingService
    {
        IEnumerable<NamedStringContent> FilterStringContents(List<PropertyValue> propertyValues);
    }
}
