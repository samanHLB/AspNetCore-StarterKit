namespace Infrastructure.Utils;

public static class SeedData
{
    public static void Seed(this ModelBuilder builder)
    {
        #region Role_SeedData
        builder.Entity<ApplicationRole>().HasData(
            new ApplicationRole
            {
                Id = "1",
                Name = nameof(Roles.SuperAdmin),
            },
            new ApplicationRole
            {
                Id = "2",
                Name = nameof(Roles.Admin),
            }
        );
        #endregion

        #region User_SeedData
        builder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = "1",
                FullName = "SuperAdmin",
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Admin@123"),
                SecurityStamp = Guid.NewGuid().ToString()
            }
        );
        #endregion

        #region UserRole_SeedData
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "1"
            }
        );
        #endregion

    }
}
