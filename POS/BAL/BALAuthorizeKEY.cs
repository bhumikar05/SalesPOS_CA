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
    class BALAuthorizeKEY : DAL
    {
        public DataTable Select()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_Authorize_Key";
            cmd.Parameters.AddWithValue("@MODE", "SELECT");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectDate()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_AuthorizeDateWisePayment";
            cmd.Parameters.AddWithValue("@MODE", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectModeName(BOLAuthorizeDate obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_AuthorizeDateWisePayment";
            cmd.Parameters.AddWithValue("@MODE", "SelectModeName");
            cmd.Parameters.AddWithValue("@ModeName", obj.ModeName);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public static void Insert(BOLAuthorizeDate obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_AuthorizeDateWisePayment";
            cmd.Parameters.AddWithValue("@MODE", "Insert");
            cmd.Parameters.AddWithValue("@ModeName", obj.ModeName);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void update(BOLAuthorizeDate obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_AuthorizeDateWisePayment";
            cmd.Parameters.AddWithValue("@MODE", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        //public DataTable SelectPayPalName(BOLPayment obj)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPCustomerMaster";
        //    cmd.Parameters.AddWithValue("@Spara", "SelectPayPalName");
        //    cmd.Parameters.AddWithValue("@PayPalName", obj.PayPalName);
        //    DAL DAL = new DAL();
        //    DataTable dt = DAL.Select(cmd);
        //    return dt;
        //}
        //public DataTable SelectRefNumber(BOLAuthorizePayment obj)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPInvoiceMaster";
        //    cmd.Parameters.AddWithValue("@Spara", "SelectRefNumber");
        //    cmd.Parameters.AddWithValue("@RefNumber", obj.invoiceNumber);
        //    DAL DAL = new DAL();
        //    DataTable dt = DAL.Select(cmd);
        //    return dt;
        //}
        public DataTable SelectPaymentMethodType(BOLAuthorizePayment obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPPaymentMethod";
            cmd.Parameters.AddWithValue("@Spara", "SelectPaymentMethodType");
            cmd.Parameters.AddWithValue("@PaymentMethodType", obj.accountType);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        //public void UpdatePaidInvoice(BOLPayment obj)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPInvoiceMaster";
        //    cmd.Parameters.AddWithValue("@Spara", "UpdatePaidInvoice");
        //    cmd.Parameters.AddWithValue("@ID", obj.ID);
        //    cmd.Parameters.AddWithValue("@PaidInvoice", obj.PaidInvoice);
        //    cmd.Parameters.AddWithValue("@AppliedAmount", obj.AppliedAmount);
        //    cmd.Parameters.AddWithValue("@BalanceDue", obj.BalanceDue);
        //    DAL DAL = new DAL();
        //    DAL.Update(cmd);
        //}
        //public DataTable SelectByCusIDAmount(BOLPayment obj)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SPInvoiceMaster";
        //    cmd.Parameters.AddWithValue("@Spara", "SelectByCusIDAmount");
        //    cmd.Parameters.AddWithValue("@CustomerID", obj.ID);
        //    cmd.Parameters.AddWithValue("@TxnDate", obj.TxnDate);
        //    cmd.Parameters.AddWithValue("@BalanceDue", obj.BalanceDue);
        //    cmd.Parameters.AddWithValue("@COUNT", obj.COUNT);
        //    DAL DAL = new DAL();
        //    DataTable dt = DAL.Select(cmd);
        //    return dt;
        //}



    }
}
