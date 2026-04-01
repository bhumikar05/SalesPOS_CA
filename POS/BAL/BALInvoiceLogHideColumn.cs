using POS.BOL;
using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POS.BAL
{
    public class BALInvoiceLogHideColumn
    {
        public DataTable Select(BOLInvoiceLogHideColumn obj)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InvoiceLogHideColumn";
            cmd.Parameters.AddWithValue("@Mode", "Select");
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public void Insert(BOLInvoiceLogHideColumn obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_InvoiceLogHideColumn";
                cmd.Parameters.AddWithValue("@Mode", "Insert");
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);

                cmd.Parameters.AddWithValue("@NewRefNumber", obj.NewRefNumber);
                cmd.Parameters.AddWithValue("@NewCustomerName", obj.NewCustomerName);
                cmd.Parameters.AddWithValue("@OldCustomerName", obj.OldCustomerName);
                cmd.Parameters.AddWithValue("@NewPONumber", obj.NewPONumber);
                cmd.Parameters.AddWithValue("@OldPONumber", obj.OldPONumber);
                cmd.Parameters.AddWithValue("@NewTermsName", obj.NewTermsName);
                cmd.Parameters.AddWithValue("@OldTermsName", obj.OldTermsName);
                cmd.Parameters.AddWithValue("@NewDueDate", obj.NewDueDate);
                cmd.Parameters.AddWithValue("@OldDueDate", obj.OldDueDate);
                cmd.Parameters.AddWithValue("@NewSalesRepName", obj.NewSalesRepName);
                cmd.Parameters.AddWithValue("@OldSalesRepName", obj.OldSalesRepName);
                cmd.Parameters.AddWithValue("@NewshipDate", obj.NewshipDate);
                cmd.Parameters.AddWithValue("@OldShipDate", obj.OldShipDate);
                cmd.Parameters.AddWithValue("@NewShipping", obj.NewShipping);
                cmd.Parameters.AddWithValue("@OldShipping", obj.OldShipping);
                cmd.Parameters.AddWithValue("@NewTotal", obj.NewTotal);
                cmd.Parameters.AddWithValue("@OldTotal", obj.OldTotal);
                cmd.Parameters.AddWithValue("@NewAppliedAmount", obj.NewAppliedAmount);
                cmd.Parameters.AddWithValue("@OldAppliedAmount", obj.OldAppliedAmount);
                cmd.Parameters.AddWithValue("@NewBalanceDue", obj.NewBalanceDue);
                cmd.Parameters.AddWithValue("@OldBalanceDue", obj.OldBalanceDue);
                cmd.Parameters.AddWithValue("@NewMemo", obj.NewMemo);
                cmd.Parameters.AddWithValue("@OldMemo", obj.OldMemo);
                cmd.Parameters.AddWithValue("@EditCount", obj.EditCount);
                cmd.Parameters.AddWithValue("@UpdateDate", obj.UpdateDate);
                DAL DAL = new DAL();
                DAL.Insert(cmd);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Class:BALCustomerLogHideColumn,Function :Insert. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        public void Update(BOLInvoiceLogHideColumn obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_InvoiceLogHideColumn";
                cmd.Parameters.AddWithValue("@Mode", "Update");
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);

                cmd.Parameters.AddWithValue("@NewRefNumber", obj.NewRefNumber);
                cmd.Parameters.AddWithValue("@NewCustomerName", obj.NewCustomerName);
                cmd.Parameters.AddWithValue("@OldCustomerName", obj.OldCustomerName);
                cmd.Parameters.AddWithValue("@NewPONumber", obj.NewPONumber);
                cmd.Parameters.AddWithValue("@OldPONumber", obj.OldPONumber);
                cmd.Parameters.AddWithValue("@NewTermsName", obj.NewTermsName);
                cmd.Parameters.AddWithValue("@OldTermsName", obj.OldTermsName);
                cmd.Parameters.AddWithValue("@NewDueDate", obj.NewDueDate);
                cmd.Parameters.AddWithValue("@OldDueDate", obj.OldDueDate);
                cmd.Parameters.AddWithValue("@NewSalesRepName", obj.NewSalesRepName);
                cmd.Parameters.AddWithValue("@OldSalesRepName", obj.OldSalesRepName);
                cmd.Parameters.AddWithValue("@NewshipDate", obj.NewshipDate);
                cmd.Parameters.AddWithValue("@OldShipDate", obj.OldShipDate);
                cmd.Parameters.AddWithValue("@NewShipping", obj.NewShipping);
                cmd.Parameters.AddWithValue("@OldShipping", obj.OldShipping);
                cmd.Parameters.AddWithValue("@NewTotal", obj.NewTotal);
                cmd.Parameters.AddWithValue("@OldTotal", obj.OldTotal);
                cmd.Parameters.AddWithValue("@NewAppliedAmount", obj.NewAppliedAmount);
                cmd.Parameters.AddWithValue("@OldAppliedAmount", obj.OldAppliedAmount);
                cmd.Parameters.AddWithValue("@NewBalanceDue", obj.NewBalanceDue);
                cmd.Parameters.AddWithValue("@OldBalanceDue", obj.OldBalanceDue);
                cmd.Parameters.AddWithValue("@NewMemo", obj.NewMemo);
                cmd.Parameters.AddWithValue("@OldMemo", obj.OldMemo);
                cmd.Parameters.AddWithValue("@EditCount", obj.EditCount);
                cmd.Parameters.AddWithValue("@UpdateDate", obj.UpdateDate);
                DAL DAL = new DAL();
                DAL.Update(cmd);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Class:BALCustomerLogHideColumn,Function :Update. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
