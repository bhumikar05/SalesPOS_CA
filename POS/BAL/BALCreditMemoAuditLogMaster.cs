using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.BOL;
using POS.HelperClass;


namespace POS.BAL
{
    class BALCreditMemoAuditLogMaster
    {
        public int Insert(BOLCreditMemoAuditLogMaster obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoAuditLogMaster";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@Datetime", obj.Datetime);
            cmd.Parameters.AddWithValue("@CreditMemoID", obj.CreditMemoID);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            DAL DAL = new DAL();
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }
    }
}

