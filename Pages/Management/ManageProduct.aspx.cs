using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConCung.Management
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                getImages();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((ddlSale.Items.FindByText("Không") == null))
            {
                ddlSale.Items.Insert(0, new ListItem("Không", "NULL"));
                ddlSale.SelectedValue = "NULL";
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connString);
            sqlCon.Open();

            string ProductName = txtProductName.Text.Trim();
            string Description = txtDescription.Text.Trim();
            string ProductType = ddlProductType.SelectedValue.ToString();
            string Brand = ddlBrand.SelectedValue.ToString();
            bool combo = cboxCombo.Checked;
            string SaleCode = ddlSale.SelectedValue.ToString();
            double Price = Convert.ToDouble(txtPrice.Text);
            int Amount = Convert.ToInt32(txtAmount.Text);
            string Image = ddlImages.SelectedValue.ToString();

            String AmountQuery = "SELECT COUNT(*) FROM SANPHAM";
            SqlCommand sqlCommand = new SqlCommand(AmountQuery, sqlCon);
            Int32 count = (Int32)sqlCommand.ExecuteScalar();

            string ProductID = "";
            if (count >= 0 && count <= 9)
            {
                count++;
                ProductID = "SP0000000" + count.ToString();
            }
            else if (count >= 10 && count <= 99)
            {
                count++;
                ProductID = "SP000000" + count.ToString();
            }
            else if (count >= 100 && count <= 999)
            {
                count++;
                ProductID = "SP00000" + count.ToString();
            }
            else if (count >= 1000 && count <= 9999)
            {
                count++;
                ProductID = "SP0000" + count.ToString();
            }
            else if (count >= 10000 && count <= 99999)
            {
                count++;
                ProductID = "SP000" + count.ToString();
            }
            else if (count >= 100000 && count <= 999999)
            {
                count++;
                ProductID = "SP00" + count.ToString();
            }
            else if (count >= 1000000 && count <= 9999999)
            {
                count++;
                ProductID = "SP0" + count.ToString();
            }
            else
            {
                count++;
                ProductID = "SP" + count.ToString();
            }
            int cb;
            if (combo == true)
            {
                cb = 1;
            }
            else
            {
                cb = 0;
            }

            if (SaleCode != "NULL")
            {
                SaleCode = "'" + SaleCode + "'";
            }

            string query = "INSERT INTO SANPHAM (MA_SP, TEN_SP, MIEUTA, MA_LOAI, MA_TH, COMBO, MA_KM, GIA, SOLUONGTON, IMAGE) " +
                "VALUES ('" + ProductID + "', N'" + ProductName + "', N'" + Description + "', '" + ProductType + "', '" + Brand + "', " + cb.ToString() + ", " + SaleCode + ", " + Price.ToString() + ", " + Amount.ToString() + ", '" + Image + "')";
            sqlCommand = new SqlCommand(query, sqlCon);
            sqlCommand.ExecuteNonQuery();

            lblResult.Text = "Đã thêm sản phẩm " + ProductName;
            sqlCon.Close();
        }

        private void getImages()
        {
            try
            {
                string[] images = Directory.GetFiles(Server.MapPath("~/Image/Products/"));

                ArrayList imageList = new ArrayList(); 
                foreach (string image in images)
                {
                    string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                    imageList.Add(imageName);

                }

                ddlImages.DataSource = imageList;
                ddlImages.AppendDataBoundItems = true;
                ddlImages.DataBind();
            }
            catch(Exception ex)
            {
                lblResult.Text = ex.ToString();
            }
        }
    }
}