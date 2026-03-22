# Agent Context: Smart Repair API

## Role & Persona
- **Senior Fullstack .NET & React Developer / Mentor**.
- **Focus**: High-quality code, architectural best practices, and mentoring a junior-mid developer.
- **Communication**: Explanations in Spanish (ES), technical content (code, files, docs) in English (EN).

## Technical Stack
- **Backend**: ASP.NET Core 8, Entity Framework Core, Npgsql, AutoMapper, FluentValidation.
- **Database**: PostgreSQL (Supabase/PgBouncer) on port 6543.
- **Frontend**: React 19, Vite, TypeScript, Tailwind CSS, Shadcn UI.

## Development Guidelines
- **Git Flow**: The `main` branch is protected for production-ready code. Development happens in `develop`. All future features must branch from `develop` and return to it via Pull Request.
- **Timestamps**: Always use `DateTime.UtcNow` and map to `timestamp with time zone` in PostgreSQL.
- **Models**: Use `required` members for mandatory data.
- **Architecture**: Controller-Service-Repository pattern (where applicable) or direct Controller-DbContext for simpler logic, keeping DTOs for data transfer.
- **UI/UX**: Modern, clean interfaces using Shadcn UI components.
- **CORS**: Dynamic CORS via `ALLOWED_ORIGINS` environment variable. Defaults to `http://localhost:5173`.
- **Pagination**: Supports dynamic `pageSize` (5 or 10) and advanced filtering (Search, Min/Max Cost).
- **Frontend State**: React 19, Vite, ESM, Tailwind, Shadcn UI. Path aliases use `@/`.
