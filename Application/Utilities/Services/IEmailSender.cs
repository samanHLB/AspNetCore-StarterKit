namespace Application.Utilities
{
    public interface IEmailSender
    {
        Task SendEmailAsync( string email, string subject, string message);
        Task SendEmailNewsLetterAsync( string email, string subject, string body);
        Task SendEmailWithFileAsync( string email, string subject, string message, string filePath);
    }
}
