using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmRequestMessage : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public string Message = "";

        public FrmRequestMessage()
        {
            InitializeComponent();
        }

        private void FrmRequestMessage_Load(object sender, EventArgs e)
        {
            txtMessage.Text = Message.Trim();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);

            return res;
        }
        
    }
}