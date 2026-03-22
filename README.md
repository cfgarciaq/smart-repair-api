# Smart Repair API

A high-performance technical management system designed for real-time repair tracking, cost optimization, and client lifecycle management.

## 🚀 Features

- **ASP.NET Core 8**: Modern, fast, and cross-platform.
- **PostgreSQL**: Robust data storage with Supabase.
- **Entity Framework Core**: Powerful ORM for data access.
- **AutoMapper**: Clean DTO mapping.
- **FluentValidation**: Strong validation logic.
- **Dynamic CORS**: Environment-based origin control.
- **Advanced Pagination**: Dynamic page sizes and multi-parameter filtering.

## 🛠️ Setup Guide

### Prerequisites
- .NET 8 SDK
- PostgreSQL (or Supabase account)

### Installation
1. Clone the repository.
2. Configure `appsettings.json` or environment variables:
   - `ConnectionStrings:DefaultConnection`: Your PostgreSQL connection string.
   - `ALLOWED_ORIGINS`: Comma-separated list of allowed origins (e.g., `https://your-ui.vercel.app,http://localhost:5173`).
3. Run migrations:
   ```bash
   dotnet ef database update
   ```
4. Start the API:
   ```bash
   dotnet run
   ```

## 🔗 Links
- **Portfolio:** [cfgarciaq.dev](https://cfgarciaq.dev)
- **LinkedIn:** [linkedin.com/in/cfgarciaq](https://www.linkedin.com/in/cfgarciaq/)
- **Frontend Repo:** [smart-repair-ui](https://github.com/cfgarciaq/smart-repair-ui)

## 📄 License
MIT
