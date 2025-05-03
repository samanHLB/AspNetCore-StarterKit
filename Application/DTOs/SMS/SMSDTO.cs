namespace Application.DTOs.SMS
{
    public class SMSMultipleDTO
    {
        public List<string> Receptor { get; set; }
        public List<string> Sender { get; set; } = new List<string>();
        public List<string> Message { get; set; }
    }
}
