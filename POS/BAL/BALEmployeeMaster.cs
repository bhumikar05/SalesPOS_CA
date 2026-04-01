using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALEmployeeMaster
    {
        public DataTable SelectByName(BOLEmployeeMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPEmployeeMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByName");
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByUpdateName(BOLEmployeeMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPEmployeeMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByUpdateName");
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
