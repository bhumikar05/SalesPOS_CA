using POS.BOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.HelperClass;
using System.Data;

namespace POS.BAL
{
    class BALPriceTier
    {
        public void Insert(BOLPriceTire obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPriceTierMaster";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@PriceTier1", obj.PriceTier1);
            cmd.Parameters.AddWithValue("@PriceTier2", obj.PriceTier2);
            cmd.Parameters.AddWithValue("@PriceTier3", obj.PriceTier3);
            cmd.Parameters.AddWithValue("@Cost", obj.Cost);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void Update(BOLPriceTire obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPriceTierMaster";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@PriceTier1", obj.PriceTier1);
            cmd.Parameters.AddWithValue("@PriceTier2", obj.PriceTier2);
            cmd.Parameters.AddWithValue("@PriceTier3", obj.PriceTier3);
            cmd.Parameters.AddWithValue("@Cost", obj.Cost);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public DataTable SelectByRepID(Int32 ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPriceTierMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectBySalesRepID");
            cmd.Parameters.AddWithValue("@SalesRepID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void Delete(Int32 ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPriceTierMaster";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@SalesRepID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

    }
}
