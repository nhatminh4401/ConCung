using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConCung.Pages.Management
{
    public partial class ManageMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Management/ManageProduct.aspx");
        }

        protected void btnProductType_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Management/ManageProductType.aspx");
        }

        protected void btnBrand_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Management/ManageProductBrand.aspx");
        }
    }
}