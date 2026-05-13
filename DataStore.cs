using System.Data;
using Microsoft.Data.Sqlite;

namespace ElectronicsInventory;

// ============================================================
// DataStore.cs  –  Database Access Layer (SQLite)
// ============================================================
// Two-layer design:
//   Layer 1 – In-memory DataTables bound to DataGridViews on every form.
//   Layer 2 – Local SQLite file (inventory.db in the app directory).
//
// Call DataStore.Initialize() once at startup (done in Program.cs).
// It creates the schema on first run, then loads all rows into the
// three DataTables before any form opens.
// ============================================================

public static class DataStore
{
    public static DataTable Components { get; } = MakeComponentsTable();
    public static DataTable Projects   { get; } = MakeProjectsTable();
    public static DataTable Checkouts  { get; } = MakeCheckoutsTable();

    public static void Initialize()
    {
        EnsureSchema();
        LoadComponents();
        LoadProjects();
        LoadCheckouts();
    }

    private static SqliteConnection OpenConnection()
    {
        var conn = new SqliteConnection(DatabaseConfig.ConnectionString);
        conn.Open();
        using var pragma = new SqliteCommand("PRAGMA foreign_keys = ON", conn);
        pragma.ExecuteNonQuery();
        return conn;
    }

    // Creates all three tables on first run; no-ops on subsequent runs.
    private static void EnsureSchema()
    {
        using var conn = OpenConnection();

        var statements = new[]
        {
            @"CREATE TABLE IF NOT EXISTS components (
                component_id INTEGER PRIMARY KEY AUTOINCREMENT,
                part_no      TEXT    NOT NULL UNIQUE,
                manufacturer TEXT    NOT NULL,
                part_name    TEXT    NOT NULL,
                qty          INTEGER NOT NULL DEFAULT 0   CHECK (qty >= 0),
                unit_cost    REAL    NOT NULL DEFAULT 0   CHECK (unit_cost >= 0),
                status       TEXT    NOT NULL DEFAULT 'In Stock'
                             CHECK (status IN ('In Stock', 'Checked Out', 'Defective'))
            )",
            @"CREATE TABLE IF NOT EXISTS projects (
                project_id   INTEGER PRIMARY KEY AUTOINCREMENT,
                project_name TEXT NOT NULL,
                project_code TEXT NOT NULL UNIQUE,
                lead_name    TEXT,
                email        TEXT
            )",
            @"CREATE TABLE IF NOT EXISTS checkouts (
                checkout_id   INTEGER PRIMARY KEY AUTOINCREMENT,
                component_id  INTEGER NOT NULL REFERENCES components(component_id),
                project_id    INTEGER NOT NULL REFERENCES projects(project_id),
                checkout_date TEXT    NOT NULL,
                return_date   TEXT    NOT NULL,
                total_value   REAL    NOT NULL,
                status        TEXT    NOT NULL DEFAULT 'Checked Out',
                CHECK (return_date > checkout_date)
            )"
        };

        foreach (var sql in statements)
        {
            using var cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }

    private static void LoadComponents()
    {
        Components.Rows.Clear();

        using var conn = OpenConnection();
        using var cmd  = new SqliteCommand(
            "SELECT component_id, part_no, manufacturer, part_name, qty, unit_cost, status " +
            "FROM components ORDER BY component_id", conn);

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
            Components.Rows.Add(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetInt32(4),
                reader.GetDecimal(5),
                reader.GetString(6));

        Components.AcceptChanges();
    }

    private static void LoadProjects()
    {
        Projects.Rows.Clear();

        using var conn = OpenConnection();
        using var cmd  = new SqliteCommand(
            "SELECT project_id, project_name, project_code, lead_name, email " +
            "FROM projects ORDER BY project_id", conn);

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
            Projects.Rows.Add(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.IsDBNull(3) ? "" : reader.GetString(3),
                reader.IsDBNull(4) ? "" : reader.GetString(4));

        Projects.AcceptChanges();
    }

    private static void LoadCheckouts()
    {
        Checkouts.Rows.Clear();

        using var conn = OpenConnection();
        using var cmd  = new SqliteCommand(
            "SELECT checkout_id, component_id, project_id, checkout_date, return_date, total_value, status " +
            "FROM checkouts ORDER BY checkout_id", conn);

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
            Checkouts.Rows.Add(
                reader.GetInt32(0),
                reader.GetInt32(1),
                reader.GetInt32(2),
                reader.GetDateTime(3),
                reader.GetDateTime(4),
                reader.GetDecimal(5),
                reader.GetString(6));

        Checkouts.AcceptChanges();
    }

    private static DataTable MakeComponentsTable()
    {
        var t = new DataTable();
        t.Columns.Add("ComponentID",  typeof(int));
        t.Columns.Add("PartNo",       typeof(string));
        t.Columns.Add("Manufacturer", typeof(string));
        t.Columns.Add("PartName",     typeof(string));
        t.Columns.Add("Qty",          typeof(int));
        t.Columns.Add("UnitCost",     typeof(decimal));
        t.Columns.Add("Status",       typeof(string));
        return t;
    }

    private static DataTable MakeProjectsTable()
    {
        var t = new DataTable();
        t.Columns.Add("ProjectID",   typeof(int));
        t.Columns.Add("ProjectName", typeof(string));
        t.Columns.Add("ProjectCode", typeof(string));
        t.Columns.Add("LeadName",    typeof(string));
        t.Columns.Add("Email",       typeof(string));
        return t;
    }

    private static DataTable MakeCheckoutsTable()
    {
        var t = new DataTable();
        t.Columns.Add("CheckoutID",   typeof(int));
        t.Columns.Add("ComponentID",  typeof(int));
        t.Columns.Add("ProjectID",    typeof(int));
        t.Columns.Add("CheckoutDate", typeof(DateTime));
        t.Columns.Add("ReturnDate",   typeof(DateTime));
        t.Columns.Add("TotalValue",   typeof(decimal));
        t.Columns.Add("Status",       typeof(string));
        return t;
    }

    // ----------------------------------------------------------
    // Components CRUD
    // ----------------------------------------------------------

    public static int AddComponent(string partNo, string manufacturer,
        string partName, int qty, decimal unitCost, string status)
    {
        using var conn = OpenConnection();
        using var cmd  = new SqliteCommand(
            @"INSERT INTO components (part_no, manufacturer, part_name, qty, unit_cost, status)
              VALUES (@pn, @mfr, @name, @qty, @cost, @status)", conn);

        cmd.Parameters.AddWithValue("pn",     partNo);
        cmd.Parameters.AddWithValue("mfr",    manufacturer);
        cmd.Parameters.AddWithValue("name",   partName);
        cmd.Parameters.AddWithValue("qty",    qty);
        cmd.Parameters.AddWithValue("cost",   (double)unitCost);
        cmd.Parameters.AddWithValue("status", status);
        cmd.ExecuteNonQuery();

        int newId = (int)(long)new SqliteCommand("SELECT last_insert_rowid()", conn).ExecuteScalar()!;

        Components.Rows.Add(newId, partNo, manufacturer, partName, qty, unitCost, status);
        Components.AcceptChanges();

        return newId;
    }

    public static void UpdateComponent(int id, string partNo, string manufacturer,
        string partName, int qty, decimal unitCost, string status)
    {
        var existing       = Components.Select($"ComponentID = {id}");
        bool wasCheckedOut = existing.Length > 0 &&
                             (string)existing[0]["Status"] == "Checked Out";
        bool nowAvailable  = status == "In Stock";

        using var conn = OpenConnection();
        using var tx   = conn.BeginTransaction();

        using var compCmd = new SqliteCommand(
            @"UPDATE components
              SET part_no=@pn, manufacturer=@mfr, part_name=@name,
                  qty=@qty, unit_cost=@cost, status=@status
              WHERE component_id=@id", conn, tx);

        compCmd.Parameters.AddWithValue("id",     id);
        compCmd.Parameters.AddWithValue("pn",     partNo);
        compCmd.Parameters.AddWithValue("mfr",    manufacturer);
        compCmd.Parameters.AddWithValue("name",   partName);
        compCmd.Parameters.AddWithValue("qty",    qty);
        compCmd.Parameters.AddWithValue("cost",   (double)unitCost);
        compCmd.Parameters.AddWithValue("status", status);
        compCmd.ExecuteNonQuery();

        if (wasCheckedOut && nowAvailable)
        {
            using var closeCmd = new SqliteCommand(
                "UPDATE checkouts SET status = 'Returned' " +
                "WHERE component_id = @id AND status = 'Checked Out'", conn, tx);
            closeCmd.Parameters.AddWithValue("id", id);
            closeCmd.ExecuteNonQuery();
        }

        tx.Commit();

        var rows = Components.Select($"ComponentID = {id}");
        if (rows.Length == 0) return;
        rows[0]["PartNo"]       = partNo;
        rows[0]["Manufacturer"] = manufacturer;
        rows[0]["PartName"]     = partName;
        rows[0]["Qty"]          = qty;
        rows[0]["UnitCost"]     = unitCost;
        rows[0]["Status"]       = status;
        Components.AcceptChanges();

        if (wasCheckedOut && nowAvailable)
        {
            foreach (DataRow r in Checkouts.Select($"ComponentID = {id} AND Status = 'Checked Out'"))
                r["Status"] = "Returned";
            Checkouts.AcceptChanges();
        }
    }

    public static void DeleteComponent(int id)
    {
        using var conn = OpenConnection();
        using var cmd  = new SqliteCommand(
            "DELETE FROM components WHERE component_id = @id", conn);
        cmd.Parameters.AddWithValue("id", id);
        cmd.ExecuteNonQuery();

        var rows = Components.Select($"ComponentID = {id}");
        if (rows.Length > 0) { rows[0].Delete(); Components.AcceptChanges(); }
    }

    // ----------------------------------------------------------
    // Projects CRUD
    // ----------------------------------------------------------

    public static int AddProject(string projectName, string projectCode,
        string leadName, string email)
    {
        using var conn = OpenConnection();
        using var cmd  = new SqliteCommand(
            @"INSERT INTO projects (project_name, project_code, lead_name, email)
              VALUES (@name, @code, @lead, @email)", conn);

        cmd.Parameters.AddWithValue("name",  projectName);
        cmd.Parameters.AddWithValue("code",  projectCode);
        cmd.Parameters.AddWithValue("lead",  string.IsNullOrEmpty(leadName) ? DBNull.Value : (object)leadName);
        cmd.Parameters.AddWithValue("email", string.IsNullOrEmpty(email)    ? DBNull.Value : (object)email);
        cmd.ExecuteNonQuery();

        int newId = (int)(long)new SqliteCommand("SELECT last_insert_rowid()", conn).ExecuteScalar()!;

        Projects.Rows.Add(newId, projectName, projectCode, leadName, email);
        Projects.AcceptChanges();
        return newId;
    }

    public static void UpdateProject(int id, string projectName, string projectCode,
        string leadName, string email)
    {
        using var conn = OpenConnection();
        using var cmd  = new SqliteCommand(
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

    public static void DeleteProject(int id)
    {
        using var conn = OpenConnection();
        using var cmd  = new SqliteCommand(
            "DELETE FROM projects WHERE project_id = @id", conn);
        cmd.Parameters.AddWithValue("id", id);
        cmd.ExecuteNonQuery();

        var rows = Projects.Select($"ProjectID = {id}");
        if (rows.Length > 0) { rows[0].Delete(); Projects.AcceptChanges(); }
    }

    // ----------------------------------------------------------
    // Checkouts
    // ----------------------------------------------------------

    public static int AddCheckout(int componentId, int projectId,
        DateTime checkoutDate, DateTime returnDate, decimal totalValue, string status)
    {
        using var conn = OpenConnection();
        using var tx   = conn.BeginTransaction();

        using var insertCmd = new SqliteCommand(
            @"INSERT INTO checkouts (component_id, project_id, checkout_date, return_date, total_value, status)
              VALUES (@cid, @pid, @co, @ret, @val, @status)", conn, tx);

        insertCmd.Parameters.AddWithValue("cid",    componentId);
        insertCmd.Parameters.AddWithValue("pid",    projectId);
        insertCmd.Parameters.AddWithValue("co",     checkoutDate);
        insertCmd.Parameters.AddWithValue("ret",    returnDate);
        insertCmd.Parameters.AddWithValue("val",    (double)totalValue);
        insertCmd.Parameters.AddWithValue("status", status);
        insertCmd.ExecuteNonQuery();

        int newId = (int)(long)new SqliteCommand("SELECT last_insert_rowid()", conn, tx).ExecuteScalar()!;

        using var updateCmd = new SqliteCommand(
            "UPDATE components SET status = 'Checked Out' WHERE component_id = @id", conn, tx);
        updateCmd.Parameters.AddWithValue("id", componentId);
        updateCmd.ExecuteNonQuery();

        tx.Commit();

        Checkouts.Rows.Add(newId, componentId, projectId, checkoutDate, returnDate, totalValue, status);
        Checkouts.AcceptChanges();

        var compRow = Components.Select($"ComponentID = {componentId}");
        if (compRow.Length > 0) { compRow[0]["Status"] = "Checked Out"; Components.AcceptChanges(); }

        return newId;
    }

    // ----------------------------------------------------------
    // GetCheckoutsView  –  In-memory JOIN for grid display
    // ----------------------------------------------------------

    public static DataTable GetCheckoutsView(DateTime? from = null, DateTime? to = null, bool activeOnly = false)
    {
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
            if (activeOnly && (string)r["Status"] != "Checked Out") continue;

            DateTime checkout = (DateTime)r["CheckoutDate"];
            DateTime returnDt = (DateTime)r["ReturnDate"];

            if (from.HasValue && returnDt.Date  < from.Value.Date) continue;
            if (to.HasValue   && checkout.Date  > to.Value.Date)   continue;

            int compId = (int)r["ComponentID"];
            int projId = (int)r["ProjectID"];
            var comp   = Components.AsEnumerable().FirstOrDefault(c => (int)c["ComponentID"] == compId);
            var proj   = Projects.AsEnumerable().FirstOrDefault(p => (int)p["ProjectID"]     == projId);

            if (comp == null || proj == null) continue;

            result.Rows.Add(
                (int)r["CheckoutID"],
                (string)comp["PartNo"],
                (string)proj["ProjectName"],
                checkout, returnDt,
                (decimal)r["TotalValue"],
                (string)r["Status"]);
        }

        return result;
    }

    // ----------------------------------------------------------
    // GetValueSummary  –  Daily checkout value totals for reports
    // ----------------------------------------------------------

    public static DataTable GetValueSummary(DateTime from, DateTime to)
    {
        var result = new DataTable();
        result.Columns.Add("Date",        typeof(string));
        result.Columns.Add("Checkouts",   typeof(int));
        result.Columns.Add("Total Value", typeof(decimal));

        var groups = Checkouts.AsEnumerable()
            .Where(r => (DateTime)r["CheckoutDate"] >= from && (DateTime)r["CheckoutDate"] <= to)
            .GroupBy(r => ((DateTime)r["CheckoutDate"]).Date)
            .OrderByDescending(g => g.Key);

        foreach (var g in groups)
            result.Rows.Add(
                g.Key.ToString("yyyy-MM-dd"),
                g.Count(),
                g.Sum(r => (decimal)r["TotalValue"]));

        return result;
    }
}
