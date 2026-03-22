# Project Context: Smart Repair API

## Current Project State
The backend core is established with a robust schema for managing repair services. The API is built with ASP.NET Core 8 and PostgreSQL.

## Last Implemented Features
- **Dynamic CORS**: Implemented environment-based CORS using `ALLOWED_ORIGINS` variable in `Program.cs`.
- **Pagination & Filtering**: Enhanced `RepairsController` to support dynamic `pageSize` (5 or 10) and integrated search/price range filters.
- **Schema Expansion**: Added `Technician` and `RepairHistory` models.
- **DTO Modernization**: Created `TechnicianDto` and `RepairHistoryDto`. Updated `RepairDto` to include `Status`, `Technician`, and `History`.
- **Eager Loading**: Implemented `.Include(r => r.Technician)` and `.Include(r => r.History)` in `RepairsController` to ensure full data synchronization.
- **Consistency**: Renamed `Specialty` to `Specialization` in `TechnicianDto` to match the domain model.
- **AutoMapper**: Updated profiles to handle new DTO mappings.
- **JSON Serialization**: Configured `JsonStringEnumConverter` in `Program.cs` for string-based Enum serialization.
- **PostgreSQL Optimization**: 
    - Configured global mapping for `DateTime` to `timestamp with time zone`.
    - Removed legacy timestamp behavior.
- **Data Seeding**: Implemented `DbSeeder` to populate the database with initial clients, technicians, repairs, and history.
- **Validation**: Added FluentValidation for Client and Repair DTOs.

## Pending Technical Debt or Bugs
- **Authentication/Authorization**: Not yet implemented.
- **Unit Testing**: Core logic and validators need comprehensive test coverage.

## Next Immediate Steps
1. **Phase 4: Dashboard Implementation**: Create the main dashboard to visualize repairs and technician assignments.
2. **Authentication**: Implement JWT-based authentication.

## Infrastructure
- **Frontend:** Vercel (Production: `main`, Staging: `develop`).
  - **Production URL:** `https://smart-repair-ui.vercel.app`
- **API:** Render.com (Web Service).
  - **Production URL:** `https://smart-repair-api-5rrg.onrender.com/api`
  - *Justification:* Render provides a sustainable Free Tier for Web Services, ensuring the portfolio remains live indefinitely without the 30-day expiration of Azure trials. It also preserves the full ASP.NET Core logic (DTOs, AutoMapper, FluentValidation) without requiring a rewrite for serverless architectures.
- **Database:** Supabase (Remote PostgreSQL).
- **Strategy:** Professional hybrid cloud approach leveraging the best-in-class features of each provider.

## Git Flow
- **Main Branch:** Protected, production-ready code.
- **Develop Branch:** Primary integration branch.
- **Feature Branches:** Created from `develop`, merged back via Pull Request.
