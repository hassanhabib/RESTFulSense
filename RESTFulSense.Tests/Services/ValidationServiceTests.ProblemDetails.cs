// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
        [Fact]
        private async Task ShouldThrowHttpResponseBadRequestDetailsIfResponseStatusCodeWasBadRequestAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage badRequestResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.BadRequest, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(badRequestResponseMessage);

            // then
            HttpResponseBadRequestException httpResponseBadRequestException =
                await Assert.ThrowsAsync<HttpResponseBadRequestException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseBadRequestException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseBadRequestException.Data)
            {
                httpResponseBadRequestException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseUnauthorizedDetailsIfResponseStatusCodeWasUnauthorizedAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage unauthorizedResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.Unauthorized, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(unauthorizedResponseMessage);

            // then
            HttpResponseUnauthorizedException httpResponseUnauthorizedException =
                await Assert.ThrowsAsync<HttpResponseUnauthorizedException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseUnauthorizedException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseUnauthorizedException.Data)
            {
                httpResponseUnauthorizedException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponsePaymentRequiredDetailsIfResponseStatusCodeWasPaymentRequiredAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage paymentRequiredResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.PaymentRequired, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(paymentRequiredResponseMessage);

            // then
            HttpResponsePaymentRequiredException httpResponsePaymentRequiredException =
                await Assert.ThrowsAsync<HttpResponsePaymentRequiredException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponsePaymentRequiredException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponsePaymentRequiredException.Data)
            {
                httpResponsePaymentRequiredException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseForbiddenDetailsIfResponseStatusCodeWasForbiddenAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage forbiddenResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.Forbidden, content);

            // when 
            ValueTask validateHttpResponseTask =
               ValidationService.ValidateHttpResponseAsync(forbiddenResponseMessage);

            // then
            HttpResponseForbiddenException httpResponseForbiddenException =
                await Assert.ThrowsAsync<HttpResponseForbiddenException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseForbiddenException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseForbiddenException.Data)
            {
                httpResponseForbiddenException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseNotFoundDetailsIfResponseStatusCodeWasNotFoundAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage notFoundResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.NotFound, content);

            notFoundResponseMessage.Content.Headers.Add("Content-Type", "text/json");

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(notFoundResponseMessage);

            // then
            HttpResponseNotFoundException httpResponseNotFoundException =
                await Assert.ThrowsAsync<HttpResponseNotFoundException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseNotFoundException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseNotFoundException.Data)
            {
                httpResponseNotFoundException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowMethodNotAllowedDetailsIfResponseStatusCodeWasMethodNotAllowedAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage methodNotAllowedResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.MethodNotAllowed, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(methodNotAllowedResponseMessage);

            // then
            HttpResponseMethodNotAllowedException httpResponseMethodNotAllowedException =
                await Assert.ThrowsAsync<HttpResponseMethodNotAllowedException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseMethodNotAllowedException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseMethodNotAllowedException.Data)
            {
                httpResponseMethodNotAllowedException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseNotAcceptableDetailsIfResponseStatusCodeWasNotAcceptableAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage notAcceptableResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.NotAcceptable, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(notAcceptableResponseMessage);

            // then
            HttpResponseNotAcceptableException httpResponseNotAcceptableException =
                await Assert.ThrowsAsync<HttpResponseNotAcceptableException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseNotAcceptableException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseNotAcceptableException.Data)
            {
                httpResponseNotAcceptableException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task
            ShouldThrowProxyAuthenticationRequiredDetailsIfResponseStatusCodeWasProxyAuthenticationRequiredAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage proxyAuthenticationRequiredResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.ProxyAuthenticationRequired, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(proxyAuthenticationRequiredResponseMessage);

            // then
            HttpResponseProxyAuthenticationRequiredException httpResponseProxyAuthenticationRequiredException =
                await Assert.ThrowsAsync<HttpResponseProxyAuthenticationRequiredException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseProxyAuthenticationRequiredException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseProxyAuthenticationRequiredException.Data)
            {
                httpResponseProxyAuthenticationRequiredException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseRequestTimeoutDetailsIfResponseStatusCodeWasRequestTimeoutAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            var requestTimeoutResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.RequestTimeout, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(requestTimeoutResponseMessage);

            // then
            HttpResponseRequestTimeoutException httpResponseRequestTimeoutException =
                await Assert.ThrowsAsync<HttpResponseRequestTimeoutException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseRequestTimeoutException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseRequestTimeoutException.Data)
            {
                httpResponseRequestTimeoutException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseConflictDetailsIfResponseStatusCodeWasConflictAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            var conflictResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.Conflict, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(conflictResponseMessage);

            // then
            HttpResponseConflictException httpResponseConflictException =
                await Assert.ThrowsAsync<HttpResponseConflictException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseConflictException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseConflictException.Data)
            {
                httpResponseConflictException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseGoneDetailsIfResponseStatusCodeWasGoneAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            var goneResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.Gone, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(goneResponseMessage);

            // then
            HttpResponseGoneException httpResponseGoneException =
                await Assert.ThrowsAsync<HttpResponseGoneException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseGoneException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseGoneException.Data)
            {
                httpResponseGoneException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseLengthRequiredDetailsIfResponseStatusCodeWasLengthRequiredAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            var lengthRequiredResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.LengthRequired, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(lengthRequiredResponseMessage);

            // then
            HttpResponseLengthRequiredException httpResponseLengthRequiredException =
                await Assert.ThrowsAsync<HttpResponseLengthRequiredException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseLengthRequiredException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseLengthRequiredException.Data)
            {
                httpResponseLengthRequiredException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowPreconditionFailedDetailsIfResponseStatusCodeWasPreconditionFailedAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            var preconditionFailedResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.PreconditionFailed, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(preconditionFailedResponseMessage);

            // then
            HttpResponsePreconditionFailedException httpResponsePreconditionFailedException =
                await Assert.ThrowsAsync<HttpResponsePreconditionFailedException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponsePreconditionFailedException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponsePreconditionFailedException.Data)
            {
                httpResponsePreconditionFailedException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowRequestEntityTooLargeDetailsIfResponseStatusCodeWasRequestEntityTooLargeAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage requestEntityTooLargeResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.RequestEntityTooLarge, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(requestEntityTooLargeResponseMessage);

            // then
            HttpResponseRequestEntityTooLargeException httpResponseRequestEntityTooLargeException =
                await Assert.ThrowsAsync<HttpResponseRequestEntityTooLargeException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseRequestEntityTooLargeException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseRequestEntityTooLargeException.Data)
            {
                httpResponseRequestEntityTooLargeException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowRequestUriTooLongDetailsIfResponseStatusCodeWasRequestUriTooLongAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage requestUriTooLongResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.RequestUriTooLong, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(requestUriTooLongResponseMessage);

            // then
            HttpResponseRequestUriTooLongException httpResponseRequestUriTooLongException =
                await Assert.ThrowsAsync<HttpResponseRequestUriTooLongException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseRequestUriTooLongException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseRequestUriTooLongException.Data)
            {
                httpResponseRequestUriTooLongException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowUnsupportedMediaTypeDetailsIfResponseStatusCodeWasUnsupportedMediaTypeAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage unsupportedMediaTypeResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.UnsupportedMediaType, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(unsupportedMediaTypeResponseMessage);

            // then
            HttpResponseUnsupportedMediaTypeException httpResponseUnsupportedMediaTypeException =
                await Assert.ThrowsAsync<HttpResponseUnsupportedMediaTypeException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseUnsupportedMediaTypeException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseUnsupportedMediaTypeException.Data)
            {
                httpResponseUnsupportedMediaTypeException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowRequestedRangeNotSatisfiableDetailsIfCodeWasRequestedRangeNotSatisfiableAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage requestedRangeNotSatisfiableResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.RequestedRangeNotSatisfiable, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(requestedRangeNotSatisfiableResponseMessage);

            // then
            HttpResponseRequestedRangeNotSatisfiableException httpResponseRequestedRangeNotSatisfiableException =
                await Assert.ThrowsAsync<HttpResponseRequestedRangeNotSatisfiableException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseRequestedRangeNotSatisfiableException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseRequestedRangeNotSatisfiableException.Data)
            {
                httpResponseRequestedRangeNotSatisfiableException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowExpectationFailedDetailsIfResponseStatusCodeWasExpectationFailedAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage expectationFailedResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.ExpectationFailed, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(expectationFailedResponseMessage);

            // then
            HttpResponseExpectationFailedException httpResponseExpectationFailedException =
                await Assert.ThrowsAsync<HttpResponseExpectationFailedException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseExpectationFailedException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseExpectationFailedException.Data)
            {
                httpResponseExpectationFailedException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowMisdirectedRequestDetailsIfResponseStatusCodeWasMisdirectedRequestAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage misdirectedRequestResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.MisdirectedRequest, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(misdirectedRequestResponseMessage);

            // then
            HttpResponseMisdirectedRequestException httpResponseMisdirectedRequestException =
                await Assert.ThrowsAsync<HttpResponseMisdirectedRequestException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseMisdirectedRequestException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseMisdirectedRequestException.Data)
            {
                httpResponseMisdirectedRequestException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowUnprocessableEntityDetailsIfResponseStatusCodeWasUnprocessableEntityAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage unprocessableEntityResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.UnprocessableEntity, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(unprocessableEntityResponseMessage);

            // then
            HttpResponseUnprocessableEntityException httpResponseUnprocessableEntityException =
                await Assert.ThrowsAsync<HttpResponseUnprocessableEntityException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseUnprocessableEntityException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseUnprocessableEntityException.Data)
            {
                httpResponseUnprocessableEntityException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseLockedDetailsIfResponseStatusCodeWasLockedAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage lockedResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.Locked, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(lockedResponseMessage);

            // then
            HttpResponseLockedException httpResponseLockedException =
                await Assert.ThrowsAsync<HttpResponseLockedException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseLockedException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseLockedException.Data)
            {
                httpResponseLockedException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowFailedDependencyDetailsIfResponseStatusCodeWasFailedDependencyAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage failedDependencyResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.FailedDependency, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(failedDependencyResponseMessage);

            // then
            HttpResponseFailedDependencyException httpResponseFailedDependencyException =
                await Assert.ThrowsAsync<HttpResponseFailedDependencyException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseFailedDependencyException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseFailedDependencyException.Data)
            {
                httpResponseFailedDependencyException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseUpgradeRequiredDetailsIfResponseStatusCodeWasUpgradeRequiredAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage upgradeRequiredResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.UpgradeRequired, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(upgradeRequiredResponseMessage);

            // then
            HttpResponseUpgradeRequiredException httpResponseUpgradeRequiredException =
                await Assert.ThrowsAsync<HttpResponseUpgradeRequiredException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseUpgradeRequiredException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseUpgradeRequiredException.Data)
            {
                httpResponseUpgradeRequiredException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowPreconditionRequiredDetailsIfResponseStatusCodeWasPreconditionRequiredAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage preconditionRequiredResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.PreconditionRequired, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(preconditionRequiredResponseMessage);

            // then
            HttpResponsePreconditionRequiredException httpResponsePreconditionRequiredException =
                await Assert.ThrowsAsync<HttpResponsePreconditionRequiredException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponsePreconditionRequiredException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponsePreconditionRequiredException.Data)
            {
                httpResponsePreconditionRequiredException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseTooManyRequestsDetailsIfResponseStatusCodeWasTooManyRequestsAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage tooManyRequestsResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.TooManyRequests, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(tooManyRequestsResponseMessage);

            // then
            HttpResponseTooManyRequestsException httpResponseTooManyRequestsException =
                await Assert.ThrowsAsync<HttpResponseTooManyRequestsException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseTooManyRequestsException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseTooManyRequestsException.Data)
            {
                httpResponseTooManyRequestsException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowRequestHeaderFieldsTooLargeDetailsIfCodeWasRequestHeaderFieldsTooLargeAsync()
        {
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage requestHeaderFieldsTooLargeResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.RequestHeaderFieldsTooLarge, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(requestHeaderFieldsTooLargeResponseMessage);

            // then
            HttpResponseRequestHeaderFieldsTooLargeException httpResponseRequestHeaderFieldsTooLargeException =
                await Assert.ThrowsAsync<HttpResponseRequestHeaderFieldsTooLargeException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseRequestHeaderFieldsTooLargeException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseRequestHeaderFieldsTooLargeException.Data)
            {
                httpResponseRequestHeaderFieldsTooLargeException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowUnavailableForLegalReasonsDetailsIfStatusCodeIsUnavailableForLegalReasonsAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage unavailableForLegalReasonsResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.UnavailableForLegalReasons, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(unavailableForLegalReasonsResponseMessage);

            // then
            HttpResponseUnavailableForLegalReasonsException httpResponseUnavailableForLegalReasonsException =
                await Assert.ThrowsAsync<HttpResponseUnavailableForLegalReasonsException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseUnavailableForLegalReasonsException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseUnavailableForLegalReasonsException.Data)
            {
                httpResponseUnavailableForLegalReasonsException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowInternalServerErrorDetailsIfResponseStatusCodeWasInternalServerErrorAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage internalServerErrorResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.InternalServerError, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(internalServerErrorResponseMessage);

            // then
            HttpResponseInternalServerErrorException httpResponseInternalServerErrorException =
                await Assert.ThrowsAsync<HttpResponseInternalServerErrorException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseInternalServerErrorException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseInternalServerErrorException.Data)
            {
                httpResponseInternalServerErrorException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseNotImplementedDetailsIfResponseStatusCodeWasNotImplementedAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage notImplementedResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.NotImplemented, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(notImplementedResponseMessage);

            // then
            HttpResponseNotImplementedException httpResponseNotImplementedException =
                await Assert.ThrowsAsync<HttpResponseNotImplementedException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseNotImplementedException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseNotImplementedException.Data)
            {
                httpResponseNotImplementedException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseBadGatewayDetailsIfResponseStatusCodeWasBadGatewayAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage badGatewayResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.BadGateway, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(badGatewayResponseMessage);

            // then
            HttpResponseBadGatewayException httpResponseBadGatewayException =
                await Assert.ThrowsAsync<HttpResponseBadGatewayException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseBadGatewayException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseBadGatewayException.Data)
            {
                httpResponseBadGatewayException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowServiceUnavailableDetailsIfResponseStatusCodeWasServiceUnavailableAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage serviceUnavailableResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.ServiceUnavailable, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(serviceUnavailableResponseMessage);

            // then
            HttpResponseServiceUnavailableException httpResponseServiceUnavailableException =
                await Assert.ThrowsAsync<HttpResponseServiceUnavailableException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseServiceUnavailableException.Message
                  .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseServiceUnavailableException.Data)
            {
                httpResponseServiceUnavailableException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseGatewayTimeoutDetailsIfResponseStatusCodeWasGatewayTimeoutAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage gatewayTimeoutResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.GatewayTimeout, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(gatewayTimeoutResponseMessage);

            // then
            HttpResponseGatewayTimeoutException httpResponseGatewayTimeoutException =
                await Assert.ThrowsAsync<HttpResponseGatewayTimeoutException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseGatewayTimeoutException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseGatewayTimeoutException.Data)
            {
                httpResponseGatewayTimeoutException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpVersionNotSupportedDetailsIfStatusCodeWasHttpVersionNotSupportedAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage httpVersionNotSupportedResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.HttpVersionNotSupported, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(httpVersionNotSupportedResponseMessage);

            // then
            HttpResponseHttpVersionNotSupportedException httpResponseHttpVersionNotSupportedException =
                await Assert.ThrowsAsync<HttpResponseHttpVersionNotSupportedException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseHttpVersionNotSupportedException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseHttpVersionNotSupportedException.Data)
            {
                httpResponseHttpVersionNotSupportedException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowVariantAlsoNegotiatesDetailsIfResponseStatusCodeWasVariantAlsoNegotiatesAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage variantAlsoNegotiatesResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.VariantAlsoNegotiates, content);

            // when
            ValueTask validateHttpResponseTask =
               ValidationService.ValidateHttpResponseAsync(variantAlsoNegotiatesResponseMessage);

            // then
            HttpResponseVariantAlsoNegotiatesException httpResponseVariantAlsoNegotiatesException =
                await Assert.ThrowsAsync<HttpResponseVariantAlsoNegotiatesException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseVariantAlsoNegotiatesException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseVariantAlsoNegotiatesException.Data)
            {
                httpResponseVariantAlsoNegotiatesException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowInsufficientStorageDetailsIfResponseStatusCodeWasInsufficientStorageAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage insufficientStorageResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.InsufficientStorage, content);

            // when
            ValueTask validateHttpResponseTask =
               ValidationService.ValidateHttpResponseAsync(insufficientStorageResponseMessage);

            // then
            HttpResponseInsufficientStorageException httpResponseInsufficientStorageException =
                await Assert.ThrowsAsync<HttpResponseInsufficientStorageException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseInsufficientStorageException.Message
                .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseInsufficientStorageException.Data)
            {
                httpResponseInsufficientStorageException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseLoopDetectedDetailIfResponseStatusCodeWasLoopDetectedAsync()
        {
            // given
            ValidationProblemDetails randomProblemDetails = CreateRandomProblemDetails();
            string randomContent = MapDetailsToString(problemDetails: randomProblemDetails);
            string content = randomContent;
            string expectedExceptionMessage = content;

            HttpResponseMessage loopDetectedResponseMessage =
                CreateHttpResponseMessage(HttpStatusCode.LoopDetected, content);

            // when
            ValueTask validateHttpResponseTask =
                ValidationService.ValidateHttpResponseAsync(loopDetectedResponseMessage);

            // then
            HttpResponseLoopDetectedException httpResponseLoopDetectedException =
                await Assert.ThrowsAsync<HttpResponseLoopDetectedException>(() =>
                    validateHttpResponseTask.AsTask());

            httpResponseLoopDetectedException.Message
              .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseLoopDetectedException.Data)
            {
                httpResponseLoopDetectedException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task ShouldThrowHttpResponseNotExtendedDetailsIfResponseStatusCodeWasNotExtendedAsync()
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

            httpResponseNotExtendedException.Message
               .Should().BeEquivalentTo(randomProblemDetails.Title);

            foreach (DictionaryEntry entry in httpResponseNotExtendedException.Data)
            {
                httpResponseNotExtendedException.Data[entry.Key].Should().BeEquivalentTo(
                    randomProblemDetails.Errors[entry.Key.ToString()]);
            }
        }

        [Fact]
        private async Task
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
