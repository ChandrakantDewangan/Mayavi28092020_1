using System;

public partial class MasterPageReg : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] != null)
        {

        }
        else
        {
            Response.Redirect("~/Home.aspx", false);
        }
    }
}
