namespace Caching
{
    using System;
    using System.Globalization;
    using System.Web.Caching;

    public class Time
    {
        public DateTime DateTime { get; set; }
    }

    public partial class DataCaching : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // this.Cache.Remove("time");
            if (this.Cache["time"] == null)
            {
                var data = new Time { DateTime = DateTime.Now };
                // this.Cache["time"] = DateTime.Now;
                Cache.Insert(
                    "time",                           // key
                    data,                     // value
                    null,                             // dependencies
                    DateTime.Now.AddSeconds(10),      // absolute exp.
                    TimeSpan.Zero,                    // sliding exp.
                    CacheItemPriority.Default,        // priority
                    this.OnCacheItemRemovedCallback); // callback delegate
                data.DateTime = new DateTime(1990, 6, 22);
            }

            this.currentTimeSpan.InnerText = (((Time)this.Cache["time"]).DateTime).ToString(CultureInfo.InvariantCulture);
        }

        private void OnCacheItemRemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            // Cache item removed
        }
    }
}