namespace Application.Utilities.Extension
{
    public static class GenerateShortLink
    {
        private static IHttpContextAccessor HttpContextAccessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public static string GenerateKey(int length = 4)
        {
            var key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);

            return key;
        }

        public static string CreateShortLink(HttpContext context, string routeIdentifier, string key)
        {
            string link = context.Request.Scheme + "/" +
                context.Request.Host + "/" +
                routeIdentifier + "/" +
                key;
            return link;
        }
    }
}
