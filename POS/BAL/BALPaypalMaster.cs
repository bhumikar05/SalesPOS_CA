
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
    class BALPaypalMaster: DAL
    {
        public DataTable SelectByID(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_PayPalMaster";
            cmd.Parameters.AddWithValue("@MODE", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable Select(BOLPayPalMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_PayPalMaster";
            cmd.Parameters.AddWithValue("@MODE", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectPayment(BOLPayPalMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_PayPalMaster";
            cmd.Parameters.AddWithValue("@MODE", "SelectPayment");
            cmd.Parameters.AddWithValue("@transaction_updated_date", obj.transaction_updated_date);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable PayPalHistory(BOLPayPalMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_PayPalMaster";
            cmd.Parameters.AddWithValue("@MODE", "PayPalHistory");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Updatetransactionamount(BOLPayPalMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_PayPalMaster";
            cmd.Parameters.AddWithValue("@MODE", "Updatetransactionamount");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@transaction_amount", obj.transaction_amount);
            DAL DAL = new DAL();
            DAL.Update(cmd);
          
        }
        public void Insert(BOLPayPalMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_PayPalMaster";
            cmd.Parameters.AddWithValue("@MODE", "Insert");
            cmd.Parameters.AddWithValue("@transaction_id", obj.transaction_id);
            cmd.Parameters.AddWithValue("@transaction_updated_date", obj.transaction_updated_date);
            cmd.Parameters.AddWithValue("@transaction_amount", obj.transaction_amount);
            cmd.Parameters.AddWithValue("@currency_code", obj.currency_code);
            cmd.Parameters.AddWithValue("@email_address", obj.email_address);
            cmd.Parameters.AddWithValue("@payer_name", obj.payer_name);
            cmd.Parameters.AddWithValue("@country_code", obj.country_code);
            cmd.Parameters.AddWithValue("@Transaction_Balance", obj.Transaction_Balance);
            //cmd.Parameters.AddWithValue("@IsUpdate", obj.IsUpdate);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public DataTable TransIDDublicateCheck(BOLPayPalMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_PayPalMaster";
            cmd.Parameters.AddWithValue("@MODE", "TransIDDublicateCheck");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Update(BOLPayPalMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_PayPalMaster";
            cmd.Parameters.AddWithValue("@MODE", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@transaction_id", obj.transaction_id);
            cmd.Parameters.AddWithValue("@transaction_updated_date", obj.transaction_updated_date);
            cmd.Parameters.AddWithValue("@transaction_amount", obj.transaction_amount);
            cmd.Parameters.AddWithValue("@currency_code", obj.currency_code);
            cmd.Parameters.AddWithValue("@email_address", obj.email_address);
            cmd.Parameters.AddWithValue("@payer_name", obj.payer_name);
            cmd.Parameters.AddWithValue("@country_code", obj.country_code);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public void UpdateAmount(BOLPayPalMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_PayPalMaster";
            cmd.Parameters.AddWithValue("@MODE", "UpdateAmount");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@transaction_amount", obj.transaction_amount);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
    }
}
