using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALPaypalPaymentVerifaction
    {
        public DataTable Select(BOLPaypalPaymentVerifaction obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaypalPaymentVerifaction";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
     


        //public DataTable SelectByInvID(BOLPaypalPaymentVerifaction obj)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPPaypalPaymentVerifaction";
        //    cmd.Parameters.AddWithValue("@Spara", "SelectByInvID");
        //    cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
        //    DAL DAL = new DAL();
        //    DataTable dt = DAL.Select(cmd);
        //    return dt;
        //}

        //public DataTable SelectInvoiceWisePayment(BOLPaypalPaymentVerifaction obj)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPPaypalPaymentVerifaction";
        //    cmd.Parameters.AddWithValue("@Spara", "SelectInvoiceWisePayment");
        //    cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
        //    DAL DAL = new DAL();
        //    DataTable dt = DAL.Select(cmd);
        //    return dt;
        //}

        //public void Insert(BOLPaypalPaymentVerifaction obj)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPPaypalPaymentVerifaction";
        //    cmd.Parameters.AddWithValue("@Spara", "Insert");
        //    cmd.Parameters.AddWithValue("@ID", obj.ID);
        //    cmd.Parameters.AddWithValue("@PaypalAccountID", obj.PaypalAccountID);
        //    cmd.Parameters.AddWithValue("@TransactionID", obj.TransactionID);
        //    cmd.Parameters.AddWithValue("@TransactionInitiationDate", obj.TransactionInitiationDate);
        //    cmd.Parameters.AddWithValue("@TransactionUpdatedDate", obj.TransactionUpdatedDate);
        //    cmd.Parameters.AddWithValue("@CurrencyCode", obj.CurrencyCode);
        //    cmd.Parameters.AddWithValue("@Amount", obj.Amount);
        //    cmd.Parameters.AddWithValue("@FeeAmount", obj.FeeAmount);
        //    cmd.Parameters.AddWithValue("@TotalAmount", obj.TotalAmount);
        //    cmd.Parameters.AddWithValue("@TransactionStatus", obj.TransactionStatus);
        //    cmd.Parameters.AddWithValue("@InvoiceNumber", obj.InvoiceNumber);
        //    cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
        //    cmd.Parameters.AddWithValue("@ModifiedID", obj.ModifiedID);
        //    DAL DAL = new DAL();
        //    DAL.Insert(cmd);
        //}

        //public void Update(BOLPaypalPaymentVerifaction obj)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPPaypalPaymentVerifaction";
        //    cmd.Parameters.AddWithValue("@Spara", "Update");
        //    cmd.Parameters.AddWithValue("@ID", obj.ID);
        //    cmd.Parameters.AddWithValue("@PaypalAccountID", obj.PaypalAccountID);
        //    cmd.Parameters.AddWithValue("@TransactionID", obj.TransactionID);
        //    cmd.Parameters.AddWithValue("@TransactionInitiationDate", obj.TransactionInitiationDate);
        //    cmd.Parameters.AddWithValue("@TransactionUpdatedDate", obj.TransactionUpdatedDate);
        //    cmd.Parameters.AddWithValue("@CurrencyCode", obj.CurrencyCode);
        //    cmd.Parameters.AddWithValue("@Amount", obj.Amount);
        //    cmd.Parameters.AddWithValue("@FeeAmount", obj.FeeAmount);
        //    cmd.Parameters.AddWithValue("@TotalAmount", obj.TotalAmount);
        //    cmd.Parameters.AddWithValue("@TransactionStatus", obj.TransactionStatus);
        //    cmd.Parameters.AddWithValue("@InvoiceNumber", obj.InvoiceNumber);
        //    cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
        //    cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
        //    cmd.Parameters.AddWithValue("@ModifiedID", obj.ModifiedID);
        //    DAL DAL = new DAL();
        //    DAL.Insert(cmd);
        //}

        public void UpdatePaymentStatus(BOLPaypalPaymentVerifaction obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaypalPaymentVerifaction";
            cmd.Parameters.AddWithValue("@Spara", "UpdatePaymentStatus");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@PaymentStatus", obj.PaymentStatus);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue("@DueAmount", obj.DueAmount);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@BankAccID", obj.BankAccID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
    }
}
