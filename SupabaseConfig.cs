namespace ElectronicsInventory;

internal static class DatabaseConfig
{
    public static string DatabasePath =>
        Path.Combine(AppContext.BaseDirectory, "inventory.db");

    public static string ConnectionString =>
        $"Data Source={DatabasePath}";
}
