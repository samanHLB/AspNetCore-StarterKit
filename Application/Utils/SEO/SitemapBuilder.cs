﻿namespace Application.Utils.SEO;

public class SitemapBuilder
{
    private readonly XNamespace NS = "http://www.sitemaps.org/schemas/sitemap/0.9";

    private List<SitemapUrl> _urls;

    public SitemapBuilder()
    {
        _urls = new List<SitemapUrl>();
    }

    public void AddUrl(string url, DateTime? modified = null, ChangeFrequency? changeFrequency = null, string priority = null)
    {
        _urls.Add(new SitemapUrl()
        {
            Url = url,
            Modified = modified,
            ChangeFrequency = changeFrequency,
            Priority = priority,
        });
    }

    public override string ToString()
    {
        var sitemap = new XDocument(
            new XDeclaration("1.0", "utf-8", null),
            new XElement(NS + "urlset",
                from item in _urls
                select CreateItemElement(item)
                ));

        StringWriter wr = new UT8StringWriter();
        sitemap.Save(wr,SaveOptions.None);
        Console.Write(wr.ToString());
        return wr.ToString();
    }

    private XElement CreateItemElement(SitemapUrl url)
    {
        XElement itemElement = new XElement(NS + "url", new XElement(NS + "loc", url.Url));

        if (url.Modified.HasValue)
        {
            itemElement.Add(new XElement(NS + "lastmod", url.Modified.Value.ToString("yyyy-MM-ddTHH:mm:ss.f") + "+00:00"));
        }

        if (url.ChangeFrequency.HasValue)
        {
            itemElement.Add(new XElement(NS + "changefreq", url.ChangeFrequency.Value.ToString().ToLower()));
        }

        if (url.Priority != "")
        {
            itemElement.Add(new XElement(NS + "priority", url.Priority.ToString()));
        }

        return itemElement;
    }
}

public class UT8StringWriter:StringWriter
{
    public override Encoding Encoding { get { return Encoding.UTF8; } }
}
