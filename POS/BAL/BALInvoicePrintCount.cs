using System;
using POS.BOL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.HelperClass;
using System.Data.SqlClient;
using System.Data;

namespace POS.BAL
{
    class BALInvoicePrintCount
    {

        public void Insert(BOLInvoicePrintCount obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPInvoicePrintCount";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@RefNumber", obj.RefNumber);
            cmd.Parameters.AddWithValue("@PrintNo", obj.PrintNo);
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            cmd.Parameters.AddWithValue("@IsPrint", obj.IsPrint);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Update(BOLInvoicePrintCount obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPInvoicePrintCount";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@PrintNo", obj.PrintNo);
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            cmd.Parameters.AddWithValue("@IsPrint", obj.IsPrint);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public DataTable Select(Int32 ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPInvoicePrintCount";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            cmd.Parameters.AddWithValue("@InvoiceID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
