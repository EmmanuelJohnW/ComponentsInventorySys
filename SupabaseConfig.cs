namespace ElectronicsInventory;

// ============================================================
// SupabaseConfig.cs  –  Database Connection Settings
// ============================================================
// This file holds the connection string used to connect to the
// Supabase (PostgreSQL) database.
//
// HOW IT WORKS:
//   Supabase is a cloud database service built on PostgreSQL.
//   The app connects directly to it using the Npgsql library,
//   which is the standard .NET driver for PostgreSQL databases.
//
// IF YOU NEED TO CHANGE THE CONNECTION:
//   1. Go to https://supabase.com and open your project.
//   2. Click "Project Settings" → "Database" → "Connection string".
//   3. Copy the "Direct connection" URI (URI tab).
//   4. Break it into the key=value parts shown below.
//
// CONNECTION STRING FORMAT EXPLAINED:
//   Host     = the database server address (provided by Supabase)
//   Port     = 5432 is the standard PostgreSQL port
//   Database = "postgres" is the default Supabase database name
//   Username = "postgres" is the default Supabase superuser
//   Password = your database password (set when you created the project)
//   SSL Mode = "Require" forces an encrypted connection (always use this)
//   Trust Server Certificate = accepts Supabase's self-signed SSL cert
// ============================================================

internal static class SupabaseConfig
{
    // The connection string that Npgsql uses to open a database connection.
    // All DataStore methods call OpenConnection() which reads this value.
    public const string ConnectionString =
        "Host=db.sutqsktqghxmzkoarnja.supabase.co;" +  // Supabase server address
        "Port=5432;" +                                   // Standard PostgreSQL port
        "Database=postgres;" +                           // Default Supabase database
        "Username=postgres;" +                           // Default Supabase user
        "Password=RCfWxDp7DHHmeuGb;" +                  // Database password
        "SSL Mode=Require;" +                            // Always use encrypted connection
        "Trust Server Certificate=true";                 // Accept Supabase's SSL certificate
}
