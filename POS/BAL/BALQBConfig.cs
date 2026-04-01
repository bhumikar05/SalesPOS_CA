using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALQBConfig
    {
        public DataTable Select(BOLQBConfig obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPQBConfig";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void Insert(BOLQBConfig obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPQBConfig";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Path", obj.Path);
            cmd.Parameters.AddWithValue("@Year", obj.Year);
            cmd.Parameters.AddWithValue("@Version", obj.Version);
            cmd.Parameters.AddWithValue("@Flag", obj.Flag);
           // cmd.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
          //  cmd.Parameters.AddWithValue("@CompanyAddress", obj.CompanyAddress);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void UpdateConfig(BOLQBConfig obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPQBConfig";
            cmd.Parameters.AddWithValue("@Spara", "UpdateConfig");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Path", obj.Path);
            cmd.Parameters.AddWithValue("@Year", obj.Year);
            cmd.Parameters.AddWithValue("@Version", obj.Version);
            cmd.Parameters.AddWithValue("@Flag", obj.Flag);
          //  cmd.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
          //  cmd.Parameters.AddWithValue("@CompanyAddress", obj.CompanyAddress);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void UpdateGetAllDate(BOLQBConfig obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPQBConfig";
            cmd.Parameters.AddWithValue("@Spara", "UpdateGetAllDate");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@GetAllDate", obj.GetAllDate);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
    }
}
