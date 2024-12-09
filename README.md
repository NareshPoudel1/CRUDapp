CRUDapp
A simple CRUD application for managing products, developed using ASP.NET Core MVC. The application demonstrates different approaches for implementing CRUD operations, including the use of dependency injection and stored procedures.

Branches Overview
master Branch
This branch contains the basic CRUD operations implemented in the controller directly, interacting with the database using ApplicationDbContext.
Key files in this branch:
1.	Controllers/ProductsController.cs
o	Handles HTTP requests for adding, editing, deleting, and listing products.
o	Directly uses ApplicationDbContext for database operations.
2.	Models/Entities/Product.cs
o	Represents the Product entity with properties such as Id, Name, Price, and Quantity.
3.	Models/AddProductViewModel.cs
o	A ViewModel used for adding new products.
4.	Views/
o	Contains Razor views for displaying and interacting with the product data (Add, Edit, List).

feat/DI Branch
This branch updates the code to use Dependency Injection.
Key additions in this branch:
1.	Services/IProductServices.cs
o	Interface defining the methods for CRUD operations (GetAllProducts, GetProductById, AddProduct, UpdateProduct, DeleteProduct).
2.	Services/ProductServices.cs
o	Implements the IProductServices interface and contains the actual logic for interacting with the database.
3.	Controllers/ProductsController.cs
o	Refactored to use IProductServices instead of directly interacting with ApplicationDbContext.
________________________________________
feat/storedprocedure Branch
This branch contains stored procedure code for CRUD operations.
Key additions in this branch:
1.	Services/ProductServicesStoredProcedure.cs
o	Implements IProductServices using stored procedures for database operations.
2.	Stored Procedures (in SQL Server):
o	SpGetAllProducts – Retrieves all products from the database.
o	SpGetProductById – Retrieves a product by its ID.
o	SpAddProduct – Adds a new product to the database.
o	SpUpdateProduct – Updates an existing product in the database.
o	SpDeleteProduct – Deletes a product from the database.
3.	Controllers/ProductsController.cs
o	Updated to use ProductServicesStoredProcedure for CRUD operations.

Setup Instructions
1.	Clone the Repository
git clone <repository-url>,cd CRUDapp
2.	Switch Between Branches
o	To view the basic CRUD operations:
git checkout master
o	To view the DI implementation:
git checkout feat/DI
o	To view the stored procedure implementation:
git checkout feat/storedprocedure
3.	Update Database Connection
o	Update the connection string in appsettings.json to match your SQL Server configuration.



4.	Apply Migrations
Add -Migration
Update -Database
5.	Run the Application

Folder and File Overview
Controllers/
•	ProductsController.cs
Handles HTTP requests for product management. The implementation changes across branches to demonstrate different approaches (direct DBContext, DI, stored procedures).
Models/Entities/
•	Product.cs
Represents the product table in the database with properties like Id, Name, Price, and Quantity.
Models/
•	AddProductViewModel.cs
A ViewModel used for passing data from the view to the controller when adding a new product.
Services/
•	IProductServices.cs
Interface defining CRUD methods for product management (added in feat/DI branch).
•	ProductServices.cs
Implements IProductServices using ApplicationDbContext for database operations (added in feat/DI branch).
•	ProductServicesStoredProcedure.cs
Implements IProductServices using stored procedures for database operations (added in feat/storedprocedure branch).

