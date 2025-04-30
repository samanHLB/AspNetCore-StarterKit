namespace Application.Utilities.Services
{
    public class ElasticEmails
    {
        public static string _APIKEY = "B160E2C28504975EE75722CE9B24DE4EEF51F5ABCBAE6D1B13C6A669DF49ECA2DB485142C02847C06B4C4B08CD9D9603";
        public void Configuration(string Recipients, string Body, string title)
        {
            NameValueCollection values = new NameValueCollection();
            values.Add("apikey", "B160E2C28504975EE75722CE9B24DE4EEF51F5ABCBAE6D1B13C6A669DF49ECA2DB485142C02847C06B4C4B08CD9D9603");
            values.Add("from", "amirhosseink.7795@gmail.com");
            values.Add("fromName", "ITSACO");
            values.Add("to", Recipients); //"recipient1@gmail.com;recipient2@gmail.com");
            values.Add("subject", title);
            values.Add("bodyText", "سلام همراه سایت دیجی پسته !");
            values.Add("bodyHtml", Body);
            values.Add("isTransactional", "true");

            string address = "https://api.elasticemail.com/v2/email/send";

            string response = Send(address, values);
        }
        static string Send(string address, NameValueCollection values)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    byte[] apiResponse = client.UploadValues(address, values);
                    return Encoding.UTF8.GetString(apiResponse);

                }
                catch (Exception ex)
                {
                    return "Exception caught: " + ex.Message + "\n" + ex.StackTrace;
                }
            }
        }
        public static async Task<string> GetTempates()
        {
            using (var client = new HttpClient())
            {
                try
                {

                    var apiResponse = await client.GetAsync($"https://api.elasticemail.com/v2/template/getlist?apikey={_APIKEY}");
                    string resultContent = await apiResponse.Content.ReadAsStringAsync();
                    return resultContent;
                }
                catch (Exception ex)
                {
                    return "Exception caught: " + ex.Message + "\n" + ex.StackTrace;
                }
            }
        }
    }
}
