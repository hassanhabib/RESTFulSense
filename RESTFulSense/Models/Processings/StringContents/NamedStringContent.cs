// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Net.Http;

namespace RESTFulSense.Models.Processings.StringContents
{
    internal class NamedStringContent
    {
        public string Name { get; set; }
        public StringContent StringContent { get; set; }
    }
}
