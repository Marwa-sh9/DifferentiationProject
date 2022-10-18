using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Differentiation.DAL;
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
                if (Session["id"] == null && Session["id"] == Session["isAdmin"])
                {
                    Response.Redirect("~/LogIn.aspx");
                }
                if(NoRepeatedDesires()==true)
                {
                    Label5.Text = "تم اختيار اللغة سابقا ";
                    Langauge1.Enabled = false;
                    DropDownList1.Enabled = false;
                    Label6.Text = " ";
                    grid();
                }
                Disable();
                Def_Language();
                AddToDataBase.Enabled = DesiresCount() < 5;
            }
        }
        protected void Def_Language()
        {
            DataAccessLayer dal = new DataAccessLayer();
            dal.Open();
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
            dal.Close();
            Enable();
        }
        public bool NoRepeatedDesires()
        {
            DataTable dt = new DataTable();
            con.Open();
           SqlCommand cmd = new SqlCommand("Select Choosing_Lang FROM Mark " +
               "where Choosing_Lang is not null " +
               "and Id_Number='"+Session["id"].ToString()+"'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            int count = dt.Rows.Count;
            con.Close();
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void Language_Click1(object sender, EventArgs e)
        {
            DataAccessLayer dal = new DataAccessLayer();
            string Language = this.DropDownList1.SelectedValue;
            dal.Open();
            dal.ExecuteCommand($"UPDATE Mark SET Choosing_Lang = '{Language}'" +
                $"  WHERE Id_Number = {Session["id"].ToString()} ");
            dal.Close();
            Label5.Text = "تم ازالة اللغة المحددة من المجموع +'" + Language + "'";
            Enable();
            Langauge1.Enabled = false;
            DropDownList1.Enabled = false;
            grid();
        }
        void Disable()
        {
            GridView1.Enabled = false;
            AddToDataBase.Enabled = false;
        }
        void Enable()
        {
            GridView1.Enabled = true;
            AddToDataBase.Enabled = true;
        }
        public int DesiresCount()
        {
            int count = 1;
            long stdId = long.Parse(Session["id"].ToString());
            string conString = ConfigurationManager.ConnectionStrings["University1"].ConnectionString;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Desires" +
                " Where Id_Number =@id");
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
            //string Language = RadioButtonList1.DataTextField;
            //+('" + Language + "')
            SqlDataAdapter ds = new SqlDataAdapter(
                "select Factuly.Factuly_Id, Factuly.Factuly_Name, " +
                "Factuly.Min_Mark_Total, University.[University_Name]" +
                " from Factuly , University" +
                " where University.University_Id=Factuly.University_Id " +
                " and Factuly.Factuly_Id not in (select Factuly_Id from Desires where Id_Number = '" + Session["id"].ToString() + "')" +
                " and Factuly.Min_Mark_Total<=(select Mark_Total-(Religious+Choosing_Lang)from Mark" +
                " where Id_Number = ('" + Session["id"].ToString() + "'))" +
                " order by Factuly.Min_Mark_Total desc", con);
            
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
                    Label4.Text = " ";
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
            if (ECUD.Time() == false)
            {
                Response.Redirect("~/default.aspx");
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
                command.ExecuteNonQuery();
                Label1.Text = "تم الحفظ";
                con.Close();
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