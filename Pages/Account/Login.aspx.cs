using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConCung.Pages.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Account/Register.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connString);
            sqlCon.Open();
            string phoneNum = txtPhoneNum.Text.Trim();
            string pass = txtPass.Text.Trim();

            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM QUANLY WHERE SDT='" + phoneNum + "' AND MATKHAU='" + pass + "'", sqlCon);
            int check = (int)sqlCommand.ExecuteScalar();

            if (check == 1)
            {
                DataContainer.login = true;
                DataContainer.userPhoneNum = phoneNum;
                DataContainer.userName = phoneNum;
                DataContainer.managerCheck = true;
                Response.Redirect("~/Pages/Management/ManageMenu.aspx");
            }
            else
            {
                sqlCommand = new SqlCommand("SELECT COUNT(*) FROM BOME WHERE SDT='" + phoneNum + "'AND MATKHAU='" + pass + "'", sqlCon);
                check = (int)sqlCommand.ExecuteScalar();

                if (check == 1)
                {
                    DataContainer.login = true;
                    DataContainer.userPhoneNum = phoneNum;
                    sqlCommand = new SqlCommand("SELECT HOTEN_BM FROM BOME WHERE SDT='" + phoneNum + "' AND MATKHAU='" + pass + "'", sqlCon);
                    string name = (string)sqlCommand.ExecuteScalar();
                    DataContainer.userName = name;
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    ltrStatus.Text = "Sai số điện thoại hoặc mật khẩu. Vui lòng nhập lại";
                }
            }
            
        }
    }
}