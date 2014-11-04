namespace SQL_Injection_Example
{
    using System;
    using System.Linq;

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var context = new MessagesDbContext();
                this.ListViewMessages.DataSource = context.Messages.ToList();
                this.DataBind();
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            var searchString = this.TextBoxSearch.Text;
            var searchSql = "SELECT * FROM Messages WHERE MessageText LIKE '%" + searchString + "%'";
            var context = new MessagesDbContext();
            var matchingMessages =
                context.Database.SqlQuery<Message>(searchSql).ToList();
            this.ListViewMessages.DataSource = matchingMessages;
            this.DataBind();
        }

        //// // The right way yo do it:
        //// protected void ButtonSearch_Click(object sender, EventArgs e)
        //// {
        ////     // This search works correctly, no SQL injection is possible
        ////     const string SearchSql = @"SELECT * FROM Messages WHERE MessageText LIKE {0} ESCAPE '~'";
        ////     var searchString = "%" + this.TextBoxSearch.Text.Replace("~", "~~").Replace("%", "~%") + "%";
        ////     var context = new MessagesDbContext();
        ////     var matchingMessages =
        ////         context.Database.SqlQuery<Message>(SearchSql, searchString).ToList();
        ////     this.ListViewMessages.DataSource = matchingMessages;
        ////     this.DataBind();
        //// }
    }
}
