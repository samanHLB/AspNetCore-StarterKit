namespace Domain.Entities.Connection
{
    public class Connection
    {
        [Key]
        public byte Id { get; set; }

        [ForeignKey("ConnectionGroup")]
        [Required(ErrorMessage = "لطفا گروه ارتباط را وارد نمایید")]
        public byte GroupId { get; set; }

        [Required(ErrorMessage = "لطفا نام راه ارتباطی را وارد نمایید")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا مقدار راه ارتباطی را وارد نمایید")]
        [MaxLength(4000)]
        public string Value { get; set; }

        [Required(ErrorMessage = "لطفا نوع ارتباط را وارد نمایید")]
        public ConnectionType Type { get; set; }

        [Required(ErrorMessage = "لطفا تصویر راه ارتباطی را وارد نمایید")]
        [MaxLength(100)]
        public string Image { get; set; }


        public virtual ConnectionGroup ConnectionGroup { get; set; }
    }
}
