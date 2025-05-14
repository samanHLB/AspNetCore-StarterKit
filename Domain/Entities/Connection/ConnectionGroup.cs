namespace Domain.Entities.Connection;

public class ConnectionGroup : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [MaxLength(200)]
    [Required(ErrorMessage ="لطفا عنوان گروه را وارد نمایید")]
    public required string Title { get; set; }

    [MaxLength(300)]
    [Required]
    public string? Slug { get; set; }

    // relations
    public ICollection<Connection>? Connections { get; set; }
}
