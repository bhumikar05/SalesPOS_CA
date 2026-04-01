using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace POS
{
    public partial class FrmManuallySyncPrint : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public FrmManuallySyncPrint()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtApplicationPath.Text != "")
            {
                Program.mySetting.ApplicationPath = txtApplicationPath.Text;
                Program.mySetting.Save();
                MessageBox.Show("Application Path Save SuccessFully");
            }
            else
            {
                txtApplicationPath.Focus();
                MessageBox.Show("Please Enter ApplicationPath");
            }
        }

        private void FrmManuallySyncPrint_Load(object sender, EventArgs e)
        {
            if (Program.mySetting.ApplicationPath != "")
            {
                txtApplicationPath.Text = Program.mySetting.ApplicationPath;
            }
        }

        private void FrmManuallySyncPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }

        private void btnRunApplication_Click(object sender, EventArgs e)
        {
            if (Program.mySetting.ApplicationPath != "")
            {
                System.Diagnostics.Process.Start(Program.mySetting.ApplicationPath);
            }
            else
            {
                MessageBox.Show("Please Enter ApplicationPath");
            }
        }
    }
}