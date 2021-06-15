using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Differentiation.DAL;

namespace Differentiation
{
    public class Global : System.Web.HttpApplication
    {
        DataAccessLayer dal = new DataAccessLayer();

        protected void Application_Start(object sender, EventArgs e)
        {

            dal.Open();
            //ادخال المحافظات/الجامعات
            var Governoratee = dal.SelectData("SELECT * FROM University");
            if (Governoratee.Rows.Count == 0)
            {
                dal.ExecuteCommand("INSERT INTO University VALUES('دمشق')");
                dal.ExecuteCommand("INSERT INTO University Values('ريف دمشق')");
                dal.ExecuteCommand("INSERT INTO University VALUES('القنيطرة')");
                dal.ExecuteCommand("INSERT INTO University VALUES('درعا')");
                dal.ExecuteCommand("INSERT INTO University VALUES('السويداء')");
                dal.ExecuteCommand("INSERT INTO University VALUES('حلب')");
                dal.ExecuteCommand("INSERT INTO University VALUES('إدلب')");
                dal.ExecuteCommand("INSERT INTO University VALUES('اللاذقية')");
                dal.ExecuteCommand("INSERT INTO University VALUES('حمص')");
                dal.ExecuteCommand("INSERT INTO University VALUES('حماه')");
                dal.ExecuteCommand("INSERT INTO University VALUES('طرطوس')");
                dal.ExecuteCommand("INSERT INTO University VALUES('دير الزور')");
                dal.ExecuteCommand("INSERT INTO University VALUES('الحسكة')");
                dal.ExecuteCommand("INSERT INTO University VALUES('الرقة')");
            }
            ////var gov = dal.SelectData("select University_ID from University where University_Name='دمشق'");
            ////var rowgov = gov.Rows[0][0];
            ////Application["gov"] = rowgov;
            //ادخال حساب للادمن
            var Admin1 = dal.SelectData("SELECT * FROM Student_Imported_Data");
            if (Admin1.Rows.Count == 0)
            {
                dal.ExecuteCommand("Insert Into Student_Imported_Data Values(11234567,1555,'Admin','Adm','Female','11/08/1999','syr',2021,'syr','syr','09622','Admin123@def.un','Admin123', 1)");
            }

            //حفظ جلسة الادمن
            //var adm = dal.SelectData("select Id_Number from Student_Imported_Data where Id_Number=11234567");
            //var rowadm = adm.Rows[0][0];
            //Application["adm"] = rowadm;
            
            ////
            //var Std = dal.SelectData("select Id_Number from Student_Imported_Data where Id_Number <> 11234567 ");
            //if (Std.Rows.Count > 0)
            //{
            //    var RowStd = Std.Rows[0][0];
            //    Application["IdStd"] = RowStd;
            //}
            //else
            //{
            //}


            dal.Close();
        }
    }
}