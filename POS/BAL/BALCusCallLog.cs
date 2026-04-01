using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.BOL;
using POS.HelperClass;

namespace POS.BAL
{
    class BALCusCallLog
    {
        public DataTable SelectBySalesRep(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCusLogMaster";
            cmd.Parameters.AddWithValue("@Mode", "SelectBySalesRep");
            cmd.Parameters.AddWithValue("@UserID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByID(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCusLogMaster";
            cmd.Parameters.AddWithValue("@Mode", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByCusID(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCusLogMaster";
            cmd.Parameters.AddWithValue("@Mode", "SelectByCusID");
            cmd.Parameters.AddWithValue("@CusID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void Insert(BOLCusCallLog obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCusLogMaster";
            cmd.Parameters.AddWithValue("@Mode", "Insert");
            cmd.Parameters.AddWithValue("@CusID", obj.CusID);
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@LogName", obj.LogName);
            cmd.Parameters.AddWithValue("@CreatedDate", obj.CreatedDate);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void Update(BOLCusCallLog obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCusLogMaster";
            cmd.Parameters.AddWithValue("@Mode", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@CusID", obj.CusID);
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@LogName", obj.LogName);
            cmd.Parameters.AddWithValue("@UpdatedDate", obj.UpdatedDate);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public void Delete(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCusLogMaster";
            cmd.Parameters.AddWithValue("@Mode", "Delete");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
