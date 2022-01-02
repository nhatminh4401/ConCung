using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConCung.Pages.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connString);
            sqlCon.Open();
            string phoneNum = _txtPhoneNum.Text.Trim();
            string pass = _txtPass.Text.Trim();
            string rePass = _txtRePass.Text.Trim();

            if (pass == rePass)
            {

                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM QUANLY WHERE SDT='" + phoneNum + "'", sqlCon);
                int check = (int) sqlCommand.ExecuteScalar();
                if (check == 0)
                {
                    string query = "INSERT INTO QUANLY (SDT, MATKHAU) VALUES('" + phoneNum + "', '" + pass + "')";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    sqlCommand.ExecuteNonQuery();
                    _litStatusMessage.Text = "Đã đăng ký thành công";
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    _litStatusMessage.Text = "Số điện thoại đã tồn tại";
                }
                
            }
            else
            {
                _litStatusMessage.Text = "Mật khẩu nhập lại không khớp!";
            }

            sqlCon.Close();

        }
    }
}