# .NET & API Conventions

## Architecture
- Follow the **Controller-Service-Repository** pattern for complex logic.
- Use direct **Controller-DbContext** for simple CRUD operations to avoid over-engineering.
- Keep **DTOs** (Data Transfer Objects) strictly separated from Domain Models.

## Models & Data
- Use `required` members for mandatory data in models and DTOs.
- **Timestamps**: Always use `DateTime.UtcNow` and map to `timestamp with time zone` in PostgreSQL.
- Database: PostgreSQL (Supabase/PgBouncer) on port 6543.

## API Design
- Use **FluentValidation** for all incoming DTOs.
- Use **AutoMapper** for entity-DTO mapping.
- **CORS**: Dynamic CORS via `ALLOWED_ORIGINS` environment variable.
- **Pagination**: Support dynamic `pageSize` (5, 10, 20) and advanced filtering.
