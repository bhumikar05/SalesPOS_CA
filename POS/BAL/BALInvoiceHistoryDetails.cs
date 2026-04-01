using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALInvoiceHistoryDetails
    {
        public void Insert(BOLInvoiceHistoryDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPInvoiceHistoryDetails";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@InvoiceHistoryID", obj.InvoiceHistoryID);
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            cmd.Parameters.AddWithValue("@Qty", obj.Qty);
            cmd.Parameters.AddWithValue("@Rate", obj.Rate);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
    }
}
