using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConCung.Pages
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        private void FillPage()
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                string id = Convert.ToString(Request.QueryString["id"]);
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
                SqlConnection sqlCon = new SqlConnection(connString);
                sqlCon.Open();
                
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SANPHAM WHERE MA_SP='" + id + "' ORDER BY TEN_SP", sqlCon);
                sqlCommand.ExecuteNonQuery();
                sqlCon.Close();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(dt);
                string productName = "";
                string productDescription = "";
                string productPrice = "";
                string image = "";
                foreach (DataRow dr in dt.Rows)
                {
                    productName = dr["TEN_SP"].ToString();
                    productDescription = dr["MIEUTA"].ToString();
                    productPrice = dr["GIA"].ToString();
                    image = dr["IMAGE"].ToString();
                }

                //Fill page with data
                lblTitle.Text = productName;
                lblDescription.Text = productDescription;
                lblPrice.Text = "Giá mỗi sản phẩm: <br/>" + productPrice + " ₫";
                imgProduct.ImageUrl = "~/Image/Products/" + image;
                lblItemNr.Text = id;

                //Fill amount list with numbers 1-20
                int[] amount = Enumerable.Range(1, 20).ToArray();
                ddlAmount.DataSource = amount;
                ddlAmount.AppendDataBoundItems = true;
                ddlAmount.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                if (DataContainer.login == true)
                {
                    string id = Convert.ToString(Request.QueryString["id"]);
                    int amount = Convert.ToInt32(ddlAmount.SelectedValue);
                    string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
                    SqlConnection sqlCon = new SqlConnection(connString);
                    sqlCon.Open();

                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO GIOHANG (SDT, MA_SP, SOLUONG) VALUES ('" + DataContainer.userPhoneNum + "', '" + id + "', " + amount.ToString() + ")", sqlCon);

                    sqlCommand.ExecuteNonQuery();
                    sqlCon.Close();
                    lblResult.Text = "Đã thêm sản phẩm vào giỏ hàng.";
                }
                else
                {
                    lblResult.Text = "Vui lòng đăng nhập để có thể đặt hàng!";
                }
                
            }
        }
    }
}