# Hearings API (Backend)

The Hearings API is a backend service built with .NET Core, providing a robust solution for managing hearings data. This API allows users to perform CRUD operations on hearings, including retrieving, adding, updating, and deleting hearing records. Below, you'll find detailed information about setting up and utilizing the backend API.

## Technologies Used

- **ASP.NET Core MVC**: The web framework used for building the API.
- **Entity Framework Core**: ORM used for interacting with the SQL Server database.
- **SQL Server**: Database for storing and managing hearings data.
- **Swagger**: API documentation tool for testing and exploring the API endpoints.

## Setup

1. **Clone the repository:**

   ```bash
   git clone https://github.com/DDFaller/HearingsApi.git
   cd HearingsApi
   ```

## Run the application

```bash
   dotnet run
   ```

## API Endpoints
- GET /Hearings/Get: Retrieve a list of hearings from a JSON file.
- GET /Hearings/GetFromDB: Retrieve a list of hearings from the SQL Server database.
- GET /Hearings/{processNumber}: Retrieve a specific hearing by process number.
- POST /Hearings/AddToDB: Add a new hearing to the SQL Server database.
- PUT /Hearings/UpdateInDB/{processNumber}: Update an existing hearing in the SQL Server database.
- DELETE /Hearings/DeleteFromDB/{processNumber}: Delete a hearing from the SQL Server database.