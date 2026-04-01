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
    public class BALEditedInvoice
    {
        public DataTable SELECT(BOLEditedInvoice obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPEditedInvoice";
            cmd.Parameters.AddWithValue("@MODE", "SELECT");
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Insert(BOLEditedInvoice obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPEditedInvoice";
            cmd.Parameters.AddWithValue("@MODE", "Insert");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            cmd.Parameters.AddWithValue("@OldTotal", obj.OldTotal);
            cmd.Parameters.AddWithValue("@NewTotal", obj.NewTotal);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void Update(BOLEditedInvoice obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPEditedInvoice";
            cmd.Parameters.AddWithValue("@MODE", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
    }
}
