# Contact Management API

## Description
The Contact Management API is a RESTful service built with ASP.NET Core Web API that allows users to manage their contacts efficiently. It provides functionalities to create, update, delete, retrieve, and search for contacts in a SQL Server database.

## Technologies Used
- **ASP.NET Core 8** (or your current version)
- **Entity Framework Core**
- **SQL Server**
- **Swagger (OpenAPI)** for API documentation

## Features
- Add new contacts
- Retrieve all contacts
- Get a specific contact by ID
- Update an existing contact
- Soft delete a contact
- Search for contacts by name, email, or phone number

## API Endpoints
### Contact Endpoints
| Method | Endpoint           | Description                      |
|--------|-------------------|----------------------------------|
| GET    | `/api/contact`     | Retrieve all contacts           |
| GET    | `/api/contact/{id}` | Get a contact by ID            |
| POST   | `/api/contact`     | Create a new contact            |
| PUT    | `/api/contact/{id}` | Update an existing contact     |
| DELETE | `/api/contact/{id}` | Soft delete a contact          |
| GET    | `/api/contact/search?query={value}` | Search for contacts by name, email, or phone |

## License
This project is licensed under the MIT License. See the LICENSE file for more details.


