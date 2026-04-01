using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALNewCustomerHistory
    {
        public DataTable Select(string CustomerID, string ToSalesRepID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNewCustomerHistory";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmd.Parameters.AddWithValue("@ToSalesRepID", ToSalesRepID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void Insert(string CustomerID,string ToSalesRepID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNewCustomerHistory";
            cmd.Parameters.AddWithValue("@Spara", "Insert");            
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmd.Parameters.AddWithValue("@ToSalesRepID", ToSalesRepID);                 
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Delete(string CustomerID, string ToSalesRepID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNewCustomerHistory";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmd.Parameters.AddWithValue("@ToSalesRepID", ToSalesRepID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

        public DataTable SelectAll(BOLNewCustomerHistory obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPNewCustomerHistory";
            cmd.Parameters.AddWithValue("@Spara", "SelectAll");
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@ToSalesRepID", obj.ToSalesRepID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
