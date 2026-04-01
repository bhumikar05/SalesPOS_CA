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
    class BALCreditMemo
    {
        public void UpdateTax(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_MaxRefNumber";
            cmd.Parameters.AddWithValue("@Spara", "UpdateTax");
            cmd.Parameters.AddWithValue("@TaxRef", obj.TaxRef);
            cmd.Parameters.AddWithValue("@Type", obj.Type);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void UpdateNonTaxRef(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_MaxRefNumber";
            cmd.Parameters.AddWithValue("@Spara", "UpdateNonTaxRef");
            cmd.Parameters.AddWithValue("@NonTaxRef", obj.NonTaxRef);
            cmd.Parameters.AddWithValue("@Type", obj.Type);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public DataTable Select()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "Select");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable PayPalSelect()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "PayPalSelect");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByInvID(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByInvID");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByUnpaidInvoice(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByUnpaidInvoice");
            cmd.Parameters.AddWithValue("@CustomerID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void UpdateCustomer(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "UpdateCustomer");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@OldCustomerID", obj.OldCustomerID);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }
        public DataTable SelectLastCusInv(int CusID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectLastCusInv");
            cmd.Parameters.AddWithValue("@CustomerID", CusID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectMAX(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectMax");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectBy()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectBy");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByCusID(int ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByCusID");
            cmd.Parameters.AddWithValue("@CustomerID", ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectUnship(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectUnship");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectPendingInvoiceByID(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectPendingInvoiceByID");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public DataTable SelectByPay(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByPay");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectByDays(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByDays");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectAllInvoiceList(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectAllInvoiceList");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectAllInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectAllInvoice");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectSearchInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectSearchInvoice");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@RefNumber", obj.RefNumber);
            cmd.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SearchUnshipInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SearchUnshipInvoice");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@RefNumber", obj.RefNumber);
            cmd.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectAllInvForPrintByCustomer(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectAllInvForPrintByCustomer");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectAllInvForPrintByRefNo(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectAllInvForPrintByRefNo");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@RefNumber", obj.RefNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectOpenInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectOpenInvoice");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public DataTable SelectOverDueInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectOverDueInvoice");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public DataTable SelectPendingAllInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectPendingAllInvoice");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectPendingOpenInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectPendingOpenInvoice");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectPendingOverDueInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectPendingOverDueInvoice");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByID(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByID");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByCusID(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByCusID");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByCustomerWiseInvoices(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByCustomerWiseInvoices");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByCustomerWiseOpenInvoices(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByCustomerWiseOpenInvoices");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectByCustomerWiseOverdueInvoices(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByCustomerWiseOverdueInvoices");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByCustomerWisePendingInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByCustomerWisePendingInvoice");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByCustomerWisePendingOpenInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByCustomerWisePendingOpenInvoice");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByCustomerWisePendingOverDueInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByCustomerWisePendingOverDueInvoice");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectByRefNumber(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByRefNumber");
            cmd.Parameters.AddWithValue("@RefNumber", obj.RefNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByCusAndRefNumber(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByCusAndRefNumber");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@RefNumber", obj.RefNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectTop1(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectTop1");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectOrder(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectOrder");
            cmd.Parameters.AddWithValue("@RefNumber", obj.RefNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }
        public int InvoiceInsert(BOLCreditMemo obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "Insert");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@ARAccountID", obj.ARAccountID);
            cmd.Parameters.AddWithValue("@TxnDate", obj.TxnDate);
            cmd.Parameters.AddWithValue("@RefNumber", obj.RefNumber);
            cmd.Parameters.AddWithValue("@PONumber", obj.PONumber);
            cmd.Parameters.AddWithValue("@TermsID", obj.TermsID);
            cmd.Parameters.AddWithValue("@DueDate", obj.DueDate);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@ShipDate", obj.ShipDate);
            cmd.Parameters.AddWithValue("@ShipMethodID", obj.ShipMethodID);
            cmd.Parameters.AddWithValue("@Total", obj.Total);
            cmd.Parameters.AddWithValue("@AppliedAmount", obj.AppliedAmount);
            cmd.Parameters.AddWithValue("@BalanceDue", obj.BalanceDue);
            cmd.Parameters.AddWithValue("@Memo", obj.Memo);
            cmd.Parameters.AddWithValue("@ShipAddressID", obj.ShipAddressID);
            cmd.Parameters.AddWithValue("@ServiceID", obj.ServiceID);
            cmd.Parameters.AddWithValue("@PaidInvoice", obj.PaidInvoice);
            cmd.Parameters.AddWithValue("@PandingInvoice", obj.PandingInvoice);
            cmd.Parameters.AddWithValue("@IsSync", obj.IsSync);
            cmd.Parameters.AddWithValue("@IsShipping", obj.IsShipping);
            cmd.Parameters.AddWithValue("@CreatedID", obj.CreatedID);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@ShipAdd1", obj.ShipAdd1);
            cmd.Parameters.AddWithValue("@ShipAdd2", obj.ShipAdd2);
            cmd.Parameters.AddWithValue("@ShipAdd3", obj.ShipAdd3);
            cmd.Parameters.AddWithValue("@ShipCity", obj.ShipCity);
            cmd.Parameters.AddWithValue("@ShipCountry", obj.ShipCountry);
            cmd.Parameters.AddWithValue("@ShipState", obj.ShipState);
            cmd.Parameters.AddWithValue("@ShipPostalCode", obj.ShipPostalCode);
            cmd.Parameters.AddWithValue("@IsPrint", obj.IsPrint);
            cmd.Parameters.AddWithValue("@PriceTier", obj.PriceTier);

            cmd.Parameters.AddWithValue("@TaxAmount", obj.TaxAmount);
            cmd.Parameters.AddWithValue("@TaxID", obj.TaxID);
            cmd.Parameters.AddWithValue("@TaxPercent", obj.TaxPercent);
            //princy
            cmd.Parameters.AddWithValue("@CustomerMessage", obj.CustomerMessage);
            DAL DAL = new DAL();
            //DAL.Insert(cmd);
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }

        public int InvoiceUpdate(BOLCreditMemo obj)
        {
            int ID = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "Update");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@ARAccountID", obj.ARAccountID);
            cmd.Parameters.AddWithValue("@TxnDate", obj.TxnDate);
            cmd.Parameters.AddWithValue("@RefNumber", obj.RefNumber);
            cmd.Parameters.AddWithValue("@PONumber", obj.PONumber);
            cmd.Parameters.AddWithValue("@TermsID", obj.TermsID);
            cmd.Parameters.AddWithValue("@DueDate", obj.DueDate);
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@ShipDate", obj.ShipDate);
            cmd.Parameters.AddWithValue("@ShipMethodID", obj.ShipMethodID);
            cmd.Parameters.AddWithValue("@Total", obj.Total);
            cmd.Parameters.AddWithValue("@AppliedAmount", obj.AppliedAmount);
            cmd.Parameters.AddWithValue("@BalanceDue", obj.BalanceDue);
            cmd.Parameters.AddWithValue("@Memo", obj.Memo);
            cmd.Parameters.AddWithValue("@ShipAddressID", obj.ShipAddressID);
            cmd.Parameters.AddWithValue("@ServiceID", obj.ServiceID);
            cmd.Parameters.AddWithValue("@PaidInvoice", obj.PaidInvoice);
            cmd.Parameters.AddWithValue("@PandingInvoice", obj.PandingInvoice);
            cmd.Parameters.AddWithValue("@IsSync", obj.IsSync);
            cmd.Parameters.AddWithValue("@IsShipping", obj.IsShipping);
            cmd.Parameters.AddWithValue("@ModifiedID", obj.ModifiedID);
            cmd.Parameters.AddWithValue("@ModifiedTime", obj.ModifiedTime);
            cmd.Parameters.AddWithValue("@ShipAdd1", obj.ShipAdd1);
            cmd.Parameters.AddWithValue("@ShipAdd2", obj.ShipAdd2);
            cmd.Parameters.AddWithValue("@ShipAdd3", obj.ShipAdd3);
            cmd.Parameters.AddWithValue("@ShipCity", obj.ShipCity);
            cmd.Parameters.AddWithValue("@ShipCountry", obj.ShipCountry);
            cmd.Parameters.AddWithValue("@ShipState", obj.ShipState);
            cmd.Parameters.AddWithValue("@ShipPostalCode", obj.ShipPostalCode);
            cmd.Parameters.AddWithValue("@IsPrint", obj.IsPrint);
            cmd.Parameters.AddWithValue("@PriceTier", obj.PriceTier);

            cmd.Parameters.AddWithValue("@TaxAmount", obj.TaxAmount);
            cmd.Parameters.AddWithValue("@TaxID", obj.TaxID);
            cmd.Parameters.AddWithValue("@TaxPercent", obj.TaxPercent);
            //princy
            cmd.Parameters.AddWithValue("@CustomerMessage", obj.CustomerMessage);

            DAL DAL = new DAL();
            //DAL.Insert(cmd);
            ID = DAL.Insert_Update_Del(cmd);
            return ID;
        }

        public void Delete(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "Delete");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DAL.Delete(cmd);
        }

        public DataTable SelectUnShippedInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectUnShippedInvoice");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectShippedInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectShippedInvoice");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectUnPaidInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectUnPaidInvoice");
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable UnPaidInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "UnPaidInvoice");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectPaidInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectPaidInvoice");
            cmd.Parameters.AddWithValue("@StartDate", obj.FromDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.ToDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectPaidAndPartialPaidInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectPaidAndPartialPaidInvoice");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);

            return dt;
        }

        public DataTable SelectLastThreeShippingMethod(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectLastThreeShippingMethod");
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectLastWeekSalesData(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectLastWeekSalesData");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);

            return dt;

        }

        public DataTable SelectTodayInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectTodayInvoice");
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectByInvoicePrintHistory(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByInvoicePrintHistory");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectInvoiceByID(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectInvoiceByID");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public void UpdatePaidInvoice(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "UpdatePaidInvoice");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@PaidInvoice", obj.PaidInvoice);
            cmd.Parameters.AddWithValue("@AppliedAmount", obj.AppliedAmount);
            cmd.Parameters.AddWithValue("@BalanceDue", obj.BalanceDue);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void UpdateTrackingNumber(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "UpdateTrackingNumber");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@TrackingNumber", obj.TrackingNumber);
            cmd.Parameters.AddWithValue("@IsShipping", obj.IsShipping);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void UpdateIsSync(string ID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "UpdateIsSync");
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }
        public void UpdateIsShipping(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "UpdateIsShipping");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@ServiceID", obj.ServiceID);
            cmd.Parameters.AddWithValue("@ShipMethodID", obj.ShipMethodID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public DataTable SelectForPrint(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectForPrint");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectOpenInvoiceForToday(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectOpenInvoiceForToday");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectOverDueInvoiceForToday(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectOverDueInvoiceForToday");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;

        }

        public DataTable SelectPendingOpenInvoiceForToday(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectPendingOpenInvoiceForToday");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectPendingOverDueInvoiceForToday(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectPendingOverDueInvoiceForToday");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectAllInvoiceForToday(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectAllInvoiceForToday");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }

        public DataTable SelectPendingAllInvoiceForToday(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectPendingAllInvoiceForToday");
            cmd.Parameters.AddWithValue("@SalesRepID", obj.SalesRepID);
            cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
            cmd.Parameters.AddWithValue("@CreatedTime", obj.CreatedTime);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectByCusIDAmount(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectByCusIDAmount");
            cmd.Parameters.AddWithValue("@CustomerID", obj.ID);
            cmd.Parameters.AddWithValue("@TxnDate", obj.TxnDate);
            cmd.Parameters.AddWithValue("@BalanceDue", obj.BalanceDue);
            cmd.Parameters.AddWithValue("@COUNT", obj.COUNT);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public DataTable SelectRefNumber(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "SelectRefNumber");
            cmd.Parameters.AddWithValue("@RefNumber", obj.RefNumber);
            DAL DAL = new DAL();
            DataTable dt = DAL.Select(cmd);
            return dt;
        }
        public void UpdateShipStatus(int ID, string shipStatus)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPCreditMemo";
            cmd.Parameters.AddWithValue("@Spara", "UpdateShipStatus");
            cmd.Parameters.AddWithValue("@ShipStatus", shipStatus);
            cmd.Parameters.AddWithValue("@ID", ID);
            DAL DAL = new DAL();
            DAL.Insert(cmd);
        }

        public void ConvertTax(BOLCreditMemo obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SPInvoiceMaster";
            cmd.Parameters.AddWithValue("@Spara", "CAConvertTax");
            cmd.Parameters.AddWithValue("@ID", obj.ID);
            cmd.Parameters.AddWithValue("@Total", obj.Total);
            cmd.Parameters.AddWithValue("@TaxPercent", obj.TaxPercent);
            cmd.Parameters.AddWithValue("@TaxAmount", obj.TaxAmount);
            cmd.Parameters.AddWithValue("@BalanceDue", obj.BalanceDue);
            cmd.Parameters.AddWithValue("@TaxID", obj.TaxID);
            DAL DAL = new DAL();
            DAL.Update(cmd);
        }

    }
}
