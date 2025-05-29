namespace Application.Utils.Services
{
    public interface ISMSSender
    {
        Task SendSMSAsync(string receptor, string message);
        Task SendSMSAsyncWithTemplate(string receptor, string message,string template);
        void SendMultipleSMS(SMSMultipleDTO sms);
        Task SendSMSAsyncWithMultipleTemplate(string receptor, List<string> messages, string template, string token10 = "", string token20 = "");
    }
}
