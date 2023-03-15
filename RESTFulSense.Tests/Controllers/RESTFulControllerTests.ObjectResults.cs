// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using FluentAssertions;
using RESTFulSense.Models;
using Xunit;

namespace RESTFulSense.Tests.Controllers
{
    public partial class RESTFulControllerTests
    {
        [Fact]
        public void ShouldReturnCreatedObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new CreatedObjectResult(inputMessage);

            // when
            CreatedObjectResult actualResult =
                restfulController.Created(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnLockedObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new LockedObjectResult(inputMessage);

            // when
            LockedObjectResult actualResult =
                restfulController.Locked(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnBadGatewayObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new BadGatewayObjectResult(inputMessage);

            // when
            BadGatewayObjectResult actualResult =
                restfulController.BadGateway(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnExpectationFailedObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new ExpectationFailedObjectResult(inputMessage);

            // when
            ExpectationFailedObjectResult actualResult =
                restfulController.ExpectationFailed(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnFailedDependencyObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new FailedDependencyObjectResult(inputMessage);

            // when
            FailedDependencyObjectResult actualResult =
                restfulController.FailedDependency(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnGatewayTimeoutObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new GatewayTimeoutObjectResult(inputMessage);

            // when
            GatewayTimeoutObjectResult actualResult =
                restfulController.GatewayTimeout(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnGoneObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new GoneObjectResult(inputMessage);

            // when
            GoneObjectResult actualResult =
                restfulController.Gone(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnHttpVersionNotSupportedObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new HttpVersionNotSupportedObjectResult(inputMessage);

            // when
            HttpVersionNotSupportedObjectResult actualResult =
                restfulController.HttpVersionNotSupported(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnInsufficientStorageObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new InsufficientStorageObjectResult(inputMessage);

            // when
            InsufficientStorageObjectResult actualResult =
                restfulController.InsufficientStorage(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnInternalServerErrorObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new InternalServerErrorObjectResult(inputMessage);

            // when
            InternalServerErrorObjectResult actualResult =
                restfulController.InternalServerError(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnLengthRequiredObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new LengthRequiredObjectResult(inputMessage);

            // when
            LengthRequiredObjectResult actualResult =
                restfulController.LengthRequired(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnLoopDetectedObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new LoopDetectedObjectResult(inputMessage);

            // when
            LoopDetectedObjectResult actualResult =
                restfulController.LoopDetected(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnMethodNotAllowedObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new MethodNotAllowedObjectResult(inputMessage);

            // when
            MethodNotAllowedObjectResult actualResult =
                restfulController.MethodNotAllowed(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnMisdirectedRequestObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new MisdirectedRequestObjectResult(inputMessage);

            // when
            MisdirectedRequestObjectResult actualResult =
                restfulController.MisdirectedRequest(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnNetworkAuthenticationRequiredObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new NetworkAuthenticationRequiredObjectResult(inputMessage);

            // when
            NetworkAuthenticationRequiredObjectResult actualResult =
                restfulController.NetworkAuthenticationRequired(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnNotAcceptableObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new NotAcceptableObjectResult(inputMessage);

            // when
            NotAcceptableObjectResult actualResult =
                restfulController.NotAcceptable(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnNotExtendedObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new NotExtendedObjectResult(inputMessage);

            // when
            NotExtendedObjectResult actualResult =
                restfulController.NotExtended(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnNotImplementedObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new NotImplementedObjectResult(inputMessage);

            // when
            NotImplementedObjectResult actualResult =
                restfulController.NotImplemented(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnPaymentRequiredObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new PaymentRequiredObjectResult(inputMessage);

            // when
            PaymentRequiredObjectResult actualResult =
                restfulController.PaymentRequired(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnPreconditionFailedObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new PreconditionFailedObjectResult(inputMessage);

            // when
            PreconditionFailedObjectResult actualResult =
                restfulController.PreconditionFailed(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnPreconditionRequiredObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new PreconditionRequiredObjectResult(inputMessage);

            // when
            PreconditionRequiredObjectResult actualResult =
                restfulController.PreconditionRequired(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnProxyAuthenticationRequiredObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new ProxyAuthenticationRequiredObjectResult(inputMessage);

            // when
            ProxyAuthenticationRequiredObjectResult actualResult =
                restfulController.ProxyAuthenticationRequired(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnRequestedRangeNotSatisfiableObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new RequestedRangeNotSatisfiableObjectResult(inputMessage);

            // when
            RequestedRangeNotSatisfiableObjectResult actualResult =
                restfulController.RequestedRangeNotSatisfiable(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnRequestEntityTooLargeObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new RequestEntityTooLargeObjectResult(inputMessage);

            // when
            RequestEntityTooLargeObjectResult actualResult =
                restfulController.RequestEntityTooLarge(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnRequestHeaderFieldsTooLargeObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new RequestHeaderFieldsTooLargeObjectResult(inputMessage);

            // when
            RequestHeaderFieldsTooLargeObjectResult actualResult =
                restfulController.RequestHeaderFieldsTooLarge(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnRequestTimeoutObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new RequestTimeoutObjectResult(inputMessage);

            // when
            RequestTimeoutObjectResult actualResult =
                restfulController.RequestTimeout(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnRequestUriTooLongObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new RequestUriTooLongObjectResult(inputMessage);

            // when
            RequestUriTooLongObjectResult actualResult =
                restfulController.RequestUriTooLong(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnServiceUnavailableObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new ServiceUnavailableObjectResult(inputMessage);

            // when
            ServiceUnavailableObjectResult actualResult =
                restfulController.ServiceUnavailable(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnTooManyRequestsObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new TooManyRequestsObjectResult(inputMessage);

            // when
            TooManyRequestsObjectResult actualResult =
                restfulController.TooManyRequests(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnUnavailableForLegalReasonsObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new UnavailableForLegalReasonsObjectResult(inputMessage);

            // when
            UnavailableForLegalReasonsObjectResult actualResult =
                restfulController.UnavailableForLegalReasons(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnUpgradeRequiredObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new UpgradeRequiredObjectResult(inputMessage);

            // when
            UpgradeRequiredObjectResult actualResult =
                restfulController.UpgradeRequired(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnVariantAlsoNegotiatesObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new VariantAlsoNegotiatesObjectResult(inputMessage);

            // when
            VariantAlsoNegotiatesObjectResult actualResult =
                restfulController.VariantAlsoNegotiates(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ShouldReturnUnsupportedMediaTypeObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new UnsupportedMediaTypeObjectResult(inputMessage);

            // when
            UnsupportedMediaTypeObjectResult actualResult =
                restfulController.UnsupportedMediaTypeObjectResult(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }
    }
}