using POS.BOL;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using POS.HelperClass;
using System;

namespace POS.BAL
{
    class BALAddressMaster
    {
        public DataTable Select(BOLAddressMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAddressMaster";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectAddressName(BOLAddressMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAddressMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectAddressName");
            cmd.Parameters.AddWithValue("@ReferenceID", obj.ReferenceID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectBillAddressName(BOLAddressMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAddressMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectBillAddress");
            cmd.Parameters.AddWithValue("@ReferenceID", obj.ReferenceID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectBySalesRepID(BOLAddressMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAddressMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectBySalesRepID");
            cmd.Parameters.AddWithValue("@ReferenceID", obj.ReferenceID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectByCusID(Int32 CusID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAddressMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByCusID");
            cmd.Parameters.AddWithValue("@ReferenceID", CusID);            
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public void SalesRepAddressInsert(BOLAddressMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAddressMaster";
            cmd.Parameters.AddWithValue("@Spara", "SalesRepAddressInsert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@ReferenceID", obj.ReferenceID);
            cmd.Parameters.AddWithValue("@ReferenceType", obj.ReferenceType);
            cmd.Parameters.AddWithValue("@AddressType", obj.AddressType);
            cmd.Parameters.AddWithValue("@Address1", obj.Address1);
            cmd.Parameters.AddWithValue("@Address2", obj.Address2);
            cmd.Parameters.AddWithValue("@Address3", obj.Address3);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@PostalCode", obj.PostalCode);
            cmd.Parameters.AddWithValue("@Country", obj.Country);
            cmd.Parameters.AddWithValue("@Note", obj.Note);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void CustomerBillAddressInsert(BOLAddressMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAddressMaster";
            cmd.Parameters.AddWithValue("@Spara", "CustomerBillAddressInsert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@ReferenceID", obj.ReferenceID);
            cmd.Parameters.AddWithValue("@ReferenceType", obj.ReferenceType);
            cmd.Parameters.AddWithValue("@AddressType", obj.AddressType);
            cmd.Parameters.AddWithValue("@Address1", obj.Address1);
            cmd.Parameters.AddWithValue("@Address2", obj.Address2);
            cmd.Parameters.AddWithValue("@Address3", obj.Address3);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@PostalCode", obj.PostalCode);
            cmd.Parameters.AddWithValue("@Country", obj.Country);
            cmd.Parameters.AddWithValue("@Note", obj.Note);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void CustomerShipAddressInsert(BOLAddressMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAddressMaster";
            cmd.Parameters.AddWithValue("@Spara", "CustomerShipAddressInsert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@ReferenceID", obj.ReferenceID);
            cmd.Parameters.AddWithValue("@ReferenceType", obj.ReferenceType);
            cmd.Parameters.AddWithValue("@AddressType", obj.AddressType);
            cmd.Parameters.AddWithValue("@AddressName", obj.AddressName);
            cmd.Parameters.AddWithValue("@Address1", obj.Address1);
            cmd.Parameters.AddWithValue("@Address2", obj.Address2);
            cmd.Parameters.AddWithValue("@Address3", obj.Address3);
            cmd.Parameters.AddWithValue("@City", obj.City);
            cmd.Parameters.AddWithValue("@State", obj.State);
            cmd.Parameters.AddWithValue("@PostalCode", obj.PostalCode);
            cmd.Parameters.AddWithValue("@Country", obj.Country);
            cmd.Parameters.AddWithValue("@Note", obj.Note);
            cmd.Parameters.AddWithValue("@DefaultShipping", obj.DefaultShipping);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void SalesRepDelete(BOLAddressMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAddressMaster";
            cmd.Parameters.AddWithValue("@Spara", "SalesRepDelete");
            cmd.Parameters.AddWithValue("@ReferenceID", obj.ReferenceID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

        public void DeleteAddress(Int32 ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAddressMaster";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }
        public void CustomerBillAddressDelete(BOLAddressMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAddressMaster";
            cmd.Parameters.AddWithValue("@Spara", "CusBillAddressDelete");
            cmd.Parameters.AddWithValue("@ReferenceID", obj.ReferenceID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

        public void CustomerShipAddressDelete(BOLAddressMaster obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAddressMaster";
            cmd.Parameters.AddWithValue("@Spara", "CusShipAddressDelete");
            cmd.Parameters.AddWithValue("@ReferenceID", obj.ReferenceID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

        public DataTable SelectByID(string ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPAddressMaster";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
    }
}
