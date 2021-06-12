using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Differentiation
{
    public partial class FactulyAdd : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["University1"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            //    ddlbatch();
            if (!IsPostBack)
            {
                grid();
            }           
        }
        public bool DesiresEmpty()
        {
            int count = 1;
            long stdId = long.Parse(Session["id"].ToString());
            string conString = ConfigurationManager.ConnectionStrings["University1"].ConnectionString;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Desires Where Id_Number =@id");
            cmd.Parameters.Add(new SqlParameter("id", stdId));
            using (SqlConnection con = new SqlConnection(conString))
            {
                cmd.Connection = con;
                con.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            if (count <=5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
        {
            selectrow();
            bindgrid();

        }
        protected void grid()
        {
            //long stdId = long.Parse(Session["id"].ToString());

            con.Open();
            SqlDataAdapter ds = new SqlDataAdapter(
                "select Factuly.Factuly_Id, Factuly.Factuly_Name, " +
                "Factuly.Min_Mark_Total, University.[University_Name]" +
                " from Factuly , University where University.University_Id=Factuly.University_Id", con);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }
        protected void bindgrid()
        {
            DataTable dt = (DataTable)ViewState["GetRecords"];
            GridView2.DataSource = dt;
            GridView2.DataBind();

        }
        private DataTable createtable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Factuly_Id");
            dt.Columns.Add("Factuly_Name");
            dt.Columns.Add("Min_Mark_Total");
            dt.Columns.Add("University_Name");
            dt.AcceptChanges();
            return dt;
        }
        private DataTable AddRow(GridViewRow gvRow, DataTable dt)
        {
            DataRow[] dr = dt.Select("Factuly_Id = '" + gvRow.Cells[1].Text + "'");
            if (dr.Length <= 0)
            {
                dt.Rows.Add();
                int rowscount = dt.Rows.Count - 1;
                dt.Rows[rowscount]["Factuly_Id"] = gvRow.Cells[1].Text;
                dt.Rows[rowscount]["Factuly_Name"] = gvRow.Cells[2].Text;
                dt.Rows[rowscount]["Min_Mark_Total"] = gvRow.Cells[3].Text;
                dt.Rows[rowscount]["University_Name"] = gvRow.Cells[4].Text;
                dt.AcceptChanges();
            }
            return dt;
        }
        private DataTable remove(GridViewRow gvRow, DataTable dt)
        {
            DataRow[] dr = dt.Select("Factuly_Id = '" + gvRow.Cells[1].Text + "'");
            if (dr.Length > 0)
            {
                dt.Rows.Remove(dr[0]);
                dt.AcceptChanges();
            }
            return dt;

        }
        private void selectrow()
        {
             DataTable dt;
                if (ViewState["GetRecords"] != null)

                    dt = (DataTable)ViewState["GetRecords"];
                else
                    dt = createtable();
            //if (dt.Rows.Count == 5)
            //    return;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ChkSelect");
                if (chk.Checked)
                {
                    dt = AddRow(GridView1.Rows[i], dt);
                    //AddToDataBase.Enabled = true;

                }
                else
                {
                    dt = remove(GridView1.Rows[i], dt);
                    AddToDataBase.Enabled = true;
                }
            }

            if (dt.Rows.Count == 5)
                AddToDataBase.Enabled = false;

            ViewState["GetRecords"] = dt;                        


        }
        protected void AddToDataBase_Click1(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            long stdId = long.Parse(Session["id"].ToString());
            int i = 1;

            //foreach
            foreach (GridViewRow gr in GridView2.Rows)
            {

                string sqlquery = "insert into Desires values " +
                    "(@Factuly_Id,@Id_Number,@Desire_Sequence)";
                SqlCommand command = new SqlCommand(sqlquery, con);
                command.Parameters.AddWithValue("@Factuly_Id", gr.Cells[0].Text);
                command.Parameters.AddWithValue("@Id_Number", stdId);
                command.Parameters.AddWithValue("@Desire_Sequence", i++);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                Label1.Text = "تم الحفظ";
            }
                


                
            
        }

        protected void ShowDisers_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/ShowDesired.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            grid();
        }

        //public void ddlbatch()
        //{
        //    conStr = ConfigurationManager.ConnectionStrings["University1"].ConnectionString;
        //    con = new SqlConnection(conStr);

        //    SqlCommand cmd1 = new SqlCommand("Select University_Name from University", con);
        //    cmd1.CommandType = CommandType.Text;
        //    cmd1.Connection = con;
        //    con.Open();

        //    ddlbatchno.DataSource = cmd1.ExecuteReader();
        //    ddlbatchno.DataTextField = "University_Name";
        //    ddlbatchno.DataBind();
        //    con.Close();
        //    ddlbatchno.Items.Insert(0, new ListItem("--Select University_Name no--", "0"));
        //}


    }
}