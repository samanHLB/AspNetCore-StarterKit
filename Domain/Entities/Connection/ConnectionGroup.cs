namespace Domain.Entities.Connection
{
    public class ConnectionGroup
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage ="لطفا عنوان گروه را وارد نمایید")]
        public string Title { get; set; }

        [MaxLength(300)]
        [Required]
        public string Slug { get; set; }

        public bool IsActive { get; set; }

        public virtual List<Connection> Connections { get; set; }
    }
}
