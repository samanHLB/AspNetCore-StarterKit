namespace Application.Utilities.Extension
{
    public static class Formatter
    {
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
}
