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
    class BALPaymentDetail
    {
        public void UpdatePaymentStatus(BOLPaymentDetail obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaidInvoiceHistory";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@PaidAmount", obj.PaidAmount);
            cmd.Parameters.AddWithValue("@CreditAmount", obj.CreditAmount);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void DeleteByID(Int32 ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        //Hiren
        public DataTable SelectByID(BOLPaymentDetail obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectCustomer(Int32 ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "SelectCustomer");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectAllPaymentByCustomer(BOLPaymentDetail obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "SelectAllPaymentByCustomer");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@PaymentMethodID", obj.PaymentMethodID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            //cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectAllPayment(BOLPaymentDetail obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "SelectAllPayment");
            cmd.Parameters.AddWithValue("@PaymentMethodID", obj.PaymentMethodID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectSearchPayment(BOLPaymentDetail obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "SelectSearchPayment");
            //cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@RefNumber", obj.RefNumber);
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            //Hiren
            //cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            //cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectAllInvoiceID()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "SelectAllInvoiceID");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
