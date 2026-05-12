using System.Data;
using Npgsql;

namespace ElectronicsInventory;

// ============================================================
// DataStore.cs  –  Database Access Layer (Supabase / PostgreSQL)
// ============================================================
// This is the central data layer for the entire application.
// Every form goes through DataStore to read or write data —
// no form talks to the database directly.
//
// HOW IT WORKS (Two-Layer Design):
//   Layer 1 – In-Memory DataTables (Components, Projects, Checkouts)
//     These are plain .NET DataTable objects held in RAM.
//     The DataGridViews on every form are bound to these tables,
//     so any change here instantly updates the on-screen grid
//     without the form needing extra refresh logic.
//
//   Layer 2 – Supabase PostgreSQL Database (cloud)
//     Every Add / Update / Delete operation first writes to the
//     real database, then mirrors the change in the DataTable.
//     This means the in-memory data always matches the database.
//
// STARTUP:
//   Call DataStore.Initialize() once (done in Program.cs).
//   It runs SELECT queries to load all rows from the database
//   into the three DataTables before any form opens.
//
// DATABASE LIBRARY USED:
//   Npgsql — the standard .NET driver for PostgreSQL.
//   It is installed as a NuGet package (see ElectronicsInventory.csproj).
//   We use "parameterized queries" (@param) everywhere to prevent
//   SQL injection attacks (never build SQL strings from user input).
//
// TABLE OVERVIEW:
//   components  → electronic parts inventory
//   projects    → groups / teams that borrow components
//   checkouts   → records of components borrowed by projects
// ============================================================

public static class DataStore
{
    // ----------------------------------------------------------
    // In-Memory DataTables
    // ----------------------------------------------------------
    // These are populated by Initialize() and kept in sync by
    // every Add / Update / Delete method below.
    // Forms bind their DataGridViews to these tables directly:
    //   dgvComponents.DataSource = DataStore.Components.DefaultView;
    // ----------------------------------------------------------

    public static DataTable Components { get; } = MakeComponentsTable();
    public static DataTable Projects   { get; } = MakeProjectsTable();
    public static DataTable Checkouts  { get; } = MakeCheckoutsTable();

    // ----------------------------------------------------------
    // Initialize  –  Load all data from Supabase on app startup
    // ----------------------------------------------------------
    // Called once in Program.cs before the login window opens.
    // Runs three SELECT queries and fills the DataTables.
    // If the database is unreachable, this throws an exception
    // which Program.cs catches and shows to the user.
    // ----------------------------------------------------------
    public static void Initialize()
    {
        LoadComponents();
        LoadProjects();
        LoadCheckouts();
    }

    // ----------------------------------------------------------
    // OpenConnection  –  Creates and opens a database connection
    // ----------------------------------------------------------
    // Every CRUD method calls this helper to get a live connection.
    // The "using" keyword in the callers ensures each connection
    // is automatically closed and disposed after use, preventing
    // connection leaks.
    // ----------------------------------------------------------
    private static NpgsqlConnection OpenConnection()
    {
        var conn = new NpgsqlConnection(SupabaseConfig.ConnectionString);
        conn.Open(); // Opens the TCP connection to Supabase.
        return conn;
    }

    // ----------------------------------------------------------
    // Load methods  –  SELECT all rows from each table
    // ----------------------------------------------------------

    private static void LoadComponents()
    {
        Components.Rows.Clear(); // Wipe existing in-memory data first.

        using var conn = OpenConnection();
        using var cmd  = new NpgsqlCommand(
            "SELECT component_id, part_no, manufacturer, part_name, qty, unit_cost, status " +
            "FROM components ORDER BY component_id", conn);

        using var reader = cmd.ExecuteReader(); // Runs the SELECT query.

        // Read one row at a time and add it to the in-memory DataTable.
        while (reader.Read())
            Components.Rows.Add(
                reader.GetInt32(0),   // component_id
                reader.GetString(1),  // part_no
                reader.GetString(2),  // manufacturer
                reader.GetString(3),  // part_name
                reader.GetInt32(4),   // qty
                reader.GetDecimal(5), // unit_cost
                reader.GetString(6)); // status

        Components.AcceptChanges(); // Marks all rows as unchanged (clean state).
    }

    private static void LoadProjects()
    {
        Projects.Rows.Clear();

        using var conn = OpenConnection();
        using var cmd  = new NpgsqlCommand(
            "SELECT project_id, project_name, project_code, lead_name, email " +
            "FROM projects ORDER BY project_id", conn);

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
            Projects.Rows.Add(
                reader.GetInt32(0),                             // project_id
                reader.GetString(1),                            // project_name
                reader.GetString(2),                            // project_code
                reader.IsDBNull(3) ? "" : reader.GetString(3), // lead_name (optional)
                reader.IsDBNull(4) ? "" : reader.GetString(4)); // email (optional)
        // IsDBNull checks for NULL values in the database — optional fields
        // are stored as NULL and we convert them to empty strings for display.

        Projects.AcceptChanges();
    }

    private static void LoadCheckouts()
    {
        Checkouts.Rows.Clear();

        using var conn = OpenConnection();
        using var cmd  = new NpgsqlCommand(
            "SELECT checkout_id, component_id, project_id, checkout_date, return_date, total_value, status " +
            "FROM checkouts ORDER BY checkout_id", conn);

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
            Checkouts.Rows.Add(
                reader.GetInt32(0),    // checkout_id
                reader.GetInt32(1),    // component_id (foreign key → components)
                reader.GetInt32(2),    // project_id   (foreign key → projects)
                reader.GetDateTime(3), // checkout_date
                reader.GetDateTime(4), // return_date
                reader.GetDecimal(5),  // total_value
                reader.GetString(6));  // status

        Checkouts.AcceptChanges();
    }

    // ----------------------------------------------------------
    // DataTable Definitions  –  Column schemas
    // ----------------------------------------------------------
    // These mirror the columns in the Supabase database tables.
    // The column names here must match exactly what the forms
    // use when reading cells (e.g. row.Cells["PartNo"]).
    // ----------------------------------------------------------

    private static DataTable MakeComponentsTable()
    {
        var t = new DataTable();
        t.Columns.Add("ComponentID",  typeof(int));      // Unique ID (from database SERIAL)
        t.Columns.Add("PartNo",       typeof(string));   // e.g. "ATM328P-AU"
        t.Columns.Add("Manufacturer", typeof(string));   // e.g. "Microchip Technology"
        t.Columns.Add("PartName",     typeof(string));   // e.g. "ATmega328P"
        t.Columns.Add("Qty",          typeof(int));      // Units in stock
        t.Columns.Add("UnitCost",     typeof(decimal));  // Cost per unit
        t.Columns.Add("Status",       typeof(string));   // "In Stock" | "Checked Out" | "Defective"
        return t;
    }

    private static DataTable MakeProjectsTable()
    {
        var t = new DataTable();
        t.Columns.Add("ProjectID",   typeof(int));     // Unique ID (from database SERIAL)
        t.Columns.Add("ProjectName", typeof(string));  // e.g. "Line Following Robot"
        t.Columns.Add("ProjectCode", typeof(string));  // Unique code e.g. "PRJ-2024-001"
        t.Columns.Add("LeadName",    typeof(string));  // Project lead's name
        t.Columns.Add("Email",       typeof(string));  // Contact email
        return t;
    }

    private static DataTable MakeCheckoutsTable()
    {
        var t = new DataTable();
        t.Columns.Add("CheckoutID",   typeof(int));       // Unique ID (from database SERIAL)
        t.Columns.Add("ComponentID",  typeof(int));       // Links to Components.ComponentID
        t.Columns.Add("ProjectID",    typeof(int));       // Links to Projects.ProjectID
        t.Columns.Add("CheckoutDate", typeof(DateTime));  // Date the component was borrowed
        t.Columns.Add("ReturnDate",   typeof(DateTime));  // Expected return date
        t.Columns.Add("TotalValue",   typeof(decimal));   // Component cost at checkout time
        t.Columns.Add("Status",       typeof(string));    // "Checked Out"
        return t;
    }

    // ----------------------------------------------------------
    // Components CRUD
    // ----------------------------------------------------------
    // CRUD = Create, Read, Update, Delete — the four basic
    // database operations.
    //
    // Each method:
    //   1. Sends the SQL command to the Supabase database.
    //   2. Mirrors the change in the in-memory DataTable so the
    //      DataGridView on screen updates immediately.
    //
    // We use "@param" placeholders (parameterized queries) instead
    // of building SQL strings like "... WHERE id = " + id.
    // This is a security best practice that prevents SQL injection.
    // ----------------------------------------------------------

    /// <summary>
    /// Inserts a new component into the database and the in-memory table.
    /// Returns the new component's ID generated by the database.
    /// </summary>
    public static int AddComponent(string partNo, string manufacturer,
        string partName, int qty, decimal unitCost, string status)
    {
        using var conn = OpenConnection();
        using var cmd  = new NpgsqlCommand(
            // RETURNING component_id sends back the new auto-generated ID.
            // The database uses SERIAL which auto-increments the ID.
            @"INSERT INTO components (part_no, manufacturer, part_name, qty, unit_cost, status)
              VALUES (@pn, @mfr, @name, @qty, @cost, @status)
              RETURNING component_id", conn);

        // Add each parameter with its value — this is how parameterized queries work.
        cmd.Parameters.AddWithValue("pn",     partNo);
        cmd.Parameters.AddWithValue("mfr",    manufacturer);
        cmd.Parameters.AddWithValue("name",   partName);
        cmd.Parameters.AddWithValue("qty",    qty);
        cmd.Parameters.AddWithValue("cost",   unitCost);
        cmd.Parameters.AddWithValue("status", status);

        // ExecuteScalar() runs the query and returns the single value
        // in the RETURNING clause — the new component_id.
        int newId = (int)cmd.ExecuteScalar()!;

        // Mirror the new row in the in-memory DataTable so the grid refreshes.
        Components.Rows.Add(newId, partNo, manufacturer, partName, qty, unitCost, status);
        Components.AcceptChanges();

        return newId;
    }

    /// <summary>
    /// Updates an existing component in the database and the in-memory table.
    /// </summary>
    public static void UpdateComponent(int id, string partNo, string manufacturer,
        string partName, int qty, decimal unitCost, string status)
    {
        using var conn = OpenConnection();
        using var cmd  = new NpgsqlCommand(
            @"UPDATE components
              SET part_no=@pn, manufacturer=@mfr, part_name=@name,
                  qty=@qty, unit_cost=@cost, status=@status
              WHERE component_id=@id", conn);

        cmd.Parameters.AddWithValue("id",     id);
        cmd.Parameters.AddWithValue("pn",     partNo);
        cmd.Parameters.AddWithValue("mfr",    manufacturer);
        cmd.Parameters.AddWithValue("name",   partName);
        cmd.Parameters.AddWithValue("qty",    qty);
        cmd.Parameters.AddWithValue("cost",   unitCost);
        cmd.Parameters.AddWithValue("status", status);

        // ExecuteNonQuery() runs INSERT/UPDATE/DELETE statements
        // that don't return data rows.
        cmd.ExecuteNonQuery();

        // Find the matching row in the in-memory DataTable and update it.
        var rows = Components.Select($"ComponentID = {id}");
        if (rows.Length == 0) return;
        rows[0]["PartNo"]       = partNo;
        rows[0]["Manufacturer"] = manufacturer;
        rows[0]["PartName"]     = partName;
        rows[0]["Qty"]          = qty;
        rows[0]["UnitCost"]     = unitCost;
        rows[0]["Status"]       = status;
        Components.AcceptChanges();
    }

    /// <summary>
    /// Deletes a component from the database and the in-memory table.
    /// </summary>
    public static void DeleteComponent(int id)
    {
        using var conn = OpenConnection();
        using var cmd  = new NpgsqlCommand(
            "DELETE FROM components WHERE component_id = @id", conn);
        cmd.Parameters.AddWithValue("id", id);
        cmd.ExecuteNonQuery();

        // Remove the matching row from the in-memory DataTable.
        var rows = Components.Select($"ComponentID = {id}");
        if (rows.Length > 0) { rows[0].Delete(); Components.AcceptChanges(); }
    }

    // ----------------------------------------------------------
    // Projects CRUD
    // ----------------------------------------------------------

    /// <summary>
    /// Inserts a new project into the database and the in-memory table.
    /// Returns the new project's ID generated by the database.
    /// </summary>
    public static int AddProject(string projectName, string projectCode,
        string leadName, string email)
    {
        using var conn = OpenConnection();
        using var cmd  = new NpgsqlCommand(
            @"INSERT INTO projects (project_name, project_code, lead_name, email)
              VALUES (@name, @code, @lead, @email)
              RETURNING project_id", conn);

        cmd.Parameters.AddWithValue("name",  projectName);
        cmd.Parameters.AddWithValue("code",  projectCode);
        // Lead name and email are optional — store NULL in the database if empty.
        cmd.Parameters.AddWithValue("lead",  string.IsNullOrEmpty(leadName) ? DBNull.Value : (object)leadName);
        cmd.Parameters.AddWithValue("email", string.IsNullOrEmpty(email)    ? DBNull.Value : (object)email);

        int newId = (int)cmd.ExecuteScalar()!;

        Projects.Rows.Add(newId, projectName, projectCode, leadName, email);
        Projects.AcceptChanges();
        return newId;
    }

    /// <summary>
    /// Updates an existing project in the database and the in-memory table.
    /// </summary>
    public static void UpdateProject(int id, string projectName, string projectCode,
        string leadName, string email)
    {
        using var conn = OpenConnection();
        using var cmd  = new NpgsqlCommand(
            @"UPDATE projects
              SET project_name=@name, project_code=@code, lead_name=@lead, email=@email
              WHERE project_id=@id", conn);

        cmd.Parameters.AddWithValue("id",    id);
        cmd.Parameters.AddWithValue("name",  projectName);
        cmd.Parameters.AddWithValue("code",  projectCode);
        cmd.Parameters.AddWithValue("lead",  string.IsNullOrEmpty(leadName) ? DBNull.Value : (object)leadName);
        cmd.Parameters.AddWithValue("email", string.IsNullOrEmpty(email)    ? DBNull.Value : (object)email);
        cmd.ExecuteNonQuery();

        var rows = Projects.Select($"ProjectID = {id}");
        if (rows.Length == 0) return;
        rows[0]["ProjectName"] = projectName;
        rows[0]["ProjectCode"] = projectCode;
        rows[0]["LeadName"]    = leadName;
        rows[0]["Email"]       = email;
        Projects.AcceptChanges();
    }

    /// <summary>
    /// Deletes a project from the database and the in-memory table.
    /// </summary>
    public static void DeleteProject(int id)
    {
        using var conn = OpenConnection();
        using var cmd  = new NpgsqlCommand(
            "DELETE FROM projects WHERE project_id = @id", conn);
        cmd.Parameters.AddWithValue("id", id);
        cmd.ExecuteNonQuery();

        var rows = Projects.Select($"ProjectID = {id}");
        if (rows.Length > 0) { rows[0].Delete(); Projects.AcceptChanges(); }
    }

    // ----------------------------------------------------------
    // Checkouts
    // ----------------------------------------------------------

    /// <summary>
    /// Creates a checkout record AND marks the component as "Checked Out"
    /// in a single database transaction so both changes always succeed
    /// or fail together — preventing inconsistent data.
    /// Returns the new checkout's ID.
    /// </summary>
    public static int AddCheckout(int componentId, int projectId,
        DateTime checkoutDate, DateTime returnDate, decimal totalValue, string status)
    {
        using var conn = OpenConnection();

        // A database TRANSACTION means: run multiple SQL statements as one
        // atomic unit. Either ALL succeed, or ALL are rolled back (undone).
        // Here we need to insert a checkout row AND update the component
        // status — we don't want one to succeed without the other.
        using var tx = conn.BeginTransaction();

        // Step 1: Insert the checkout record and get its new ID.
        using var insertCmd = new NpgsqlCommand(
            @"INSERT INTO checkouts (component_id, project_id, checkout_date, return_date, total_value, status)
              VALUES (@cid, @pid, @co, @ret, @val, @status)
              RETURNING checkout_id", conn, tx);

        insertCmd.Parameters.AddWithValue("cid",    componentId);
        insertCmd.Parameters.AddWithValue("pid",    projectId);
        insertCmd.Parameters.AddWithValue("co",     checkoutDate);
        insertCmd.Parameters.AddWithValue("ret",    returnDate);
        insertCmd.Parameters.AddWithValue("val",    totalValue);
        insertCmd.Parameters.AddWithValue("status", status);
        int newId = (int)insertCmd.ExecuteScalar()!;

        // Step 2: Update the component's status to "Checked Out" so it
        // no longer appears in the "available components" dropdown.
        using var updateCmd = new NpgsqlCommand(
            "UPDATE components SET status = 'Checked Out' WHERE component_id = @id", conn, tx);
        updateCmd.Parameters.AddWithValue("id", componentId);
        updateCmd.ExecuteNonQuery();

        // Commit — confirms both changes to the database permanently.
        tx.Commit();

        // Mirror both changes in the in-memory DataTables.
        Checkouts.Rows.Add(newId, componentId, projectId, checkoutDate, returnDate, totalValue, status);
        Checkouts.AcceptChanges();

        var compRow = Components.Select($"ComponentID = {componentId}");
        if (compRow.Length > 0) { compRow[0]["Status"] = "Checked Out"; Components.AcceptChanges(); }

        return newId;
    }

    // ----------------------------------------------------------
    // GetCheckoutsView
    // ----------------------------------------------------------
    // Builds a human-readable joined view of checkout records.
    // Instead of showing raw IDs (ComponentID, ProjectID), it
    // looks up and displays the Part No. and Project Name.
    //
    // Optional date range: only includes checkouts that overlap
    // the [from, to] window. If both are null, all records are returned.
    //
    // This reads from the in-memory DataTables (no database query)
    // so it is fast and doesn't need a network connection.
    // ----------------------------------------------------------
    public static DataTable GetCheckoutsView(DateTime? from = null, DateTime? to = null)
    {
        // Define the output table structure (what the grid will show).
        var result = new DataTable();
        result.Columns.Add("ID",            typeof(int));
        result.Columns.Add("Component",     typeof(string));
        result.Columns.Add("Project",       typeof(string));
        result.Columns.Add("Checkout Date", typeof(DateTime));
        result.Columns.Add("Return Date",   typeof(DateTime));
        result.Columns.Add("Unit Value",    typeof(decimal));
        result.Columns.Add("Status",        typeof(string));

        foreach (DataRow r in Checkouts.Rows)
        {
            DateTime checkout = (DateTime)r["CheckoutDate"];
            DateTime returnDt = (DateTime)r["ReturnDate"];

            // Date range filter: skip records outside the requested window.
            if (from.HasValue && returnDt.Date  < from.Value.Date) continue;
            if (to.HasValue   && checkout.Date  > to.Value.Date)   continue;

            // Look up the component and project by their IDs (simulating a SQL JOIN).
            int compId = (int)r["ComponentID"];
            int projId = (int)r["ProjectID"];
            var comp   = Components.AsEnumerable().FirstOrDefault(c => (int)c["ComponentID"] == compId);
            var proj   = Projects.AsEnumerable().FirstOrDefault(p => (int)p["ProjectID"]     == projId);

            // Skip orphaned records where the component or project was deleted.
            if (comp == null || proj == null) continue;

            result.Rows.Add(
                (int)r["CheckoutID"],
                (string)comp["PartNo"],       // Display Part No. instead of ComponentID
                (string)proj["ProjectName"],  // Display Project Name instead of ProjectID
                checkout, returnDt,
                (decimal)r["TotalValue"],
                (string)r["Status"]);
        }

        return result;
    }

    // ----------------------------------------------------------
    // GetValueSummary
    // ----------------------------------------------------------
    // Groups checkouts by date and sums their unit values.
    // Used by frmReports for the "Value Summary" report type.
    // Shows how much inventory value was checked out each day.
    // ----------------------------------------------------------
    public static DataTable GetValueSummary(DateTime from, DateTime to)
    {
        var result = new DataTable();
        result.Columns.Add("Date",        typeof(string));
        result.Columns.Add("Checkouts",   typeof(int));
        result.Columns.Add("Total Value", typeof(decimal));

        // LINQ query: filter by date range, group by date, sort newest first.
        var groups = Checkouts.AsEnumerable()
            .Where(r => (DateTime)r["CheckoutDate"] >= from && (DateTime)r["CheckoutDate"] <= to)
            .GroupBy(r => ((DateTime)r["CheckoutDate"]).Date)
            .OrderByDescending(g => g.Key);

        foreach (var g in groups)
            result.Rows.Add(
                g.Key.ToString("yyyy-MM-dd"),          // Date as formatted string
                g.Count(),                             // Number of checkouts that day
                g.Sum(r => (decimal)r["TotalValue"])); // Total value checked out that day

        return result;
    }
}
