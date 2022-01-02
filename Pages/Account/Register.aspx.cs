using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConCung.Pages.Account
{
    public partial class Register1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Account/RegisterCustomer.aspx");
        }

        protected void btnManager_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Account/RegisterManager.aspx");
        }
    }
}