using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALTerms
    {
        public DataTable Select(BOLTerms obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPTerms";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByID(BOLTerms obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPTerms";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID",obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

    }
}
