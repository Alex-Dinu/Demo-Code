# Demo Code

The purpose of this repository is to showcase various tools, development principles, solution architecture and the usage of 3rd party tools that demonstrate my experience.

## Download and Run 
In order to run this solution, you would need to:
 1. Install .NETCore 2.2
 2. Install the Wide World Importers database
	2.1 Download the [**WideWorldImporters-Standard.bak**](https://github.com/Microsoft/sql-server-samples/releases/download/wide-world-importers-v1.0/WideWorldImporters-Standard.bak) backup database in order to restore it from this [site](https://github.com/Microsoft/sql-server-samples/releases/tag/wide-world-importers-v1.0).
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
