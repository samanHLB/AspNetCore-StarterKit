namespace Application.Utilities.Services
{
    public class EmailHelper
    {
        public bool SendEmail(string From, string To, string Subject, string Body, string Name)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(From, Name);
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;

            //Attachment attachment;
            //attachment = new Attachment(filePath);
            //mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new NetworkCredential("amirhosseink.7795@gmail.com", "amir1997");
            SmtpServer.EnableSsl = true;

            try
            {
                SmtpServer.Send(mail);
            }
            catch (Exception err)
            {

                return false;
            }
            return true;

        }
    }
}
