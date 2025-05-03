namespace Domain.Entities.SocialNetwork;

public static class EnumSocialNetworkType
{
    public static IEnumerable<T> GetValues<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }
}

public class SocialNetwork
{
    [Key]
    public short SocialNetwork_ID { get; set; }

    [DisplayName("لینک")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [DataType(DataType.Url, ErrorMessage = "لطفا {0} را بصورت صحیح وارد نمایید")]
    [MaxLength(200)]
    public string Link { get; set; }

    [DisplayName("نوع شبکه اجتماعی")]
    public SocialNetworkType Type { get; set; }

    [DisplayName("عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [MaxLength(50)]
    public string Title { get; set; }

    [DisplayName("وضعیت")]
    public bool IsActive { get; set; }
}
