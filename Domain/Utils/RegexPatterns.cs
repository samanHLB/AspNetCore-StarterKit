namespace Domain.Utils;

public static class RegexPatterns
{
    public const string Number = @"^[0-9]*$";
    public const string Mobile = @"^[0][9]?(9\d{9})$";
    public const string PhoneNumber = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$";
    public const string PostalCode = @"^\d{10}$";
    public const string Slug = @"^[a-zA-Z0-9\- \u0600-\u06FF]+$";
    public const string Permission = "^permission.[a-zA-Z0-9-.]*$";

}