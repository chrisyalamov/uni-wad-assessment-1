using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkyGardens
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Redirect to homepage if no user is signed in
            if (Session["AuthenticatedAsFullname"] == null)
            {

                Response.Redirect("/index.aspx");
                return;
            }
            lbl_authStatus.Text = Session["AuthenticatedAsFullname"].ToString();
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            // Clear all data from the current session and redirect user back to homepage
            Session.Clear();
            Response.Redirect("/index.aspx");
        }
    }
}