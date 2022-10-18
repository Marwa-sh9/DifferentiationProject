using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Differentiation.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Differentiation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null && Session["id"] == Session["isAdmin"])
            {
                Response.Redirect("~/LogIn.aspx");
            }
            Def_Language();

        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["University1"].ConnectionString);
        protected void Def_Language()
        {
            con.Open();
            var lan = dal.SelectData(
                " select M.mark_Id, M.English,M.French," +
                " ds.Id_Number," +
                " F.Factuly_Id" +
                " from Mark M ,Student_Imported_Data ds,Factuly F" +
                " where M.mark_Id=F.Factuly_Id" +
                " and ds.Id_Number=('" + Session["id"].ToString() + "') " +
                " and M.Id_Number= ('" + Session["id"] + "')");

            //DropDownList1.DataSource = lan;
            //DropDownList1.DataTextField = "English";
            //DropDownList1.DataTextField = "French";

            DropDownList1.Items.Add(lan.Rows[0]["English"].ToString());
            DropDownList1.Items.Add(lan.Rows[0]["French"].ToString());

            DropDownList1.DataBind();

            //SqlDataAdapter ds = new SqlDataAdapter(
            //    " select M.mark_Id, M.English,M.French," +
            //    " ds.Id_Number," +
            //    " F.Factuly_Id" +
            //    " from Mark M ,Student_Imported_Data ds,Factuly F" +
            //    " where M.mark_Id=F.Factuly_Id" +
            //    " and ds.Id_Number=('" + Session["id"].ToString() + "') " +
            //    "and M.Id_Number=('" + Session["id"].ToString() + "')", con);
            //DataTable ds1 = new DataTable();
            //ds.Fill(ds1);
            //RadioButtonList1.Items.Clear();
            //RadioButtonList1.Items.Add(ds1.Rows[0]["English"].ToString());
            //RadioButtonList1.Items.Add(ds1.Rows[0]["French"].ToString());
            //RadioButtonList1.DataBind();
            con.Close();


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            var l = dal.SelectData
                ($"select mark_Id from Mark " +
                $"where Mark.Id_Number=('" + Session["id"].ToString() + "')");
            Session["Lan"] = l.Rows[0]["mark_Id"];
            SqlConnection con = null;
            SqlCommand cmd = null;
            string conStr;
            string Language = this.DropDownList1.SelectedValue;
            //conStr = ConfigurationManager.ConnectionStrings["University1"].ConnectionString;
            //con = new SqlConnection(conStr);
            //string query = "insert into Factuly_mark (mark_Id,Def_Language)values(@mark_Id,@Def_Language) ";
            //cmd = new SqlCommand(query, con);
            //con.Open();
            //cmd.Parameters.Clear();
            //cmd.Parameters.AddWithValue("@mark_Id", Session["Lan"]);
            //cmd.Parameters.AddWithValue("@Def_Language", Language);
            //cmd.ExecuteNonQuery();
            //con.Close();
            Label1.Text = "Add +'" + Language + "'";
        }
        
    }
}