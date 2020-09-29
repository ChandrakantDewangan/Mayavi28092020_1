using System;

public partial class Home : System.Web.UI.Page
{
    DataBaseOperations dbop = new DataBaseOperations();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void txtEMAIL_TextChanged(object sender, EventArgs e)
    {
        Login();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Login();
    }
    public void Login()
    {
        if (!string.IsNullOrWhiteSpace(txtEMAIL.Text.Trim()))
        {
            modalLogin.Show();
            lblMAIL.Text = txtEMAIL.Text.Trim();
            MAYAVI_USERS_C user = dbop.GetMayaviUserByMail(lblMAIL.Text.Trim());
            if (!string.IsNullOrWhiteSpace(user.EMAIL))
            {
                lblLoginHead.Text = "Login";
                txtUSER_NAME.Text = user.USER_NAME;
                txtUSER_NAME.Enabled = false;
                txtConfirm.Visible = false;
                btnSubmit.Text = "Login";
                txtPWD.Focus();
            }
            else
            {
                lblLoginHead.Text = "Sign Up";
                btnSubmit.Text = "Sign Up";
                txtUSER_NAME.Enabled = true;
                txtConfirm.Visible = true;
                txtUSER_NAME.Focus();
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string ErrorMsg = "";
        int ErrorCnt = 0;
        MD5Encryption md5 = new MD5Encryption();
        if (lblLoginHead.Text == "Login")
        {
            if (string.IsNullOrWhiteSpace(txtEMAIL.Text.Trim()))
            {
                ErrorMsg += "Enter e-mail<br/>";
                ErrorCnt++;
            }
            if (string.IsNullOrWhiteSpace(txtPWD.Text.Trim()))
            {
                ErrorMsg += "Enter password<br/>";
                ErrorCnt++;
            }
            if (ErrorCnt > 0)
            {
                lblMessage.Text = ErrorMsg;
            }
            else
            {
                string PWD = md5.ClientDecrypt(txtPWD.Text.Trim());
                MAYAVI_USERS_C user = dbop.GetMayaviUserByMailPwd(txtEMAIL.Text.Trim(), PWD);
                if (!string.IsNullOrWhiteSpace(user.UID))
                {
                    Session["USER"] = user;
                    Response.Redirect("~/HomeUser.aspx", false);
                }
                else
                {
                    lblMessage.Text = "<h2>Failed...</h2>Invalid User";
                }
            }
        }
        else
        {
            if (string.IsNullOrWhiteSpace(txtUSER_NAME.Text.Trim()))
            {
                ErrorMsg += "Enter Full Name<br/>";
                ErrorCnt++;
            }
            if (string.IsNullOrWhiteSpace(lblMAIL.Text.Trim()))
            {
                ErrorMsg += "Enter e-mail<br/>";
                ErrorCnt++;
            }
            if (string.IsNullOrWhiteSpace(txtPWD.Text.Trim()))
            {
                ErrorMsg += "Enter password<br/>";
                ErrorCnt++;
            }
            if (string.IsNullOrWhiteSpace(txtConfirm.Text.Trim()))
            {
                ErrorMsg += "Enter confirm password<br/>";
                ErrorCnt++;
            }
            if (!string.IsNullOrWhiteSpace(txtConfirm.Text.Trim()))
            {
                string PWD = md5.ClientDecrypt(txtPWD.Text.Trim());
                if (PWD != txtConfirm.Text.Trim())
                {
                    ErrorMsg += "password and confirm password should be same<br/>";
                    ErrorCnt++;
                }
            }
            if (ErrorCnt > 0)
            {
                lblMessage.Text = ErrorMsg;
            }
            else
            {
                MAYAVI_USERS_C user = dbop.GetMayaviUserByMail(txtEMAIL.Text.Trim());
                if (string.IsNullOrWhiteSpace(user.UID))
                {
                    int AffectedRow = dbop.InsertMayavi_Users(txtUSER_NAME.Text.Trim(), txtEMAIL.Text.Trim(), txtConfirm.Text.Trim());
                    if (AffectedRow > 0)
                    {
                        string PWD = md5.ClientDecrypt(txtPWD.Text.Trim());
                        MAYAVI_USERS_C user1 = dbop.GetMayaviUserByMailPwd(txtEMAIL.Text.Trim(), PWD);
                        if (!string.IsNullOrWhiteSpace(user1.UID))
                        {
                            Session["USER"] = user1;
                            Response.Redirect("~/HomeUser.aspx", false);
                        }
                        else
                        {
                            lblMessage.Text = "<h2>Failed...</h2>Invalid User";
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "<h2>Failed...</h2>User already exists";
                }
            }
        }
        modalLogin.Show();
    }
}