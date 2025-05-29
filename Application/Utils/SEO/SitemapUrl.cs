namespace Application.Utils.SEO;

public enum SiteMapType { sitemap_products, sitemap_contents, sitemap_files };

public static class EnumSiteMapType
{
    public static IEnumerable<T> GetValues<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }
}

public enum ChangeFrequency
{
    Always,
    Hourly,
    Daily,
    Weekly,
    Monthly,
    Yearly,
    Never
}

public class SitemapUrl
{
    public string Url { get; set; }
    public DateTime? Modified { get; set; }
    public ChangeFrequency? ChangeFrequency { get; set; }
    public string Priority { get; set; }
}
