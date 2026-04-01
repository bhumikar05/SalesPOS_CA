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
    class BALInvoiceMessage
    {
        public void Insert(BOLInvoiceMessage obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InvoiceMessage";
            cmd.Parameters.AddWithValue("@Mode", "Insert");
            cmd.Parameters.AddWithValue("@LogName", obj.LogName);
            cmd.Parameters.AddWithValue("@CreateDate", obj.CreatedDate);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public DataTable SelectByID(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InvoiceMessage";
            cmd.Parameters.AddWithValue("@Mode", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Update(BOLInvoiceMessage obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InvoiceMessage";
            cmd.Parameters.AddWithValue("@Mode", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@LogName", obj.LogName);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public void Delete(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InvoiceMessage";
            cmd.Parameters.AddWithValue("@Mode", "Delete");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public DataTable SelectAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InvoiceMessage";
            cmd.Parameters.AddWithValue("@Mode", "SelectAll");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        
        public DataTable Customermessage_Last()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_InvoiceMessage";
            cmd.Parameters.AddWithValue("@Mode", "Customermessage_Last");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
