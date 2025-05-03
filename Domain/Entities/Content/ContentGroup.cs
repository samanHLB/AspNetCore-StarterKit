namespace Domain.Entities.Content;

public class ContentGroup  : BaseEntity
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ContentGroup_ID { get; set; }

    [DisplayName("عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(200)]
    public string Title { get; set; }

    [DisplayName("اسلاگ")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(300)]
    public string Slug { get; set; }

    [DisplayName("توضیحات")]
    [MaxLength(2000)]
    public string Description { get; set; }
   
    [ForeignKey("ParentContentGroup")]
    public int? ParentId { get; set; }

    [DisplayName("وضعیت")]
    public bool IsActive { get; set; }

    [MaxLength(50)]
    public string SiteMapIdentifier { get; set; }

    public virtual ContentGroup ParentContentGroup { get; set; }
}