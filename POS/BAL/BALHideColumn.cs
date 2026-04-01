using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Office.Interop.Outlook;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using MessageBox = System.Windows.MessageBox;
using Exception = System.Exception;

namespace POS.BAL
{
    public class BALHideColumn
    {
        public DataTable Select(BOLHideColumn obj)
        {
            
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_HideColumn";
                cmd.Parameters.AddWithValue("@Mode", "Select");
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);
                DAL DAL = new DAL();
                DataTable dt = DAL.Select(cmd);
                return dt;
           
        }
        public void Insert(BOLHideColumn obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_HideColumn";
                cmd.Parameters.AddWithValue("@Mode", "Insert");
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);
                cmd.Parameters.AddWithValue("@NoOfInvoice", obj.NoOfInvoice);
                cmd.Parameters.AddWithValue("@CUSTOMER", obj.CUSTOMER);
                cmd.Parameters.AddWithValue("@NUM", obj.NUM);
                cmd.Parameters.AddWithValue("@DATE", obj.DATE);

                //PRINCY
                cmd.Parameters.AddWithValue("@UPDATEDATE", obj.UPDATEDATE);


                cmd.Parameters.AddWithValue("@DUEDATE", obj.DUEDATE);
                cmd.Parameters.AddWithValue("@TERMS", obj.TERMS);
                cmd.Parameters.AddWithValue("@AMOUNT", obj.AMOUNT);
                cmd.Parameters.AddWithValue("@OPENBALANCE", obj.OPENBALANCE);
                cmd.Parameters.AddWithValue("@SalesRep", obj.SalesRep);
                cmd.Parameters.AddWithValue("@NoOfTimesEdit", obj.NoOfTimesEdit);
                cmd.Parameters.AddWithValue("@VIA_Services", obj.VIA_Services);
                cmd.Parameters.AddWithValue("@ErrorLog", obj.ErrorLog);
                cmd.Parameters.AddWithValue("@PaidStatus", obj.PaidStatus);
                cmd.Parameters.AddWithValue("@PendingInvoice", obj.PendingInvoice);
                cmd.Parameters.AddWithValue("@Print1", obj.Print1);
                cmd.Parameters.AddWithValue("@Payit", obj.Payit);
                cmd.Parameters.AddWithValue("@Shipit", obj.Shipit);
                cmd.Parameters.AddWithValue("@ShipStatus", obj.ShipStatus);
                cmd.Parameters.AddWithValue("@TYPE", obj.TYPE);
                cmd.Parameters.AddWithValue("@NUM1", obj.NUM1);
                cmd.Parameters.AddWithValue("@DATE1", obj.DATE1);

                //PRINCY
                cmd.Parameters.AddWithValue("@UPDATEDATE1", obj.UPDATEDATE1);

                cmd.Parameters.AddWithValue("@ACCOUNT", obj.ACCOUNT);
                cmd.Parameters.AddWithValue("@TERMS1", obj.TERMS1);
                cmd.Parameters.AddWithValue("@AMOUNT1", obj.AMOUNT1);
                cmd.Parameters.AddWithValue("@SalesRep1", obj.SalesRep1);
                cmd.Parameters.AddWithValue("@NoOfTimesEdit1", obj.NoOfTimesEdit1);
                cmd.Parameters.AddWithValue("@VIA_Service1", obj.VIA_Service1);
                cmd.Parameters.AddWithValue("@ErrorLog1", obj.ErrorLog1);
                cmd.Parameters.AddWithValue("@PaidStatus1", obj.PaidStatus1);
                cmd.Parameters.AddWithValue("@Print2", obj.Print2);
                cmd.Parameters.AddWithValue("@Payit2", obj.Payit2);
                cmd.Parameters.AddWithValue("@Shipit2", obj.Shipit2);
                cmd.Parameters.AddWithValue("@ShipStatus2", obj.ShipStatus2);
                cmd.Parameters.AddWithValue("@AddButton", obj.AddButton);
                cmd.Parameters.AddWithValue("@AddButton1", obj.AddButton1);
                cmd.Parameters.AddWithValue("@ShippingCost", obj.ShippingCost);
                cmd.Parameters.AddWithValue("@ShippingCost1", obj.ShippingCost1);
                cmd.Parameters.AddWithValue("@Profit", obj.Profit);
                cmd.Parameters.AddWithValue("@ProfitPercentage", obj.ProfitPercentage);
                cmd.Parameters.AddWithValue("@Profit1", obj.Profit1);
                cmd.Parameters.AddWithValue("@ProfitPercentage1", obj.ProfitPercentage1);
                // Nidhi Add
                cmd.Parameters.AddWithValue("@TIME", obj.TIME);
                cmd.Parameters.AddWithValue("@TIME1", obj.TIME1);
                //

                //Add Princy
                cmd.Parameters.AddWithValue("@UPDATETIME", obj.UPDATETIME);
                cmd.Parameters.AddWithValue("@UPDATETIME1", obj.UPDATETIME1);
                //

                cmd.Parameters.AddWithValue("@MultiplePrint", obj.MultiplePrint);
                cmd.Parameters.AddWithValue("@ShipCharges", obj.ShipCharges);
                cmd.Parameters.AddWithValue("@ShipCharges1", obj.ShipCharges1);

                DAL DAL = new DAL();
                DAL.Insert(cmd);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Class:BALHideColumn,Function :Insert. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        public void Update(BOLHideColumn obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_HideColumn";
                cmd.Parameters.AddWithValue("@Mode", "Update");
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);
                cmd.Parameters.AddWithValue("@NoOfInvoice", obj.NoOfInvoice);
                cmd.Parameters.AddWithValue("@CUSTOMER", obj.CUSTOMER);
                cmd.Parameters.AddWithValue("@NUM", obj.NUM);
                cmd.Parameters.AddWithValue("@DATE", obj.DATE);
                //PRINCY
                cmd.Parameters.AddWithValue("@UPDATEDATE", obj.UPDATEDATE);

                cmd.Parameters.AddWithValue("@DUEDATE", obj.DUEDATE);
                cmd.Parameters.AddWithValue("@TERMS", obj.TERMS);
                cmd.Parameters.AddWithValue("@AMOUNT", obj.AMOUNT);
                cmd.Parameters.AddWithValue("@OPENBALANCE", obj.OPENBALANCE);
                cmd.Parameters.AddWithValue("@SalesRep", obj.SalesRep);
                cmd.Parameters.AddWithValue("@NoOfTimesEdit", obj.NoOfTimesEdit);
                cmd.Parameters.AddWithValue("@VIA_Services", obj.VIA_Services);
                cmd.Parameters.AddWithValue("@ErrorLog", obj.ErrorLog);
                cmd.Parameters.AddWithValue("@PaidStatus", obj.PaidStatus);
                cmd.Parameters.AddWithValue("@PendingInvoice", obj.PendingInvoice);
                cmd.Parameters.AddWithValue("@Print1", obj.Print1);
                cmd.Parameters.AddWithValue("@Payit", obj.Payit);
                cmd.Parameters.AddWithValue("@Shipit", obj.Shipit);
                cmd.Parameters.AddWithValue("@ShipStatus", obj.ShipStatus);
                cmd.Parameters.AddWithValue("@TYPE", obj.TYPE);
                cmd.Parameters.AddWithValue("@NUM1", obj.NUM1);
                cmd.Parameters.AddWithValue("@DATE1", obj.DATE1);

                //PRINCY
                cmd.Parameters.AddWithValue("@UPDATEDATE1", obj.UPDATEDATE1);

                cmd.Parameters.AddWithValue("@ACCOUNT", obj.ACCOUNT);
                cmd.Parameters.AddWithValue("@TERMS1", obj.TERMS1);
                cmd.Parameters.AddWithValue("@AMOUNT1", obj.AMOUNT1);
                cmd.Parameters.AddWithValue("@SalesRep1", obj.SalesRep1);
                cmd.Parameters.AddWithValue("@NoOfTimesEdit1", obj.NoOfTimesEdit1);
                cmd.Parameters.AddWithValue("@VIA_Service1", obj.VIA_Service1);
                cmd.Parameters.AddWithValue("@ErrorLog1", obj.ErrorLog1);
                cmd.Parameters.AddWithValue("@PaidStatus1", obj.PaidStatus1);
                cmd.Parameters.AddWithValue("@Print2", obj.Print2);
                cmd.Parameters.AddWithValue("@Payit2", obj.Payit2);
                cmd.Parameters.AddWithValue("@Shipit2", obj.Shipit2);
                cmd.Parameters.AddWithValue("@ShipStatus2", obj.ShipStatus2);
                cmd.Parameters.AddWithValue("@AddButton", obj.AddButton);
                cmd.Parameters.AddWithValue("@AddButton1", obj.AddButton1);
                cmd.Parameters.AddWithValue("@ShippingCost", obj.ShippingCost);
                cmd.Parameters.AddWithValue("@ShippingCost1", obj.ShippingCost1);
                cmd.Parameters.AddWithValue("@Profit", obj.Profit);
                cmd.Parameters.AddWithValue("@ProfitPercentage", obj.ProfitPercentage);
                cmd.Parameters.AddWithValue("@Profit1", obj.Profit1);
                cmd.Parameters.AddWithValue("@ProfitPercentage1", obj.ProfitPercentage1);
                // Add Nidhi
                cmd.Parameters.AddWithValue("@TIME", obj.TIME);
                cmd.Parameters.AddWithValue("@TIME1", obj.TIME1);
                //

                //Add Princy
                cmd.Parameters.AddWithValue("@UPDATETIME", obj.UPDATETIME);
                cmd.Parameters.AddWithValue("@UPDATETIME1", obj.UPDATETIME1);
                //

                cmd.Parameters.AddWithValue("@MultiplePrint", obj.MultiplePrint);
                cmd.Parameters.AddWithValue("@ShipCharges", obj.ShipCharges);
                cmd.Parameters.AddWithValue("@ShipCharges1", obj.ShipCharges1);


                DAL DAL = new DAL();
                DAL.Update(cmd);
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Class:BALHideColumn,Function :Update. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }

}
