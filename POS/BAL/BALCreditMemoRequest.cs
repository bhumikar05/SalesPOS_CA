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
    public class BALCreditMemoRequest
    {
        public DataTable Select(BOLCreditMemoRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoRequest";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByID(BOLCreditMemoRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@CreditMemoNumber", obj.CreditMemoNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Insert(BOLCreditMemoRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoRequest";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@CreditMemoNumber", obj.CreditMemoNumber);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@Status", obj.Status);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Update(BOLCreditMemoRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoRequest";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@CreditMemoNumber", obj.CreditMemoNumber);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@Status", obj.Status);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);

            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void Delete(BOLCreditMemoRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoRequest";
            cmd.Parameters.AddWithValue("@Spara", "DeleteByNo");
            cmd.Parameters.AddWithValue("@CreditMemoNumber", obj.CreditMemoNumber);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public void DeleteRequest(string ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoRequest";
            cmd.Parameters.AddWithValue("@Spara", "DeleteRequest");
            cmd.Parameters.AddWithValue("@CustomerID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public DataTable SelectByDate(BOLCreditMemoRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoRequest";
            cmd.Parameters.AddWithValue("@Spara", "SelectByDate");
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
