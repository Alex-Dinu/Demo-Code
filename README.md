# Demo Code
https://stackedit.io/app#
The purpose of this repository is to showcase various tools, development principles, solution architecture and the usage of 3rd party tools that demonstrate my experience. This demo code solution uses .NETCore 2.2.

## Technologies and tools
### Architecture
Although the solution is not strictly [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html), it does implement the basic principles. I did take some shortcuts in order to make it easier to follow and try it out.

## .NET Core
### Tools and packages
#### Logger
I use [Serilog](https://serilog.net/) in order to help me log information and errors in JSON format in a daily rolling file with a max size.

The Infrastructure.Log project does it all. It is referenced by each project that requires to log something. I set up some properties in Startup.cs in a private AddSerilogServices() method. We are also loading the class as scoped. The reason being is that it also generates a unique ID for each http request, so when we log the events and errors, we can easily search by the ID and order by the date so we can see a complete picture of a specific request. You can vew the code [here](https://github.com/Alex-Dinu/Demo-Code/blob/master/Infrastructure.Log/DataLogger.cs).

The following NugetPackages are used:

 - Serilog.Exceptions which makes it easier to log exceptions and their properties.
 - Serilog.Settings.Configuration is used to read some configuration settings
 - Serilog.Sinks.Async is used to log asynchronously
 - Serilog.Sinks.RollingFile allows me to easily setup the rolling log file.

Notice that we are sending a parameter type to the logger methods. This allows us to send in as many parameters as are needed to be logged as illustrated by the following interface contract:

    void LogError(Exception ex, params object[] data);

#### Entity Framework Core
Being a .NETCore solution, EFCore is being used. While most of the demos do not require a database, some calls under the EFCore menu item do, so you would need to perform the following steps:

 1. Install the Wide World Importers database
	1.1 Download the [**WideWorldImporters-Standard.bak**](https://github.com/Microsoft/sql-server-samples/releases/download/wide-world-importers-v1.0/WideWorldImporters-Standard.bak) backup database in order to restore it from this [site](https://github.com/Microsoft/sql-server-samples/releases/tag/wide-world-importers-v1.0).
2. Compile the application stored procedures in Infrastructure.Database.SQL.StoredProcedures
3. Update the EFCore connection string in the appsettings file.

#### AutoMapper
AutoMapper is a library I use to map the different data objects that are passed between the different layers in Clean Architecture solution.
Mapper rules are setup in [WebUi.Shared.DataMapper class](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Shared/DataMapper.cs) and is added as a service in Startup.cs.

#### XUnit
I use XUnit to run my tests. It has a few nice features:
- Useage of constructors instead of initializers
- Test fixtures that are loaded once and used in every test
- Pass in data as parameters to test cases that will allow you to run the same test with multiple data elements. You can see this in this [test](https://github.com/Alex-Dinu/Demo-Code/blob/master/Test.IntergationTests/OrderTests/GetOrderTests.cs). OrderAuthorizationTests() expects two classes that will return the parameters the test method requires.
- Will start an Http Client based on the startup settings.

#### Swashbuckle
This package automatically generates json and a UI representation of your services. You can expand it by adding .NET XML documentation to the properties and methods and creating test data for the models. All the settings are in one [class](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Shared/SwaggerServiceExtension.cs) that is referenced in the startup class.

## MVC/API
### Middleware
We use [middleware](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.2) to manage the request pipeline. Any classes that the middleware require need to be added to the container in Startup.cs and we need to also add the middleware to the application also in Startup.Configure() method.
#### Request\Response logger
This middleware automatically logs the request values and the response, It can be found [here](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Middleware/RequestResponseLoggingMiddleware.cs)
#### Unhandled Exception middleware
This [middleware](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Middleware/UnhandledExceptionHandlerMiddleware.cs) will catch any unhandled exceptions, build a custom response and return it so we won't return any secure information just in case someone missed a try\catch.
### Responses
#### Return types
We can now explicitly return the type of the action. In the past, we used to return ActionResult, but now we can explicitly say what the type is, e.g. Task<ActionResult<CustomerSearchMvcResponseModel>>.
### Validators	
#### Custom Validators
I added a custom validator attribute to showcase how we can pass the existing property we need to validate and anotherproperty value into the validator. The validator code can be found [here](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/CustomValidatorAttributes/ValidLogonAttribute.cs) and is used as follows:

        [DisplayName("Preferred Name")]
        public string PreferredName { get; set; }
        [DisplayName("Logon Name")]
        [ValidLogon("PreferredName", ErrorMessage = "Invalid Logon")]
        public string LogonName { get; set; }
	
As you can see, we are validating the LogonName against the PreferredName. 
#### Remote Validations
[Remote validations](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-2.2#remote-attribute) perform an asynchronous call to the server to perform a validation while the client continues to fill out the form. For example, if an email address has to be unique, once they tab away from the input, and continue to fill out the form, an AJAX call is made to make sure the field is not already in use.
The validation code can be found [here](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Controllers/CustomerSearchController.cs) at the end in the PhoneNumberIsUnique() method and is setup as an attribute on the property:

        [Remote("CheckIfEmailAlreadyExists", "Employees", ErrorMessage = "Email already exists")]
        public string EmailAddress { get; set; }
	
The first parameter is the action an the second is the controller.

## JQuery

### Closures
[This](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Views/Closures/Index.cshtml) is the source code. You can see it in action by running the site and selecting Closures from the JQUery menu.

### Promises
[This](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Views/Promises/Index.cshtml) is the source code. You can see it in action by running the site and selecting Promises from the JQUery menu.

### AJAX calls
This demonstrates a simple AJAX call to get some results from an API call. You can look at the code [here](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Views/Address/Create.cshtml) and see it in action by running the site and selecting AJAX from the JQUery menu.

