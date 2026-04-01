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
    class BALCreditMemoDetails
    {
        public DataTable SelectByID(BOLCreditMemoDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoDetails";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void UpdateItem(BOLCreditMemoDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoDetails";
            cmd.Parameters.AddWithValue("@Spara", "UpdateItem");
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            cmd.Parameters.AddWithValue("@OldItemID", obj.OldItemID);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public DataTable SelectInvID(BOLCreditMemoDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoDetails";
            cmd.Parameters.AddWithValue("@Spara", "SelectByItemID");
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByInvID(BOLCreditMemoDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoDetails";
            cmd.Parameters.AddWithValue("@Spara", "SelectByInvID");
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void InvoiceDetailsInsert(BOLCreditMemoDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoDetails";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@SrNo", obj.SrNo);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            cmd.Parameters.AddWithValue("@Decs", obj.Decs);
            cmd.Parameters.AddWithValue("@Quantity", obj.Quantity);
            cmd.Parameters.AddWithValue("@Rate", obj.Rate);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue("@ItemType", obj.ItemType);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            if (obj.IMEINumber != null)
            {
                cmd.Parameters.AddWithValue("@IMEINumber", obj.IMEINumber.Replace("\n", ","));
            }
            cmd.Parameters.AddWithValue("@Reason", obj.Reason);
            cmd.Parameters.AddWithValue("@GRADING", obj.GRADING);
            cmd.Parameters.AddWithValue("@Tax", obj.Tax);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Delete(BOLCreditMemoDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoDetails";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

        public void DeleteByItemID(BOLCreditMemoDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoDetails";
            cmd.Parameters.AddWithValue("@Spara", "DeleteByItemID");
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public void DeleteByItemName(BOLCreditMemoDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoDetails";
            cmd.Parameters.AddWithValue("@Spara", "DeleteByItemName");
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@ItemName", obj.ItemName);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public void DeleteByID(Int32 ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoDetails";
            cmd.Parameters.AddWithValue("@Spara", "DeleteByID");
            cmd.Parameters.AddWithValue("@InvoiceID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

        public DataTable SelectByItemID(BOLCreditMemoDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoDetails";
            cmd.Parameters.AddWithValue("@Spara", "SelectByItemID");
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectIEMINumber(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoDetails";
            cmd.Parameters.AddWithValue("@Spara", "IMEIReportsDetails");
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SearchIEMINumber(BOLCreditMemoDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoDetails";
            cmd.Parameters.AddWithValue("@Spara", "SearchIMEIReportsDetails");
            cmd.Parameters.AddWithValue("@IMEINumber", obj.IMEINumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

    }
}
