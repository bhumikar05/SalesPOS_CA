using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALUserType
    {
        public DataTable Select(BOLUserType obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserType";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByID(BOLUserType obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserType";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByName(BOLUserType obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserType";
            cmd.Parameters.AddWithValue("@Spara", "SelectByName");
            cmd.Parameters.AddWithValue("@UserType", obj.UserType);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void Insert(BOLUserType obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserType";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@UserType", obj.UserType);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Update(BOLUserType obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserType";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@UserType", obj.UserType);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Delete(BOLUserType obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserType";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
