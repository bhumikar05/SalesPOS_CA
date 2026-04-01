using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.BOL;
using POS.HelperClass;

namespace POS.BAL
{
    class BALInvoiceAuditLogDetail
    {
        public void Insert(BOLInvoiceAuditLogDetail obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPInvoiceAuditLogDetail";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@AuditID", obj.AuditID);
            cmd.Parameters.AddWithValue("@SrNo", obj.SrNo);
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            cmd.Parameters.AddWithValue("@Decs", obj.Decs);
            cmd.Parameters.AddWithValue("@Quantity", obj.Quantity);
            cmd.Parameters.AddWithValue("@Rate", obj.Rate);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue("@ItemType", obj.ItemType);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
    }
}
