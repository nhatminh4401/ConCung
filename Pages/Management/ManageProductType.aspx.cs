using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace ConCung.Management
{
    public partial class ManageProductType : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connString);
            sqlCon.Open();

            string ProductType = txtProductType.Text.Trim();
            string BelongProductID = DropDownList1.SelectedValue.ToString();

            String AmountQuery = "SELECT COUNT(*) FROM LOAISP";
            SqlCommand sqlCommand = new SqlCommand(AmountQuery, sqlCon);
            Int32 count = (Int32)sqlCommand.ExecuteScalar();

            string ProductID = "";
            if (count >= 0 && count <= 9)
            {
                count++;
                ProductID = "LSP00" + count.ToString();
            }
            else if (count >= 10 && count <= 99)
            {
                count++;
                ProductID = "LSP0" + count.ToString();
            }
            else
            {
                count++;
                ProductID = "LSP" + count.ToString();
            }

            if (BelongProductID != "NULL")
            {
                BelongProductID = "'" + BelongProductID + "'";
            }

            string query = "INSERT INTO LOAISP (MA_LOAI, TEN_LOAI, LOAISP_CHA) VALUES ('" + ProductID + "', N'" + ProductType + "', " + BelongProductID + ")";
            sqlCommand = new SqlCommand(query, sqlCon);
            sqlCommand.ExecuteNonQuery();

            lblResult.Text = "Đã thêm loại sản phẩm " + ProductType;
            sqlCon.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((DropDownList1.Items.FindByText("Không") == null))
            {
                DropDownList1.Items.Insert(0, new ListItem("Không", "NULL"));
                DropDownList1.SelectedValue = "NULL";
            }
        }
    }
}