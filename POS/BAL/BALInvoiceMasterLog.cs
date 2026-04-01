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
    class BALInvoiceMasterLog
    {
        public int InsertMaster(BOLInvoiceMasterLog obj)
        {
            int result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_InvoiceUpdateLogs";
                cmd.Parameters.AddWithValue("@Spara", "InsertMaster");
                cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
                cmd.Parameters.AddWithValue("@NewRefNumber", obj.NewRefNumber);
                cmd.Parameters.AddWithValue("@NewCustomerID", obj.NewCustomerID);
                cmd.Parameters.AddWithValue("@OldCustomerID", obj.OldCustomerID);
                cmd.Parameters.AddWithValue("@NewPONumber", obj.NewPONumber);
                cmd.Parameters.AddWithValue("@OldPONumber", obj.OldPONumber);
                cmd.Parameters.AddWithValue("@NewTermsID", obj.NewTermsID);
                cmd.Parameters.AddWithValue("@OldTermsID", obj.OldTermsID);
                cmd.Parameters.AddWithValue("@NewDueDate", obj.NewDueDate);
                cmd.Parameters.AddWithValue("@OldDueDate", obj.OldDueDate);
                cmd.Parameters.AddWithValue("@NewSalesRepId", obj.NewSalesRepId);
                cmd.Parameters.AddWithValue("@OldSalesRepId", obj.OldSalesRepId);
                cmd.Parameters.AddWithValue("@NewShipDate", obj.NewShipDate);
                cmd.Parameters.AddWithValue("@OldShipDate", obj.OldShipDate);
                cmd.Parameters.AddWithValue("@NewShipMethodID", obj.NewShipMethodID);
                cmd.Parameters.AddWithValue("@OldShipMethodID", obj.OldShipMethodID);
                cmd.Parameters.AddWithValue("@NewTotal", obj.NewTotal);
                cmd.Parameters.AddWithValue("@OldTotal", obj.OldTotal);
                cmd.Parameters.AddWithValue("@NewAppliedAmount", obj.NewAppliedAmount);
                cmd.Parameters.AddWithValue("@OldAppliedAmount", obj.OldAppliedAmount);
                cmd.Parameters.AddWithValue("@NewBalanceDue", obj.NewBalanceDue);
                cmd.Parameters.AddWithValue("@OldBalanceDue", obj.OldBalanceDue);
                cmd.Parameters.AddWithValue("@NewMemo", obj.NewMemo);
                cmd.Parameters.AddWithValue("@OldMemo", obj.OldMemo);
                //SqlParameter outputParam = new SqlParameter("@Ids", SqlDbType.Int)
                //{
                //    Direction = ParameterDirection.Output
                //};
                //cmd.Parameters.Add(outputParam);
                //result = Convert.ToInt32(cmd.Parameters["@Ids"].Value);
                DAL DAL = new DAL();
                result = DAL.Insert_Update_Del(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating invoice master log", ex);
            }

            return result;
        }

        public int InsertDetails(BOLInvoiceDetailsLog obj)
        {
            int result = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_InvoiceUpdateLogs";
                cmd.Parameters.AddWithValue("@Spara", "InsertDetails");
                cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
                cmd.Parameters.AddWithValue("@EditMode", obj.EditMode);
                cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
                cmd.Parameters.AddWithValue("@OldItemID", obj.OldItemID);
                cmd.Parameters.AddWithValue("@Description", obj.Description);
                cmd.Parameters.AddWithValue("@OldDescription", obj.OldDescription);
                cmd.Parameters.AddWithValue("@Qty", obj.Qty);
                cmd.Parameters.AddWithValue("@OldQty", obj.OldQty);
                cmd.Parameters.AddWithValue("@PriceEach", obj.PriceEach);
                cmd.Parameters.AddWithValue("@OldPriceEach", obj.OldPriceEach);
                cmd.Parameters.AddWithValue("@Amount", obj.Amount);
                cmd.Parameters.AddWithValue("@OldAmount", obj.OldAmount);
                //SqlParameter outputParam = new SqlParameter("@Ids", SqlDbType.Int)
                //{
                //    Direction = ParameterDirection.Output
                //};
                //cmd.Parameters.Add(outputParam);
                //result = Convert.ToInt32(cmd.Parameters["@Ids"].Value);
                DAL DAL = new DAL();
                result = DAL.Insert_Update_Del(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating invoice master log", ex);
            }
            return result;

        }

        public void UpdateMasterID(BOLInvoiceDetailsLog obj)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_InvoiceUpdateLogs";
                cmd.Parameters.AddWithValue("@Spara", "UpdateMasterId");
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@MasterLogID", obj.MasterLogID);

                DAL DAL = new DAL();
                DAL.Insert(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating invoice master log", ex);
            }

        }

        public DataTable SelectByDate(BOLInvoiceMasterLog obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InvoiceUpdateLogs";
            cmd.Parameters.AddWithValue("@Spara", "SelectByDate");
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }


        public DataTable SelectByInvID(BOLInvoiceDetailsLog obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InvoiceUpdateLogs";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@MasterLogID", obj.MasterLogID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void DeleteMaster(BOLInvoiceMasterLog obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InvoiceUpdateLogs";
            cmd.Parameters.AddWithValue("@Spara", "DeleteMasterData");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public void DeleteDetail(BOLInvoiceMasterLog obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InvoiceUpdateLogs";
            cmd.Parameters.AddWithValue("@Spara", "DeleteDetailsData");
            cmd.Parameters.AddWithValue("@MasterLogID", obj.ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

    }
}
