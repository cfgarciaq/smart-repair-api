# Smart Repair API

[ 🇪🇸 Castellano ](#castellano) | [ 🇺🇸 English ](#english) | [ 🇫🇷 Français ](#français)

---

<a name="castellano"></a>
## 🇪🇸 Castellano

Sistema de gestión técnica de alto rendimiento diseñado para el seguimiento de reparaciones en tiempo real, optimización de costes y gestión del ciclo de vida del cliente.

### Características
- **ASP.NET Core 8**: API REST moderna, rápida y multiplataforma.
- **PostgreSQL & Supabase**: Almacenamiento de datos robusto con seguridad Row Level Security (RLS).
- **Búsqueda Avanzada**: Filtrado no sensible a mayúsculas (case-insensitive) por dispositivo, descripción, nombre de cliente y técnico.
- **Ordenación Dinámica**: Soporte para ordenación ascendente y descendente en todas las columnas principales.
- **Infraestructura**: Control de CORS dinámico y paginación ajustable mediante variables de entorno.

### Guía de Configuración
1. Clonar el repositorio.
2. Configurar variables de entorno:
   - `ConnectionStrings__DefaultConnection`: Cadena de conexión a PostgreSQL.
   - `ALLOWED_ORIGINS`: Lista de dominios permitidos separada por comas.
3. Aplicar migraciones: `dotnet ef database update`.
4. Ejecutar: `dotnet run`.

---

<a name="english"></a>
## 🇺🇸 English

High-performance technical management system designed for real-time repair tracking, cost optimization, and client lifecycle management.

### Key Features
- **ASP.NET Core 8**: Modern, fast, and cross-platform REST API.
- **PostgreSQL & Supabase**: Robust data storage with Row Level Security (RLS).
- **Advanced Search**: Case-insensitive filtering across devices, descriptions, client names, and technicians.
- **Dynamic Sorting**: Support for ascending and descending order on all main columns.
- **Infrastructure**: Dynamic CORS control and adjustable pagination via environment variables.

### Setup Guide
1. Clone the repository.
2. Configure environment variables:
   - `ConnectionStrings__DefaultConnection`: PostgreSQL connection string.
   - `ALLOWED_ORIGINS`: Comma-separated list of allowed domains.
3. Apply migrations: `dotnet ef database update`.
4. Run: `dotnet run`.

---

<a name="français"></a>
## 🇫🇷 Français

Système de gestion technique haute performance conçu pour le suivi des réparations en temps réel, l'optimisation des coûts et la gestion du cycle de vie des clients.

### Caractéristiques Principales
- **ASP.NET Core 8** : API REST moderne, rapide et multiplateforme.
- **PostgreSQL & Supabase** : Stockage de données robuste avec sécurité Row Level Security (RLS).
- **Recherche Avancée** : Filtrage insensible à la casse par appareil, description, nom du client et technicien.
- **Tri Dynamique** : Support du tri ascendant et descendant sur toutes las colonnes principales.
- **Infrastructure** : Contrôle dynamique du CORS et pagination ajustable via variables d'environnement.

### Guide de Configuration
1. Cloner le dépôt.
2. Configurer les variables d'environnement :
   - `ConnectionStrings__DefaultConnection` : Chaîne de connexion PostgreSQL.
   - `ALLOWED_ORIGINS` : Liste de domaines autorisés séparée par des virgules.
3. Appliquer les migrations : `dotnet ef database update`.
4. Lancer : `dotnet run`.

---

## Links / Liens
- **Portfolio:** [cfgarciaq.dev](https://cfgarciaq.dev)
- **LinkedIn:** [linkedin.com/in/cfgarciaquiroga](https://www.linkedin.com/in/cfgarciaquiroga/)
- **Frontend Repo:** [smart-repair-ui](https://github.com/cfgarciaq/smart-repair-ui)

---