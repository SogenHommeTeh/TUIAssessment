# TUIAssessment

This project is an ASP.NET Core application answering the following need:

	A user should be able to enter a new flight which has a departure airport and a destination airport

To launch the application, load the solution `TUI.application.sln` into Visual Studio 2017 and run it.

###### Dependencies

First of all you will need the .Net Core SDK and Runtime using:

	.Net Core 2.0

The data is persisted in a SQLServer database, during the development I used the following version:

	SQLServer Express 14.0.1000 RTM

Once the database set, you must provide a `ConnectionStrings:DefaultConnection` environment variable corresponding to the following format (example for local database):

	Server=<server name>;Database=<database name>;Trusted_Connection=True;

See `appsettings.Development.json` for the example.

# 

Thanks for reading.