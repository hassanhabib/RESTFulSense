// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Moq;
using RESTFulSense.Brokers.Reflections;
using RESTFulSense.Models.Attributes;
using RESTFulSense.Services.Foundations.StreamContents;
using Tynamix.ObjectFiller;

namespace RESTFulSense.Tests.Services.Foundations.StreamContents
{
    public partial class StreamContentServiceTests
    {
        private readonly Mock<IReflectionBroker> reflectionBrokerMock;
        private readonly IStreamContentService streamContentService;

        public StreamContentServiceTests()
        {
            reflectionBrokerMock = new Mock<IReflectionBroker>();
            streamContentService = new StreamContentService(reflectionBrokerMock.Object);
        }

        private RESTFulFileContentStreamAttribute CreateRandomStreamContent() =>
            new RESTFulFileContentStreamAttribute(name: CreateRandomString());

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();
    }
}
