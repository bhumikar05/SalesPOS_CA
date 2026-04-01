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
    class BALAuthorizePayment:DAL
    {
        public void Insert(BOLAuthorizePayment obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_AuthorizeRetrivePayment";
            cmd.Parameters.AddWithValue("@MODE", "Insert");
            cmd.Parameters.AddWithValue("@transId", obj.transId);
            cmd.Parameters.AddWithValue("@invoiceNumber", obj.invoiceNumber);
            cmd.Parameters.AddWithValue("@firstName", obj.firstName);
            cmd.Parameters.AddWithValue("@lastName", obj.lastName);
            cmd.Parameters.AddWithValue("@accountType", obj.accountType);
            cmd.Parameters.AddWithValue("@settleAmount", obj.settleAmount);
            cmd.Parameters.AddWithValue("@submitTimeUTC", obj.submitTimeUTC);
            cmd.Parameters.AddWithValue("@transactionStatus", obj.transactionStatus);
            cmd.Parameters.AddWithValue("@IsUpdate", obj.IsUpdate);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public DataTable SelectTransIDDublicateCheck(BOLAuthorizePayment OBJ)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_AuthorizeRetrivePayment";
            cmd.Parameters.AddWithValue("@MODE", "TransIDDublicateCheck");
            cmd.Parameters.AddWithValue("@transId", OBJ.transId);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void Update(BOLAuthorizePayment obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_AuthorizeRetrivePayment";
            cmd.Parameters.AddWithValue("@MODE", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@transId", obj.transId);
            cmd.Parameters.AddWithValue("@invoiceNumber", obj.invoiceNumber);
            cmd.Parameters.AddWithValue("@firstName", obj.firstName);
            cmd.Parameters.AddWithValue("@lastName", obj.lastName);
            cmd.Parameters.AddWithValue("@accountType", obj.accountType);
            cmd.Parameters.AddWithValue("@settleAmount", obj.settleAmount);
            cmd.Parameters.AddWithValue("@submitTimeUTC", obj.submitTimeUTC);
            cmd.Parameters.AddWithValue("@transactionStatus", obj.transactionStatus);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        } 
        public DataTable Select()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_AuthorizeRetrivePayment";
            cmd.Parameters.AddWithValue("@MODE", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void IsUpdate(BOLAuthorizePayment obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_AuthorizeRetrivePayment";
            cmd.Parameters.AddWithValue("@MODE", "IsUpdate");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@IsUpdate", obj.IsUpdate);
            cmd.Parameters.AddWithValue("@settleAmount", obj.settleAmount);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }


    }
}
