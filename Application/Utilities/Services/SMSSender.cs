namespace Application.Utilities.Services
{
    public class SMSSender : ISMSSender
    {
        public static string _APIKEY = "476F5465626336334D50706850596167634D306833665A345536654842356A64"; //ITSA
        private string SENDER = "1000596446";
        private string URL = $"https://api.kavenegar.com/v1/{_APIKEY}";

        public void SendMultipleSMS(SMSMultipleDTO sms)
        {
            using (var client = new HttpClient())
            {
                var url = $"{URL}/sms/sendarray.json";
                sms.Sender.Add(SENDER);
                var jsonBody = JsonConvert.SerializeObject(sms);
                var buffer = Encoding.UTF8.GetBytes(jsonBody);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = client.PostAsync(url, byteContent).Result;
            }
        }

        public async Task SendSMSAsync(string receptor, string message)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync($"{URL}/sms/send.json?receptor={receptor}&sender={SENDER}&message={message}");
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            };
        }

        public async Task SendSMSAsyncWithTemplate(string receptor, string message, string template)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync($"{URL}/verify/lookup.json?receptor={receptor}&token={message}&template={template}");
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            };
        }

        public async Task SendSMSAsyncWithMultipleTemplate(string receptor, List<string> messages, string template, string token10 = "", string token20 = "")
        {
            var link = new StringBuilder();
            link.Append($"{URL}/verify/lookup.json?receptor={receptor}");

            using (var client = new HttpClient())
            {

                for (int i = 0; i < messages.Count; i++)
                {
                    if (i == 0)
                    {
                        link.Append($"&token={messages[i]}");
                    }
                    else
                    {
                        link.Append($"&token{i + 1}={messages[i]}");
                    }
                }
                if (!string.IsNullOrEmpty(token10))
                {
                    link.Append($"&token10={token10}");
                }
                if (!string.IsNullOrEmpty(token20))
                {
                    link.Append($"&token20={token20}");
                }

                link.Append($"&template={template}");

                var result = await client.GetAsync(link.ToString());
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            };
        }


    }
}
