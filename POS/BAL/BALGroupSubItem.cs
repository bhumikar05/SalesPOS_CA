using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;

namespace POS.BAL
{
    class BALGroupSubItem
    {
        public DataTable SelectByGroupID(BOLGroupSubItem obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPGroupSubItem";
            cmd.Parameters.AddWithValue("@Spara", "SelectByGroupID");
            cmd.Parameters.AddWithValue("@GroupItemID", obj.GroupItemID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void GroupSubItemInsert(BOLGroupSubItem obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPGroupSubItem";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@GroupItemID", obj.GroupItemID);
            cmd.Parameters.AddWithValue("@ItemID", obj.ItemID);
            cmd.Parameters.AddWithValue("@Description", obj.Description);
            cmd.Parameters.AddWithValue("@Qty", obj.Qty);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void DeleteByGroupID(BOLGroupSubItem obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPGroupSubItem";
            cmd.Parameters.AddWithValue("@Spara", "DeleteByGroupID");
            cmd.Parameters.AddWithValue("@GroupItemID", obj.GroupItemID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
