// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Models;

namespace RESTFulSense.Controllers
{
    public class RESTFulController : ControllerBase, IRESTFulController
    {
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
    }
}