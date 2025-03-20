using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkyGardens.admin
{
    public partial class _new : System.Web.UI.Page
    {
        protected void btn_continue_Click(object sender, EventArgs e)
        {
            // Set all labels to the respective user input
            lbl_Name.Text = txt_name.Text;
            lbl_Description.Text = txt_desc.Text;
            lbl_Origin.Text = ddl_origin.SelectedItem.Text;
            lbl_Price.Text = txt_price.Text;
            lbl_Type.Text = lst_category.SelectedItem.Text;

            // Show the confirmation, hide the initial form
            div_confirm.Visible = true;
            div_form.Visible = false;
        }

        protected void btn_return_Click(object sender, EventArgs e)
        {
            // Revert form visibility
            div_confirm.Visible = false;
            div_form.Visible = true;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            // Connect to the Flower SKU table adapter
            SkyGardensDSTableAdapters.FlowerSKUTableAdapter flowersTable = new SkyGardensDSTableAdapters.FlowerSKUTableAdapter();
            
            // Insert the new flower SKU
            flowersTable.NewSKU(
                    txt_name.Text,
                    txt_desc.Text,
                    decimal.Parse(txt_price.Text),
                    false,
                    ddl_origin.SelectedValue,
                    lst_category.SelectedValue
                );

            // Redirect user to the listing page
            Response.Redirect("/admin/index.aspx");
        }
    }
}