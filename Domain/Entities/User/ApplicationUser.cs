namespace Domain.Entities.User;

public class ApplicationUser : IdentityUser, IBaseEntity
{
    #region base
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsActive { get; set; } = true;
    [MaxLength(100)]
    public string? UpdatedBy { get; set; }
    [MaxLength(100)]
    public string? CreatedBy { get; set; }
    #endregion

    [MaxLength(100)]
    public required string FullName { get; set; }

    [MaxLength(11)]
    public string? LandLine { get; set; }

    public DateTime? BirthDate { get; set; }

    [MaxLength(200)]
    public string? Address { get; set; }
}
