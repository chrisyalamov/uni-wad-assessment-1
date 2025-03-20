using SkyGardens.SkyGardensDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkyGardens
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If the user is already authenticated, send them to the management console
            if (Session?["AuthenticatedAsID"] != null)
            {
                Response.Redirect("/admin/index.aspx");
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            // Connect to the users table adapter
            SkyGardensDSTableAdapters.UsersTableAdapter users = new SkyGardensDSTableAdapters.UsersTableAdapter();
            SkyGardensDS.UsersDataTable userMatches = users.GetUserByUsername(txt_username.Text);

            // If no users with this username found, set validation error
            if (userMatches.Rows.Count == 0) {
                CredentialsValidator.IsValid = false;
                CredentialsValidator.Visible = true;
                return;
            }

            // Extract user
            SkyGardensDS.UsersRow user = userMatches[0];

            // Check that the password is correct
            // NB: This is not a safe method of checking passwords. Please do not enter any personal passwords in this field.
            // Any password processed by this application is stored in PLAIN TEXT. 

            if (user.password != txt_password.Text)
            {
                // If the password does not match, set validation error
                CredentialsValidator.IsValid = false;
                CredentialsValidator.Visible = true;
                return;
            } else
            {
                // Set the user account details in the session
                Session["AuthenticatedAsID"] = user.Id;
                Session["AuthenticatedAsUsername"] = user.username;
                Session["AuthenticatedAsFullname"] = user.fullname;
                Response.Redirect("/admin/index.aspx");
            }
            
        }
    }
}