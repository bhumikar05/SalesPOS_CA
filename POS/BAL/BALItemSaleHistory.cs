using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;
using System;

namespace POS.BAL
{
    class BALItemSaleHistory
    {
        public DataTable SelectLastThreeSale(BOLItemSaleHistory obj)
        {
            DataTable dt=new DataTable();
            try
            {


                ClsCommon.WriteErrorLogs("start get BALItemSaleHistory InvoiceSaleHistory Line No:-13");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SPItemSaleHistory";
                cmd.Parameters.AddWithValue("@Spara", "SelectLastThreeSale");
                cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
                cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
                DAL DAL = new DAL();
                 dt = DAL.Select(cmd);
            }
            catch(Exception ex) 
            {
                ClsCommon.WriteErrorLogs("start get BALItemSaleHistory InvoiceSaleHistory Line No:-30 error message:-"+ex.Message);

            }

            return dt;
            ClsCommon.WriteErrorLogs("start get BALItemSaleHistory InvoiceSaleHistory Line No:-35");

        }

        public void Insert(BOLItemSaleHistory obj)
        {
            try
            {
                ClsCommon.WriteErrorLogs("start insert BALItemSaleHistory InvoiceSaleHistory Line No:-44");

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SPItemSaleHistory";
                cmd.Parameters.AddWithValue("@Spara", "Insert");
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
                cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
                cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
                cmd.Parameters.AddWithValue("@SalePrice", obj.SalePrice);
                cmd.Parameters.AddWithValue("@LastSaleDate", obj.LastSaleDate);
                cmd.Parameters.AddWithValue("@ShippingMethodID", obj.ShippingMethodID);
                cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
                DAL DAL = new DAL();
                DAL.Insert(cmd);
                ClsCommon.WriteErrorLogs("end insert BALItemSaleHistory InvoiceSaleHistory Line No:-44");

            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("insert BALItemSaleHistory InvoiceSaleHistory Line No:-44");

            }


        }

        public void Update(BOLItemSaleHistory obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemSaleHistory";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@SalePrice", obj.SalePrice);
            cmd.Parameters.AddWithValue("@LastSaleDate", obj.LastSaleDate);
            cmd.Parameters.AddWithValue("@ShippingMethodID", obj.ShippingMethodID);
            cmd.Parameters.AddWithValue("@ModifiedID", obj.ModifiedID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Delete(BOLItemSaleHistory obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemSaleHistory";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

        public DataTable SelectByDateWise(BOLItemSaleHistory obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemSaleHistory";
            cmd.Parameters.AddWithValue("@Spara", "SelectByDateWise");
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            cmd.Parameters.AddWithValue("@FromDate", obj.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByItemWise(BOLItemSaleHistory obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemSaleHistory";
            cmd.Parameters.AddWithValue("@Spara", "SelectByItem");
            cmd.Parameters.AddWithValue("@FromDate", obj.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectCustomerSaleHistory(BOLItemSaleHistory obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemSaleHistory";
            cmd.Parameters.AddWithValue("@Spara", "SelectCustomerSaleHistory");
            cmd.Parameters.AddWithValue("@FromDate", obj.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectItemSaleHistory(BOLItemSaleHistory obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPItemSaleHistory";
            cmd.Parameters.AddWithValue("@Spara", "SelectItemSaleHistory");
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
