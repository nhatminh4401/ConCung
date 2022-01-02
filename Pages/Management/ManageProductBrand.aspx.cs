using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConCung.Management
{
    public partial class ManageProductBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connString);
            sqlCon.Open();

            string BrandName = txtBrand.Text.Trim();
            string Origin = txtFromNation.Text.Trim();

            String AmountQuery = "SELECT COUNT(*) FROM THUONGHIEU";
            SqlCommand sqlCommand = new SqlCommand(AmountQuery, sqlCon);
            Int32 count = (Int32)sqlCommand.ExecuteScalar();

            string BrandID = "";
            if (count >= 0 && count <= 9)
            {
                count++;
                BrandID = "TH000" + count.ToString();
            }
            else if (count >= 10 && count <= 99)
            {
                count++;
                BrandID = "TH00" + count.ToString();
            }
            else if (count >= 100 && count <= 999)
            {
                count++;
                BrandID = "TH0" + count.ToString();
            }
            else
            {
                count++;
                BrandID = "TH" + count.ToString();
            }

            string query = "INSERT INTO THUONGHIEU (MA_TH, TEN_TH, XUATXU_TH) VALUES ('" + BrandID + "', N'" + BrandName + "', N'" + Origin + "')";
            sqlCommand = new SqlCommand(query, sqlCon);
            sqlCommand.ExecuteNonQuery();

            lblResult.Text = "Đã thêm thương hiệu " + BrandName;
            sqlCon.Close();
        }
    }
}