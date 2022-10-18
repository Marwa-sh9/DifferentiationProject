using System;
using System.Data.SqlClient;
using Differentiation.DAL;

namespace Differentiation
{
    public partial class LogInAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (ECUD.Time() == false)
                //{
                //    Response.Redirect("~/default.aspx");
                //}
            }
        }

        DataAccessLayer dal = new DataAccessLayer();
        protected void Login_click(object sender, EventArgs e)
        {
            string email = email1.Text;
            string password = pass.Text;
            var user = dal.SelectData2
                ($"select Id_Number, IsAdmin from Student_Imported_Data where" +
                $"  Email = @email and PassWord = @password",
                new SqlParameter[]
                {
                    new SqlParameter("email", email),
                    new SqlParameter("password", password),
                });
            // asd' or 1 = 1 or '' = '
            if (user.Rows.Count == 0)
            {
                Response.Write("<script>alert('Information Error')</script>");
                return;
            }

            Session["id"] = user.Rows[0]["Id_Number"];
            var isAdmin = user.Rows[0]["IsAdmin"] != DBNull.Value && (bool?)user.Rows[0]["IsAdmin"] == true;
            Session["isAdmin"] = isAdmin;
            if (isAdmin)
            {
                Response.Redirect("~/AddStudentData.aspx");
                return;
            }
            Response.Redirect("~/FactulyAdd.aspx");
        }
    }
}