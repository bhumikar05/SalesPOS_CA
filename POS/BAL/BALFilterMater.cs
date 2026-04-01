using POS.BOL;
using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BAL
{
     class BALFilterMater: DAL
    {

        public DataTable Select(BOLFilterMater obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFilterMaster";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Insert(BOLFilterMater obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFilterMaster";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@FilterName", obj.FilterName);
            cmd.Parameters.AddWithValue("@Weight", obj.Weight);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void Update(BOLFilterMater obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFilterMaster";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@FilterName", obj.FilterName);
            cmd.Parameters.AddWithValue("@Weight", obj.Weight);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public DataTable SelectByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFilterMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", id);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByName(BOLFilterMater obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFilterMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByName");
            cmd.Parameters.AddWithValue("@FilterName", obj.FilterName);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void DeleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFilterMaster";
            cmd.Parameters.AddWithValue("@Spara", "DeleteByID");
            cmd.Parameters.AddWithValue("@ID", id);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
