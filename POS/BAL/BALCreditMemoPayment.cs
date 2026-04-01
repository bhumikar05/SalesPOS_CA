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
    class BALCreditMemoPayment
    {
        public void Insert(BOLCreditMemoPayment obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoPayment";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
           // cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@CreditMemoID", obj.CreditMemoID);
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            cmd.Parameters.AddWithValue("@PayAmount", obj.PayAmount);
            cmd.Parameters.AddWithValue("@IsQBSync", obj.IsQBSync);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public DataTable Select(string ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoPayment";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            cmd.Parameters.AddWithValue("@InvoiceID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Delete(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoPayment";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
