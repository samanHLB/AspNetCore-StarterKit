namespace Domain.Entities.Seo;

public class SeoPage
{
    [Key]
    public int Id { get; set; }

    [DisplayName("لینک")]
    [DataType(DataType.Url)]
    [MaxLength(5000)]
    [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
    public string? PageUrl { get; set; }

    [DisplayName("عنوان سئویی")]
    [MaxLength(200)]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    public required string MetaTitle { get; set; }

    [MaxLength(500)]
    [DisplayName("کلید واژه")]
    public string? MetaKeyword { get; set; }

    [DisplayName("توضیحات")]
    [MaxLength(5000)]
    public string? MetaDescription { get; set; }

    [MaxLength(5000)]
    public string? MetaOther { get; set; }

    [MaxLength(500)]
    [Display(Name = "تگ Canonical")]
    public string? Canonical { get; set; }

    [DisplayName("کلمات کلیدی")]
    [MaxLength(1000)]
    public string? Tag { get; set; }
}
