using System;
using System.Web.UI;

public partial class HomeUser : System.Web.UI.Page
{
    DataBaseOperations dbop = new DataBaseOperations();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] != null)
        {
            if (!Page.IsPostBack)
            {
                MAYAVI_USERS_C user = (MAYAVI_USERS_C)Session["USER"];
                HF_UID.Value = user.UID;
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx", false);
        }
    }
}