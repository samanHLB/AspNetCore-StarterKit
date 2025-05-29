namespace Application.DTOs.SMS
{
    public class SMSMultipleDTO
    {
        public required List<string> Receptor { get; set; }
        public required List<string> Sender { get; set; } = new List<string>();
        public required List<string> Message { get; set; }
    }
}
