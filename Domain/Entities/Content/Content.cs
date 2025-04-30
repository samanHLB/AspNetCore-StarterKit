namespace Domain.Entities.Content;

public class Content : BaseEntity
{
    [Key]
    public int Content_ID { get; set; }

    [DisplayName("عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(200)]
    public string Title { get; set; }

    [DisplayName("اسلاگ")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(200)]
    public string Slug { get; set; }

    public ContentsType Type { get; set; }

    [DisplayName("خلاصه محتوا")]
    [MaxLength(500)]
    public string Summery { get; set; }

    [DisplayName("متن محتوا")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    public string ContentText { get; set; }

    [Display(Name = "عنوان سئویی")]
    [MaxLength(200)]
    public string MetaTitle { get; set; }

    [Display(Name = "کلمات کلیدی")]
    [MaxLength(500)]
    public string MetaKeword { get; set; }

    [Display(Name = "توضیحات")]
    [MaxLength(5000)]
    public string MetaDescription { get; set; }

    [MaxLength(5000)]
    public string MetaOther { get; set; }

    [MaxLength(500)]
    [Display(Name = "تگ Canonical")]
    public string Canonical { get; set; }

    [DisplayName("کلمات کلیدی")]
    [MaxLength(1000)]
    public string Tag { get; set; }

    [DisplayName("تعداد بازدید")]
    public short VisitCount { get; set; } = 0;

    [DisplayName("تعداد لایک")]
    public short LikeCount { get; set; } = 0;

    [DisplayName("نویسنده")]
    [MaxLength(100)]
    public string Author { get; set; }

    [DisplayName("مدت زمان مطالعه برحسب دقیقه")]
    public int ReadingTime { get; set; }

    public DateTime ReleaseDate { get; set; }

    [DisplayName("فعال / غیرفعال")]
    public bool IsActive { get; set; } = true;

    public bool IsImportant { get; set; }

    [MaxLength(400)]
    public string Image { get; set; }

    [DisplayName("اولویت")]
    public int Priority { get; set; }
}
