namespace Domain.Entities.Global;

public class UrlRedirect : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "آدرس قدیم")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(500)]
    public required string Url { get; set; }

    [Display(Name = "آدرس جدید")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(500)]
    public required string RedirectUrl { get; set; }

    [Display(Name = "نوع هدایت لینک")]
    public UrlRedirectStatusCode StatusCode { get; set; }
}
