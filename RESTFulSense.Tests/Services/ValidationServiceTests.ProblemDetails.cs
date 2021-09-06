// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RESTFulSense.Exceptions;
using RESTFulSense.Services;
using Tynamix.ObjectFiller;
using Xunit;

namespace RESTFulSense.Tests.Services
{
    public partial class ValidationServiceTests
    {
        //        [Fact]
        //        public async Task ShouldThrowHttpResponseBadRequestExceptionIfResponseStatusCodeWasBadRequestAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage badRequestResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.BadRequest, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(badRequestResponseMessage);

        //            // then
        //            HttpResponseBadRequestException httpResponseBadRequestException =
        //                await Assert.ThrowsAsync<HttpResponseBadRequestException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseBadRequestException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseUnauthorizedExceptionIfResponseStatusCodeWasUnauthorizedAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage unauthorizedResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.Unauthorized, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(unauthorizedResponseMessage);

        //            // then
        //            HttpResponseUnauthorizedException httpResponseUnauthorizedException =
        //                await Assert.ThrowsAsync<HttpResponseUnauthorizedException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseUnauthorizedException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponsePaymentRequiredExceptionIfResponseStatusCodeWasPaymentRequiredAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage paymentRequiredResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.PaymentRequired, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(paymentRequiredResponseMessage);

        //            // then
        //            HttpResponsePaymentRequiredException httpResponsePaymentRequiredException =
        //                await Assert.ThrowsAsync<HttpResponsePaymentRequiredException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponsePaymentRequiredException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseForbiddenExceptionIfResponseStatusCodeWasForbiddenAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage forbiddenResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.Forbidden, content);

        //            // when 
        //            ValueTask validateHttpResponseTask =
        //               ValidationService.ValidateHttpResponseAsync(forbiddenResponseMessage);

        //            // then
        //            HttpResponseForbiddenException httpResponseForbiddenException =
        //                await Assert.ThrowsAsync<HttpResponseForbiddenException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseForbiddenException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseNotFoundExceptionIfResponseStatusCodeWasNotFoundAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage notFoundResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.NotFound, content);

        //            notFoundResponseMessage.Content.Headers.Add("Content-Type", "text/json");

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(notFoundResponseMessage);

        //            // then
        //            HttpResponseNotFoundException httpResponseNotFoundException =
        //                await Assert.ThrowsAsync<HttpResponseNotFoundException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseNotFoundException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseUrlNotFoundExceptionIfResponseStatusCodeWasNotFoundAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage notFoundResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.NotFound, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(notFoundResponseMessage);

        //            // then
        //            HttpResponseUrlNotFoundException httpResponseNotFoundException =
        //                await Assert.ThrowsAsync<HttpResponseUrlNotFoundException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseNotFoundException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowMethodNotAllowedExceptionIfResponseStatusCodeWasMethodNotAllowedAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage methodNotAllowedResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.MethodNotAllowed, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(methodNotAllowedResponseMessage);

        //            // then
        //            HttpResponseMethodNotAllowedException httpResponseMethodNotAllowedException =
        //                await Assert.ThrowsAsync<HttpResponseMethodNotAllowedException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseMethodNotAllowedException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseNotAcceptableExceptionIfResponseStatusCodeWasNotAcceptableAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage notAcceptableResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.NotAcceptable, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(notAcceptableResponseMessage);

        //            // then
        //            HttpResponseNotAcceptableException httpResponseNotAcceptableException =
        //                await Assert.ThrowsAsync<HttpResponseNotAcceptableException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseNotAcceptableException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task
        //            ShouldThrowProxyAuthenticationRequiredExceptionIfResponseStatusCodeWasProxyAuthenticationRequiredAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage proxyAuthenticationRequiredResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.ProxyAuthenticationRequired, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(proxyAuthenticationRequiredResponseMessage);

        //            // then
        //            HttpResponseProxyAuthenticationRequiredException httpResponseProxyAuthenticationRequiredException =
        //                await Assert.ThrowsAsync<HttpResponseProxyAuthenticationRequiredException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseProxyAuthenticationRequiredException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseRequestTimeoutExceptionIfResponseStatusCodeWasRequestTimeoutAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;
        //            var requestTimeoutResponseMessage = CreateHttpResponseMessage(HttpStatusCode.RequestTimeout, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(requestTimeoutResponseMessage);

        //            // then
        //            HttpResponseRequestTimeoutException httpResponseRequestTimeoutException =
        //                await Assert.ThrowsAsync<HttpResponseRequestTimeoutException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseRequestTimeoutException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseConflictExceptionIfResponseStatusCodeWasConflictAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;
        //            var conflictResponseMessage = CreateHttpResponseMessage(HttpStatusCode.Conflict, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(conflictResponseMessage);

        //            // then
        //            HttpResponseConflictException httpResponseConflictException =
        //                await Assert.ThrowsAsync<HttpResponseConflictException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseConflictException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseGoneExceptionIfResponseStatusCodeWasGoneAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;
        //            var goneResponseMessage = CreateHttpResponseMessage(HttpStatusCode.Gone, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(goneResponseMessage);

        //            // then
        //            HttpResponseGoneException httpResponseGoneException =
        //                await Assert.ThrowsAsync<HttpResponseGoneException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseGoneException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseLengthRequiredExceptionIfResponseStatusCodeWasLengthRequiredAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;
        //            var lengthRequiredResponseMessage = CreateHttpResponseMessage(HttpStatusCode.LengthRequired, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(lengthRequiredResponseMessage);

        //            // then
        //            HttpResponseLengthRequiredException httpResponseLengthRequiredException =
        //                await Assert.ThrowsAsync<HttpResponseLengthRequiredException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseLengthRequiredException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowPreconditionFailedExceptionIfResponseStatusCodeWasPreconditionFailedAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            var preconditionFailedResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.PreconditionFailed, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(preconditionFailedResponseMessage);

        //            // then
        //            HttpResponsePreconditionFailedException httpResponsePreconditionFailedException =
        //                await Assert.ThrowsAsync<HttpResponsePreconditionFailedException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponsePreconditionFailedException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowRequestEntityTooLargeExceptionIfResponseStatusCodeWasRequestEntityTooLargeAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage requestEntityTooLargeResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.RequestEntityTooLarge, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(requestEntityTooLargeResponseMessage);

        //            // then
        //            HttpResponseRequestEntityTooLargeException httpResponseRequestEntityTooLargeException =
        //                await Assert.ThrowsAsync<HttpResponseRequestEntityTooLargeException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseRequestEntityTooLargeException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowRequestUriTooLongExceptionIfResponseStatusCodeWasRequestUriTooLongAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage requestUriTooLongResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.RequestUriTooLong, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(requestUriTooLongResponseMessage);

        //            // then
        //            HttpResponseRequestUriTooLongException httpResponseRequestUriTooLongException =
        //                await Assert.ThrowsAsync<HttpResponseRequestUriTooLongException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseRequestUriTooLongException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowUnsupportedMediaTypeExceptionIfResponseStatusCodeWasUnsupportedMediaTypeAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage unsupportedMediaTypeResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.UnsupportedMediaType, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(unsupportedMediaTypeResponseMessage);

        //            // then
        //            HttpResponseUnsupportedMediaTypeException httpResponseUnsupportedMediaTypeException =
        //                await Assert.ThrowsAsync<HttpResponseUnsupportedMediaTypeException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseUnsupportedMediaTypeException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowRequestedRangeNotSatisfiableExceptionIfCodeWasRequestedRangeNotSatisfiableAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage requestedRangeNotSatisfiableResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.RequestedRangeNotSatisfiable, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(requestedRangeNotSatisfiableResponseMessage);

        //            // then
        //            HttpResponseRequestedRangeNotSatisfiableException httpResponseRequestedRangeNotSatisfiableException =
        //                await Assert.ThrowsAsync<HttpResponseRequestedRangeNotSatisfiableException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseRequestedRangeNotSatisfiableException.Message
        //                .Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowExpectationFailedExceptionIfResponseStatusCodeWasExpectationFailedAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage expectationFailedResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.ExpectationFailed, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(expectationFailedResponseMessage);

        //            // then
        //            HttpResponseExpectationFailedException httpResponseExpectationFailedException =
        //                await Assert.ThrowsAsync<HttpResponseExpectationFailedException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseExpectationFailedException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowMisdirectedRequestExceptionIfResponseStatusCodeWasMisdirectedRequestAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage misdirectedRequestResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.MisdirectedRequest, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(misdirectedRequestResponseMessage);

        //            // then
        //            HttpResponseMisdirectedRequestException httpResponseMisdirectedRequestException =
        //                await Assert.ThrowsAsync<HttpResponseMisdirectedRequestException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseMisdirectedRequestException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowUnprocessableEntityExceptionIfResponseStatusCodeWasUnprocessableEntityAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage unprocessableEntityResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.UnprocessableEntity, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(unprocessableEntityResponseMessage);

        //            // then
        //            HttpResponseUnprocessableEntityException httpResponseUnprocessableEntityException =
        //                await Assert.ThrowsAsync<HttpResponseUnprocessableEntityException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseUnprocessableEntityException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseLockedExceptionIfResponseStatusCodeWasLockedAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage lockedResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.Locked, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(lockedResponseMessage);

        //            // then
        //            HttpResponseLockedException httpResponseLockedException =
        //                await Assert.ThrowsAsync<HttpResponseLockedException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseLockedException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowFailedDependencyExceptionIfResponseStatusCodeWasFailedDependencyAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage failedDependencyResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.FailedDependency, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(failedDependencyResponseMessage);

        //            // then
        //            HttpResponseFailedDependencyException httpResponseFailedDependencyException =
        //                await Assert.ThrowsAsync<HttpResponseFailedDependencyException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseFailedDependencyException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseUpgradeRequiredExceptionIfResponseStatusCodeWasUpgradeRequiredAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage upgradeRequiredResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.UpgradeRequired, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(upgradeRequiredResponseMessage);

        //            // then
        //            HttpResponseUpgradeRequiredException httpResponseUpgradeRequiredException =
        //                await Assert.ThrowsAsync<HttpResponseUpgradeRequiredException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseUpgradeRequiredException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowPreconditionRequiredExceptionIfResponseStatusCodeWasPreconditionRequiredAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage preconditionRequiredResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.PreconditionRequired, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(preconditionRequiredResponseMessage);

        //            // then
        //            HttpResponsePreconditionRequiredException httpResponsePreconditionRequiredException =
        //                await Assert.ThrowsAsync<HttpResponsePreconditionRequiredException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponsePreconditionRequiredException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseTooManyRequestsExceptionIfResponseStatusCodeWasTooManyRequestsAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage tooManyRequestsResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.TooManyRequests, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(tooManyRequestsResponseMessage);

        //            // then
        //            HttpResponseTooManyRequestsException httpResponseTooManyRequestsException =
        //                await Assert.ThrowsAsync<HttpResponseTooManyRequestsException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseTooManyRequestsException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowRequestHeaderFieldsTooLargeExceptionIfCodeWasRequestHeaderFieldsTooLargeAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage requestHeaderFieldsTooLargeResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.RequestHeaderFieldsTooLarge, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(requestHeaderFieldsTooLargeResponseMessage);

        //            // then
        //            HttpResponseRequestHeaderFieldsTooLargeException httpResponseRequestHeaderFieldsTooLargeException =
        //                await Assert.ThrowsAsync<HttpResponseRequestHeaderFieldsTooLargeException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseRequestHeaderFieldsTooLargeException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowUnavailableForLegalReasonsExceptionIfStatusCodeIsUnavailableForLegalReasonsAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage unavailableForLegalReasonsResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.UnavailableForLegalReasons, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(unavailableForLegalReasonsResponseMessage);

        //            // then
        //            HttpResponseUnavailableForLegalReasonsException httpResponseUnavailableForLegalReasonsException =
        //                await Assert.ThrowsAsync<HttpResponseUnavailableForLegalReasonsException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseUnavailableForLegalReasonsException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowInternalServerErrorExceptionIfResponseStatusCodeWasInternalServerErrorAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage internalServerErrorResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.InternalServerError, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(internalServerErrorResponseMessage);

        //            // then
        //            HttpResponseInternalServerErrorException httpResponseInternalServerErrorException =
        //                await Assert.ThrowsAsync<HttpResponseInternalServerErrorException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseInternalServerErrorException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseNotImplementedExceptionIfResponseStatusCodeWasNotImplementedAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage notImplementedResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.NotImplemented, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(notImplementedResponseMessage);

        //            // then
        //            HttpResponseNotImplementedException httpResponseNotImplementedException =
        //                await Assert.ThrowsAsync<HttpResponseNotImplementedException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseNotImplementedException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseBadGatewayExceptionIfResponseStatusCodeWasBadGatewayAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage badGatewayResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.BadGateway, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(badGatewayResponseMessage);

        //            // then
        //            HttpResponseBadGatewayException httpResponseBadGatewayException =
        //                await Assert.ThrowsAsync<HttpResponseBadGatewayException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseBadGatewayException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowServiceUnavailableExceptionIfResponseStatusCodeWasServiceUnavailableAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage serviceUnavailableResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.ServiceUnavailable, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(serviceUnavailableResponseMessage);

        //            // then
        //            HttpResponseServiceUnavailableException httpResponseServiceUnavailableException =
        //                await Assert.ThrowsAsync<HttpResponseServiceUnavailableException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseServiceUnavailableException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseGatewayTimeoutExceptionIfResponseStatusCodeWasGatewayTimeoutAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage gatewayTimeoutResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.GatewayTimeout, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(gatewayTimeoutResponseMessage);

        //            // then
        //            HttpResponseGatewayTimeoutException httpResponseGatewayTimeoutException =
        //                await Assert.ThrowsAsync<HttpResponseGatewayTimeoutException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseGatewayTimeoutException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpVersionNotSupportedExceptionIfStatusCodeWasHttpVersionNotSupportedAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage httpVersionNotSupportedResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.HttpVersionNotSupported, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(httpVersionNotSupportedResponseMessage);

        //            // then
        //            HttpResponseHttpVersionNotSupportedException httpResponseHttpVersionNotSupportedException =
        //                await Assert.ThrowsAsync<HttpResponseHttpVersionNotSupportedException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseHttpVersionNotSupportedException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowVariantAlsoNegotiatesExceptionIfResponseStatusCodeWasVariantAlsoNegotiatesAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage variantAlsoNegotiatesResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.VariantAlsoNegotiates, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //               ValidationService.ValidateHttpResponseAsync(variantAlsoNegotiatesResponseMessage);

        //            // then
        //            HttpResponseVariantAlsoNegotiatesException httpResponseVariantAlsoNegotiatesException =
        //                await Assert.ThrowsAsync<HttpResponseVariantAlsoNegotiatesException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseVariantAlsoNegotiatesException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowInsufficientStorageExceptionIfResponseStatusCodeWasInsufficientStorageAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage insufficientStorageResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.InsufficientStorage, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //               ValidationService.ValidateHttpResponseAsync(insufficientStorageResponseMessage);

        //            // then
        //            HttpResponseInsufficientStorageException httpResponseInsufficientStorageException =
        //                await Assert.ThrowsAsync<HttpResponseInsufficientStorageException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseInsufficientStorageException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        //        [Fact]
        //        public async Task ShouldThrowHttpResponseLoopDetectedExceptionIfResponseStatusCodeWasLoopDetectedAsync()
        //        {
        //            // given
        //            string randomContent = GetRandomContent();
        //            string content = randomContent;
        //            string expectedExceptionMessage = content;

        //            HttpResponseMessage loopDetectedResponseMessage =
        //                CreateHttpResponseMessage(HttpStatusCode.LoopDetected, content);

        //            // when
        //            ValueTask validateHttpResponseTask =
        //                ValidationService.ValidateHttpResponseAsync(loopDetectedResponseMessage);

        //            // then
        //            HttpResponseLoopDetectedException httpResponseLoopDetectedException =
        //                await Assert.ThrowsAsync<HttpResponseLoopDetectedException>(() =>
        //                    validateHttpResponseTask.AsTask());

        //            httpResponseLoopDetectedException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        //        }

        [Fact]
        public async Task ShouldThrowHttpResponseNotExtendedDetailsIfResponseStatusCodeWasNotExtendedAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage notExtendedResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.NotExtended, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(notExtendedResponseMessage);

            // then
            HttpResponseNotExtendedException httpResponseNotExtendedException =
                await Assert.ThrowsAsync<HttpResponseNotExtendedException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseNotExtendedException.Message.Should().BeEquivalentTo(expectedExceptionMessage);
        }

        [Fact]
        public async Task
            ShouldThrowNetworkAuthenticationRequiredDetailsIfStatusCodeWasNetworkAuthenticationRequiredAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage networkAuthenticationRequiredResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.NetworkAuthenticationRequired, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(networkAuthenticationRequiredResponseMessage);

            // then
            HttpResponseNetworkAuthenticationRequiredException httpResponseNetworkAuthenticationRequiredException =
                await Assert.ThrowsAsync<HttpResponseNetworkAuthenticationRequiredException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseNetworkAuthenticationRequiredException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseNetworkAuthenticationRequiredException.Data)
            {
                httpResponseNetworkAuthenticationRequiredException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        private static string MapDetailsToString(ValidationProblemDetails problemDetails) =>
            JsonConvert.SerializeObject(problemDetails);

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static ValidationProblemDetails CreateRandomProblemDetails()
        {
            var randomValidationProblemDetails = new ValidationProblemDetails
            {
                Title = GetRandomString(),
                Type = GetRandomString()
            };

            foreach (KeyValuePair<string, string[]> entry in CreateRandomErrorDictionary())
            {
                randomValidationProblemDetails.Errors.Add(entry.Key, entry.Value);
            }

            return randomValidationProblemDetails;
        }

        private static Dictionary<string, string[]> CreateRandomErrorDictionary()
        {
            var filler = new Filler<Dictionary<string, string[]>>();

            filler.Setup()
                .DictionaryItemCount(maxCount: 10);

            return filler.Create();
        }
    }
}
