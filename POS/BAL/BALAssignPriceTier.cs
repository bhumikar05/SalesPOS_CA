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
    class BALAssignPriceTier
    {
        public DataTable SelectByCustomerAndID(int CustomerID,int UserID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_AssignPriceTier";
            cmd.Parameters.AddWithValue("@MODE", "SelectByCustomerAndID");
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void InsertUpdate(BOLAssignPriceTier obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_AssignPriceTier";
            cmd.Parameters.AddWithValue("@MODE", "InsertUpdate");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@PriceTier", obj.PriceTier);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        

    }
}
