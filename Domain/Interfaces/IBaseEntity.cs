namespace Domain.Interfaces;

public interface IBaseEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    [MaxLength(100)]
    public string? CreatedBy { get; set; }
    [MaxLength(100)]
    public string? UpdatedBy { get; set; }
}
