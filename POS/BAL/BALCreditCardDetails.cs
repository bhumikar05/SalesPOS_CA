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
    class BALCreditCardDetails : DAL
    {
        public DataTable Select(BOLCreditCardDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditCardDetails";
            cmd.Parameters.AddWithValue("@MODE", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditCardDetails";
            cmd.Parameters.AddWithValue("@MODE", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", id);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByCustomerID(int CustomerID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditCardDetails";
            cmd.Parameters.AddWithValue("@MODE", "SelectByCustomerID");
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByCustomerSrNo(BOLCreditCardDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditCardDetails";
            cmd.Parameters.AddWithValue("@MODE", "SelectByCustomerSrNo");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@SrNo", obj.SrNo);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }


        public void Insert(BOLCreditCardDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditCardDetails";
            cmd.Parameters.AddWithValue("@MODE", "InsertUpdate");
            cmd.Parameters.AddWithValue("@SrNo", obj.SrNo);
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@CardType", obj.CardType);
            cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue("@LastName", obj.LastName);
            cmd.Parameters.AddWithValue("@CardNumber", obj.CardNumber);
            cmd.Parameters.AddWithValue("@Year", obj.Year);
            cmd.Parameters.AddWithValue("@Month", obj.Month);
            cmd.Parameters.AddWithValue("@CVV", obj.CVV);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@ZipCode", obj.ZipCode);
            cmd.Parameters.AddWithValue("@Country", obj.Country);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void DeleteByID(BOLCreditCardDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditCardDetails";
            cmd.Parameters.AddWithValue("@MODE", "DeleteByID");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@SrNo", obj.SrNo);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

        public void CreditPayment(BOLCreditCardDetails obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditCardPayment";
            cmd.Parameters.AddWithValue("@MODE", "Insert");
            cmd.Parameters.AddWithValue("@CreditID", obj.CreditID);
            cmd.Parameters.AddWithValue("@RefNumber", obj.RefNumber);
            cmd.Parameters.AddWithValue("@PayAmount", obj.PayAmount);
            cmd.Parameters.AddWithValue("@Date", obj.Date);
            cmd.Parameters.AddWithValue("@TransctionID", obj.TransctionID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
    }
}
