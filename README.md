# E-Commerce Project

This project is an e-commerce platform consisting of both a backend ASP.NET Core Web API and a frontend Vue.js application.

## Backend (E-Commerce API)

This ASP.NET Core Web API provides endpoints for managing products, brands, categories, users, carts, and cart items.

### Features

- **Products**: CRUD operations for managing products.
- **Brands**: CRUD operations for managing brands.
- **Categories**: CRUD operations for managing categories.
- **Users**: CRUD operations for managing users.
- **Carts**: CRUD operations for managing carts.
- **Cart Items**: CRUD operations for managing cart items.

### Technologies Used

- ASP.NET Core 3.1
- Entity Framework Core
- SQL Server
- AutoMapper
- Swagger UI

### Getting Started

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Configure the connection string in `appsettings.json` to point to your SQL Server instance.
4. Run the Entity Framework Core migrations to create the database schema: `dotnet ef database update`.
5. Run the application. It will launch the API, and you can start making requests.

### API Documentation

The API documentation is available using Swagger UI. After running the application, navigate to `https://localhost:<port>/swagger` to view and test the API endpoints.

## Frontend

This Vue.js application serves as the frontend for the e-commerce platform.

### Project setup
npm install

### Compiles and hot-reloads for development
npm run serve
Compiles and minifies for production


npm run build

### Contributing
Contributions are welcome! If you find any issues or have suggestions for improvements, feel free to open an issue or create a pull request.

### License
This project is licensed under the MIT License - see the LICENSE file for details.

## Screenshots

![Screenshot 2024-05-28 153156](https://github.com/naordabush/ecommerce-csharp-vue.js/assets/65256155/6248f8b3-f473-4a4d-a5fc-d2bb6d5fc749)

![Screenshot 2024-05-28 153148](https://github.com/naordabush/ecommerce-csharp-vue.js/assets/65256155/41747790-8953-4cd0-8350-d565dc79fb99)

![Screenshot 2024-05-28 153250](https://github.com/naordabush/ecommerce-csharp-vue.js/assets/65256155/fd0391aa-841d-4c81-a682-62f5dc5139ba)

![Screenshot 2024-05-28 153301](https://github.com/naordabush/ecommerce-csharp-vue.js/assets/65256155/9d29500f-1871-45ea-be75-2709876ed020)












