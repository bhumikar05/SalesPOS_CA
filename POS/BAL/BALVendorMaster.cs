using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALVendorMaster
    {
        public DataTable Select(BOLVendorMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPVendorMaster";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByName(BOLVendorMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPVendorMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByName");
            cmd.Parameters.AddWithValue("@VendorName", obj.VendorName);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByUpdateName(BOLVendorMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPVendorMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByUpdateName");
            cmd.Parameters.AddWithValue("@VendorName", obj.VendorName);
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
