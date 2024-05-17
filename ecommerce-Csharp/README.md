# E-Commerce API

This project is an ASP.NET Core Web API for an e-commerce platform. It provides endpoints for managing products, brands, categories, users, carts, and cart items.

## Features

- **Products**: CRUD operations for managing products, including listing, creating, updating, and deleting.
- **Brands**: CRUD operations for managing brands, including listing, creating, updating, and deleting.
- **Categories**: CRUD operations for managing categories, including listing, creating, updating, and deleting.
- **Users**: CRUD operations for managing users, including listing, creating, updating, and deleting.
- **Carts**: CRUD operations for managing carts, including listing, creating, updating, and deleting.
- **Cart Items**: CRUD operations for managing cart items, including listing, creating, updating, and deleting.

## Technologies Used

- ASP.NET Core 3.1: The framework used for building the Web API.
- Entity Framework Core: The ORM used for database operations.
- SQL Server: The database management system used for storing data.
- AutoMapper: A library used for object-object mapping.
- Swagger UI: Used for API documentation and testing.

## Getting Started

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Configure the connection string in `appsettings.json` to point to your SQL Server instance.
4. Run the Entity Framework Core migrations to create the database schema: `dotnet ef database update`.
5. Run the application. It will launch the API and you can start making requests.

## API Documentation

The API documentation is available using Swagger UI. After running the application, navigate to `https://localhost:<port>/swagger` to view and test the API endpoints.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, feel free to open an issue or create a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
