# SQL Server Docker Setup

This project uses Docker Compose to run SQL Server on macOS.

## Quick Start

1. **Start SQL Server:**
   ```bash
   docker-compose up -d
   ```

2. **Verify it's running:**
   ```bash
   docker-compose ps
   ```

3. **Stop SQL Server:**
   ```bash
   docker-compose down
   ```

## Connection Details

- **Server:** localhost,1433
- **User:** sa
- **Password:** YourStrongPassword123!
- **Database:** (create your own database, e.g., VideoGameDb)

## Creating a Database

Connect using SQL Server Management Studio, Azure Data Studio, or sqlcmd:

```bash
# Using sqlcmd in the container
docker exec -it videogame-sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P YourStrongPassword123!

-- Then run:
CREATE DATABASE VideoGameDb;
GO
USE VideoGameDb;
GO
-- Create your tables here
```

## Environment Variables

- `SA_PASSWORD`: Change this to your preferred strong password
- `MSSQL_PID`: Express (free) or Developer (full-featured)

## Data Persistence

Database files are stored in a Docker volume named `sqlserver_data` and will persist across container restarts.
