using POS.BAL;
using POS.BOL;
using POS.HelperClass;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace POS
{
    public partial class FrmAvailableService : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public FrmAvailableService()
        {
            InitializeComponent();
        }

        private void FrmAvailableService_Load(object sender, EventArgs e)
        {
            if (clsOnline.dtTime.Rows.Count > 0)
            {
                clsOnline.dtTime.Columns.Remove("Date");
                dgvRequestList.DataSource = clsOnline.dtTime;
            }
            else
                dgvRequestList.Rows.Clear();
            Cursor.Current = Cursors.Default;
        }
    }
}