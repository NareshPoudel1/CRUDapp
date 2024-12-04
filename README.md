CRUD Application in ASP.NET Core MVC
Project Overview
This is a simple CRUD (Create, Read, Update, Delete) application built using ASP.NET Core MVC and Entity Framework Core. It manages a product inventory stored in a SQL Server database. The application demonstrates essential concepts of .NET development, including MVC architecture, database integration, asynchronous programming, and the use of Dependency Injection (DI) for improved design and testability.
________________________________________
Features
•	Create: Add new products with details like name, price, and quantity.
•	Read: View a list of all products in a table.
•	Update: Edit product details.
•	Delete: Remove products from the inventory.
________________________________________
Technologies Used
•	Framework: ASP.NET Core MVC
•	Database: SQL Server (managed via SSMS)
•	ORM: Entity Framework Core
•	Language: C#
•	Tools: Visual Studio, GitHub
________________________________________
Installation and Setup
Prerequisites
•	.NET SDK: Download and install.
•	SQL Server: Download and set up SQL Server with SSMS.
•	Visual Studio: Download and install.
Steps to Run Locally
1.	Clone the repository:
2.	git clone https://github.com/NareshPoudel1/CRUDapp.git
3.	cd CRUDapp


4.	Update Connection String:
•Open appsettings.json.
•Replace YOUR_SERVER_NAME with your SQL Server instance: 
•"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=CRUDAppDb;Trusted_Connection=True;}
5.	Apply Migrations:
•Open the Package Manager Console and run: 
•Add-Migration "InitialMigration"
•Update-Database
6.	Run the Application:
•Start the project in Visual Studio.
•Access the application in your browser.
________________________________________
Project Structure
•	Models: Defines the data structure (Product model).
•	Services: Contains ProductServices which handles all business logic and database operations.
•	Views: Razor views for rendering the UI (List.cshtml, Add.cshtml, Edit.cshtml).
•	Controllers: Handles user requests (ProductsController).
________________________________________
Key Learning Points
•	ASP.NET Core MVC: Implementing the MVC pattern for web applications.
•	Entity Framework Core: Managing database operations with EF Core.
•	CRUD Operations: Understanding how to perform Create, Read, Update, and Delete.
•	Asynchronous Programming: Using async/await for better performance.
•	Dependency Injection (DI): Using DI to decouple ProductsController from ApplicationDbContext for improved testability and maintainability.
________________________________________


Before Introducing IProductServices
•	Dependency:
The ProductsController directly depended on ApplicationDbContext.
________________________________________
After Introducing IProductServices
•	Dependency:
The ProductsController now depends on the IProductServices interface, which abstracts the business logic.
________________________________________

