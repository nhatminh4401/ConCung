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
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = DataContainer.userPhoneNum;
            GetPurchasesInCart(id);
        }
        protected void Delete_Item(object sender, EventArgs e)
        {
            LinkButton selectedLink = (LinkButton)sender;
            string link = selectedLink.ID.Replace("del", "");
            string productId = link;

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connString);
            sqlCon.Open();
            SqlCommand sqlCommand = new SqlCommand("DELETE GIOHANG WHERE SDT='" + DataContainer.userPhoneNum + "' AND MA_SP='" + productId + "'", sqlCon);
            sqlCommand.ExecuteNonQuery();
            sqlCon.Close();

            Response.Redirect("~/Pages/ShoppingCart.aspx");
        }

        private void ddlAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get ID of product that has had its quantity dropdownlist changed.
            DropDownList selectedList = (DropDownList)sender;
            int quantity = Convert.ToInt32(selectedList.SelectedValue);
            string productId = selectedList.ID;

            //Update purchase with new quantity and refresh page
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connString);
            sqlCon.Open();
            SqlCommand sqlCommand = new SqlCommand("UPDATE GIOHANG SET SOLUONG = " + quantity.ToString() + " WHERE SDT='" + DataContainer.userPhoneNum + "'AND MA_SP='" + productId + "'", sqlCon);
            sqlCommand.ExecuteNonQuery();
            sqlCon.Close();

            Response.Redirect("~/Pages/ShoppingCart.aspx");
        }
        private void GetPurchasesInCart(string id)
        {
            double subTotal = 0;
            CreateShopTable(out subTotal);

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connString);
            sqlCon.Open();

            String AmountQuery = "SELECT TONGTIEN FROM BOME WHERE SDT='" + id + "'";
            SqlCommand sqlCommand = new SqlCommand(AmountQuery, sqlCon);
            subTotal = (double)sqlCommand.ExecuteScalar();

            //Add totals to webpage
            double vat = subTotal * 0.01;
            double totalAmount = subTotal + vat;

            litTotal.Text = subTotal + " ₫";
            litVat.Text = vat + " ₫";
            litTotalAmount.Text = totalAmount + " ₫";
            sqlCon.Close();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.Parameters["@username"].Value = DataContainer.userPhoneNum;
        }

        private void CreateShopTable(out double subTotal)
        {
            subTotal = new double();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connString);
            sqlCon.Open();

            DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            if (dv != null)
            {
                foreach (DataRow product in dv.Table.Rows)
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SANPHAM WHERE MA_SP='" + product[1].ToString() + "'", sqlCon);
                    sqlCommand.ExecuteNonQuery();

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


                    ImageButton btnImage = new ImageButton
                    {
                        ImageUrl = string.Format("~/Image/Products/{0}", image),
                        PostBackUrl = string.Format("~/Pages/Product.aspx?id={0}", product[1].ToString())
                };

                    LinkButton lnkDelete = new LinkButton
                    {
                        PostBackUrl = string.Format("~/Pages/ShoppingCart.aspx?productId={0}", product[1].ToString()),
                        Text = "Bỏ sản phẩm",
                        ID = "del" + product[1].ToString(),
                    };

                    lnkDelete.Click += Delete_Item;

                    // Fill amount list with numbers 1-20
                    int[] amount = Enumerable.Range(1, 20).ToArray();
                    DropDownList ddlAmount = new DropDownList
                    {
                        DataSource = amount,
                        AppendDataBoundItems = true,
                        AutoPostBack = true,
                        ID = product[1].ToString()
                    };
                    sqlCommand = new SqlCommand("SELECT SOLUONG FROM GIOHANG WHERE SDT='" + DataContainer.userPhoneNum + "' AND MA_SP='" + product[1].ToString() + "'", sqlCon);
                    int number = (int)sqlCommand.ExecuteScalar();
                    ddlAmount.DataBind();
                    ddlAmount.SelectedValue = number.ToString();
                    ddlAmount.SelectedIndexChanged += ddlAmount_SelectedIndexChanged;

                    // Create table to hold shopping cart details
                    Table table = new Table { CssClass = "CartTable" };
                    TableRow row1 = new TableRow();
                    TableRow row2 = new TableRow();

                    TableCell cell1_1 = new TableCell { RowSpan = 2, Width = 50 };
                    TableCell cell1_2 = new TableCell
                    {
                        Text = string.Format("<h4>{0}</h4><br />{1}<br/>In Stock",
                        productName, "Item No:" + product[1].ToString()),
                        HorizontalAlign = HorizontalAlign.Left,
                        Width = 350,
                    };
                    TableCell cell1_3 = new TableCell { Text = "Giá<hr/>" };
                    TableCell cell1_4 = new TableCell { Text = "Số lượng<hr/>" };
                    TableCell cell1_5 = new TableCell { Text = "Thành tiền<hr/>" };
                    TableCell cell1_6 = new TableCell();

                    TableCell cell2_1 = new TableCell();
                    TableCell cell2_2 = new TableCell { Text = productPrice + " ₫" };
                    TableCell cell2_3 = new TableCell();
                    TableCell cell2_4 = new TableCell { Text = product[3].ToString() + " ₫" };
                    TableCell cell2_5 = new TableCell();

                    // Set custom controls
                    cell1_1.Controls.Add(btnImage);
                    cell1_6.Controls.Add(lnkDelete);
                    cell2_3.Controls.Add(ddlAmount);

                    // Add rows & cells to table
                    row1.Cells.Add(cell1_1);
                    row1.Cells.Add(cell1_2);
                    row1.Cells.Add(cell1_3);
                    row1.Cells.Add(cell1_4);
                    row1.Cells.Add(cell1_5);
                    row1.Cells.Add(cell1_6);

                    row2.Cells.Add(cell2_1);
                    row2.Cells.Add(cell2_2);
                    row2.Cells.Add(cell2_3);
                    row2.Cells.Add(cell2_4);
                    row2.Cells.Add(cell2_5);
                    table.Rows.Add(row1);
                    table.Rows.Add(row2);
                    pnlShoppingCart.Controls.Add(table);

                    // Add total of current purchased item to subtotal
                    subTotal += Convert.ToDouble(product[3]); 
                }
            }
            sqlCon.Close();
            //Session[DataContainer.userPhoneNum] = carts;
            
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connString);
            sqlCon.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM GIOHANG WHERE SDT='" + DataContainer.userPhoneNum + "'", sqlCon);
            int number = (int)sqlCommand.ExecuteScalar();
            if (number > 0)
            {
                String AmountQuery = "SELECT COUNT(*) FROM DONHANG";
                sqlCommand = new SqlCommand(AmountQuery, sqlCon);
                Int32 count = (Int32)sqlCommand.ExecuteScalar();

                string ProductID = "";
                if (count >= 0 && count <= 9)
                {
                    count++;
                    ProductID = "DH0000000" + count.ToString();
                }
                else if (count >= 10 && count <= 99)
                {
                    count++;
                    ProductID = "DH000000" + count.ToString();
                }
                else if (count >= 100 && count <= 999)
                {
                    count++;
                    ProductID = "DH00000" + count.ToString();
                }
                else if (count >= 1000 && count <= 9999)
                {
                    count++;
                    ProductID = "DH0000" + count.ToString();
                }
                else if (count >= 10000 && count <= 99999)
                {
                    count++;
                    ProductID = "DH000" + count.ToString();
                }
                else if (count >= 100000 && count <= 999999)
                {
                    count++;
                    ProductID = "DH00" + count.ToString();
                }
                else if (count >= 1000000 && count <= 9999999)
                {
                    count++;
                    ProductID = "DH0" + count.ToString();
                }
                else
                {
                    count++;
                    ProductID = "DH" + count.ToString();
                }

                sqlCommand = new SqlCommand("THANHTOAN", sqlCon);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@MADH", SqlDbType.Char).Value = ProductID;
                sqlCommand.Parameters.Add("@SDT", SqlDbType.Char).Value = DataContainer.userPhoneNum;
                sqlCommand.ExecuteNonQuery();

                Response.Redirect("~/Pages/Success.aspx");
            }
            else
            {
                ltrStatusCheckout.Text = "Bạn không thể thanh toán khi chưa đặt món hàng nào :<";
            }
            sqlCon.Close();
        }
    }
}