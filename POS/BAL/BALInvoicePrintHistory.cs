using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALInvoicePrintHistory
    {
        public void Insert(BOLInvoicePrintHistory obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPInvoicePrintHistory";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            //cmd.Parameters.AddWithValue("@PrintDate", obj.PrintDate);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Delete(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPInvoicePrintHistory";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@InvoiceID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

    }
}
