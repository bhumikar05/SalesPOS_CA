using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALCreditMemoHistoryMaster
    {
        public DataTable SelectCreditMemoAuditReport(BOLCreditMemoHistoryMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoHistoryMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectAuditReport");
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public int Insert(BOLCreditMemoHistoryMaster obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoHistoryMaster";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@CreditMemoID", obj.CreditMemoID);
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@AccountID", obj.AccountID);
            cmd.Parameters.AddWithValue("@Total", obj.Total);
            cmd.Parameters.AddWithValue("@Time", obj.Time);
            cmd.Parameters.AddWithValue("@Mode", obj.Mode);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            cmd.Parameters.AddWithValue("@ModifiedID", obj.ModifiedID);
            DAL DAL = new DAL();
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }
    }
}
