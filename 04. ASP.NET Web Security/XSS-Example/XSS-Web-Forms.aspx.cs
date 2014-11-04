using System;

public partial class XssWebForms : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ButtonJustShowText_Click(object sender, EventArgs e)
    {
        var enteredText = this.TextBoxSampleText.Text;
        this.LabelEnteredText.Text = enteredText;
        this.LiteralEnteredText.Text = enteredText;
    }

    protected void ButtonShowHtmlEncoded_Click(object sender, EventArgs e)
    {
        var enteredText = this.TextBoxSampleText.Text;
        this.LabelEnteredText.Text = Server.HtmlEncode(enteredText);
        this.LiteralEnteredText.Text = Server.HtmlEncode(enteredText);
    }
}
