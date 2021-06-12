using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Differentiation.DAL;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Differentiation
{
    public partial class ShowDesired : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViewData();
                StdData();
            }
        }
        protected void StdData()
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/login.aspx");
            }

            long stdId = long.Parse(Session["id"].ToString());
            GridView2.DataSource = ECUD.GetAllStdData(stdId);
            GridView2.DataBind();
        }
        public void BindGridViewData()
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            long stdId = long.Parse(Session["id"].ToString());
            GridView1.DataSource = ECUD.GetAllDesires(stdId);
            GridView1.DataBind();
        }
        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int rowIndex = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;
                GridView1.EditIndex = rowIndex;
                BindGridViewData();
            }
            else if (e.CommandName == "DeleteRow")
            {
                ECUD.Delete(Convert.ToInt32(e.CommandArgument));
                BindGridViewData();

            }
            else if (e.CommandName == "CancelRow")
            {
                GridView1.EditIndex = -1;

                BindGridViewData();

            }
            else if (e.CommandName == "UpdateRow")
            {
                int rowIndex = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;
                int Factuly_Id = Convert.ToInt32(e.CommandArgument);
                string Desired_Idd = ((DropDownList)GridView1.Rows[rowIndex].FindControl("drp1")).SelectedValue;

                ECUD.Update(Factuly_Id, Desired_Idd);

                GridView1.EditIndex = -1;
                BindGridViewData();

            }
        }
        protected void ShowFactuly_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/FactulyAdd.aspx");

        }
        protected void repeater()
        {

            //foreach (GridViewRow gr in GridView1.Rows)
            //{

            //}
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

        protected void logout_Click1(object sender, EventArgs e)
        {
            Int64? sessionId = Convert.ToInt64(Session["id"]);
            sessionId = null;
            Response.Redirect("~/LogIn.aspx");
        }
    }
}