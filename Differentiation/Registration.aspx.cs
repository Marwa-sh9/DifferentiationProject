using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Differentiation
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ECUD.Time() == false)
                {
                    Response.Redirect("~/default.aspx");
                }
                Disable();
            }

        }
        SqlConnection con = null;
        SqlCommand cmd = null;
        string conStr;
        public bool EmailExist()
        {
            conStr = ConfigurationManager.ConnectionStrings["University1"].ConnectionString;
            SqlDataAdapter sda = null;
            DataTable Dt = new DataTable();
            con = new SqlConnection(conStr);
            cmd = new SqlCommand("Select Email FROM Student_Imported_Data WHERE Email =@txtStuEmail", con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@txtStuEmail", SqlDbType.VarChar).Value = txtStuEmail.Text;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        void Disable()
        {
            txtStuEmail.Enabled = false;
            txtStuPass.Enabled = false;
            txtStuRePass.Enabled = false;
            btnRegister.Enabled = false;
            lblStuValid.Text = null;
        }
        void Enable()
        {
            txtStuEmail.Enabled = true;
            txtStuPass.Enabled = true;
            txtStuRePass.Enabled = true;
            btnRegister.Enabled = true;
        }
        public bool IDNumberValidation()
        {
            conStr = ConfigurationManager.ConnectionStrings["University1"].ConnectionString;
            SqlDataAdapter sda = null;
            DataTable Dt = new DataTable();
            con = new SqlConnection(conStr);
            cmd = new SqlCommand("Select Id_Number FROM Student_Imported_Data WHERE Id_Number =@txtID_Number", con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@txtID_Number", SqlDbType.VarChar).Value = txtID_Number.Text;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IPONumberValidation()
        {
            conStr = ConfigurationManager.ConnectionStrings["University1"].ConnectionString;
            SqlDataAdapter sda = null;
            DataTable Dt = new DataTable();
            con = new SqlConnection(conStr);
            cmd = new SqlCommand("Select IPO_Number FROM Student_Imported_Data WHERE IPO_Number =@txtIPO_Number", con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@txtIPO_Number", SqlDbType.VarChar).Value = txtIPO_Number.Text;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                txtID_Number.Enabled = false;
                txtIPO_Number.Enabled = false;
                btnCheck.Visible = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtStuPass.Text == txtStuRePass.Text)
            {
                if (EmailExist() == false)
                {
                    conStr = ConfigurationManager.ConnectionStrings["University1"].ConnectionString;
                    con = new SqlConnection(conStr);
                    SqlCommand cmd = new SqlCommand("Student_Insert", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Number", txtID_Number.Text);
                    cmd.Parameters.AddWithValue("@Email", txtStuEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtStuPass.Text);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i > 0)
                    {
                        Response.Write("<script> alert('Registered Sucessfully'); </script>");
                        Response.Redirect("~/LogIn.aspx");
                    }
                    else
                    {
                        Response.Write("<script> alert('Retype The Password'); </script>");
                    }
                }
                else
                {
                    Response.Write("<script> alert('Email already exists... Try Again!'); </script>");
                    Enable();
                }
            }
        }
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if (IDNumberValidation() == true && IPONumberValidation() == true)
            {
                lblStuValid.Text = "Welcome Student";
                lblStuValid.ForeColor = System.Drawing.Color.LimeGreen;
                Enable();
            }
            else
            {
                lblStuValid.Text = "Try Again!";
                lblStuValid.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

}