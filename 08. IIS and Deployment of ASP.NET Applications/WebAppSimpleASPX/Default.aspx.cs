namespace WebAppSimpleASPX
{
    using System;

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonGreetings_Click(object sender, EventArgs e)
        {
            this.LiteralGreetings.Text = "Hello, " + this.TextBoxName.Text + "!";
        }
    }
}