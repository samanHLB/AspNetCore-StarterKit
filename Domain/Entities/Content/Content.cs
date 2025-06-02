namespace Domain.Entities.Content;

public class Content : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [DisplayName("عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(200)]
    public required string Title { get; set; }

    [DisplayName("اسلاگ")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(200)]
    public required string Slug { get; set; }

    public required ContentsType Type { get; set; }

    [DisplayName("متن محتوا")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    public required string ContentText { get; set; }

    [DisplayName("خلاصه محتوا")]
    [MaxLength(500)]
    public string? Summery { get; set; }

    [DisplayName("تعداد بازدید")]
    public short? VisitCount { get; set; } = 0;

    [DisplayName("تعداد لایک")]
    public short? LikeCount { get; set; } = 0;

    [DisplayName("نویسنده")]
    [MaxLength(100)]
    public string? Author { get; set; }

    [DisplayName("مدت زمان مطالعه برحسب دقیقه")]
    public int? ReadingTime { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public bool? IsImportant { get; set; }

    [MaxLength(400)]
    public string? Image { get; set; }

    [DisplayName("اولویت")]
    public int? Priority { get; set; }

    // relations
    [ForeignKey("ContentGroup")]
    public int? ContentGroupId { get; set; }
    public ContentGroup? ContentGroup { get; set; }

    public int? SeoPage { get; set; }
    public SeoPage? SeoPageId { get; set; }
}
