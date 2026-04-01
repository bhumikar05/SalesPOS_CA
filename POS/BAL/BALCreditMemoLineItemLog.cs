using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;
using System;

namespace POS.BAL
{
    class BALCreditMemoLineItemLog
    {
      

        public void Insert(BOLCreditMemoLineItemLog obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemoLineItemLog";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@CreditMemoID", obj.CreditMemoID);
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            cmd.Parameters.AddWithValue("@EditCount", obj.EditCount);
            cmd.Parameters.AddWithValue("@Description", obj.Description);
            cmd.Parameters.AddWithValue("@Qty", obj.Qty);
            cmd.Parameters.AddWithValue("@PriceEach", obj.PriceEach);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue("@IsPrint", obj.IsPrint);
            cmd.Parameters.AddWithValue("@EditMode", obj.EditMode);
            cmd.Parameters.AddWithValue("@OldQty", obj.OldQty);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
     
    }
}
