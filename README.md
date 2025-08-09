
# Employee Management API

This is a clean architecture-based ASP.NET Core Web API for managing employees and departments. The system supports basic CRUD operations with additional features like filtering, sorting, logging, and AutoMapper integration.

---

## 🚀 Setup Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/emanelbaz/EmployeeManagement
   cd EmployeeManagement
   ```

2. **Install dependencies (if needed):**
   - [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

3. **Apply EF Core migrations:**
 
   > Ensure that the `EmployeeManagementAPI` project is set as the startup project.

4. **Run the project:**



## 📁 Folder Structure & Layers

- `EmployeeManagement.Core/`
  - Contains core domain models and interfaces (`IUnitOfWork`, `IRepository`, etc.)

- `EmployeeManagement.EF/`
  - Entity Framework implementation for `DbContext`, migrations, and repositories.

- `EmployeeManagementAPI/`
  - Web API layer (controllers, DI, logging, AutoMapper configs).



## 🔎 Filters, Sorting, and Logs

- **Filtering & Sorting**:
  - Filtering and sorting are implemented in the repository using LINQ expressions.
  - You can filter employees by name, department, etc., using query parameters.

- **LogHistory**:
  - Every time an employee is created and updated, a `LogHistory` record is added with a timestamp and action name.


## 📦 EF Core Migrations (SQL Schema)

- The project uses **Entity Framework Core (Code First)**.
- Migrations are stored in the `/Migrations` folder.
- To apply the schema to your database:
  ```bash
  dotnet ef database update
  ```

- To generate the SQL script manually:
  ```bash
  dotnet ef migrations script -o init.sql
  ```

---

## 🔁 AutoMapper

- AutoMapper is used to map between domain models (`Employee`, `Department`) and DTOs (`EmployeeRequest`, `EmployeeResponse`).
- Mapping configuration is located in `MappingProfile.cs`.

---

## 📌 Assumptions

- The application assumes all employees must belong to a department.



## 📬 Sample API Requests

### ➕ Create Employee
```http
POST /api/Employee
Content-Type: application/json

{
  "name": "Eman Ahmed",
  "email": "eman@test.com",
  "departmentId": 1
}
```

### 🔁 Update Employee
```http
PUT /api/Employee
Content-Type: application/json

{
  "id": 1,
  "name": "Eman Ali",
  "email": "eman.ali@test.com",
  "departmentId": 2
}
```





## 🧑‍💻 Developed With

- .NET 8.0
- Entity Framework Core 9
- AutoMapper
- Clean Architecture principles
