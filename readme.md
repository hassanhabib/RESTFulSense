![RESTFulSense](https://raw.githubusercontent.com/hassanhabib/RESTFulSense/master/RESTFulSense/images/rs_git_logo.png)

[![.NET](https://github.com/hassanhabib/RESTFulSense/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hassanhabib/RESTFulSense/actions/workflows/dotnet.yml)
[![Nuget](https://img.shields.io/nuget/v/RESTFulSense?logo=nuget&style=default)](https://www.nuget.org/packages/RESTFulSense)
![Nuget](https://img.shields.io/nuget/dt/RESTFulSense?logo=nuget&style=default&color=blue&label=Downloads)
[![The Standard - COMPLIANT](https://img.shields.io/badge/The_Standard-COMPLIANT-2ea44f?style=default)](https://github.com/hassanhabib/The-Standard)
[![The Standard](https://img.shields.io/github/v/release/hassanhabib/The-Standard?filter=v2.9.0&style=default&label=Standard%20Version&color=2ea44f)](https://github.com/hassanhabib/The-Standard/tree/2.9.0)
[![The Standard Community](https://img.shields.io/discord/934130100008538142?style=default&color=%237289da&label=The%20Standard%20Community&logo=Discord)](https://discord.gg/vdPZ7hS52X)

# RESTFulSense 
I designed & developed this library as a wrapper around the existing .NET Core ```HttpClient``` implementation to provide the following values:

1. Meaningful Exceptions for APIs response status codes.

2. Simplified API communications.

3. Test-friendly implementation.

You can get RESTFulSense [Nuget](https://www.nuget.org/packages/RESTFulSense/) package by typing:
```powershell
Install-Package RESTFulSense
```

Here's the details of what this library has to offer:

### 1. Meaningful Exceptions

##### RESTFulSense provide the following exceptions for erroring HTTP Status Codes as follows:

|Status|Code|Exception|
|--- |--- |--- |
|BadRequest|400|HttpResponseBadRequestException|
|Unauthorized|401|HttpResponseUnauthorizedException|
|PaymentRequired|402|HttpResponsePaymentRequiredException|
|Forbidden|403|HttpResponseForbiddenException|
|NotFound|404|HttpResponseNotFoundException|
|NotFound|404|HttpResponseUrlNotFoundException|
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

### 2. Simplified API Communications
API controllers in ASP.NET Core today don't offer the full range of HTTP Codes that can be used to communicate certain events and errors to end users, in this library we managed to implement all the missing methods to communicate the full range of error codes as follows:

#### 2.1 On Controller Level 

|Controller Method|Code|
|--- |--- |
|PaymentRequired(object value)|402|
|MethodNotAllowed(object value)|405|
|NotAcceptable(object value)|406|
|ProxyAuthenticationRequired(object value)|407|
|RequestTimeout(object value)|408|
|Gone(object value)|410|
|LengthRequired(object value)|411|
|PreconditionFailed(object value)|412|
|RequestEntityTooLarge(object value)|413|
|RequestUriTooLong(object value)|414|
|UnsupportedMediaType(object value)|415|
|RequestedRangeNotSatisfiable(object value)|416|
|ExpectationFailed(object value)|417|
|MisdirectedRequest(object value)|421|
|UnprocessableEntity(object value)|422|
|Locked(object value)|423|
|FailedDependency(object value)|424|
|UpgradeRequired(object value)|426|
|PreconditionRequired(object value)|428|
|TooManyRequests(object value)|429|
|RequestHeaderFieldsTooLarge(object value)|431|
|UnavailableForLegalReasons(object value)|451|
|InternalServerError(object value)|500|
|NotImplemented(object value)|501|
|BadGateway(object value)|502|
|ServiceUnavailable(object value)|503|
|GatewayTimeout(object value)|504|
|HttpVersionNotSupported(object value)|505|
|VariantAlsoNegotiates(object value)|506|
|InsufficientStorage(object value)|507|
|LoopDetected(object value)|508|
|NotExtended(object value)|510|
|NetworkAuthenticationRequired(object value)|511|

This can be achieved by simply replacing the inheritance ```ControllerBase``` in your ASP.NET Core Controller class with RESTFulController as follows:

```csharp
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : RESTFulController
    {
        ...
    }
```

Once that's done, you will have full access to use any of the methods above to communicate more meaningful errors to your API consumers and clients.

#### 2.2 On Consumer Level
Passing or retrieving objects from an API should be as simple as one method call, for RESTFulSense, you don't have to worry about how to serialize your input or deserialize the API output, here's how simple it works:


##### 2.2.1 Initialization
The initialization of the RESTFulSense Client can be done in two different ways:

###### 2.2.1.1 HttpClientFactory Approach
In your ASP.NET Core application, you can initialize the ```IRESTFulApiFactoryClient``` in your startup.cs as follows:


```csharp
services.AddHttpClient<IRESTFulApiFactoryClient, RESTFulApiFactoryClient>(client => client.BaseAddress = new Uri(YOUR_API_URL));
```

###### 2.2.1.2 Basic Initialization
You can also use the RESTFulClient simple initialize in a console app for instance as follows:

```csharp
var apiClient = new RESTFulApiClient();
```


##### 2.2.1 Deserialization
```csharp
List<Student> students = 
    await restfulApiClient.GetContentAsync<List<Student>>(relativeUrl: "api/students");

```

##### 2.2.2 Serialization
```csharp
Student student = 
    await restfulApiClient.PostContentAsync<Student>(relativeUrl: "api/students", content: inputStudent); 
```

In addition to the wrappers around API calls and serialization/deserialization, this library also provides a simplified way to execute communications without any workarounds.

For instance, to execute a ```PUT``` API call without a body, to update a status for instance, you don't have to fake a ```PUT``` body to execute a successful call, you can just do the follows:
```csharp
Account activatedAccount = 
    await restfulApiClient.PutContentAsync(relativeUrl: $"api/accounts/{accountId}/activate");
```

### 3. MultipartFormDataContent support

`RESTFulSense`  allows you to easily convert a C# class with attributes into a MultipartFormDataContent and send it as a `POST` request using the `PostFormAsync` method.

The library includes the following attributes:

| Attribute | Description |
| --- | --- |
| `RESTFulByteArrayContentAttribute` | Specifies a byte array content type |
| `RESTFulStreamContentAttribute` | Specifies a stream content type |
| `RESTFulStringContentAttribute` | Specifies a string content type |
| `RESTFulFileNameAttribute` | Adds a file name to the content |

These attributes allow you to specify the content types and names of the form data. The `RESTFulFileNameAttribute` also allows you to add a file name to the content. Simply apply the attributes to your class properties and the library will handle the rest.

Here's an example usage:

```csharp
public class FormUpload
{
    [RESTFulStreamContent(name: "file")]
    public Stream Stream { get; set; }

    [RESTFulStringContent(name: "purpose")]
    public string Purpose { get; set; }

    [RESTFulFileName(name: "file")]
    public string FileName { get; set; }
}

// ...

var formUpload = new FormUpload
{
    Stream = GetStream(),
    Purpose = "fine-tune",
    FileName = "SomeFile.jsonl"
};

var result = await PostFormAsync<FormUpload, ResultType>("https://example.com/upload", formUpload);
```

Note the linking of the FileName to the StreamContent via the name parameter in the attributes.

### 4. Testing-Friendly Implementation
RESTFulSense provides an interface to the API client class, to make it easier to mock and leverage dependency injection for the testability of the client consumers, here's an example:
 
```csharp
var restfulApiClientMock = new Mock<IRestfulApiClient>();

restfulApiClient.Setup(client =>
    client.GetContentAsync<Student>(relativeUrl: $"api/students/{studentId}")
        .ReturnsAsync(student);
```



If you have any suggestions, comments or questions, please feel free to contact me on:

[Twitter](https://twitter.com/hassanrezkhabib)

[LinkedIn](https://www.linkedin.com/in/hassanrezkhabib/)

[E-Mail](mailto:hassanhabib@live.com)


Huge thanks to Mr. Brian Parker @BrianLParker for his RESTfulSense Web Assembly effort. 
