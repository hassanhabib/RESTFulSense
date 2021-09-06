// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RESTFulSense.Exceptions;

namespace RESTFulSense.Services
{
    public class ValidationService
    {
        public async static ValueTask ValidateHttpResponseAsync(HttpResponseMessage httpResponseMessage)
        {
            string content = await httpResponseMessage.Content.ReadAsStringAsync();
            bool isProblemDetailContent = IsProblemDetail(content);

            switch (isProblemDetailContent)
            {
                case false when httpResponseMessage.StatusCode == HttpStatusCode.BadRequest:
                    throw new HttpResponseBadRequestException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized:
                    throw new HttpResponseUnauthorizedException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.PaymentRequired:
                    throw new HttpResponsePaymentRequiredException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.Forbidden:
                    throw new HttpResponseForbiddenException(httpResponseMessage, content);

                case false when NotFoundWithNoContent(httpResponseMessage):
                    throw new HttpResponseUrlNotFoundException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.NotFound:
                    throw new HttpResponseNotFoundException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.MethodNotAllowed:
                    throw new HttpResponseMethodNotAllowedException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.NotAcceptable:
                    throw new HttpResponseNotAcceptableException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.ProxyAuthenticationRequired:
                    throw new HttpResponseProxyAuthenticationRequiredException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.RequestTimeout:
                    throw new HttpResponseRequestTimeoutException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.Conflict:
                    throw new HttpResponseConflictException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.Gone:
                    throw new HttpResponseGoneException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.LengthRequired:
                    throw new HttpResponseLengthRequiredException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.PreconditionFailed:
                    throw new HttpResponsePreconditionFailedException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.RequestEntityTooLarge:
                    throw new HttpResponseRequestEntityTooLargeException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.RequestUriTooLong:
                    throw new HttpResponseRequestUriTooLongException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.UnsupportedMediaType:
                    throw new HttpResponseUnsupportedMediaTypeException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.RequestedRangeNotSatisfiable:
                    throw new HttpResponseRequestedRangeNotSatisfiableException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.ExpectationFailed:
                    throw new HttpResponseExpectationFailedException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.MisdirectedRequest:
                    throw new HttpResponseMisdirectedRequestException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.UnprocessableEntity:
                    throw new HttpResponseUnprocessableEntityException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.Locked:
                    throw new HttpResponseLockedException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.FailedDependency:
                    throw new HttpResponseFailedDependencyException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.UpgradeRequired:
                    throw new HttpResponseUpgradeRequiredException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.PreconditionRequired:
                    throw new HttpResponsePreconditionRequiredException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.TooManyRequests:
                    throw new HttpResponseTooManyRequestsException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.RequestHeaderFieldsTooLarge:
                    throw new HttpResponseRequestHeaderFieldsTooLargeException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.UnavailableForLegalReasons:
                    throw new HttpResponseUnavailableForLegalReasonsException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError:
                    throw new HttpResponseInternalServerErrorException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.NotImplemented:
                    throw new HttpResponseNotImplementedException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.BadGateway:
                    throw new HttpResponseBadGatewayException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.ServiceUnavailable:
                    throw new HttpResponseServiceUnavailableException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.GatewayTimeout:
                    throw new HttpResponseGatewayTimeoutException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.HttpVersionNotSupported:
                    throw new HttpResponseHttpVersionNotSupportedException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.VariantAlsoNegotiates:
                    throw new HttpResponseVariantAlsoNegotiatesException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.InsufficientStorage:
                    throw new HttpResponseInsufficientStorageException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.LoopDetected:
                    throw new HttpResponseLoopDetectedException(httpResponseMessage, content);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.NotExtended:
                    throw new HttpResponseNotExtendedException(httpResponseMessage, content);

                case true when httpResponseMessage.StatusCode == HttpStatusCode.NetworkAuthenticationRequired:
                    ValidationProblemDetails problemDetails = MapToProblemDetails(content);
                    throw new HttpResponseNetworkAuthenticationRequiredException(httpResponseMessage, problemDetails);

                case false when httpResponseMessage.StatusCode == HttpStatusCode.NetworkAuthenticationRequired:
                    throw new HttpResponseNetworkAuthenticationRequiredException(httpResponseMessage, content);
            }
        }

        private static bool NotFoundWithNoContent(HttpResponseMessage httpResponseMessage) =>
            httpResponseMessage.Content.Headers.Contains("Content-Type") == false
            && httpResponseMessage.StatusCode == HttpStatusCode.NotFound;

        private static ValidationProblemDetails MapToProblemDetails(string content) =>
            JsonConvert.DeserializeObject<ValidationProblemDetails>(content);

        private static bool IsProblemDetail(string content) =>
            content.ToLower().Contains("\"title\":") && content.ToLower().Contains("\"type\":");
    }
}