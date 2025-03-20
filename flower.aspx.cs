using SkyGardens.SkyGardensDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SkyGardens.admin
{
    public partial class flower : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // First, check if the "id" parameter is an integer. Return an error if not.
            if (!Int32.TryParse(Request.Params["id"], out _))
            {
                Response.StatusCode = 400;
                Response.StatusDescription = "Malformed SKU ID";
                Response.End();
            }

            // Connect to flowers table adapter and retrieve the flower/SKU with the provided ID
            SkyGardensDSTableAdapters.FlowerSKUTableAdapter flowersTable = new SkyGardensDSTableAdapters.FlowerSKUTableAdapter();
            SkyGardensDS.FlowerSKUDataTable matches = flowersTable.GetSKUById(int.Parse(Request.Params["id"]));

            // If there are no matches, return a 404 error
            if (matches.Count == 0)
            {
                Response.StatusCode = 404;
                Response.StatusDescription = "SKU with the provided ID has not been found";
                Response.End();
            }

            // Extract the first and only match (there may only be one, as "id" is the PK)
            SkyGardensDS.FlowerSKURow sku = matches[0];

            // Connect to the adapter which pulls information regarding stock levels and retrieve
            // the levels reported for the given SKU ID. Bind this as the datasource for the grid view.
            SkyGardensDSTableAdapters.LocationLevelsTableAdapter locationLevels = new SkyGardensDSTableAdapters.LocationLevelsTableAdapter();
            gv_stock.DataSource = locationLevels.GetSKULevelsAllLocations(sku.Id);
            gv_stock.DataBind();

            // Trip-switch to exit the function early, unless this is the first time we are requesting this page
            // E.g. if this controller fired because of a postback event (e.g. the save button was pressed),
            // we do not want to override the values in the inputs that the user provided.
            if (IsPostBack) return;

            // Populating the fields from the database
            lbl_skuHeadingId.InnerText = sku.Id.ToString();
            lbl_skuHeadingName.InnerText = sku.name;
            lbl_skuTitle.Text = sku.name + " (" + sku.Id.ToString() + ")";

            txt_name.Text = sku.name;
            txt_desc.Text = sku.description;
            txt_price.Text = sku.price.ToString();

            ckb_discontinued.Checked = sku.discontinued;
            lst_category.SelectedValue = sku.product_type;

            ddl_origin.SelectedValue = sku.origin;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            // Connecting to the flowers table
            SkyGardensDSTableAdapters.FlowerSKUTableAdapter flowersTable = new SkyGardensDSTableAdapters.FlowerSKUTableAdapter();

            // Updating the record
            flowersTable.UpdateSKU(
                txt_name.Text,
                txt_desc.Text,
                decimal.Parse(txt_price.Text),
                ckb_discontinued.Checked,
                ddl_origin.SelectedValue,
                lst_category.SelectedValue,
                int.Parse(Request.Params["id"])
            );

            // Redirecting to the main listing page 
            Response.Redirect("/admin/index.aspx");
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            // Connecting to the flower SKUs table
            SkyGardensDSTableAdapters.FlowerSKUTableAdapter flowersTable = new SkyGardensDSTableAdapters.FlowerSKUTableAdapter();
            
            // Deleting record and redirecting
            flowersTable.DeleteSKU(int.Parse(Request.Params["id"]));
            Response.Redirect("/admin/index.aspx");
        }
    }
}