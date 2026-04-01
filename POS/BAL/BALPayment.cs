using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;
using System;

namespace POS.BAL
{
    class BALPayment
    {
        public DataTable Select(string ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            cmd.Parameters.AddWithValue("@InvoiceID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByTransactionID(BOLPayment obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "SelectByTransactionID");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByInvID(Int32 ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "SelectByInvID");
            cmd.Parameters.AddWithValue("@InvoiceID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Insert(BOLPayment obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@PaymentMethodID", obj.PaymentMethodID);
            cmd.Parameters.AddWithValue("@PayAmount", obj.PayAmount);
            cmd.Parameters.AddWithValue("@CreditAmount", obj.CreditAmount);
            cmd.Parameters.AddWithValue("@TransactionID", obj.TransactionID);
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            cmd.Parameters.AddWithValue("@IsQBSync", obj.IsQBSync);
            cmd.Parameters.AddWithValue("@PayPalID", obj.PayPalID);
            //Hiren
            cmd.Parameters.AddWithValue("@Reference", obj.Reference);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void UpdateAll(BOLPayment obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "UpdateAll");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@PaymentMethodID", obj.PaymentMethodID);
            cmd.Parameters.AddWithValue("@PayAmount", obj.PayAmount);
            cmd.Parameters.AddWithValue("@CreditAmount", obj.CreditAmount);
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            //Hiren
            cmd.Parameters.AddWithValue("@Reference", obj.Reference);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        //Hiren
        public void DeletePayment(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "UpdateIsDelete");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public DataTable SelectByPaymentID(string ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentDetail";
            cmd.Parameters.AddWithValue("@Spara", "SelectByPaymentID");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
