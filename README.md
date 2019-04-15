# Demo Code
https://stackedit.io/app#
The purpose of this repository is to showcase various tools, development principles, solution architecture and the usage of 3rd party tools that demonstrate my experience.

## Download and Run 
In order to run this solution, you would need to:
 1. Install .NETCore 2.2
 2. Install the Wide World Importers database
	2.1 Download the [**WideWorldImporters-Standard.bak**](https://github.com/Microsoft/sql-server-samples/releases/download/wide-world-importers-v1.0/WideWorldImporters-Standard.bak) backup database in order to restore it from this [site](https://github.com/Microsoft/sql-server-samples/releases/tag/wide-world-importers-v1.0).
3. Compile the application stored procedures in Infrastructure.Database.SQL.StoredProcedures
 3. Update the EFCore connection string in the appsettings file.

## Technologies and tools
### Architecture
Although the solution is not strictly [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html), it does implement the basic principles. I did take some shortcuts in order to make it easier to follow and try it out.

### .NET Core tools and packages
#### Logger
I use [Serilog](https://serilog.net/) in order to help me log information and errors in JSON format in a daily rolling file with a max size.

The Infrastructure.Log project does it all. It is referenced by each project that requires to log something. I set up some properties in Startup.cs in a private AddSerilogServices() method.

The following NugetPackages are used:

 - Serilog.Exceptions which makes it easier to log exceptions and their properties.
 - Serilog.Settings.Configuration is used to read some configuration settings
 - Serilog.Sinks.Async is used to log asynchronously
 - Serilog.Sinks.RollingFile allows me to easily setup the rolling log file.



Notice that we are sending a parameter type to the logger methods. This allows us to send in as many parameters as are needed to be logged as illustrated by the following interface contract:

    void LogError(Exception ex, params object[] data);

#### Entity Framework Core
Being a .NETCore solution, EFCore is being used.
#### AutoMapper
AutoMapper is a library I use to map the different data objects that are passed between the different layers in Clean Architecture solution.
Mapper rules are setup in WebUi.Shared.DataMapper class and is added as a service in Startup.cs.
#### XUnit
I use XUnit to run my tests.

### MVC
#### Return types
We can now explicitly return the type of the action. In the past, we used to return ActionResult, but now we can explicitly say what the type is, e.g. Task<ActionResult<CustomerSearchMvcResponseModel>>.
	
#### Custom Validators
I added a custom validator attribute to showcase how we can pass the existing property we need to validate and anotherproperty value into the validator. The validator code can be found in WebUi.CustomValidatorAttributes.ValidLogonAttribute and is used as follows:

        [DisplayName("Preferred Name")]
        public string PreferredName { get; set; }
        [DisplayName("Logon Name")]
        [ValidLogon("PreferredName", ErrorMessage = "Invalid Logon")]
        public string LogonName { get; set; }
	
As you can see, we are validating the LogonName against the PreferredName. 
#### Remote Validations
[Remote validations](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-2.2#remote-attribute) perform an asynchronous call to the server to perform a validation while the client continues to fill out the form. For example, if an email address has to be unique, once they tab away from the input, and continue to fill out the form, an AJAX call is made to make sure the field is not already in use.
The validation code can be found in EmployeeManagement.Controllers.EmployeesController.CheckIfEmailAlreadyExists() method and is setup as an attribute on the property:

        [Remote("CheckIfEmailAlreadyExists", "Employees", ErrorMessage = "Email already exists")]
        public string EmailAddress { get; set; }
	
The first parameter is the action an the second is the controller.




