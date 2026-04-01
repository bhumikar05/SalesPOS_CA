using POS.HelperClass;
using System.Data;
using System.Data.SqlClient;

namespace POS.BAL
{
    public class BALUserRequest
    {
        public DataTable Select()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserRequest";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Insert(int UserID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserRequest";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@UserID", UserID);           
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Update(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserRequest";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", ID);            
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
    }
}

