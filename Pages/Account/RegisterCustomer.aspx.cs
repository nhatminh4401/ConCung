using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConCung.Pages.Account
{
    public partial class RegisterCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CONCUNGConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connString);
            sqlCon.Open();
            string phoneNum = txtPhoneNum.Text.Trim();
            string pass = txtPass.Text.Trim();
            string rePass = txtRePass.Text.Trim();
            string name = txtName.Text.Trim();
            string mail = txtMail.Text.Trim();
            string gender = ddlGender.SelectedValue.ToString();
            string date = txtDate.Text.Trim();
            string addr = txtAddress.Text.Trim();

            if (pass == rePass)
            {

                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM QUANLY WHERE SDT='" + phoneNum + "'", sqlCon);
                int check = (int)sqlCommand.ExecuteScalar();
                if (check == 0)
                {
                    sqlCommand = new SqlCommand("SELECT COUNT(*) FROM BOME WHERE SDT='" + phoneNum + "'", sqlCon);
                    check = (int)sqlCommand.ExecuteScalar();
                    if (check == 0)
                    {
                        string query = "INSERT INTO BOME(SDT, HOTEN_BM, EMAIL, PHAI_BM, NGAYSINH_BM, MATKHAU, DIACHI_BM, TONGTIEN, THANH_TIEN)"
                            + "VALUES('" + phoneNum + "', N'" + name + "', '" + mail + "', N'" + gender + "', '" + date + "', '" + pass + "', N'" + addr + "', 0, 0)";
                        sqlCommand = new SqlCommand(query, sqlCon);
                        sqlCommand.ExecuteNonQuery();
                        litStatusMessage.Text = "Đã đăng ký thành công";
                        Response.Redirect("~/Index.aspx");
                    }
                    
                }
                else
                {
                    litStatusMessage.Text = "Số điện thoại đã tồn tại";
                }

            }
            else
            {
                litStatusMessage.Text = "Mật khẩu nhập lại không khớp!";
            }

            sqlCon.Close();
        }
    }
}