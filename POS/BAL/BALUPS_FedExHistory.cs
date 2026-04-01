using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALUPS_FedExHistory
    {


        public DataTable Select()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUPS_FedEx_History";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByTrackingID(BOLUPS_FedExHistory obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUPS_FedEx_History";
            cmd.Parameters.AddWithValue("@Spara", "SelectByTrackingID");
            cmd.Parameters.AddWithValue("@TrackingID", obj.TrackingID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void DeleteByID(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUPS_FedEx_History";
            cmd.Parameters.AddWithValue("@Spara", "DeleteByID");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public DataTable SelectByRefNo(string OrderID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUPS_FedEx_History";
            cmd.Parameters.AddWithValue("@Spara", "SelectByRefNo");
            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void UPS_FedExHistoryInsert(BOLUPS_FedExHistory obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUPS_FedEx_History";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Type", obj.Type);
            cmd.Parameters.AddWithValue("@OrderID", obj.OrderID);
            cmd.Parameters.AddWithValue("@TrackingID", obj.TrackingID);
            cmd.Parameters.AddWithValue("@Time", obj.Time);
            cmd.Parameters.AddWithValue("@Status", obj.Status);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@COD", obj.COD);
            cmd.Parameters.AddWithValue("@Service", obj.Service);
            cmd.Parameters.AddWithValue("@Weight", obj.Weight);
            cmd.Parameters.AddWithValue("@Charges", obj.Charges);
            cmd.Parameters.AddWithValue("@TotalCost", obj.TotalCost);

            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public DataTable SelectByFilter(BOLUPS_FedExHistory obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPUPS_FedEx_History";
            cmd.Parameters.AddWithValue("@Spara", "SelectByFilter");
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
    }
}
