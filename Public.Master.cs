using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkyGardens.admin
{
    public partial class Public : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Populate the bottom authentication status bar
            if (Session["AuthenticatedAsFullname"] != null)
            {
                lbl_authStatus.Text = "Logged in as " + Session["AuthenticatedAsFullname"].ToString();
            } else
            {
                lbl_authStatus.Text = "Not authenticated.";
                btn_console.Visible = false;
                btn_logout.Visible = false;
            }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            // Clear the user session and redirect to main page
            Session.Clear();
            Response.Redirect("/index.aspx");
        }

        protected void btn_console_Click(object sender, EventArgs e)
        {
            // Redirect to management console
            Response.Redirect("/admin/index.aspx");
        }
    }
}