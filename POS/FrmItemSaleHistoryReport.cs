using ClosedXML.Excel;
using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using POS.Report;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmItemSaleHistoryReport : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DataTable dtDetail = new DataTable();

        public FrmItemSaleHistoryReport()
        {
            InitializeComponent();
        }

        private void FrmItemSaleHistoryReport_Load(object sender, EventArgs e)
        {
            try
            {
                dtpFromDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.CustomFormat = "MM/dd/yyyy";
                dtpToDate.Format = DateTimePickerFormat.Custom;
                dtpToDate.CustomFormat = "MM/dd/yyyy";

                GetItem();
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemSaleHistoeyReport,Function :FrmItemSaleHistoryReport_Load. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
          
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }

        private void GetItem()
        {
            try
            {
                DataTable dtItem = new BALItemMaster().SelectAllItem(new BOLItemMaster() { });
                DataRow dr = dtItem.NewRow();
                dr["ID"] = "0";
                dr["FullName"] = "--Select--";
                dr["QtyOnHand"] = 0;
                dr["ItemType"] = "";
                dtItem.Rows.InsertAt(dr, 0);
                cmbItemName.DataSource = dtItem;
                cmbItemName.DisplayMember = "FullName";
                cmbItemName.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemSaleHistoeyReport,Function :GetItem. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private Boolean CheckValidation()
        {
            Boolean ISValid = false;
            try
            {
                if (Convert.ToDateTime(dtpToDate.Value).Date < Convert.ToDateTime(dtpFromDate.Value).Date)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select Correct Date");
                    dtpToDate.Focus();
                    goto Final;
                }
                if (cmbItemName.SelectedIndex == 0)
                {
                    ISValid = false;
                    MessageBox.Show("Please Select ItemName");
                    cmbItemName.Focus();
                    goto Final;
                }
                else
                    ISValid = true;

                Final:
                return ISValid;
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemSaleHistoryReport,Function :CheckValidation. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
                return ISValid;
            }
        }

        
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.FunctionVisibility("Print", "ItemSaleHistory"))
                {
                    
                        if (Convert.ToDateTime(dtpToDate.Value).Date >= Convert.ToDateTime(dtpFromDate.Value).Date)
                        {
                           if (cmbItemName.SelectedIndex > 0)
                           {
                              dtDetail = new DataTable();
                              dtDetail = new BALItemSaleHistory().SelectByDateWise(new BOLItemSaleHistory() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value, ItemID = Convert.ToInt32(cmbItemName.SelectedValue) });
                              if (dtDetail.Rows.Count > 0)
                              {
                                   rptItemSaleHistoryReport cryRptItemSaleHistoryReport = new rptItemSaleHistoryReport();
                                   cryRptItemSaleHistoryReport.Database.Tables[0].SetDataSource(dtDetail);
 
                                   FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                                   crViewer.Text = "Item Sale History Report";
                                   crViewer.crystalReportViewer.ReportSource = cryRptItemSaleHistoryReport;
                                   crViewer.Show();

                              }
                              else
                              {
                                   MessageBox.Show("No records found");
                              }
                           }
                           else
                           {
                                 dtDetail = new DataTable();
                                 dtDetail = new BALItemSaleHistory().SelectByItemWise(new BOLItemSaleHistory() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value});
                                 if (dtDetail.Rows.Count > 0)
                                 {
                                     dgvAllInvoiceList.Rows.Clear();                           
                                     int iRow = 0;
                                     foreach (DataRow item in dtDetail.Rows)
                                     {
                                        if(item["Quantity"].ToString() != "" && item["TotalAMount"].ToString() != "")
                                        {
                                           dgvAllInvoiceList.Rows.Add();
                                           dgvAllInvoiceList[0, iRow].Value = item["ID"].ToString();
                                           dgvAllInvoiceList[1, iRow].Value = item["ItemFullName"].ToString();
                                           dgvAllInvoiceList[2, iRow].Value = item["Quantity"].ToString();
                                           dgvAllInvoiceList[3, iRow].Value = item["TotalAMount"].ToString();
                                           iRow++;
                                        }
                                       
                                     }
                                     if(dgvAllInvoiceList.Rows.Count == 0) 
                                     {
                                          MessageBox.Show("No records found");
                                     }

                                 }
                                 else
                                 {
                                     MessageBox.Show("No records found");
                                 }
                           }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Correct Date");
                            dtpToDate.Focus();
                        }
                                 
                }
                else
                    MessageBox.Show("You can not access");
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemSaleHistoryReport,Function :btnPrint_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnExpot_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbItemName.SelectedIndex > 0)
                {

                    dtDetail = new DataTable();
                    dtDetail = new BALItemSaleHistory().SelectByDateWise(new BOLItemSaleHistory() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value, ItemID = Convert.ToInt32(cmbItemName.SelectedValue) });
                    if (dtDetail.Rows.Count > 0)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        sfd.FilterIndex = 1;
                        sfd.RestoreDirectory = true;
                        sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dtDetail, "Sheet1");
                                wb.SaveAs(sfd.FileName);
                            }
                            MessageBox.Show("Export Successfully");
                        }

                    }
                    else
                    {
                        MessageBox.Show("No records found");
                    }
                }
                else
                {
                    dtDetail = new DataTable();
                    dtDetail = new BALItemSaleHistory().SelectByItemWise(new BOLItemSaleHistory() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value });
                    if (dtDetail.Rows.Count > 0)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                        sfd.FilterIndex = 1;
                        sfd.RestoreDirectory = true;
                        sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dtDetail, "Sheet1");
                                wb.SaveAs(sfd.FileName);
                            }
                            MessageBox.Show("Export Successfully");
                        }

                    }
                    else
                    {
                        MessageBox.Show("No records found");
                    }
                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemSaleHistoryReport,Function :btnExport_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void dgvAllInvoiceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == 4)
                {
                    DataTable dt = new DataTable();
                    int ID = Convert.ToInt32(dgvAllInvoiceList.CurrentRow.Cells[0].Value);
                    dt = new BALItemSaleHistory().SelectByDateWise(new BOLItemSaleHistory() { FromDate = dtpFromDate.Value, ToDate = dtpToDate.Value, ItemID = ID });
                    if (dt.Rows.Count > 0)
                    {
                        rptItemSaleHistoryReport cryRptItemSaleHistoryReport = new rptItemSaleHistoryReport();
                        cryRptItemSaleHistoryReport.Database.Tables[0].SetDataSource(dt);

                        FrmCrystalReportViewer crViewer = new FrmCrystalReportViewer();
                        crViewer.Text = "Item Sale History Report";
                        crViewer.crystalReportViewer.ReportSource = cryRptItemSaleHistoryReport;
                        crViewer.Show();
                    }
                    else
                    {
                        MessageBox.Show("No records found");
                    }
                }
              
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmItemSaleHistoryReport,Function :dgvAllInvoiceList_CellContentClick. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}