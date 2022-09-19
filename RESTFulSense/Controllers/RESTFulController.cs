// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Models;

namespace RESTFulSense.Controllers
{
    public class RESTFulController : ControllerBase, IRESTFulController
    {
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public RESTFulController(JsonSerializerOptions jsonSerializerOptions = null)
        {
            this.jsonSerializerOptions = jsonSerializerOptions ?? new JsonSerializerOptions();
        }

        [NonAction]
        public CreatedObjectResult Created(object value) =>
            new CreatedObjectResult(value);

        [NonAction]
        public BadGatewayObjectResult BadGateway(object value) =>
            new BadGatewayObjectResult(value);

        [NonAction]
        public ExpectationFailedObjectResult ExpectationFailed(object value) =>
            new ExpectationFailedObjectResult(value);

        [NonAction]
        public FailedDependencyObjectResult FailedDependency(object value) =>
            new FailedDependencyObjectResult(value);

        [NonAction]
        public GatewayTimeoutObjectResult GatewayTimeout(object value) =>
            new GatewayTimeoutObjectResult(value);

        [NonAction]
        public GoneObjectResult Gone(object value) =>
            new GoneObjectResult(value);

        [NonAction]
        public HttpVersionNotSupportedObjectResult HttpVersionNotSupported(object value) =>
            new HttpVersionNotSupportedObjectResult(value);

        [NonAction]
        public InsufficientStorageObjectResult InsufficientStorage(object value) =>
            new InsufficientStorageObjectResult(value);

        [NonAction]
        public InternalServerErrorObjectResult InternalServerError(object value) =>
            new InternalServerErrorObjectResult(value);

        [NonAction]
        public LengthRequiredObjectResult LengthRequired(object value) =>
            new LengthRequiredObjectResult(value);

        [NonAction]
        public LockedObjectResult Locked(object value) =>
            new LockedObjectResult(value);

        [NonAction]
        public LoopDetectedObjectResult LoopDetected(object value) =>
            new LoopDetectedObjectResult(value);

        [NonAction]
        public MethodNotAllowedObjectResult MethodNotAllowed(object value) =>
            new MethodNotAllowedObjectResult(value);

        [NonAction]
        public MisdirectedRequestObjectResult MisdirectedRequest(object value) =>
            new MisdirectedRequestObjectResult(value);

        [NonAction]
        public NetworkAuthenticationRequiredObjectResult NetworkAuthenticationRequired(object value) =>
            new NetworkAuthenticationRequiredObjectResult(value);

        [NonAction]
        public NotAcceptableObjectResult NotAcceptable(object value) =>
            new NotAcceptableObjectResult(value);

        [NonAction]
        public NotExtendedObjectResult NotExtended(object value) =>
            new NotExtendedObjectResult(value);

        [NonAction]
        public NotImplementedObjectResult NotImplemented(object value) =>
            new NotImplementedObjectResult(value);

        [NonAction]
        public PaymentRequiredObjectResult PaymentRequired(object value) =>
            new PaymentRequiredObjectResult(value);

        [NonAction]
        public PreconditionFailedObjectResult PreconditionFailed(object value) =>
            new PreconditionFailedObjectResult(value);

        [NonAction]
        public PreconditionRequiredObjectResult PreconditionRequired(object value) =>
            new PreconditionRequiredObjectResult(value);

        [NonAction]
        public ProxyAuthenticationRequiredObjectResult ProxyAuthenticationRequired(object value) =>
            new ProxyAuthenticationRequiredObjectResult(value);

        [NonAction]
        public RequestedRangeNotSatisfiableObjectResult RequestedRangeNotSatisfiable(object value) =>
            new RequestedRangeNotSatisfiableObjectResult(value);

        [NonAction]
        public RequestEntityTooLargeObjectResult RequestEntityTooLarge(object value) =>
            new RequestEntityTooLargeObjectResult(value);

        [NonAction]
        public RequestHeaderFieldsTooLargeObjectResult RequestHeaderFieldsTooLarge(object value) =>
            new RequestHeaderFieldsTooLargeObjectResult(value);

        [NonAction]
        public RequestTimeoutObjectResult RequestTimeout(object value) =>
            new RequestTimeoutObjectResult(value);

        [NonAction]
        public RequestUriTooLongObjectResult RequestUriTooLong(object value) =>
            new RequestUriTooLongObjectResult(value);

        [NonAction]
        public ServiceUnavailableObjectResult ServiceUnavailable(object value) =>
            new ServiceUnavailableObjectResult(value);

        [NonAction]
        public TooManyRequestsObjectResult TooManyRequests(object value) =>
            new TooManyRequestsObjectResult(value);

        [NonAction]
        public UnavailableForLegalReasonsObjectResult UnavailableForLegalReasons(object value) =>
            new UnavailableForLegalReasonsObjectResult(value);

        [NonAction]
        public UnsupportedMediaTypeObjectResult UnsupportedMediaTypeObjectResult(object value) =>
            new UnsupportedMediaTypeObjectResult(value);

        [NonAction]
        public UpgradeRequiredObjectResult UpgradeRequired(object value) =>
            new UpgradeRequiredObjectResult(value);

        [NonAction]
        public VariantAlsoNegotiatesObjectResult VariantAlsoNegotiates(object value) =>
            new VariantAlsoNegotiatesObjectResult(value);

        [NonAction]
        public BadRequestObjectResult BadRequest(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new BadRequestObjectResult(problemDetail);
        }

        [NonAction]
        public UnauthorizedObjectResult Unauthorized(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Type = "https://tools.ietf.org/html/rfc7235#section-3.1",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new UnauthorizedObjectResult(problemDetail);
        }

        [NonAction]
        public PaymentRequiredObjectResult PaymentRequired(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status402PaymentRequired,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.2",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new PaymentRequiredObjectResult(problemDetail);
        }

        [NonAction]
        public ForbiddenObjectResult Forbidden(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status403Forbidden,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new ForbiddenObjectResult(problemDetail);
        }

        [NonAction]
        public NotFoundObjectResult NotFound(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new NotFoundObjectResult(problemDetail);
        }

        [NonAction]
        public MethodNotAllowedObjectResult MethodNotAllowed(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status405MethodNotAllowed,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.5",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new MethodNotAllowedObjectResult(problemDetail);
        }

        [NonAction]
        public NotAcceptableObjectResult NotAcceptable(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status406NotAcceptable,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.6",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new NotAcceptableObjectResult(problemDetail);
        }

        [NonAction]
        public ProxyAuthenticationRequiredObjectResult ProxyAuthenticationRequired(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status407ProxyAuthenticationRequired,
                Type = "https://tools.ietf.org/html/rfc7235#section-3.2",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new ProxyAuthenticationRequiredObjectResult(problemDetail);
        }

        [NonAction]
        public RequestTimeoutObjectResult RequestTimeout(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status408RequestTimeout,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.7",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new RequestTimeoutObjectResult(problemDetail);
        }

        [NonAction]
        public ConflictObjectResult Conflict(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new ConflictObjectResult(problemDetail);
        }

        [NonAction]
        public GoneObjectResult Gone(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status410Gone,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.9",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new GoneObjectResult(problemDetail);
        }

        [NonAction]
        public LengthRequiredObjectResult LengthRequired(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status411LengthRequired,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.10",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new LengthRequiredObjectResult(problemDetail);
        }

        [NonAction]
        public PreconditionFailedObjectResult PreconditionFailed(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status412PreconditionFailed,
                Type = "https://tools.ietf.org/html/rfc7232#section-4.2",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new PreconditionFailedObjectResult(problemDetail);
        }

        [NonAction]
        public RequestEntityTooLargeObjectResult RequestEntityTooLarge(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status413RequestEntityTooLarge,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.11",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new RequestEntityTooLargeObjectResult(problemDetail);
        }

        [NonAction]
        public RequestUriTooLongObjectResult RequestUriTooLong(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status414RequestUriTooLong,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.12",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new RequestUriTooLongObjectResult(problemDetail);
        }

        [NonAction]
        public UnsupportedMediaTypeObjectResult UnsupportedMediaType(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status415UnsupportedMediaType,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.13",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new UnsupportedMediaTypeObjectResult(problemDetail);
        }

        [NonAction]
        public RequestedRangeNotSatisfiableObjectResult RequestedRangeNotSatisfiable(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status416RequestedRangeNotSatisfiable,
                Type = "https://tools.ietf.org/html/rfc7233#section-4.4",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new RequestedRangeNotSatisfiableObjectResult(problemDetail);
        }

        [NonAction]
        public ExpectationFailedObjectResult ExpectationFailed(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status417ExpectationFailed,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.14",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new ExpectationFailedObjectResult(problemDetail);
        }

        [NonAction]
        public MisdirectedRequestObjectResult MisdirectedRequest(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status421MisdirectedRequest,
                Type = "https://tools.ietf.org/html/rfc7540#section-9.1.2",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new MisdirectedRequestObjectResult(problemDetail);
        }

        [NonAction]
        public UnprocessableEntityObjectResult UnprocessableEntity(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status422UnprocessableEntity,
                Type = "https://tools.ietf.org/html/rfc4918#section-11.2",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new UnprocessableEntityObjectResult(problemDetail);
        }

        [NonAction]
        public LockedObjectResult Locked(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status423Locked,
                Type = "https://tools.ietf.org/html/rfc4918#section-11.3",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new LockedObjectResult(problemDetail);
        }

        [NonAction]
        public FailedDependencyObjectResult FailedDependency(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status424FailedDependency,
                Type = "https://tools.ietf.org/html/rfc4918#section-11.4",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new FailedDependencyObjectResult(problemDetail);
        }

        [NonAction]
        public UpgradeRequiredObjectResult UpgradeRequired(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status426UpgradeRequired,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.15",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new UpgradeRequiredObjectResult(problemDetail);
        }

        [NonAction]
        public PreconditionRequiredObjectResult PreconditionRequired(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status428PreconditionRequired,
                Type = "https://tools.ietf.org/html/rfc6585#section-3",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new PreconditionRequiredObjectResult(problemDetail);
        }

        [NonAction]
        public TooManyRequestsObjectResult TooManyRequests(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status429TooManyRequests,
                Type = "https://tools.ietf.org/html/rfc6585#section-4",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new TooManyRequestsObjectResult(problemDetail);
        }

        [NonAction]
        public RequestHeaderFieldsTooLargeObjectResult RequestHeaderFieldsTooLarge(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status431RequestHeaderFieldsTooLarge,
                Type = "https://tools.ietf.org/html/rfc6585#section-5",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new RequestHeaderFieldsTooLargeObjectResult(problemDetail);
        }

        [NonAction]
        public UnavailableForLegalReasonsObjectResult UnavailableForLegalReasons(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status451UnavailableForLegalReasons,
                Type = "https://tools.ietf.org/html/rfc7725#section-3",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new UnavailableForLegalReasonsObjectResult(problemDetail);
        }

        [NonAction]
        public InternalServerErrorObjectResult InternalServerError(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new InternalServerErrorObjectResult(problemDetail);
        }

        [NonAction]
        public NotImplementedObjectResult NotImplemented(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status501NotImplemented,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.2",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new NotImplementedObjectResult(problemDetail);
        }

        [NonAction]
        public BadGatewayObjectResult BadGateway(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status502BadGateway,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.3",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new BadGatewayObjectResult(problemDetail);
        }

        [NonAction]
        public ServiceUnavailableObjectResult ServiceUnavailable(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status503ServiceUnavailable,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.4",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new ServiceUnavailableObjectResult(problemDetail);
        }

        [NonAction]
        public GatewayTimeoutObjectResult GatewayTimeout(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status504GatewayTimeout,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.5",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new GatewayTimeoutObjectResult(problemDetail);
        }

        [NonAction]
        public HttpVersionNotSupportedObjectResult HttpVersionNotSupported(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status505HttpVersionNotsupported,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.6",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new HttpVersionNotSupportedObjectResult(problemDetail);
        }

        [NonAction]
        public VariantAlsoNegotiatesObjectResult VariantAlsoNegotiates(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status506VariantAlsoNegotiates,
                Type = "https://tools.ietf.org/html/rfc2295#section-8.1",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new VariantAlsoNegotiatesObjectResult(problemDetail);
        }

        [NonAction]
        public InsufficientStorageObjectResult InsufficientStorage(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status507InsufficientStorage,
                Type = "https://tools.ietf.org/html/rfc4918#section-11.5",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new InsufficientStorageObjectResult(problemDetail);
        }

        [NonAction]
        public LoopDetectedObjectResult LoopDetected(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status508LoopDetected,
                Type = "https://tools.ietf.org/html/rfc5842#section-7.2",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new LoopDetectedObjectResult(problemDetail);
        }

        [NonAction]
        public NotExtendedObjectResult NotExtended(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status510NotExtended,
                Type = "https://tools.ietf.org/html/rfc2774#section-7",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new NotExtendedObjectResult(problemDetail);
        }

        [NonAction]
        public NetworkAuthenticationRequiredObjectResult NetworkAuthenticationRequired(Exception exception)
        {
            var problemDetail = new ValidationProblemDetails
            {
                Status = StatusCodes.Status511NetworkAuthenticationRequired,
                Type = "https://tools.ietf.org/html/rfc6585#section-6",
                Title = exception.Message
            };

            MapExceptionDataToProblemDetail(exception, problemDetail);

            return new NetworkAuthenticationRequiredObjectResult(problemDetail);
        }

        private void MapExceptionDataToProblemDetail(
            Exception exception,
            ValidationProblemDetails problemDetail)
        {
            foreach (DictionaryEntry error in exception.Data)
            {
                string errorKey = ApplySerialization(error, jsonSerializerOptions);

                problemDetail.Errors.Add(
                    key: errorKey,
                    value: ((List<string>)error.Value)?.ToArray());
            }
        }

        private static string ApplySerialization(DictionaryEntry error, JsonSerializerOptions jsonSerializerOptions)
        {
            IDictionary<string, Object> interimObject = new ExpandoObject();
            interimObject.Add(error.Key.ToString(), error.Value);

            string serialisedInterimObject =
                JsonSerializer.Serialize(interimObject, jsonSerializerOptions);

            var deserializedError =
                JsonSerializer.Deserialize<IDictionary<string, Object>>(
                    serialisedInterimObject,
                    jsonSerializerOptions);

            return deserializedError.Keys.First();
        }
    }
}