using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;
using System;


namespace POS.BAL
{
    class BALCustomerTransferList
    {
        public void Insert(BOLCustomerTransferList obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerTransferList";
            cmd.Parameters.AddWithValue("@Mode", "Insert");
            cmd.Parameters.AddWithValue("@CusID", obj.CusID);
            cmd.Parameters.AddWithValue("@OldSalesRep", obj.OldSalesRep);
            cmd.Parameters.AddWithValue("@NewSalesRep", obj.NewSalesRep);
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public DataTable Select()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerTransferList";
            cmd.Parameters.AddWithValue("@Mode", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByID(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCustomerTransferList";
            cmd.Parameters.AddWithValue("@Mode", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
