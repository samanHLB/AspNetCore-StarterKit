namespace Domain.Entities.Content;

public class ContentGroup  : BaseEntity
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [DisplayName("عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(200)]
    public required string Title { get; set; }

    [DisplayName("اسلاگ")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(300)]
    public required string Slug { get; set; }

    [DisplayName("توضیحات")]
    [MaxLength(2000)]
    public required string Description { get; set; }
   
    [ForeignKey("ParentContentGroup")]
    public int? ParentId { get; set; }

    [MaxLength(50)]
    public string? SiteMapIdentifier { get; set; }


    public ContentGroup? ParentContentGroup { get; set; }
    public ICollection<Content>? Contents { get; set; }
}