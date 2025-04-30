namespace Domain.Utils;

public enum CommentType
{
    Product = 1,
    Content = 2,
    File = 3
}

public enum VoteType
{
    Product = 1,
    Content = 2,
    File = 3
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
    [Display(Name ="تلفن پشتیبانی")]
    Support
}

public enum ReceiverType : byte
{
    [Display(Name = "پیامک")]
    Mobile,
    [Display(Name = "ایمیل")]
    Email,
    [Display(Name = "هر دو")]
    Both,
    [Display(Name = "هیچکدام")]
    None
}

public enum PaymentType
{
    [Display(Name = "آنلاین")]
    Online = 0,
    [Display(Name = "آفلاین")]
    Offline = 1,
    [Display(Name = "حضوری")]
    Presence = 2
}
public enum OrderStatus
{
    [Display(Name = "معلق")]
    Suspend = 0,
    [Display(Name = "ثبت شده")]
    Register = 1,
    [Display(Name = "انصرافی")]
    Cancel = 2,
    [Display(Name = "درحال بررسی")]
    Pending = 3,
    [Display(Name = "ارسال شده")]
    Send = 4,
    [Display(Name = "دریافت شده")]
    Deliverd = 5,
    //[Display(Name = "مرجوعی")]
    //Returned = 6,
    [Display(Name = "تایید شده")]
    Confirmed = 7
}

public enum UploadType : byte
{
    File,
    Script
}

public enum DiscountType : byte
{
    [Display(Name = "همه")]
    All = 1,
    [Display(Name = "گروه محصول")]
    ProductGroup = 2,
    [Display(Name = "محصول")]
    Product = 3,
    [Display(Name = "کاربر")]
    User = 4
}

public enum DiscountRandomType : byte
{
    [Display(Name = "کاراکتر")]
    Character = 1,
    [Display(Name = "عدد")]
    Number = 2,
    [Display(Name = "ترکیبی")]
    Both = 3
}

public enum OfferType : byte
{
    [Display(Name = "دسته بندی")]
    ProductGroup = 1,
    [Display(Name = "محصولات")]
    Product = 2
}

public enum Roles
{
    SuperAdmin,
    Admin,
    Customer
}
public enum SendTypeItem : byte
{
    [Display(Name = "ماشینی")]
    Car = 1,
    [Display(Name = "موتوری")]
    Motor = 2,
    [Display(Name = "حضوری")]
    Home = 3,
    [Display(Name = "پیشتاز")]
    Express = 4
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

public enum SupportTicketStatus
{
    [Display(Name = "درحال بررسی")]
    Pending = 1,
    [Display(Name = "پاسخ داده شده")]
    Answered = 2,
    [Display(Name = "بسته شده")]
    Closed = 3,
}

public enum ContentsType : byte
{
    [Display(Name = "درباره ما")]
    AboutUs = 1,
    Rules = 2,
    StaticPages = 3,
    News = 4
}
public enum LogType : byte
{
    Information = 1,
    Error = 0
}