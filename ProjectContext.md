# Project Context: Smart Repair API

## Current Project State
The backend core is established with a robust schema for managing repair services. The API is built with ASP.NET Core 8 and PostgreSQL.

## Last Implemented Features
- **Enhanced Search & Sorting**: Implemented case-insensitive search across Device, Description, Client Name, and Technician Name. Added support for sorting by Client and Technician names.
- **Dynamic CORS**: Implemented environment-based CORS using `ALLOWED_ORIGINS` variable in `Program.cs`.
- **Pagination & Filtering**: Enhanced `RepairsController` to support dynamic `pageSize` (5 or 10) and integrated search/price range filters.
- **Schema Expansion**: Added `Technician` and `RepairHistory` models.
- **DTO Modernization**: Created `TechnicianDto` and `RepairHistoryDto`. Updated `RepairDto` to include `Status`, `Technician`, and `History`.
- **Eager Loading**: Implemented `.Include(r => r.Technician)` and `.Include(r => r.History)` in `RepairsController` to ensure full data synchronization.
- **Data Seeding**: Implemented `DbSeeder` to populate the database with initial clients, technicians, repairs, and history.
- **Validation**: Added FluentValidation for Client and Repair DTOs.
- **Multilingual README**: Added support for Spanish, English, and French.
- **CRUD Implementation (feature/crud-imp)**:
  - Implemented `DeleteRepair` endpoint in `RepairsController`.
  - Created `TechniciansController` to provide technician data.
  - Added `api/clients/all` endpoint for non-paginated client lists.
  - Refactored `Agents.md` into a modular structure with specialized conventions in `docs/conventions/`.

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
- **Database:** Supabase (Remote PostgreSQL).

## Git Flow
- **Main Branch:** Protected, production-ready code.
- **Develop Branch:** Primary integration branch.
- **Feature Branches:** Created from `develop`, merged back via Pull Request.
- **API:** Render.com (Web Service).
  - *Justification:* Render provides a sustainable Free Tier for Web Services, ensuring the portfolio remains live indefinitely without the 30-day expiration of Azure trials. It also preserves the full ASP.NET Core logic (DTOs, AutoMapper, FluentValidation) without requiring a rewrite for serverless architectures.
- **Database:** Supabase (Remote PostgreSQL).
- **Strategy:** Professional hybrid cloud approach leveraging the best-in-class features of each provider.
