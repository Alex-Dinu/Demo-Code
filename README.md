# Demo Code

The purpose of this repository is to showcase various tools, development principles, solution architecture and the usage of 3rd party tools that demonstrate my experience. This demo code solution uses .NETCore 2.2.
It is built in modules, so it does not implement any architecture design ot principle.

# Table of Contents
1. [Technologies and tools](#TechAndTools)
	1. [Clean Architecture](#architecture)
	2. [SOLID Principles](#solid)	
		1. [Single Responsibility Principle](#srp)
		2. [Open Closed Principle](#ocp)
		3. [Liskov Substitution Principle](#lsp)
		4. [Interface Segregation Principle](#isp)
		5. [Dependency Inversion Principle](#dip)
	3. [Async](#async)
2. [.NET Core](#netcore)
	1. [Tools and packages](#tools)
		1. [Logger](#logger) 
		2. [Entity Framework Core](#efc)
		3. [Automapper](#automapper)
		4. [XUnit](#xunit)
		5. [Swashbuckle](#swashbuckle)
		6. [MiniProfiler](#miniprofiler)
3. [MVC](#mvc)
	1. [Middleware](#middleware)
		1. [Request\Response logger](#reqres)
		2. [Unhandled Exception middleware](#ex)
	2. [Responses](#res)
		1. [Return types](#rettype)
	3. [Validators](#validators)
		1. [Custom Validators](#customvalidators)
		2. [Remote Validations](3remotevalidations)
4. [JQuery](#jquery)
	1. [Closures](#closures)
	2. [Promises](#promises)
	3. [AJAX calls](#ajax)
5. [JQuery UI](#jqueryui)
	1. [Drag\Drop](#dragdrop)
6. [TODO](#todo)

	
	
## Technologies and tools <a name="TechAndTools"></a>
### Clean Architecture <a name="architecture"></a>
Although the solution is not strictly [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html), it does implement the basic principles. I did take some shortcuts in order to make it easier to follow the code and try it out. One of the rules of CA is a strict direction of data flow and to use interfaces when communicating the opposite direction.

One way to implement these rules, is to use 3rd prty packages that reduce the amount of code you have to write. An example of such a package is documented below (Automapper).

### SOLID Principles <a name="solid"></a>
#### Single Responsibility Principle <a name="srp"></a>
Each software module should have only one reason to change.

[This](https://github.com/Alex-Dinu/Demo-Code/blob/master/SOLID/SingleResponsibilityPrincipleStart.cs) link demonstrates the smell and this [link](https://github.com/Alex-Dinu/Demo-Code/blob/master/SOLID/SingleResponsibilityPrincipleEnd.cs) demonstrates the fix.
#### Open Closed Principle <a name="ocp"></a>
Software entities should be open for extension, but closed for modification

There are at least three wyas to resolve the OPC:

1. [Using parameters](https://github.com/Alex-Dinu/Demo-Code/blob/master/SOLID/OpenClosedPrincipleEndOption1.cs).
2. [Virtual methods](https://github.com/Alex-Dinu/Demo-Code/blob/master/SOLID/OpenClosedPrincipleEndOption2.cs).
3. [Factories](https://github.com/Alex-Dinu/Demo-Code/blob/master/SOLID/OpenClosedPrincipleEndOption3.cs). This option can be expanded to use interfaces instead of abstract classes and reflection to eliminate the conditional code.

#### Liskov Substitution Principle <a name="lsp"></a>
Subtypes must be substitutable for their base types

There are at least three [smells](https://github.com/Alex-Dinu/Demo-Code/blob/master/SOLID/LiskovSubstitutionPrincipleStart.cs) that can be used to identify when we break LSP:
1. The need to check the type,
2. The need to check for nulls,
3. We don't implement the whole contract and require to throw a NotImplementedException.

The forst two break the Tell, Don't Ask Principle. This [link](https://github.com/Alex-Dinu/Demo-Code/blob/master/SOLID/LiskovSubstitutionPrincipleEnd.cs) shows some possible fixes.

#### Interface Segregation Principle <a name="isp"></a>
Clients should not be forced to depend on methods they do not use.

Closely related to LSP, [this](https://github.com/Alex-Dinu/Demo-Code/blob/master/SOLID/InterfaceSegregationPrincipleStart.cs) code adds another smell that breaks ISP. And here is a possible [fix](https://github.com/Alex-Dinu/Demo-Code/blob/master/SOLID/InterfaceSegregationPrincipleEnd.cs).

#### Dependency Inversion Principle <a name="dip"></a>
High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions.

[This code](https://github.com/Alex-Dinu/Demo-Code/blob/master/SOLID/DependencyInjectionPrincipleStart.cs) shows us the problem. and a possible [solution](https://github.com/Alex-Dinu/Demo-Code/blob/master/SOLID/DependencyInjectionPrincipleEnd.cs). One thing to note, .NET Core has a built-in IoC(Inversion of Control) container for us to use.

### Async <a name="async"></a>
To view the code and execution, make the [NetCoreAsync](https://github.com/Alex-Dinu/Demo-Code/tree/master/NetCoreAsync) project as the startup project. It uses a simple breakfast preparation steps to illustrate how async helps you prepare it faster and how it helps the code be more scalabale.

In Program.cs, you will see the natural regression from non-async code to an async code:
Uncomment each PrepareBreakfast call to see the execution.
- sync.PrepareBrakfast() is a non-async call. 
- async.PrepareBreakfast() shows you how to convert the non-async code into async code.
- async.PrepareBreakfast2() groups together related methods to make the code more readable.
- async.PrepareBreakfast3() adds the WhenAll functionality to improve the readbility and async controll better.

## .NET Core <a name="netcore"></a>
### Tools and packages <a name="tools"></a>
#### Logger <a name="logger"></a>
Microsoft introduced ILogger to help us log information. There are numerous other 3rd party packages that extend ILOgger and add additional functionality. I use [Serilog](https://serilog.net/) in order to help me log information and errors in JSON format in a daily rolling file with a max size.

The Infrastructure.Log project does it all. It is referenced by each project that requires to log something. I set up some properties in Startup.cs in a private AddSerilogServices() method. We are also loading the class as scoped. The reason being is that it also generates a unique ID for each http request, so when we log the events and errors, we can easily search by the ID and order by the date so we can see a complete picture of a specific request. You can vew the code [here](https://github.com/Alex-Dinu/Demo-Code/blob/master/Infrastructure.Log/DataLogger.cs).

Serilog has a rich number of supporting packages. The following NugetPackages are used:

 - Serilog.Exceptions which makes it easier to log exceptions and their properties.
 - Serilog.Settings.Configuration is used to read some configuration settings
 - Serilog.Sinks.Async is used to log asynchronously
 - Serilog.Sinks.RollingFile allows me to easily setup the rolling log file.

Notice that we are sending a parameter type to the logger methods. This allows us to send in as many parameters as are needed to be logged as illustrated by the following interface contract:

    void LogError(Exception ex, params object[] data);

#### Entity Framework Core <a name="efc"></a>
Being a .NETCore solution, EFCore is being used. While most of the demos do not require a database, some calls under the EFCore menu item do, so you would need to perform the following steps:

 1. Install the Wide World Importers database
	1. Download the [**WideWorldImporters-Standard.bak**](https://github.com/Microsoft/sql-server-samples/releases/download/wide-world-importers-v1.0/WideWorldImporters-Standard.bak) backup database in order to restore it from this [site](https://github.com/Microsoft/sql-server-samples/releases/tag/wide-world-importers-v1.0).
2. Compile the application stored procedures in Infrastructure.Database.SQL.StoredProcedures
3. Update the EFCore connection string in the appsettings file.

#### AutoMapper <a name="automapper"></a>
[AutoMapper](http://automapper.org/) is a library I use to map the different data objects that are passed between the different layers in Clean Architecture solution.
Mapper rules are setup in [WebUi.Shared.DataMapper class](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Shared/DataMapper.cs) and is added as a service in Startup.cs.

#### XUnit <a name="xunit"></a>
I use XUnit to run my tests. It has a few nice features:
- Useage of constructors instead of initializers
- [Test fixtures](https://github.com/Alex-Dinu/Demo-Code/blob/master/Test.IntergationTests/TextFixtures/TestClientFixture.cs) that are loaded once and used in every test
- Pass in data as parameters to test cases that will allow you to run the same test with multiple data elements. You can see this in this [test](https://github.com/Alex-Dinu/Demo-Code/blob/master/Test.IntergationTests/OrderTests/GetOrderTests.cs). OrderAuthorizationTests() expects two classes that will return the parameters the test method requires.
- Will start an Http Client based on the startup settings.

#### Swashbuckle <a name="swashbuckle"></a>
This package automatically generates json and a UI representation of your services. You can expand it by adding .NET XML documentation to the properties and methods and creating test data for the models. All the settings are in one [class](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Shared/SwaggerServiceExtension.cs) that is referenced in the startup class. You can also document [sample data](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Services/Orders/ClientOrderServiceResponseModel.cs)

To get the JSON code that can be used to communicate with consumers, add the following to the end of the home URL: /swagger/v1.0/swagger.json e.g. http://localhost:62681/swagger/v1.0/swagger.json

To view the UI, add the following to the end of the home URL: /swagger/index.html e.g. http://localhost:62681/swagger/index.html

#### MiniProfiler <a name="miniprofiler"></a>
MiniProfiler helps us log performance counters to better detect any performance issues. It's a configurable set of functions that display data on an MVC page, store data in a database, implements role security and hooks into Http and EF Core calls to supply additional details like the SQL statement or Http details.

Once you install the related Nuget packages and configure them in the Startup, all you need to do is add it to the [UI](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Views/ExchangeRate/Index.cshtml). You can see the output from the Misc\MiniProfiler menu.

## MVC/API <a name="mvc"></a>
### Middleware <a name="middleware"></a>
We use [middleware](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.2) to manage the request pipeline. Any classes that the middleware require need to be added to the container in Startup.cs and we need to also add the middleware to the application also in Startup.Configure() method.
#### Request\Response logger <a name="reqres"></a>
This middleware automatically logs the request values and the response, It can be found [here](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Middleware/RequestResponseLoggingMiddleware.cs)
#### Unhandled Exception middleware <a name="ex"></a>
This [middleware](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Middleware/UnhandledExceptionHandlerMiddleware.cs) will catch any unhandled exceptions, build a custom response and return it so we won't return any secure information just in case someone missed a try\catch.
### Responses <a name="responses"></a>
#### Return types <a name="rettype"></a>
We can now explicitly return the type of the action. In the past, we used to return ActionResult, but now we can explicitly say what the type is, e.g. Task<ActionResult<CustomerSearchMvcResponseModel>>.
### Validators <a name="validators"></a>
#### Custom Validators <a name="customvalidators"></a>
I added a custom validator attribute to showcase how we can pass the existing property we need to validate and anotherproperty value into the validator. The validator code can be found [here](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/CustomValidatorAttributes/ValidLogonAttribute.cs) and is used as follows:

        [DisplayName("Preferred Name")]
        public string PreferredName { get; set; }
        [DisplayName("Logon Name")]
        [ValidLogon("PreferredName", ErrorMessage = "Invalid Logon")]
        public string LogonName { get; set; }
	
As you can see, we are validating the LogonName against the PreferredName. 
#### Remote Validations <a name="remotevalidations"></a>
[Remote validations](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-2.2#remote-attribute) perform an asynchronous call to the server to perform a validation while the client continues to fill out the form. For example, if an email address has to be unique, once they tab away from the input, and continue to fill out the form, an AJAX call is made to make sure the field is not already in use.
The validation code can be found [here](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Controllers/CustomerSearchController.cs) at the end in the PhoneNumberIsUnique() method and is setup as an attribute on the property:

        [Remote("CheckIfEmailAlreadyExists", "Employees", ErrorMessage = "Email already exists")]
        public string EmailAddress { get; set; }
	
The first parameter is the action an the second is the controller.

## JQuery <a name="jquery"></a>

### Closures <a name="closures"></a>
[This](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Views/Closures/Index.cshtml) is the source code. You can see it in action by running the site and selecting Closures from the JQUery menu.

### Promises <a name="promises"></a>
[This](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Views/Promises/Index.cshtml) is the source code. You can see it in action by running the site and selecting Promises from the JQUery menu.

### AJAX calls <a name="ajax"></a>
This demonstrates a simple AJAX call to get some results from an API call. You can look at the code [here](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Views/Address/Create.cshtml) and see it in action by running the site and selecting AJAX from the JQUery menu.

## JQuery UI <a name="jqueryui"></a>

### Drag\Drop <a name="dragdrop"></a>
[This](https://github.com/Alex-Dinu/Demo-Code/blob/master/WebUi/Views/JQueryUI/ShopList.cshtml) code demonstrates the drag\drop features, append, JQuery data and and how to manage JSON data.

## TODO  <a name="todo"></a>
The following section lists additional code I want to add to the solution.
- [Role authorization](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/authoring?view=aspnetcore-2.2)
- [Fluent validations](https://fluentvalidation.net/)
- [SignalR](https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-2.2)
- [Blazer](https://github.com/aspnet/AspNetCore/tree/master/src/Components)
- [Filters](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1)
- [Health Monitoring](https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/implement-resilient-applications/monitor-app-health)

