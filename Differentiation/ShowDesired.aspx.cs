using System;
using System.Web.UI.WebControls;
using Differentiation.DAL;

namespace Differentiation
{
    public partial class ShowDesired : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //اذا كانت الجلسة فارغة
                if (Session["id"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                BindGridGetAllDesires();
                StdData();
            }
        }
        //استدعاء ميثود جلب بيانات الطالب المراد عرضه من الصف
        protected void StdData()
        {
            long stdId = long.Parse(Session["id"].ToString());
            GridView2.DataSource = ECUD.GetAllStdData(stdId);
            GridView2.DataBind();
        }
        //استدعاء جميع الرغبات المححفوظة
        public void BindGridGetAllDesires()
        {
            long stdId = long.Parse(Session["id"].ToString());
            GridView1.DataSource = ECUD.GetAllDesires(stdId);
            GridView1.DataBind();
        }
        //حدث في الكريد فيو عند التغيير للتعديل والحذف والحفظ والغاء الحفظ
        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int rowIndex = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;
                GridView1.EditIndex = rowIndex;
                BindGridGetAllDesires();
            }
            else if (e.CommandName == "DeleteRow")
            {
                ECUD.Delete(Convert.ToInt32(e.CommandArgument));
                BindGridGetAllDesires();
            }
            else if (e.CommandName == "CancelRow")
            {
                GridView1.EditIndex = -1;
                BindGridGetAllDesires();

            }
            else if (e.CommandName == "UpdateRow")
            {
                int rowIndex = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;
                int Factuly_Id = Convert.ToInt32(e.CommandArgument);
                string Desired_Idd = ((DropDownList)GridView1.Rows[rowIndex].FindControl("drp1")).SelectedValue;
                ECUD.Update(Factuly_Id, Desired_Idd);
                GridView1.EditIndex = -1;
                BindGridGetAllDesires();

            }
        }
        protected void ShowFactuly_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/FactulyAdd.aspx");

        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Int64? sessionId = Convert.ToInt64(Session["id"]);
            sessionId = null;
            Response.Redirect("~/default.aspx");
        
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

    }
}