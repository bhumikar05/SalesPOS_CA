using POS.BOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace POS.BAL
{
    class BALNoteMaster
    {

        public void Insert(BOLNoteMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNoteMaster";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@CusID", obj.CusID);
            cmd.Parameters.AddWithValue("@Note", obj.Note);
            cmd.Parameters.AddWithValue("@UseOneTime", obj.UseOneTime);
            cmd.Parameters.AddWithValue("@UseEveryTime", obj.UseEveryTime);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Update(BOLNoteMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNoteMaster";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@CusID", obj.CusID);
            cmd.Parameters.AddWithValue("@Note", obj.Note);
            cmd.Parameters.AddWithValue("@UseOneTime", obj.UseOneTime);
            cmd.Parameters.AddWithValue("@UseEveryTime", obj.UseEveryTime);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }

        public void UpdateStatus(BOLNoteMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNoteMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateStatus");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@UseOneTime", obj.UseOneTime);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }

        public DataTable SelectByCusID(Int32 ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNoteMaster";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            cmd.Parameters.AddWithValue("@CusID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByID(Int32 ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNoteMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void Delete(Int32 ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNoteMaster";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public void DeleteCusID(Int32 ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNoteMaster";
            cmd.Parameters.AddWithValue("@Spara", "DeleteByCusID");
            cmd.Parameters.AddWithValue("@CusID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
