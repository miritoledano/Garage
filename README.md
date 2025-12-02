# Garage Project

This README contains all the steps needed to set up the Garage project on your local machine.

Repository: [https://github.com/miritoledano/Garage.git](https://github.com/miritoledano/Garage.git)

---

## **English Instructions – Step by Step**

### 1. Clone the Repository
Clone the project to your local machine:

```bash
git clone https://github.com/miritoledano/Garage.git
cd Garage
2. Install Dependencies
Install the following NuGet packages via Package Manager Console:

powershell
Copy code
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design   # החבילה שהוספת
Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
Install-Package Serilog.AspNetCore
Install-Package Swashbuckle.AspNetCore

3. Configure Database Connection
Open appsettings.json and update the connection string according to your local SQL Server:

json
Copy code
"ConnectionStrings": {
  "GarageDb": "Data Source=YOUR_SERVER_NAME;Initial Catalog=GarageDb;Integrated Security=True;TrustServerCertificate=True;"
}
⚠️ Replace YOUR_SERVER_NAME with your actual SQL Server name.

4. Scaffold the Database
Run the following command in the Package Manager Console to generate EF models and context:

powershell
Copy code
Scaffold-DbContext "Data Source=YOUR_SERVER_NAME;Initial Catalog=GarageDb;Integrated Security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir EF\Models -ContextDir EF\Contexts -Context GarageContext -Project GarageDb -StartupProject GarageDb -Force
5. Create Database Tables
Execute the included SQL file to create the necessary tables in your database.

6. Run the Project
Open the project in Visual Studio.

Build the solution.

Run the project.

7. Logging
The project uses Serilog for logging. Logs are written to both the console and a file:

bash
Copy code
Logs/log.txt
Logging configuration can be adjusted in appsettings.json.

8. Optional – Swagger
To explore the API using Swagger, navigate to:

bash
Copy code
https://localhost:{PORT}/swagger
