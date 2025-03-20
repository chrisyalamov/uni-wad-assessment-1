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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * Why take this approach?
             * 
             * Postbacks are carried out using the POST HTTP verb. When a user is POSTed, their
             * browser will think they have carried out an action which changes a remote resource,
             * and therefore shouldn't be unintentionally repeated.
             * 
             * Because of this, when a user presees the back button to return to this page,
             * they are asked if they are sure they'd like to reload the page.
             * 
             * This leads to a confusing UX, so instead, a POST/REDIRECT/GET approach is taken.
             * 
             * https://en.wikipedia.org/wiki/Post/Redirect/Get#:~:text=Post%2FRedirect%2FGet%20(PRG,problem%20encountered%20in%20user%20agents.
             */

            // Connecting to the adapter for retrieving SKUs and their global availability levels
            SkyGardensDSTableAdapters.SKUsAndLevelsTableAdapter table = new SKUsAndLevelsTableAdapter();

            // Retrieving the advanced search options passed in the URL query params
            string filters = Request.Params["filter"];
            string sortMode = Request.Params["sort"];

            // Binding the data source, modified using the filter and selector expressions passed
            // in the query params
            lv_sku.DataSource = table.GetAllSKUsAndStockLevels().Select(String.Join(" and ", filters), sortMode);            
            lv_sku.DataBind();
        }

        protected void btn_newSKU_Click(object sender, EventArgs e)
        {
            // Redirect to the new SKU page
            Response.Redirect("/admin/new.aspx");
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            // Retrieve the sort mode from the drop down
            string sortMode = ddl_sort.SelectedItem.Value;

            // Initialise a list, which will store the different filters, as they are applied
            List<string> filters = new List<string>();

            // If the price filter is enabled
            if (ckb_priceFilter.Checked)
            {
                // First check that a price has been entered
                if (String.IsNullOrEmpty(txt_priceFilter.Text)) 
                {
                    PriceValidator.IsValid = false;
                    return;
                }

                // Add the expression to the filters list
                filters.Add(
                    "(price " + ddl_priceFilter.SelectedValue + " " + txt_priceFilter.Text + ")"
                );
            }

            // If filter only for SKUs with stock level > 0 is selected, add expression
            if (ckb_available.Checked) { filters.Add("(stockLevel > 0)"); }
            // If only non-discontinued filter is selected, add expression
            if (ckb_discontinuedFilter.Checked) { filters.Add("(discontinued = false)"); }


            // Assemble a URL with populated filter and sort query parameters and redirect the user
            // Use Server.UrlEncode to ensure the params are properly encoded before they are sent
            Response.Redirect(
                "/admin/index.aspx?filter=" 
                + Server.UrlEncode(String.Join(" and ", filters)) 
                + "&sort=" 
                + Server.UrlEncode(sortMode)
            );
        }
    }
}