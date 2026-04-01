using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using POS.HelperClass;

namespace POS.BAL
{
    public class BALUserMenuAccess
    {
        public DataTable Select(BOLUserMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void Insert(BOLUserMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@MenuID", obj.MenuID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Update(BOLUserMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@MenuID", obj.MenuID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Delete(BOLUserMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

        public DataTable SelectForSave(BOLUserMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "SelectForSave");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectForUpdate(BOLUserMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "SelectForUpdate");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByUserID(BOLUserMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "SelectByUserID");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectForAccess(BOLUserMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "SelectForAccess");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }



        public void DeleteAccess(BOLUserMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "DeleteAccess");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
