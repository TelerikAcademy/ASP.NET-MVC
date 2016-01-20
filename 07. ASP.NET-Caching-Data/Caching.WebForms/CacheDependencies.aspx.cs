namespace Caching
{
    using System;
    using System.IO;
    using System.Web.Caching;

    public partial class CacheDependencies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\file.txt";
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "content");
            }

            if (this.Cache["file"] == null)
            {
                var dependency = new CacheDependency(filePath);
                var content = string.Format("{0} [{1}]", File.ReadAllText(filePath), DateTime.Now);
                Cache.Insert(
                    "file",                    // key
                    content,                   // object
                    dependency,                // dependencies
                    DateTime.Now.AddHours(1),  // absolute exp.
                    TimeSpan.Zero,             // sliding exp.
                    CacheItemPriority.Default, // priority
                    null);                     // callback delegate
            }

            this.filePathSpan.InnerText = filePath;
            this.currentTimeSpan.InnerText = this.Cache["file"] as string;
        }
    }
}