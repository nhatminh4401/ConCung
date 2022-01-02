using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace ConCung
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        private void FillPage()
        {
            DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            if (dv != null)
            {
                foreach (DataRow product in dv.Table.Rows)
                {
                    Panel productPanel = new Panel();
                    ImageButton imageButton = new ImageButton();
                    Label lblName = new Label();
                    Label lblPrice = new Label();

                    imageButton.ImageUrl = "~/Image/Products/" + product[9].ToString();
                    imageButton.CssClass = "productImage";
                    imageButton.PostBackUrl = "~/Pages/Product.aspx?id=" + product[0].ToString();

                    lblName.Text = product[1].ToString();
                    lblName.CssClass = "productName";

                    lblPrice.Text = product[7].ToString() + " ₫";
                    lblPrice.CssClass = "productPrice";

                    productPanel.Controls.Add(imageButton);
                    productPanel.Controls.Add(new Literal { Text = "<br />" });
                    productPanel.Controls.Add(lblName);
                    productPanel.Controls.Add(new Literal { Text = "<br />" });
                    productPanel.Controls.Add(lblPrice);

                    pnlProducts.Controls.Add(productPanel);
                }
            }
            else
            {
                pnlProducts.Controls.Add(new Literal { Text = "Không tìm thấy sản phẩm!" });
            }

        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            string type = DataContainer.productType;
            if (type != "All")
            {
                e.Command.Parameters["@productType"].Value = type;
            }

        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList selectedList = (DropDownList)sender;
            DataContainer.productType = selectedList.SelectedValue.ToString();
            string type = DataContainer.productType;
            //MessageBox.Show(type);
            if (type == "All")
            {
                pnlProducts.Controls.Clear();
                FillPage();
            }
            else
            {
                pnlProducts.Controls.Clear();
                DataView dv = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
                if (dv != null)
                {
                    foreach (DataRow product in dv.Table.Rows)
                    {
                        Panel productPanel = new Panel();
                        ImageButton imageButton = new ImageButton();
                        Label lblName = new Label();
                        Label lblPrice = new Label();

                        imageButton.ImageUrl = "~/Image/Products/" + product[9].ToString();
                        imageButton.CssClass = "productImage";
                        imageButton.PostBackUrl = "~/Pages/Product.aspx?id=" + product[0].ToString();

                        lblName.Text = product[1].ToString();
                        lblName.CssClass = "productName";

                        lblPrice.Text = product[7].ToString() + " ₫";
                        lblPrice.CssClass = "productPrice";

                        productPanel.Controls.Add(imageButton);
                        productPanel.Controls.Add(new Literal { Text = "<br />" });
                        productPanel.Controls.Add(lblName);
                        productPanel.Controls.Add(new Literal { Text = "<br />" });
                        productPanel.Controls.Add(lblPrice);

                        pnlProducts.Controls.Add(productPanel);
                    }

                }
                else
                {
                    pnlProducts.Controls.Add(new Literal { Text = "Không tìm thấy sản phẩm!" });
                }
            }
        }
    }
}