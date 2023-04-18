// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Net.Http;

namespace RESTFulSense.Models.Processings.StreamContents
{
    internal class NamedStreamContent
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public StreamContent StreamContent { get; set; }
    }
}
