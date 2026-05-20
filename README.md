# Book Store Web App

A modern web application for managing and browsing a collection of books. This project provides a user-friendly interface for customers to explore books and manage their collections.

## 📋 Project Summary

The Book Store Web App is a full-stack web application designed to provide an intuitive platform for book browsing and management. Built with ASP.NET Core, the application features a responsive interface with a clean separation between the backend logic and frontend presentation.

## 🛠 Tech Stack

- **Backend:** ASP.NET Core (C#) - 53.5%
- **Frontend:** HTML - 43.2%
- **Styling:** CSS - 2.8%
- **Scripting:** JavaScript - 0.5%
- **Database:** Entity Framework Core (Data Access Layer)
- **Project Format:** ASP.NET Core Solution (.sln)

## 📁 Project Structure

```
Book-Store-Web-App/
├── Data/                 # Database context and data access layer
├── Models/               # Data models and business entities
├── Pages/                # Razor pages for server-side rendering
├── Migrations/           # Entity Framework Core database migrations
├── Properties/           # Project configuration and build settings
├── wwwroot/              # Static files (CSS, JavaScript, images)
├── BookStore.sln         # Solution file
├── BookStore.csproj      # Project configuration
└── README.md             # This file
```

## 🚀 Getting Started

### Prerequisites

Before you begin, ensure you have the following installed on your system:

- **.NET SDK** (6.0 or higher) - [Download here](https://dotnet.microsoft.com/download)
- **Git** - [Download here](https://git-scm.com/)
- **Visual Studio** (optional but recommended) or any code editor

### Clone the Repository

```bash
git clone https://github.com/Feawos/Book-Store-Web-App.git
cd Book-Store-Web-App
```

### Installation

1. **Restore NuGet Packages**
   ```bash
   dotnet restore
   ```

2. **Build the Project**
   ```bash
   dotnet build
   ```

3. **Apply Database Migrations** (if applicable)
   ```bash
   dotnet ef database update
   ```

### Running the Application

#### Using .NET CLI

```bash
dotnet run
```

The application will start and be accessible at `https://localhost:5001` (or `http://localhost:5000` depending on your configuration).

#### Using Visual Studio

1. Open `BookStore.sln` in Visual Studio
2. Press `F5` or click the **Start** button
3. The application will launch in your default browser

## 📚 Features

- Browse and search for books
- View book details
- Manage book collections
- Responsive design for desktop and mobile devices
- Clean and intuitive user interface

## 🛠 Development

### Building for Development

```bash
dotnet build
```

### Building for Production

```bash
dotnet publish -c Release
```

The production-ready files will be in the `bin/Release/net6.0/publish` directory.

## 📝 Database Setup

If this project uses a database, migrations are included in the `Migrations/` directory. To set up the database:

```bash
dotnet ef database update
```

To add a new migration after model changes:

```bash
dotnet ef migrations add MigrationName
```

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📄 License

This project is open source and available under the MIT License (or your chosen license).

## 👨‍💻 Author

**Feawos** - [GitHub Profile](https://github.com/Feawos)

## 📞 Support

If you encounter any issues or have questions about the project, please open an [issue](https://github.com/Feawos/Book-Store-Web-App/issues) on GitHub.

---

**Last Updated:** May 2025
