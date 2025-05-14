namespace Domain.Utils;

public enum UrlRedirectStatusCode : short
{
    [Display(Name = "301")]
    Redirect301 = 301,
    [Display(Name = "302")]
    Redirect302 = 302,
    [Display(Name = "410")]
    Redirect410 = 410,
}

public enum ConnectionType
{
    [Display(Name = "تلفن همراه")]
    Mobile,
    [Display(Name = "ایمیل")]
    Email,
    [Display(Name = "تلفن")]
    Phone,
    //[Display(Name = "نقشه")]
    //Map,
    [Display(Name = "آدرس")]
    Address,
    [Display(Name = "تلفن پشتیبانی")]
    Support
}

public enum Roles
{
    SuperAdmin,
    Admin,
    Customer
}

public enum SocialNetworkType
{
    [Display(Name = "تلگرام")]
    Telegram,
    [Display(Name = "اینستاگرام")]
    Instagram,
    [Display(Name = "توئیتر")]
    Twitter,
    [Display(Name = "لینکدین")]
    Linkedin,
    [Display(Name = "فیسبوک")]
    Facebook,
    [Display(Name = "واتساپ")]
    Whatsapp,
    [Display(Name = "ایتا")]
    Eitaa
}

public enum ContentsType : byte
{
    [Display(Name = "درباره ما")]
    AboutUs = 1,
    [Display(Name = "قوانین و مقررات")]
    Rules = 2,
    [Display(Name = "مقالات")]
    Contents = 3,
    [Display(Name = "اخبار")]
    News = 4
}
