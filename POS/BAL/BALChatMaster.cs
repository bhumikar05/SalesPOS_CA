using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALChatMaster
    {
        public DataTable SelectByID(BOLChatMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPChatMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@SenderID", obj.SenderID);
            cmd.Parameters.AddWithValue("@ReceiverID", obj.ReceiverID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectTotalMessageByID(BOLChatMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPChatMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectTotalMessageByID");
            cmd.Parameters.AddWithValue("@ReceiverID", obj.ReceiverID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectUnReadMessageByID(BOLChatMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPChatMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectUnReadMessageByID");
            cmd.Parameters.AddWithValue("@SenderID", obj.SenderID);
            cmd.Parameters.AddWithValue("@ReceiverID", obj.ReceiverID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectUnReadGroupMessageByID(BOLChatMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPChatMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectUnReadGroupMessageByID");
            cmd.Parameters.AddWithValue("@SenderID", obj.SenderID);
            cmd.Parameters.AddWithValue("@ReceiverID", obj.ReceiverID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectTotalMessageByName(BOLChatMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPChatMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectTotalMessageByName");
            cmd.Parameters.AddWithValue("@ReceiverID", obj.ReceiverID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectGroupMessage(BOLChatMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPChatMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectGroupMessage");
            cmd.Parameters.AddWithValue("@ReceiverID", obj.ReceiverID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void Insert(BOLChatMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPChatMaster";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@SenderID", obj.SenderID);
            cmd.Parameters.AddWithValue("@ReceiverID", obj.ReceiverID);
            cmd.Parameters.AddWithValue("@Message", obj.Message);
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            cmd.Parameters.AddWithValue("@Time", obj.Time);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            cmd.Parameters.AddWithValue("@IsRead", obj.IsRead);
            cmd.Parameters.AddWithValue("@GroupMessage", obj.GroupMessage);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void UpdateIsRead(BOLChatMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPChatMaster";
            cmd.Parameters.AddWithValue("@Spara", "UpdateIsRead");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@IsRead", obj.IsRead);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
    }
}
