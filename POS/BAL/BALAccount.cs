using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALAccount
    {
        public DataTable SelectIncomeAccount(BOLAccount obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAccount";
            cmd.Parameters.AddWithValue("@Spara", "SelectIncomeAccount");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectExpenseAccount(BOLAccount obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAccount";
            cmd.Parameters.AddWithValue("@Spara", "SelectExpenseAccount");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectCOGSAccount(BOLAccount obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAccount";
            cmd.Parameters.AddWithValue("@Spara", "SelectCOGSAccount");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectAssetAccount(BOLAccount obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAccount";
            cmd.Parameters.AddWithValue("@Spara", "SelectAssetAccount");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectARAccount(BOLAccount obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAccount";
            cmd.Parameters.AddWithValue("@Spara", "SelectARAccount");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectBankAccount()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAccount";
            cmd.Parameters.AddWithValue("@Spara", "SelectBankAccount");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
