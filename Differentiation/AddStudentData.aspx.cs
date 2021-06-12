using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Microsoft.VisualBasic.FileIO;
//using System.Data.OleDb;
//using System.Data.Common;


namespace Differentiation
{
    public partial class AddStudentData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        //    //long stdId = long.Parse(Session["id"].ToString());
        //    var isAdmin = bool.Parse(Session["isAdmin"].ToString());
        //    if (!isAdmin || Session["id"] == null)
        //        Response.Redirect("~/LogIn.aspx");

        }

        //public static string pathM = @"C:\Users\Marwa\Desktop\Mark.xlsx";
        //public static string connstrM = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathM + ";Extended Properties=Excel 12.0");
        //DataSet dsM;
        protected void Mark_Click(object sender, EventArgs e)
        {

            //DataSet ds;
            //string PathM = Server.MapPath("~/" + FileUploadMark.FileName.ToString());
            //string connstr1 = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + PathM + ";Extended Properties=Excel 12.0");

            //OleDbConnection oledbcon = new OleDbConnection(connstrM);
            //OleDbCommand cmd = new OleDbCommand("select * from [MarkStd$]", oledbcon);
            //OleDbDataAdapter adapter1 = new OleDbDataAdapter(cmd);
            //dsM = new DataSet();
            //adapter1.Fill(dsM);
            //oledbcon.Open();
            //DbDataReader dr = cmd.ExecuteReader();
            //string constr = "Data Source=DESKTOP-56BJG2B;Initial Catalog=Differentiation;Integrated Security=True;";
            //SqlBulkCopy bulkinsert = new SqlBulkCopy(constr);
            //bulkinsert.DestinationTableName = "Mark";
            //bulkinsert.WriteToServer(dr);
            //oledbcon.Close();
            HttpPostedFile postedfile = FileUploadMark.PostedFile;

            string FileName = Path.GetFileName(postedfile.FileName);
            string FileEx = Path.GetExtension(FileName);
            if (FileEx.ToLower() == ".csv")
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[12] {
                new DataColumn("mark_ID", typeof(int)),//0
                new DataColumn("Maths", typeof(int)),//1
                new DataColumn("physics",typeof(int)),//2
                new DataColumn("chemistry",typeof(int)),//3
                new DataColumn("English",typeof(int)),//4
                new DataColumn("French",typeof(int)),//5
                new DataColumn("Arabic",typeof(int)),//6
                new DataColumn("[National]",typeof(int)),//7
                new DataColumn("Religious",typeof(int)),//8
                new DataColumn("Sciences",typeof(int)),//9
                new DataColumn("Mark_Total",typeof(int)),//10
                new DataColumn("ID_Number",typeof(Int64)),//11

                });


                string csvPath = Server.MapPath("~/" + FileUploadMark.FileName.ToString());

                FileUploadMark.SaveAs(csvPath);

                try
                {
                    using (TextFieldParser textFieldParser = new TextFieldParser(csvPath))
                    {
                        textFieldParser.SetDelimiters(new string[] { "," });
                        textFieldParser.HasFieldsEnclosedInQuotes = true;
                        string[] columns = textFieldParser.ReadFields();

                        while (!textFieldParser.EndOfData)
                        {
                            string[] fieldData = textFieldParser.ReadFields();
                            //Making empty value as null
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            dt.Rows.Add(fieldData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                string consString = ConfigurationManager.ConnectionStrings["University1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.Mark";
                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                    }
                }
                Label2.Text = ("Student Mark Added Successfully!");
                //Response.Write("Factulies Added Successfully!");
            }

        }

        //public static string pathF = @"C:\Users\Marwa\Desktop\FactuliesS.xlsx";
        //public static string connstrF = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathM + ";Extended Properties=Excel 12.0");
        //DataSet dsF;
        protected void btnAddFactuly_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedfile = FileUploadFactuly.PostedFile;
            string FileName = Path.GetFileName(postedfile.FileName);
            string FileEx = Path.GetExtension(FileName);
            if (FileEx.ToLower() == ".csv")
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] {
                new DataColumn("Factuly_ID", typeof(int)),//0
                new DataColumn("Factuly_Name", typeof(string)),//1
                new DataColumn("Capacity",typeof(int)),//2
                new DataColumn("Min_Mark_Total",typeof(int)),//3
                new DataColumn("University_ID",typeof(int)),//4
                });


                string csvPath = Server.MapPath("~/" + FileUploadFactuly.FileName.ToString());

                FileUploadFactuly.SaveAs(csvPath);

                try
                {
                    using (TextFieldParser textFieldParser = new TextFieldParser(csvPath))
                    {
                        textFieldParser.SetDelimiters(new string[] { "," });
                        textFieldParser.HasFieldsEnclosedInQuotes = true;
                        string[] columns = textFieldParser.ReadFields();

                        while (!textFieldParser.EndOfData)
                        {
                            string[] fieldData = textFieldParser.ReadFields();
                            //Making empty value as null
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            dt.Rows.Add(fieldData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                string consString = ConfigurationManager.ConnectionStrings["University1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.Factuly";
                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                    }
                }
                Label3.Text = ("Factulies Added Successfully!");
                //Response.Write("Factulies Added Successfully!");
            }


            ////DataSet dsF;
            ////string PathF = Server.MapPath("~/" + FileUploadFactuly.FileName.ToString());
            ////string connstrF = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + PathF + ";Extended Properties=Excel 12.0");
            //OleDbConnection oledbcon = new OleDbConnection(connstrF);
            //OleDbCommand cmd = new OleDbCommand("select * from [Factulies$]", oledbcon);
            //OleDbDataAdapter adapter1 = new OleDbDataAdapter(cmd);
            //dsF = new DataSet();
            //adapter1.Fill(dsF);
            //oledbcon.Open();
            //DbDataReader dr = cmd.ExecuteReader();
            //string constr = "Data Source=DESKTOP-56BJG2B;Initial Catalog=Differentiation;Integrated Security=True;";
            //SqlBulkCopy bulkinsert = new SqlBulkCopy(constr);
            //bulkinsert.DestinationTableName ="Factuly";
            //bulkinsert.WriteToServer(dr);
            //oledbcon.Close();


        }

        //public static string pathS = @"C:\Users\Marwa\Desktop\ImpStdData.xlsx";
        //public static string connstrS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathM + ";Extended Properties=Excel 12.0");
        //DataSet dsS;
        protected void ImpInfoStd_Click1(object sender, EventArgs e)
        {
            HttpPostedFile postedfile = FileUploadStudent.PostedFile;
            string FileName = Path.GetFileName(postedfile.FileName);
            string FileEx = Path.GetExtension(FileName);
            if (FileEx.ToLower() == ".csv")
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[14] {
                    new DataColumn("ID_Number", typeof(long)),//0
                    new DataColumn("IPO_Number", typeof(int)),//1
                    new DataColumn("Student_Full_Name",typeof(string)),//2
                    new DataColumn("Student_Mother_Name",typeof(string)),//3
                    new DataColumn("Gender",typeof(string)),//4
                    new DataColumn("Date_Of_Birth",typeof(string)),//5
                    new DataColumn("Student_Nationality",typeof(string)),//6
                    new DataColumn("year",typeof(int)),//7
                    new DataColumn("Seesion",typeof(int)),//8
                    new DataColumn("Source",typeof(string)),//9
                    new DataColumn("Address",typeof(string)),//10
                    new DataColumn("Phone",typeof(string)),//11
                    new DataColumn("Email",typeof(string)),//12
                    new DataColumn("PassWord",typeof(string)),//13


                    });


                string csvPath = Server.MapPath("~/" + FileUploadStudent.FileName.ToString());

                FileUploadStudent.SaveAs(csvPath);

                try
                {
                    using (TextFieldParser textFieldParser = new TextFieldParser(csvPath))
                    {
                        textFieldParser.SetDelimiters(new string[] { "," });
                        textFieldParser.HasFieldsEnclosedInQuotes = true;
                        string[] columns = textFieldParser.ReadFields();

                        while (!textFieldParser.EndOfData)
                        {
                            string[] fieldData = textFieldParser.ReadFields();
                            //Making empty value as null
                                for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            dt.Rows.Add(fieldData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                string consString = ConfigurationManager.ConnectionStrings["University1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.Student_Imported_Data";
                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                    }
                }
                Label1.Text = ("Students Information Added Successfully!");
                //Response.Write("Students Information Added Successfully!");
            }
            //DataSet dsS;
            //string PathS = Server.MapPath("~/" + FileUploadStudent.FileName.ToString());
            //string connstrS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + PathS + ";Extended Properties=Excel 12.0");

            //OleDbConnection oledbcon = new OleDbConnection(connstrS);
            //OleDbCommand cmd = new OleDbCommand("select * from [Student$]", oledbcon);
            //OleDbDataAdapter adapter1 = new OleDbDataAdapter(cmd);
            //dsS = new DataSet();
            //adapter1.Fill(dsS);
            //oledbcon.Open();
            //DbDataReader dr = cmd.ExecuteReader();
            //string constr = "Data Source=DESKTOP-56BJG2B;Initial Catalog=Differentiation;Integrated Security=True;";
            //SqlBulkCopy bulkinsert = new SqlBulkCopy(constr);
            //bulkinsert.DestinationTableName = "Student_Imported_Data";
            //bulkinsert.WriteToServer(dr);
            //oledbcon.Close();

        }

        protected void Statistics_Click1(object sender, EventArgs e)
        {

        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Int64? sessionId = Convert.ToInt64(Session["id"]);
            sessionId = null;
            Response.Redirect("~/default.aspx.aspx");
        }

        protected void btnMarquee_Click1(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx?News=" + txtMarquee.Text.ToString().Replace("\n", ""));
        }

        protected void open_Click1(object sender, EventArgs e)
        {

        }

        protected void close_Click1(object sender, EventArgs e)
        {

        }
    }
}