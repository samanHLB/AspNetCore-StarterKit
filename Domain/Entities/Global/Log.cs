namespace Domain.Entities.Global
{
    public class Logger
    {
        [Key]
        [MaxLength(450)]
        public string Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Path { get; set; }

        [MaxLength(100)]
        public string Page { get; set; }

        [MaxLength(100)]
        public string Handler { get; set; }

        [Required]
        public LogType LogType { get; set; }

        public int StatusCode { get; set; }

        [MaxLength(50)]
        public string IP { get; set; }

        [MaxLength(200)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string TraceId { get; set; }

        [MaxLength(800)]
        public string Message { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
