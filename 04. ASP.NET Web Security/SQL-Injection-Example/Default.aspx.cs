using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQL_Injection_Example
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MessagesDbContext dbContext = new MessagesDbContext();
                this.ListViewMessages.DataSource = dbContext.Messages.ToList();
                this.DataBind();
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string searchString = this.TextBoxSearch.Text;
            string searchSql = "SELECT * FROM Messages WHERE MessageText LIKE '%" + searchString + "%'";
            MessagesDbContext dbContext = new MessagesDbContext();
            var matchingMessages =
                dbContext.Database.SqlQuery<Message>(searchSql).ToList();
            this.ListViewMessages.DataSource = matchingMessages;
            this.DataBind();
        }

        //protected void ButtonSearch_Click(object sender, EventArgs e)
        //{
        //    // This search works correctly, no SQL injection is possible
        //    string searchSql = @"SELECT * FROM Messages WHERE MessageText LIKE {0} ESCAPE '~'";
        //    string searchString = "%" + this.TextBoxSearch.Text.Replace("~", "~~").Replace("%", "~%") + "%";
        //    MessagesDbContext dbContext = new MessagesDbContext();
        //    var matchingMessages =
        //        dbContext.Database.SqlQuery<Message>(searchSql, searchString).ToList();
        //    this.ListViewMessages.DataSource = matchingMessages;
        //    this.DataBind();
        //}
    }
}
