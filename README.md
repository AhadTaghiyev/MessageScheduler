# MessageScheduler.APi
Before starting the application, make sure to configure the connection string. 

Update the appsettings.json file with the correct connection string for your database.

In the appsettings.json file, locate the placeholders for the email secret key and Telegram API key.

Replace these placeholders with the actual email secret key and Telegram API key that you obtained.

Make sure you have the .NET Core SDK installed on your machine

Open a terminal or command prompt and navigate to the MessageScheduler.Data library directory.

Run the following command to apply the database migrations :   dotnet ef database update --startup-project ../MessageScheduler

This command uses the Entity Framework Core CLI tooling (dotnet ef) to apply any pending migrations and update the database schema.

Make sure to include any additional prerequisites or steps specific to your project or database setup in the README, 
such as providing the necessary database connection information in the appsettings.json file before running the migration command.

To run the project and enable automatic code reloading, use the following command: dotnet watch run

This command will start the project and automatically restart it whenever changes are made to the source code.



