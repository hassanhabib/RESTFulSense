
# RESTFulSense 
I designed & developed this library as a wrapper around the existing .NET Core ```HttpClient``` implementation to provide the following values:

<ol>
	<li>Meaningful Exceptions for APIs response status codes.</li>
	<li>Simplified API communications.</li>
	<li>Test-friendly implementation.</li>
</ol>

<br />

You can get RESTFulSense [Nuget](https://www.nuget.org/packages/RESTFulSense/) package by typing:
```powershell
Install-Package RESTFulSense
```

Here's the details of what this library has to offer:

### 1. Meaningful Exceptions
RESTFulSense provide the following exceptions for erroring HTTP Status Codes as follows:
<br />

|Status|Code|Exception|
|--- |--- |--- |
|BadRequest|400|HttpResponseBadRequestException|
|Unauthorized|401|HttpResponseUnauthorizedException|
|PaymentRequired|402|HttpResponsePaymentRequiredException|
|Forbidden|403|HttpResponseForbiddenException|
|NotFound|404|HttpResponseNotFoundException|
|MethodNotAllowed|405|HttpResponseMethodNotAllowedException|
|NotAcceptable|406|HttpResponseNotAcceptableException|
|ProxyAuthenticationRequired|407|HttpResponseProxyAuthenticationRequiredException|
|RequestTimeout|408|HttpResponseRequestTimeoutException|
|Conflict|409|HttpResponseConflictException|
|Gone|410|HttpResponseGoneException|
|LengthRequired|411|HttpResponseLengthRequiredException|
|PreconditionFailed|412|HttpResponsePreconditionFailedException|
|RequestEntityTooLarge|413|HttpResponseRequestEntityTooLargeException|
|RequestUriTooLong|414|HttpResponseRequestUriTooLongException|
|UnsupportedMediaType|415|HttpResponseUnsupportedMediaTypeException|
|RequestedRangeNotSatisfiable|416|HttpResponseRequestedRangeNotSatisfiableException|
|ExpectationFailed|417|HttpResponseExpectationFailedException|
|MisdirectedRequest|421|HttpResponseMisdirectedRequestException|
|UnprocessableEntity|422|HttpResponseUnprocessableEntityException|
|Locked|423|HttpResponseLockedException|
|FailedDependency|424|HttpResponseFailedDependencyException|
|UpgradeRequired|426|HttpResponseUpgradeRequiredException|
|PreconditionRequired|428|HttpResponsePreconditionRequiredException|
|TooManyRequests|429|HttpResponseTooManyRequestsException|
|RequestHeaderFieldsTooLarge|431|HttpResponseRequestHeaderFieldsTooLargeException|
|UnavailableForLegalReasons|451|HttpResponseUnavailableForLegalReasonsException|
|InternalServerError|500|HttpResponseInternalServerErrorException|
|NotImplemented|501|HttpResponseNotImplementedException|
|BadGateway|502|HttpResponseBadGatewayException|
|ServiceUnavailable|503|HttpResponseServiceUnavailableException|
|GatewayTimeout|504|HttpResponseGatewayTimeoutException|
|HttpVersionNotSupported|505|HttpResponseHttpVersionNotSupportedException|
|VariantAlsoNegotiates|506|HttpResponseVariantAlsoNegotiatesException|
|InsufficientStorage|507|HttpResponseInsufficientStorageException|
|LoopDetected|508|HttpResponseLoopDetectedException|
|NotExtended|510|HttpResponseNotExtendedException|
|NetworkAuthenticationRequired|511|HttpResponseNetworkAuthenticationRequiredException|


<br />

### 2. Simplified API communications
Passing or retrieving objects from an API should be as simple as one method call, for RESTFulSense, you don't have to worry about how to serialize your input or deserialize the API output, here's how simple it works:

#### 2.1 Deserialization
```csharp
List<Student> students = 
    await restfulApiClient.GetContentAsync<List<Student>>(relativeUrl: "api/students");

```

#### 2.2 Serialization
```csharp
Student student = 
    await restfulApiClient.PostContentAsync<Student>(relativeUrl: "api/students", content: inputStudent); 
```
<br />

In addition to the wrappers around API calls and serialziation/deserialization, this library alos provides a simplified way to execute communications without any workarounds.
<br />
For instance, to execute a ```PUT``` API call without a body, to update a status for instance, you don't have to fake a ```PUT``` body to execute a successful call, you can just do the follows:
```csharp
Account activatedAccount = 
    await restfulApiClient.PutContentAsync(relativeUrl: $"api/accounts/{accountId}/activate");
```

<br />

### 3. Testing-Friendly Implementation
RESTFulSense provides an interface to the API client class, to make it easier to mock and leverage dependency injection for the testability of the client consumers, here's an example:
 
```csharp
var restfulApiClientMock = new Mock<IRestfulApiClient>();

restfulApiClient.Setup(client =>
    client.GetContentAsync<Student>(relativeUrl: $"api/students/{studentId}")
        .ReturnsAsync(student);
```

<br />

If you have any suggestions, comments or questions, please feel free to contact me on:
<br />
Twitter: @hassanrezkhabib
<br />
LinkedIn: hassanrezkhabib
<br />
E-Mail: hassanhabib@live.com
<br />
