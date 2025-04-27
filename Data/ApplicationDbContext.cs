namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _contextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region BaseEntity
            Expression<Func<BaseEntity, bool>> filterExpr = bm => !bm.IsDeleted;
            foreach (var mutableEntityType in builder.Model.GetEntityTypes())
            {
                // check if current entity type is child of BaseModel
                if (mutableEntityType.ClrType.IsAssignableTo(typeof(BaseEntity)))
                {
                    // modify expression to handle correct child type
                    var parameter = Expression.Parameter(mutableEntityType.ClrType);
                    var body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
                    var lambdaExpression = Expression.Lambda(body, parameter);

                    // set filter
                    mutableEntityType.SetQueryFilter(lambdaExpression);
                }
            }
            builder.Ignore<BaseEntity>();
            #endregion

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var modifiedEntries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            var currentUsername = _contextAccessor.HttpContext is not null && !string.IsNullOrEmpty(_contextAccessor.HttpContext.User?.Identity?.Name)
            ? _contextAccessor.HttpContext.User?.Identity?.Name
            : "Anonymous";

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is BaseEntity entity)
                {
                    var now = DateTime.Now;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedDate = now;
                        entity.CreatedBy = currentUsername;
                    }
                    else
                    {
                        entry.Property("CreateDate").IsModified = false;
                        entry.Property("CreatedBy").IsModified = false;
                        entity.UpdatedDate = now;
                        entity.UpdatedBy = currentUsername;
                    }
                }
            }

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }






    }
}
