using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConCung
{
    
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DataContainer.login == true)
            {
                litStatus.Text = DataContainer.userName;
                LnkLogIn.Visible = false;
                lnkRegister.Visible = false;

                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(connString);
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM GIOHANG WHERE SDT='" + DataContainer.userPhoneNum + "'", sqlCon);
                int amount = (int)sqlCommand.ExecuteScalar();
                sqlCon.Close();

                HyperLink3.Text = string.Format("{0} ({1})", "Shopping Cart", amount.ToString());
                HyperLink3.Visible = true;
                HyperLink4.Visible = false;
                litStatus.Visible = true;
                btnLogOut.Visible = true;
                if (DataContainer.managerCheck == true)
                {
                    HyperLink4.Visible = true;
                    HyperLink3.Visible = false;
                }
            }
            else
            {
                LnkLogIn.Visible = true;
                lnkRegister.Visible = true;

                litStatus.Visible = false;
                btnLogOut.Visible = false;
                HyperLink4.Visible = false;
                HyperLink3.Visible = false;
            }
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            DataContainer.login = false;
            DataContainer.userPhoneNum = "";
            DataContainer.userName = "";
            DataContainer.managerCheck = false;
            Response.Redirect("~/Index.aspx");
        }
    }
    public static class DataContainer
    {
        public static bool login = false;
        public static string userPhoneNum = "0938391731";
        public static string userName = "";
        public static bool managerCheck = false;
        public static string productType = "All";
    }
}