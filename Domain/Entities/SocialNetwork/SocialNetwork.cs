namespace Domain.Entities.SocialNetwork;

public class SocialNetwork : BaseEntity
{
    [Key]
    public short Id { get; set; }

    [DisplayName("لینک")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [DataType(DataType.Url, ErrorMessage = "لطفا {0} را بصورت صحیح وارد نمایید")]
    [MaxLength(200)]
    public required string Link { get; set; }

    [DisplayName("نوع شبکه اجتماعی")]
    public required SocialNetworkType Type { get; set; }

    [DisplayName("عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(50)]
    public required string Title { get; set; }
}
