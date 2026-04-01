using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using POS.HelperClass;
using POS.BAL;
using POS.BOL;

namespace POS
{
    public partial class FrmPriceTier : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
       
        DataTable dt = new DataTable();
        public string SalesRepID = ""; public string SalesRepName = "";

        BALPriceTier ObjPriceBAL = new BALPriceTier();
        BOLPriceTire ObjPriceBOL = new BOLPriceTire();
        public FrmPriceTier() 
        {
            InitializeComponent();
        }

        private void DisplayMessage(string Text, string Mode)
        {
            switch (Mode)
            {
                case "W":
                    lblErrorMsg.StateCommon.TextColor = Color.FromArgb(16, 6, 244);
                    lblErrorMsg.StateNormal.TextColor = Color.FromArgb(16, 6, 244);
                    lblErrorMsg.Text = Text;
                    break;
                case "I":
                    lblErrorMsg.StateCommon.TextColor = Color.DarkGreen;
                    lblErrorMsg.StateNormal.TextColor = Color.DarkGreen;
                    lblErrorMsg.Text = Text;
                    break;
                case "E":
                    lblErrorMsg.StateCommon.TextColor = Color.DarkRed;
                    lblErrorMsg.StateNormal.TextColor = Color.DarkRed;
                    lblErrorMsg.Text = "Error: " + Text;
                    break;
            }
        }

        private void FrmPriceTier_Load(object sender, EventArgs e)
        {
            txtRepID.Text = SalesRepID;
            lblSalesRep.Text = SalesRepName;
        }
        public Boolean checkvalidator()
        {
            Boolean x = true;
            try
            {
                if (chkPrice.CheckedItems.Count == 0)
                {
                    DisplayMessage("Please Select Price","E");
                    x = false;
                }
            }      
            catch (Exception ex)
            {
                x = false;
                ClsCommon.WriteErrorLogs("Form:FrmPriceTier,Function :btnSave_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
            return x;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if(checkvalidator())
                  if (chkPrice.CheckedItems.Count > 0)
                  {
                      ObjPriceBOL = new BOLPriceTire();
                      dt = ObjPriceBAL.SelectByRepID(Convert.ToInt32(txtRepID.Text));
                      if (dt.Rows.Count > 0)
                      {
                            ObjPriceBOL.SalesRepID = Convert.ToInt32(txtRepID.Text);
                            for (int x = 0; x < chkPrice.Items.Count; x++)
                            {
                                if (chkPrice.GetItemChecked(x))
                                {
                                    if (chkPrice.Items[x].ToString() == "TierGF")
                                    {
                                        ObjPriceBOL.PriceTier1 = 1;
                                    }
                                    if (chkPrice.Items[x].ToString() == "TierP4C")
                                    {
                                        ObjPriceBOL.PriceTier2 = 1;
                                    }
                                    if (chkPrice.Items[x].ToString() == "TierMS")
                                    {
                                        ObjPriceBOL.PriceTier3 = 1;
                                    }
                                    if (chkPrice.Items[x].ToString() == "Cost")
                                    {
                                        ObjPriceBOL.Cost = 1;
                                    }
                                }
                            }
                            ObjPriceBAL.Update(ObjPriceBOL);
                            DisplayMessage("Price Save Successfully", "I");
                      }
                      else
                      {

                            ObjPriceBOL.SalesRepID = Convert.ToInt32(txtRepID.Text);
                            for (int x = 0; x < chkPrice.Items.Count; x++)
                            {
                                if (chkPrice.GetItemChecked(x))
                                {
                                    if (chkPrice.Items[x].ToString() == "TierGF")
                                    {
                                        ObjPriceBOL.PriceTier1 = 1;
                                    }
                                    if (chkPrice.Items[x].ToString() == "TierP4C")
                                    {
                                        ObjPriceBOL.PriceTier2 = 1;
                                    }
                                    if (chkPrice.Items[x].ToString() == "TierMS")
                                    {
                                        ObjPriceBOL.PriceTier3 = 1;
                                    }
                                    if (chkPrice.Items[x].ToString() == "Cost")
                                    {
                                        ObjPriceBOL.Cost = 1;
                                    }
                                }
                            }
                            ObjPriceBAL.Insert(ObjPriceBOL);
                            DisplayMessage("Price Save Successfully", "I");
                      }
                  }
                  else
                  {
                     if(txtRepID.Text != "")
                     {
                        ObjPriceBAL.Delete(Convert.ToInt32(txtRepID.Text));
                        DisplayMessage("Price Save Successfully", "I");
                    }                    
                  }
               
            }
            catch (Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPriceTier,Function :btnSave_Click. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }

        public void Display(DataTable dt)
        {
            string x = "";
            try
            {
                if(dt.Rows[0]["PriceTier1"].ToString() == "1")
                {
                    if(x == "")
                    {
                        //x = "PriceTier1";
                        x = "TierGF";
                    }
                    else
                    {
                        //x += ',' + "PriceTier1";
                        x += ',' + "TierGF";
                    }
                     
                }

                if(dt.Rows[0]["PriceTier2"].ToString() == "1")
                {
                    if (x == "")
                    {
                        //x = "PriceTier2";
                        x = "TierP4C";
                    }
                    else
                    {
                        //x += ',' + "PriceTier2";
                        x += ',' + "TierP4C";
                    }
                }

                if(dt.Rows[0]["PriceTier3"].ToString() == "1")
                {
                    if (x == "")
                    {
                        x = "TierMS";
                        //x = "PriceTier3";
                    }
                    else
                    {
                        //x += ',' + "PriceTier3";
                        x += ',' + "TierMS";
                    }
                }

                if (dt.Rows[0]["Cost"].ToString() == "1")
                {
                    if (x == "")
                    {
                        x = "Cost";
                    }
                    else
                    {
                        x += ',' + "Cost";
                    }
                }


                string[] value = x.Split(',');
                for (int i = 0; i < chkPrice.Items.Count; i++)
                {
                    foreach (var items in value)
                    {
                        if (items.ToString().Trim().ToLower() == chkPrice.Items[i].ToString().ToLower())
                        {
                            chkPrice.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                ClsCommon.WriteErrorLogs("Form:FrmPriceTier,Function :Display. Message:" + ex.Message);
                MessageBox.Show("Error:" + ex.Message, "E");
            }
        }
    }
}