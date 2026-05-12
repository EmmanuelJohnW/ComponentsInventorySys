# Car Rental Management System

A Windows Forms desktop application built with **C# and .NET 6** for managing car rentals — cars, customers, rental transactions, availability checks, and reports.

![.NET](https://img.shields.io/badge/.NET-6.0-512BD4?logo=dotnet)
![Platform](https://img.shields.io/badge/platform-Windows-0078D6?logo=windows)
![Language](https://img.shields.io/badge/language-C%23-239120?logo=csharp)

---

## Features

| Module | Description |
|---|---|
| **Login** | Credential-protected entry screen |
| **Dashboard** | Live counters for total cars, available cars, customers, and active rentals |
| **Cars** | Add, update, delete, and search cars by plate, brand, or model |
| **Customers** | Add, update, delete, and search customers |
| **Rentals** | Create rental transactions with auto-calculated total amount |
| **Availability** | Check which cars are free for a given date range |
| **Reports** | View all rentals or a revenue summary by date range; export to CSV |

---

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- Windows 10 / 11
- Visual Studio 2022 (recommended) or the `dotnet` CLI

### Run with Visual Studio

1. Open `CarRental.sln`
2. Press **F5** to build and run

### Run with CLI

```bash
dotnet run
```

### Default Login

| Field | Value |
|---|---|
| Username | `admin` |
| Password | `admin123` |

---

## Project Structure

```
CarRental/
├── Program.cs                       # Entry point
├── DataStore.cs                     # In-memory data layer (swap this for a real DB)
├── frmLogin.cs / .Designer.cs       # Login screen
├── frmMain.cs / .Designer.cs        # Main window — menu bar and dashboard
├── frmCars.cs / .Designer.cs        # Car management
├── frmCustomers.cs / .Designer.cs   # Customer management
├── frmRentals.cs / .Designer.cs     # Rental transactions
├── frmAvailability.cs / .Designer.cs # Availability checker
└── frmReports.cs / .Designer.cs     # Reports and CSV export
```

All forms talk exclusively to `DataStore.cs`. Data is held **in memory** and resets when the application closes — see below for how to connect a real database.

---

## Connecting a Real Database

To replace the in-memory store with a persistent database (MS Access, SQL Server, SQLite, etc.):

1. Replace the contents of `DataStore.cs` with your implementation
2. Keep the same **public API** — these are the only calls the forms make:

```csharp
DataStore.Cars                                          // DataTable
DataStore.Customers                                     // DataTable
DataStore.Rentals                                       // DataTable
DataStore.NextCarId()                                   // int
DataStore.NextCustomerId()                              // int
DataStore.NextRentalId()                                // int
DataStore.GetRentalsView(DateTime? from, DateTime? to)  // DataTable
DataStore.GetRevenueSummary(DateTime from, DateTime to) // DataTable
```

No changes are needed in any form file.

### MS Access example connection string

```csharp
string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=carrental.accdb;";
```

> **Note:** MS Access requires the **Microsoft Access Database Engine (ACE OLEDB)** redistributable. Make sure the driver bitness (x86/x64) matches your project's target platform.

---

## Color Theme

| Element | Color |
|---|---|
| Primary (headers, buttons) | `#C0392B` — dark red |
| Background | White |
| Grid lines | `#EEEEEE` |
| Stat card subtext | `#757575` |

---

## License

For academic / internal use.
