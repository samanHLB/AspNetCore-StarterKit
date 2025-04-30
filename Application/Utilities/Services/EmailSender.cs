namespace Application.Utilities
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string messsage)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    message.To.Add(new MailAddress(email));
                    message.From = new MailAddress(_configuration["EmailSender:Email"], _configuration["GlobalConfig:LatinSiteName"]);
                    message.Subject = subject;
                    message.Body = messsage;
                    message.IsBodyHtml = true;

                    using (var client = new SmtpClient(_configuration["EmailSender:Host"]))
                    {
                        client.Port = 25;
                        client.Credentials = new NetworkCredential(_configuration["EmailSender:UserName"], _configuration["EmailSender:Password"]);
                        client.EnableSsl = false;
                        client.Send(message);
                    }
                }
            }
            catch (Exception er)
            {

                throw;
            }

            await Task.CompletedTask;
        }
        public async Task SendEmailNewsLetterAsync(string email,string subject,string body)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    message.To.Add(new MailAddress(email));
                    message.From = new MailAddress(_configuration["EmailSender:Email"], "تخفیفان فرش");
                    message.Subject =subject;
                    message.Body = body;
                    message.IsBodyHtml = true;

                    using (var client = new SmtpClient(_configuration["EmailSender:Host"]))
                    {
                        client.Port = 25;
                        client.Credentials = new NetworkCredential(_configuration["EmailSender:UserName"], _configuration["EmailSender:Password"]);
                        client.EnableSsl = false;
                        client.Send(message);
                    }
                }


            }
            catch (Exception er)
            {

                throw;
            }

            await Task.CompletedTask;
        }

        public async Task SendEmailWithFileAsync(string email, string subject, string message, string filePath)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = _configuration["EmailSender:UserName"],
                    Password = _configuration["EmailSender:Password"]
                };

                client.Credentials = credential;
                client.Host = _configuration["EmailSender:Host"];
                client.Port = int.Parse(_configuration["EmailSender:Port"]);
                client.EnableSsl = false;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(email));
                    emailMessage.From = new MailAddress(_configuration["EmailSender:Email"]);
                    emailMessage.Subject = subject;
                    emailMessage.IsBodyHtml = true;
                    emailMessage.Body = message;

                    if (filePath != null)
                    {
                        Attachment attachment;
                        attachment = new Attachment(filePath);
                        emailMessage.Attachments.Add(attachment);
                    }

                    client.Send(emailMessage);
                }
            }
            await Task.CompletedTask;
        }
    }

}
