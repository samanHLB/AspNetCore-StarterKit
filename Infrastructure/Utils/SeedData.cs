namespace Infrastructure.Utils;

public static class SeedData
{
    public static void Seed(this ModelBuilder builder)
    {
        #region User_SeedData
        //builder.Entity<ApplicationUser>().HasData(
            //new ApplicationUser
            //{

            //}
        //);
        #endregion

        #region Role_SeedData
        //builder.Entity<ApplicationRole>().HasData(
            //new ApplicationRole
            //{

            //},
            //new ApplicationRole
            //{

            //}
        //);
        #endregion

        #region UserRole_SeedData
        //builder.Entity<IdentityUserRole<string>>().HasData(
        //    new IdentityUserRole<string>
        //    {

        //    }
        //);
        #endregion

    }
}
