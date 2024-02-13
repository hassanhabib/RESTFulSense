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
        private void ShouldReturnCreatedObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new CreatedObjectResult(inputMessage);

            // when
            CreatedObjectResult actualResult =
                this.restfulController.Created(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnLockedObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new LockedObjectResult(inputMessage);

            // when
            LockedObjectResult actualResult =
                this.restfulController.Locked(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnBadGatewayObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new BadGatewayObjectResult(inputMessage);

            // when
            BadGatewayObjectResult actualResult =
                this.restfulController.BadGateway(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnExpectationFailedObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new ExpectationFailedObjectResult(inputMessage);

            // when
            ExpectationFailedObjectResult actualResult =
                this.restfulController.ExpectationFailed(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnFailedDependencyObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new FailedDependencyObjectResult(inputMessage);

            // when
            FailedDependencyObjectResult actualResult =
                this.restfulController.FailedDependency(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnGatewayTimeoutObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new GatewayTimeoutObjectResult(inputMessage);

            // when
            GatewayTimeoutObjectResult actualResult =
                this.restfulController.GatewayTimeout(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnGoneObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new GoneObjectResult(inputMessage);

            // when
            GoneObjectResult actualResult =
                this.restfulController.Gone(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnHttpVersionNotSupportedObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new HttpVersionNotSupportedObjectResult(inputMessage);

            // when
            HttpVersionNotSupportedObjectResult actualResult =
                this.restfulController.HttpVersionNotSupported(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnInsufficientStorageObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new InsufficientStorageObjectResult(inputMessage);

            // when
            InsufficientStorageObjectResult actualResult =
                this.restfulController.InsufficientStorage(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnInternalServerErrorObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new InternalServerErrorObjectResult(inputMessage);

            // when
            InternalServerErrorObjectResult actualResult =
                this.restfulController.InternalServerError(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnLengthRequiredObjectResult()
        {
            // given 
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new LengthRequiredObjectResult(inputMessage);

            // when
            LengthRequiredObjectResult actualResult =
                this.restfulController.LengthRequired(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnLoopDetectedObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new LoopDetectedObjectResult(inputMessage);

            // when
            LoopDetectedObjectResult actualResult =
                this.restfulController.LoopDetected(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnMethodNotAllowedObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new MethodNotAllowedObjectResult(inputMessage);

            // when
            MethodNotAllowedObjectResult actualResult =
                this.restfulController.MethodNotAllowed(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnMisdirectedRequestObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new MisdirectedRequestObjectResult(inputMessage);

            // when
            MisdirectedRequestObjectResult actualResult =
                this.restfulController.MisdirectedRequest(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnNetworkAuthenticationRequiredObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new NetworkAuthenticationRequiredObjectResult(inputMessage);

            // when
            NetworkAuthenticationRequiredObjectResult actualResult =
                this.restfulController.NetworkAuthenticationRequired(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnNotAcceptableObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new NotAcceptableObjectResult(inputMessage);

            // when
            NotAcceptableObjectResult actualResult =
                this.restfulController.NotAcceptable(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnNotExtendedObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new NotExtendedObjectResult(inputMessage);

            // when
            NotExtendedObjectResult actualResult =
                this.restfulController.NotExtended(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnNotImplementedObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new NotImplementedObjectResult(inputMessage);

            // when
            NotImplementedObjectResult actualResult =
                this.restfulController.NotImplemented(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnPaymentRequiredObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new PaymentRequiredObjectResult(inputMessage);

            // when
            PaymentRequiredObjectResult actualResult =
                this.restfulController.PaymentRequired(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnPreconditionFailedObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new PreconditionFailedObjectResult(inputMessage);

            // when
            PreconditionFailedObjectResult actualResult =
                this.restfulController.PreconditionFailed(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnPreconditionRequiredObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new PreconditionRequiredObjectResult(inputMessage);

            // when
            PreconditionRequiredObjectResult actualResult =
                this.restfulController.PreconditionRequired(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnProxyAuthenticationRequiredObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new ProxyAuthenticationRequiredObjectResult(inputMessage);

            // when
            ProxyAuthenticationRequiredObjectResult actualResult =
                this.restfulController.ProxyAuthenticationRequired(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnRequestedRangeNotSatisfiableObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new RequestedRangeNotSatisfiableObjectResult(inputMessage);

            // when
            RequestedRangeNotSatisfiableObjectResult actualResult =
                this.restfulController.RequestedRangeNotSatisfiable(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnRequestEntityTooLargeObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new RequestEntityTooLargeObjectResult(inputMessage);

            // when
            RequestEntityTooLargeObjectResult actualResult =
                this.restfulController.RequestEntityTooLarge(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnRequestHeaderFieldsTooLargeObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new RequestHeaderFieldsTooLargeObjectResult(inputMessage);

            // when
            RequestHeaderFieldsTooLargeObjectResult actualResult =
                this.restfulController.RequestHeaderFieldsTooLarge(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnRequestTimeoutObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new RequestTimeoutObjectResult(inputMessage);

            // when
            RequestTimeoutObjectResult actualResult =
                this.restfulController.RequestTimeout(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnRequestUriTooLongObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new RequestUriTooLongObjectResult(inputMessage);

            // when
            RequestUriTooLongObjectResult actualResult =
                this.restfulController.RequestUriTooLong(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnServiceUnavailableObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new ServiceUnavailableObjectResult(inputMessage);

            // when
            ServiceUnavailableObjectResult actualResult =
                this.restfulController.ServiceUnavailable(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnTooManyRequestsObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new TooManyRequestsObjectResult(inputMessage);

            // when
            TooManyRequestsObjectResult actualResult =
                this.restfulController.TooManyRequests(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnUnavailableForLegalReasonsObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new UnavailableForLegalReasonsObjectResult(inputMessage);

            // when
            UnavailableForLegalReasonsObjectResult actualResult =
                this.restfulController.UnavailableForLegalReasons(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnUpgradeRequiredObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new UpgradeRequiredObjectResult(inputMessage);

            // when
            UpgradeRequiredObjectResult actualResult =
                this.restfulController.UpgradeRequired(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnVariantAlsoNegotiatesObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new VariantAlsoNegotiatesObjectResult(inputMessage);

            // when
            VariantAlsoNegotiatesObjectResult actualResult =
                this.restfulController.VariantAlsoNegotiates(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        private void ShouldReturnUnsupportedMediaTypeObjectResult()
        {
            // given
            string randomMessage = GetRandomMessage();
            string inputMessage = randomMessage;
            var expectedResult = new UnsupportedMediaTypeObjectResult(inputMessage);

            // when
            UnsupportedMediaTypeObjectResult actualResult =
                this.restfulController.UnsupportedMediaTypeObjectResult(inputMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedResult);
        }
    }
}