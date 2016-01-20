namespace Caching
{
    using System;
    using System.Web.UI;

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Response.Cache.SetCacheability(HttpCacheability.Public);
            // Response.Cache.SetMaxAge(new TimeSpan(1, 0, 0));
        }
    }
}