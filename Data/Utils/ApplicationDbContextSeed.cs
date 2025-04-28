namespace Infrastructure.Utils;

public static class ApplicationDbContextSeed
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        await context.SaveChangesAsync();
    }
}