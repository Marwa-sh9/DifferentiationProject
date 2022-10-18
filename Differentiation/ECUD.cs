using System;
using System.Collections.Generic;
using Differentiation.DAL;
using System.Data.SqlClient;
using System.Configuration;

namespace Differentiation
{
    public class Desired
    {
        public int Factuly_Id { get; set; }
        public int Desire_Id { get; set; }
        public string Factuly_Name { get; set; }
        public string Accepted { get; set; }

    }
    public class DataStudent
    {
        public Int64 Id_Number { get; set; }
        public int IPO_Number { get; set; }
        public string Student_Full_Name { get; set; }
        public string Student_Mother_Name { get; set; }
        public string Gender { get; set; }
        public string Date_Of_Birth { get; set; }
        public string Student_Nationality { get; set; }
        public int year { get; set; }
        public string Source { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Maths { get; set; }
        public int physics { get; set; }
        public int chemistry { get; set; }
        public int English { get; set; }
        public int French { get; set; }
        public int Arabic { get; set; }
        public int National { get; set; }
        public int Religious { get; set; }
        public int Science { get; set; }
        public int Mark_Total { get; set; }



    }
    public class ECUD
    {
       // لجلب جميع الرغبات المخزنة في الداتا وتبعئتها في حقول الجدول
        public static List<Desired> GetAllDesires(long stdId)
        {
            List<Desired> listDes = new List<Desired>();
            string cs = ConfigurationManager.ConnectionStrings["University1"].ToString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "select d.Factuly_Id,d.Desire_Sequence,a.Factuly_Name" +
                    " from Desires d,Factuly a" +
                    " where d.Factuly_Id=a.Factuly_Id and Id_Number=@id" +
                    " order by d.Desire_Sequence;", con);
                cmd.Parameters.Add(new SqlParameter("id", stdId));
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Desired desired = new Desired();
                    desired.Factuly_Id = Convert.ToInt32(rd["Factuly_Id"]);
                    desired.Desire_Id = Convert.ToInt32(rd["Desire_Sequence"]);
                    desired.Factuly_Name = Convert.ToString(rd["Factuly_Name"]);
                   // desired.Accepted = Convert.ToString(rd["Accepted"]);
                    listDes.Add(desired);

                }
            }
            return listDes;
        }
        //جلب جميع معلومات الطالب المراد عرضها في الجدول
        public static List<DataStudent> GetAllStdData(long stdId)
        {
            List<DataStudent> listDatastd = new List<DataStudent>();
            string cs = ConfigurationManager.ConnectionStrings["University1"].ToString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "select ds.Id_Number,ds.IPO_Number,ds.Student_Full_Name" +
                    ",ds.Student_Mother_Name,ds.Gender,ds.Date_Of_Birth" +
                    ",ds.Student_Nationality,ds.year,ds.Source,ds.Address,ds.Phone" +
                    ",M.Maths,M.physics,M.chemistry,M.English,M.French,M.Arabic,M.[National]" +
                    ",M.Religious,M.Science,M.Mark_Total " +
                    " from Student_Imported_Data ds , Mark M" +
                    " where ds.Id_Number = M.Id_Number and ds.Id_Number=@id ;", con);
                cmd.Parameters.Add(new SqlParameter("id", stdId));
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DataStudent dataStudent = new DataStudent();
                    dataStudent.Id_Number = Convert.ToInt64(rd["Id_Number"]);
                    dataStudent.IPO_Number = Convert.ToInt32(rd["IPO_Number"]);
                    dataStudent.Student_Full_Name = Convert.ToString(rd["Student_Full_Name"]);
                    dataStudent.Student_Mother_Name = Convert.ToString(rd["Student_Mother_Name"]);
                    dataStudent.Gender = Convert.ToString(rd["Gender"]);
                    dataStudent.Date_Of_Birth = Convert.ToString(rd["Date_Of_Birth"]);
                    dataStudent.Student_Nationality = Convert.ToString(rd["Student_Nationality"]);
                    dataStudent.year = Convert.ToInt32(rd["year"]);
                    dataStudent.Source = Convert.ToString(rd["Source"]);
                    dataStudent.Address = Convert.ToString(rd["Address"]);
                    dataStudent.Phone = Convert.ToString(rd["Phone"]);
                    dataStudent.Maths = Convert.ToInt32(rd["Maths"]);
                    dataStudent.physics = Convert.ToInt32(rd["physics"]);
                    dataStudent.chemistry = Convert.ToInt32(rd["chemistry"]);
                    dataStudent.English = Convert.ToInt32(rd["English"]);
                    dataStudent.French = Convert.ToInt32(rd["French"]);
                    dataStudent.Arabic = Convert.ToInt32(rd["Arabic"]);
                    dataStudent.National = Convert.ToInt32(rd["National"]);
                    dataStudent.Religious = Convert.ToInt32(rd["Religious"]);
                    dataStudent.Science = Convert.ToInt32(rd["Science"]);
                    dataStudent.Mark_Total = Convert.ToInt32(rd["Mark_Total"]);
                    listDatastd.Add(dataStudent);
                }
            }
            return listDatastd;
        }
        //ميثود لحذف الرغبة المراد حذفها من جدول الرغبات
        public static void Delete(int Factuly_Id)
        {
            string cs = ConfigurationManager.ConnectionStrings["University1"].ToString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("delete from Desires where Factuly_Id=@Factuly_Id", con);
                SqlParameter param = new SqlParameter("@Factuly_Id", Factuly_Id);
                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        //تعديل ترتيب الرغبة الموحودة في الجدول
        public static int Update(int Factuly_Id ,string Desire_Id)
        {
            string cs = ConfigurationManager.ConnectionStrings["University1"].ToString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string UpdateUser = "Update Desires Set Desire_Sequence=@Desire_Id" +
                    " Where Factuly_Id=@Factuly_Id ";
                SqlCommand cmd = new SqlCommand(UpdateUser, con);
                SqlParameter sqlparam = new SqlParameter("@Factuly_Id", Factuly_Id);
                cmd.Parameters.Add(sqlparam);
                SqlParameter DesID = new SqlParameter("@Desire_Id", Desire_Id);
                cmd.Parameters.Add(DesID);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        //لبداية فتح الصفحات و تسكريها
        public static bool Time()
        {
            DateTime NowDate = DateTime.Now;
            DateTime StartDate = DateTime.Parse("06/13/2022");
            DateTime EndDate = DateTime.Parse("10/01/2025");
            if (NowDate.Date >= StartDate.Date && NowDate.Date <= EndDate.Date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}