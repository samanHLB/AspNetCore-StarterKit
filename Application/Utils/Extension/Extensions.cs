namespace Application.Utils.Extension;

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

    public static string FloatDotCharFormat(this float number)
    {
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.NumberDecimalSeparator = ".";

        return number.ToString(nfi);
    }

    public static string DoubleToString(this double? value, int num = 13)
    {
        return value.HasValue ? value.Value.ToString($"F{num}", CultureInfo.InvariantCulture) : null;
    }

    public static string DoubleToString(this double value, int num = 13)
    {
        return value > 0 ? value.ToString($"F{num}", CultureInfo.InvariantCulture) : null;
    }

    public static double? StringToDoubleWithNull(this string value)
    {
        return string.IsNullOrEmpty(value) ? null : double.Parse(value, CultureInfo.InvariantCulture);
    }

    public static double StringToDouble(this string value)
    {
        return string.IsNullOrEmpty(value) ? 0 : double.Parse(value, CultureInfo.InvariantCulture);
    }

    public static string D2Format(this TimeSpan timeSpan)
    {
        return string.Format("{0:hh\\:mm}", timeSpan);
    }

    public static string ToToman(this int val)
    {
        if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "fa")
            return val.ToString("#,0 تومان");
        else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en")
            return val.ToString("#,0 $");
        else
            return val.ToString("#,0 التومان");
    }

    public static string ToToman(this Int64 val, bool isTomanText = false)
    {
        if (val <= 0)
            return "-";

        if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "fa")
        {
            if (isTomanText)
                return val.ToString("#,0 تومان");

            return val.ToString("#,0");
        }
        else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en")
            return val.ToString("#,0 $");
        else
            return val.ToString("#,0 التومان");
    }

    public static string ToToman(this Int64? val, bool isTomanText = false)
    {
        if (!val.HasValue)
            return "-";

        if (val.Value <= 0)
            return "-";

        if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "fa")
        {
            if (isTomanText)
                return val.Value.ToString("#,0 تومان");

            return val.Value.ToString("#,0");
        }
        else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en")
            return val.Value.ToString("#,0 $");
        else
            return val.Value.ToString("#,0 التومان");
    }

    public static string ToCurrency(this int val)
    {
        return val.ToString("#,0");
    }

    public static string ToCurrency(this object val)
    {
        var price = Convert.ToInt32(val);
        return (price).ToString("#,0");
    }

    public static string ToDerham(this decimal value)
    {
        var result = string.Format(new CultureInfo("ar-AE"), "{0:C}", value);
        return result;
    }

    public static string ToDollarWithoutSign(this decimal value)
    {
        var result = String.Format("{0:N}", value);
        return result;
    }

    public static string ToRial(this string val)
    {
        var price = Convert.ToUInt32(val) * 10;
        return price.ToString("#,0 ریال");
    }



}
