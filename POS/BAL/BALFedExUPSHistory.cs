using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALFedExUPSHistory
    {
        public void Insert(BOLFedExUPSHistory obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPFedExUPSHistory";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Type", obj.Type);
            cmd.Parameters.AddWithValue("@OrderID", obj.OrderID);
            cmd.Parameters.AddWithValue("@TrackingID", obj.TrackingID);
            cmd.Parameters.AddWithValue("@Postage", obj.Postage);
            cmd.Parameters.AddWithValue("@Time", obj.Time);
            cmd.Parameters.AddWithValue("@Status", obj.Status);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

    }
}
