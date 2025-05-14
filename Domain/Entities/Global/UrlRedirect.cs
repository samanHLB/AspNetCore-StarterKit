namespace Domain.Entities.Global;

public enum UrlRedirectStatusCode : short
{
    [Display(Name = "301")]
    Redirect301 = 301,
    [Display(Name = "302")]
    Redirect302 = 302,
    [Display(Name = "410")]
    Redirect410 = 410,
}

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
