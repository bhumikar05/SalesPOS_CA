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
    class BALHistoryMaster
    {
        public DataTable Select(int InvoiceID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPHistoryMaster";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            cmd.Parameters.AddWithValue("@InvoiceID",InvoiceID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Delete(BOLHistoryMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPHistoryMaster";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public void Insert(BOLHistoryMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPHistoryMaster";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@IsPrint", obj.IsPrint);
            cmd.Parameters.AddWithValue("@IsUpdate", obj.IsUpdate);
            cmd.Parameters.AddWithValue("@IsPrintDate", obj.IsPrintDate);
            cmd.Parameters.AddWithValue("@IsUpdateDate", obj.IsUpdateDate);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Update(BOLHistoryMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPHistoryMaster";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@IsPrint", obj.IsPrint);
            cmd.Parameters.AddWithValue("@IsUpdate", obj.IsUpdate);  
            cmd.Parameters.AddWithValue("@IsUpdateDate", obj.IsUpdateDate);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }

        public void UpdatePrint(BOLHistoryMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPHistoryMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdatePrint");
            cmd.Parameters.AddWithValue("@IsPrint", obj.IsPrint);
            cmd.Parameters.AddWithValue("@IsUpdate", obj.IsUpdate);
            cmd.Parameters.AddWithValue("@IsPrintDate", obj.IsPrintDate);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
    }
}
