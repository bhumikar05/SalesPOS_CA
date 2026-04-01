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
    class BALZelleMaster:DAL
    {
        public DataTable Select()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_ZelleMaster";
            cmd.Parameters.AddWithValue("@MODE", "SELECT");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Insert(BOLZelleMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_ZelleMaster";
            cmd.Parameters.AddWithValue("@MODE", "INSERT");
            cmd.Parameters.AddWithValue("@ZelleName", obj.ZelleName);
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            cmd.Parameters.AddWithValue("@TotalAmount", obj.TotalAmount);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void UpdateAmount(BOLZelleMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_ZelleMaster";
            cmd.Parameters.AddWithValue("@MODE", "UpdateAmount");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Amount", obj.Amount);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
    }
}
