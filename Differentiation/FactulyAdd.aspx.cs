using System;
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
            if (!IsPostBack)
            {
                if (ECUD.Time() == false)
                {
                    Response.Redirect("~/default.aspx");
                }
                if (Session["id"]==null && Session["id"] == Session["isAdmin"])
                {
                    Response.Redirect("~/LogIn.aspx");
                }
                AddToDataBase.Enabled = DesiresCount() < 5;
                grid();
            }           
        }
        public bool NoRepeatedDesires()
        {
            SqlCommand cmd;
            cmd = new SqlCommand("Select COUNT(Factuly_Id) FROM Desires group by Factuly_Id " +
                "having Count(Factuly_Id)>1 ", con);
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public int DesiresCount()
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
            return count;
        }
        protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
        {
            selectrow();
            bindgrid();
        }
        protected void grid()
        {
            con.Open();
            SqlDataAdapter ds = new SqlDataAdapter(
                "select Factuly.Factuly_Id, Factuly.Factuly_Name, " +
                "Factuly.Min_Mark_Total, University.[University_Name]" +
                " from Factuly , University" +
                " where University.University_Id=Factuly.University_Id " +
                "and Factuly.Min_Mark_Total<=(select Mark_Total from Mark" +
                " where Id_Number = ('" + Session["id"].ToString() + "'))", con);
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
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("ChkSelect");
                if (chk.Checked )
                {
                    dt = AddRow(GridView1.Rows[i], dt);
                }
                else
                {
                    dt = remove(GridView1.Rows[i], dt);
                    AddToDataBase.Enabled = true;
                    Label3.Text = " ";

                }
            }
            var count = dt.Rows.Count + DesiresCount();
            if (count >= 6)
            {
                AddToDataBase.Enabled = false;
                Label3.Text = "لقد أدخلت الحد الاعلى من الرغبات";
            }
            ViewState["GetRecords"] = dt;                        
        }
        protected void AddToDataBase_Click1(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            long stdId = long.Parse(Session["id"].ToString());
            int i = DesiresCount() + 1;

            foreach (GridViewRow gr in GridView2.Rows)
            {
                
                    string sqlquery = "insert into Desires values " +
                        "(@Factuly_Id,@Id_Number,@Desire_Sequence,@Accepted)";
                    SqlCommand command = new SqlCommand(sqlquery, con);
                    command.Parameters.AddWithValue("@Factuly_Id", gr.Cells[0].Text);
                    command.Parameters.AddWithValue("@Id_Number", stdId);
                    command.Parameters.AddWithValue("@Desire_Sequence", i++);
                    command.Parameters.AddWithValue("@Accepted", 0);
                    con.Open();
                if (NoRepeatedDesires() == false)
                {
                    if (ECUD.Time() == false)
                    {
                        Response.Redirect("~/default.aspx");
                        command.ExecuteNonQuery();
                        Label1.Text = "تم الحفظ";
                        con.Close();
                    }                    
                }
                else
                {
                    Label2.Text = "هناك كلية مكررة راجع ذلك";
                }
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
        protected void Logout_Click(object sender, EventArgs e)
        {
            Int64? sessionId = Convert.ToInt64(Session["id"]);
            sessionId = null;
            Response.Redirect("~/default.aspx");
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}