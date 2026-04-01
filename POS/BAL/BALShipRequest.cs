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
    public class BALShipRequest
    {
        public DataTable SELECTBYID(BOLShipRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPShipRequest";
            cmd.Parameters.AddWithValue("@MODE", "SELECTBYID");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SELECTBYAllowed(BOLShipRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPShipRequest";
            cmd.Parameters.AddWithValue("@MODE", "SELECTBYAllowed");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SELECTBYDate(BOLShipRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPShipRequest";
            cmd.Parameters.AddWithValue("@MODE", "SELECTBYDate");
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Insert(BOLShipRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPShipRequest";
            cmd.Parameters.AddWithValue("@MODE", "Insert");
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID); 
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            cmd.Parameters.AddWithValue("@Reason", obj.Reason);
            cmd.Parameters.AddWithValue("@Allow", obj.Allow);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void Update(BOLShipRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPShipRequest";
            cmd.Parameters.AddWithValue("@MODE", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@UserID", obj.UserID);
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            cmd.Parameters.AddWithValue("@InvoiceID", obj.InvoiceID);
            cmd.Parameters.AddWithValue("@Allow", obj.Allow);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void UpdateOnlyAllow(BOLShipRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPShipRequest";
            cmd.Parameters.AddWithValue("@MODE", "UpdateOnlyAllow");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Allow", obj.Allow);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void Delete(BOLShipRequest obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPShipRequest";
            cmd.Parameters.AddWithValue("@MODE", "Delete");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
    }
}
