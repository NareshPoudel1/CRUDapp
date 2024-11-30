CRUD Application in ASP.NET Core MVC
Project Overview
This is a simple CRUD (Create, Read, Update, Delete) application built using ASP.NET Core MVC and Entity Framework Core. It manages a product inventory stored in a SQL Server database. The application demonstrates essential concepts of .NET development, including MVC architecture, database integration, and asynchronous programming.
________________________________________
Features
Create: Add new products with details like name, price, and quantity.
Read: View a list of all products in a table.
Update: Edit product details.
Delete: Remove products from the inventory.
________________________________________
Technologies Used
Framework: ASP.NET Core MVC
Database: SQL Server (managed via SSMS)
ORM: Entity Framework Core
Language: C#
Tools: Visual Studio, GitHub
________________________________________
Installation and Setup
Prerequisites
.NET SDK: Download and install.
SQL Server: Download and set up SQL Server with SSMS.
Visual Studio: Download and install.
Steps to Run Locally
Clone the repository:
git clone https://github.com/NareshPoudel1/CRUDapp.git
cd CRUDapp
Update Connection String:
Open appsettings.json.
Replace YOUR_SERVER_NAME with your SQL Server instance."ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=CRUDAppDb;Trusted_Connection=True;"
}
Apply Migrations:
App-Migration “Initial Migtation”
Update-Database
Run the application
Access the application: Open your browser and go to https://localhost:7198/Products/List.
________________________________________
Project Structure
Models: Defines data structure (Product model).
Views: Razor views for rendering the UI (List.cshtml, Add.cshtml, Edit.cshtml).
Controllers: Handles user requests (ProductsController).
________________________________________
Sample Screenshots
Product List View: Displays all products in the database.
Add Product Form: Allows users to create new products.
Edit Product Form: Enables updating existing product details.
________________________________________
Key Learning Points
ASP.NET Core MVC: Implementing the MVC pattern for web applications.
Entity Framework Core: Managing database operations with EF Core.
CRUD Operations: Understanding how to perform Create, Read, Update, and Delete.
Asynchronous Programming: Using async/await for better performance.
Dependency Injection: Injecting DbContext for database access.
________________________________________
Contact
For any queries or suggestions, feel free to reach out:
Name: Naresh Poudel
Email: nareshpoudel126@gmail.com
Portfolio: nareshpoudel1.github.io/portfolio

