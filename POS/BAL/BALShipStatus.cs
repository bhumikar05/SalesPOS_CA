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
    internal class BALShipStatus:DAL
    {
        public DataTable Select(BOLShipStatus obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_ShipStatus";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Insert(BOLShipStatus obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_ShipStatus";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ShipStatus", obj.ShipStatus);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Update(BOLShipStatus obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_ShipStatus";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@ShipStatus", obj.ShipStatus);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }

        public DataTable SelectByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_ShipStatus";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", id);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }


        public DataTable SelectByName(BOLShipStatus obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_ShipStatus";
            cmd.Parameters.AddWithValue("@Spara", "SelectByName");
            cmd.Parameters.AddWithValue("@ShipStatus", obj.ShipStatus);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void DeleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_ShipStatus";
            cmd.Parameters.AddWithValue("@Spara", "DeleteByID");
            cmd.Parameters.AddWithValue("@ID", id);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
