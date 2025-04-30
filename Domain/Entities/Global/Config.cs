namespace Domain.Entities.Global
{
    public class Config
    {
        [Display(Name ="کلید (عنوان)")]
        [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
        [MaxLength(100)]
        [Key]
        public required string Key { get; set; }

        [Display(Name = "مقدار")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(800)]
        public required string Value { get; set; }
    }
}
