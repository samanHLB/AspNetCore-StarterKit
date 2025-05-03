namespace Application.Utilities.Extension
{
    public static class MyExtensions
    {
        public static string GenerateRandomSlug(int length = 6)
        {
            while (true)
            {
                Random random = new Random();

                const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqReSsTtUuVvWwXxYyZz0123456789";
                var slug = new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());

                return slug;
            }
        }

        public static string GenerateLinkShortKey(int length = 5)
        {
            string key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);
            return key;
        }

        public static string ToShortText(this string text)
        {
            if (text == null) return "";
            else if (text.Length > 50) return text.Substring(0, 50) + " ...";
            else return text;
        }

        public static string PersianToEnglish(this string persianStr)
        {
            Dictionary<char, char> LettersDictionary = new Dictionary<char, char>
            {
                ['۰'] = '0',
                ['۱'] = '1',
                ['۲'] = '2',
                ['۳'] = '3',
                ['۴'] = '4',
                ['۵'] = '5',
                ['۶'] = '6',
                ['۷'] = '7',
                ['۸'] = '8',
                ['۹'] = '9'
            };

            foreach (var item in persianStr)
            {
                if (LettersDictionary.ContainsKey(item))
                    persianStr = persianStr.Replace(item, LettersDictionary[item]);
            }
            return persianStr;
        }

        public static string ToSlug(this string Value)
        {
            Regex pattern = new Regex("[*/+() ]");
            Value = pattern.Replace(Value, "-");
            return Value;
        }

        public static string ToTitle(this string Value)
        {
            return Value.Replace("-", " ");
        }

        public static string ToMB(this long Value)
        {
            long temp = Value % (1024 * 1024 * 1024);
            long MBs = temp / (1024 * 1024);
            return MBs.ToString() + "MB";
        }

        public static string ToKB(this long Value)
        {
            long MBs = Value / 1024;
            return MBs.ToString() + "KB";
        }

        public static string GenerateSecurityCode(int lenght = 5)
        {
            while (true)
            {
                Random random = new Random();

                const string chars = "0123456789";
                var slug = new string(Enumerable.Repeat(chars, lenght)
                  .Select(s => s[random.Next(s.Length)]).ToArray());

                return slug;
            }
        }



    }
}
