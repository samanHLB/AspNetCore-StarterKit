namespace Domain.Entities.User;

public class ApplicationRole : IdentityRole
{
    [MaxLength(50)]
    public string? DisplayName { get; set; }

}
