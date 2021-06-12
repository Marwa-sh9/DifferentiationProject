using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Differentiation.DAL;

namespace Differentiation
{
    public partial class LogInAdmin : System.Web.UI.Page
    {

        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void Login_click(object sender, EventArgs e)
        {
            //int adId = Convert.ToInt32(Application["adm"]);
            //string Id_Number = ID_Number11.Text;
            string email = email1.Text;
            string password = pass.Text;
            //var user = DataAccessLayer.SelectData
            //    ($"select * from Users where UserEmail = '{email}' and UserPassword = '{password}'");

            var user = dal.SelectData2
                ($"select Id_Number, IsAdmin from Student_Imported_Data where  Email = @email and PassWord = @password",
                new SqlParameter[]
                {
                   // new SqlParameter("Id_Number",Id_Number),
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
            //var rowadm = user.Rows[0][0];
            //Int64 userAdmin = Convert.ToInt64(rowadm);
            if (isAdmin)
            {
               // Response.Write("Admiiiin");
                 Response.Redirect("~/AddStudentData.aspx");
                return;
            }
            // Response.Write("Studeeent");
            Response.Redirect("~/FactulyAdd.aspx");
        }
    }
}