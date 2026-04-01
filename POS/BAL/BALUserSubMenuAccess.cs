using POS.BOL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    public class BALUserSubMenuAccess
    {
        public DataTable SelectByUserID(BOLUserSubMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserSubMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "SelectByUserID");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@MenuID", obj.MenuID);
            cmd.Parameters.AddWithValue("@MenuName", obj.MenuName);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByMenuName(BOLUserSubMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserSubMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "SelectByMenuName");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@MenuName", obj.MenuName);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void Insert(BOLUserSubMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserSubMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@MenuID", obj.MenuID);
            cmd.Parameters.AddWithValue("@SubMenuID", obj.SubMenuID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Delete(BOLUserSubMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserSubMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

        public DataTable Select(BOLUserSubMenuAccess obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUserSubMenuAccess";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
