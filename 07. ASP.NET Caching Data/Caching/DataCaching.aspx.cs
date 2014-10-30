namespace Caching
{
    using System;
    using System.Web.Caching;

    public partial class DataCaching : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // this.Cache.Remove("time");
            if (this.Cache["time"] == null)
            {
                // this.Cache["time"] = DateTime.Now;
                Cache.Insert(
                    "time",         // key
                    DateTime.Now,   // object
                    null,           // dependencies
                    DateTime.Now.AddSeconds(10), // absolute exp.
                    TimeSpan.Zero,               // sliding exp.
                    CacheItemPriority.Default,   // priority
                    this.OnRemoveCallback);          // callback delegate
            }

            this.currentTimeSpan.InnerText = ((DateTime)this.Cache["time"]).ToString();
        }

        private void OnRemoveCallback(string key, object value, CacheItemRemovedReason reason)
        {
            // Cache item removed
        }
    }
}