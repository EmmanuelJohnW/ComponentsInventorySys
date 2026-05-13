# Electronics Inventory System

A Windows Forms desktop application built with **C# and .NET 6** for managing an electronics component inventory — tracking components, projects, and component checkouts.

![.NET](https://img.shields.io/badge/.NET-6.0-512BD4?logo=dotnet)
![Platform](https://img.shields.io/badge/platform-Windows-0078D6?logo=windows)
![Language](https://img.shields.io/badge/language-C%23-239120?logo=csharp)
![Database](https://img.shields.io/badge/database-Supabase-3ECF8E?logo=supabase)

---

## Features

| Module | Description |
|---|---|
| **Login** | Credential-protected entry screen |
| **Dashboard** | Live counters for total components, in-stock, total projects, and active checkouts |
| **Components** | Add, update, delete, and search electronic components by part number, manufacturer, or name |
| **Projects** | Add, update, delete, and search projects that borrow components |
| **Checkouts** | Check out components to a project with date tracking and auto-filled unit cost |
| **Stock Status** | Check which components are available within a given date range |
| **Reports** | View all checkouts or a value summary by date range; export to CSV |

---

## Tech Stack

- **Language:** C# (.NET 6, Windows Forms)
- **Database:** [Supabase](https://supabase.com) (PostgreSQL)
- **Database Driver:** [Npgsql](https://www.npgsql.org/) — the standard .NET PostgreSQL driver

---

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- Windows 10 / 11
- A [Supabase](https://supabase.com) account with a project created

### 1. Clone the repository

```bash
git clone https://github.com/EmmanuelJohnW/ComponentsInventorySys.git
cd ComponentsInventorySys
```

### 2. Set up the database

1. Open your Supabase project dashboard
2. Go to **SQL Editor** → **New query**
3. Paste the contents of `supabase_schema.sql` and click **Run**

This creates three tables: `components`, `projects`, and `checkouts`.

### 3. Configure your connection string

1. Copy the example config file:
   ```
   SupabaseConfig.example.cs  →  SupabaseConfig.cs
   ```
2. Open `SupabaseConfig.cs` and replace the placeholders with your real credentials:
   - Go to Supabase → **Project Settings** → **Database** → **Connection string** → **URI tab**
   - Copy the **Direct connection** string and fill in the `Host` and `Password` fields

> `SupabaseConfig.cs` is listed in `.gitignore` — your credentials will never be committed.

### 4. Run the application

```bash
dotnet run
```

Or open `ElectronicsInventory.sln` in Visual Studio 2022 and press **F5**.

### Default Login

| Field | Value |
|---|---|
| Username | `admin` |
| Password | `admin123` |

---

## Project Structure

```
ComponentsInventorySys/
├── Program.cs                        # Entry point — connects to DB, opens login
├── DataStore.cs                      # Database access layer (Supabase / PostgreSQL)
├── SupabaseConfig.example.cs         # Connection string template (copy → SupabaseConfig.cs)
├── supabase_schema.sql               # SQL to create all tables in Supabase
├── frmLogin.cs / .Designer.cs        # Login screen
├── frmMain.cs / .Designer.cs         # Main window — dashboard and menu bar
├── frmComponents.cs / .Designer.cs   # Component management (CRUD)
├── frmProjects.cs / .Designer.cs     # Project management (CRUD)
├── frmCheckouts.cs / .Designer.cs    # Component checkout form
├── frmStockStatus.cs / .Designer.cs  # Component availability checker
└── frmReports.cs / .Designer.cs      # Reports and CSV export
```

---

## Database Schema

```sql
components  (component_id, part_no, manufacturer, part_name, qty, unit_cost, status)
projects    (project_id, project_name, project_code, lead_name, email)
checkouts   (checkout_id, component_id, project_id, checkout_date, return_date, total_value, status)
```

---

## How the Data Layer Works

All forms talk exclusively to `DataStore.cs`. It uses a two-layer design:

- **In-memory DataTables** — loaded from the database on startup; DataGridViews bind to these for instant UI updates
- **Supabase PostgreSQL** — every Add / Update / Delete writes to the real database first, then mirrors the change in memory

Checkout creation uses a **database transaction** so the checkout record and the component status update always succeed or fail together.

---

## Color Theme

| Element | Color |
|---|---|
| Primary (headers, buttons) | `#1565C0` — dark blue |
| Background | White / `#F0F4F8` |
| In Stock card | `#2E7D32` — green |
| Active Checkouts card | `#B71C1C` — red |

---

## License

For academic / internal use.
