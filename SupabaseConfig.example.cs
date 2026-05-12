namespace ElectronicsInventory;

// ============================================================
// SupabaseConfig.example.cs  –  Connection String Template
// ============================================================
// This is the TEMPLATE file — it is safe to commit to GitHub.
// The real credentials file (SupabaseConfig.cs) is in .gitignore.
//
// SETUP INSTRUCTIONS (do this once per machine):
//   1. Copy this file and rename the copy to: SupabaseConfig.cs
//   2. Fill in your Supabase project details below.
//   3. Never commit SupabaseConfig.cs — it stays local only.
//
// WHERE TO FIND YOUR CREDENTIALS:
//   Supabase Dashboard → Your Project → Project Settings
//   → Database → Connection string → URI tab
//   Copy the "Direct connection" string (not the pooler).
// ============================================================

internal static class SupabaseConfig
{
    public const string ConnectionString =
        "Host=db.REPLACE_WITH_YOUR_PROJECT_ID.supabase.co;" +
        "Port=5432;" +
        "Database=postgres;" +
        "Username=postgres;" +
        "Password=REPLACE_WITH_YOUR_DB_PASSWORD;" +
        "SSL Mode=Require;" +
        "Trust Server Certificate=true";
}
