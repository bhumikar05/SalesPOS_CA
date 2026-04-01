namespace POS
{
    partial class FrmShippedInvoiceList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.PnlTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btmClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSearch = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnReset = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvShippiedInvoiceList = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalHeader = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtTranTo = new System.Windows.Forms.DateTimePicker();
            this.dtTranFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbTransactionsFilterDate = new System.Windows.Forms.ComboBox();
            this.radLabel60 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel61 = new Telerik.WinControls.UI.RadLabel();
            this.lbldate = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblto = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackingNumber = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ShipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Services = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Void = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingPrint = new System.Windows.Forms.DataGridViewLinkColumn();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShippiedInvoiceList)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel61)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PnlTop.Controls.Add(this.btnRefresh);
            this.PnlTop.Controls.Add(this.btmClose);
            this.PnlTop.Controls.Add(this.btnSearch);
            this.PnlTop.Controls.Add(this.btnReset);
            this.PnlTop.Controls.Add(this.txtInvoiceNo);
            this.PnlTop.Controls.Add(this.lblSearch);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(1139, 78);
            this.PnlTop.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.Location = new System.Drawing.Point(695, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnRefresh.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnRefresh.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRefresh.OverrideDefault.Border.Rounding = 3;
            this.btnRefresh.OverrideDefault.Border.Width = 1;
            this.btnRefresh.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnRefresh.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnRefresh.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRefresh.OverrideFocus.Border.Rounding = 3;
            this.btnRefresh.OverrideFocus.Border.Width = 1;
            this.btnRefresh.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRefresh.StateCommon.Border.Rounding = 3;
            this.btnRefresh.StateCommon.Border.Width = 1;
            this.btnRefresh.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnRefresh.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnRefresh.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRefresh.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.TabIndex = 320;
            this.btnRefresh.Values.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btmClose
            // 
            this.btmClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btmClose.Location = new System.Drawing.Point(599, 7);
            this.btmClose.Name = "btmClose";
            this.btmClose.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btmClose.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btmClose.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btmClose.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btmClose.OverrideDefault.Border.Rounding = 3;
            this.btmClose.OverrideDefault.Border.Width = 1;
            this.btmClose.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btmClose.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btmClose.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btmClose.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btmClose.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btmClose.OverrideFocus.Border.Rounding = 3;
            this.btmClose.OverrideFocus.Border.Width = 1;
            this.btmClose.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmClose.Size = new System.Drawing.Size(90, 30);
            this.btmClose.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btmClose.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btmClose.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btmClose.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btmClose.StateCommon.Border.Rounding = 3;
            this.btmClose.StateCommon.Border.Width = 1;
            this.btmClose.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmClose.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btmClose.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmClose.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btmClose.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btmClose.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btmClose.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btmClose.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmClose.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btmClose.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmClose.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btmClose.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmClose.TabIndex = 5;
            this.btmClose.Values.Text = "Close";
            this.btmClose.Click += new System.EventHandler(this.btmClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Location = new System.Drawing.Point(398, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSearch.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSearch.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSearch.OverrideDefault.Border.Rounding = 3;
            this.btnSearch.OverrideDefault.Border.Width = 1;
            this.btnSearch.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSearch.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSearch.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSearch.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSearch.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSearch.OverrideFocus.Border.Rounding = 3;
            this.btnSearch.OverrideFocus.Border.Width = 1;
            this.btnSearch.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSearch.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSearch.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSearch.StateCommon.Border.Rounding = 3;
            this.btnSearch.StateCommon.Border.Width = 1;
            this.btnSearch.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSearch.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSearch.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSearch.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSearch.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSearch.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSearch.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSearch.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSearch.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSearch.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSearch.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSearch.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSearch.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSearch.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Values.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.Location = new System.Drawing.Point(503, 7);
            this.btnReset.Name = "btnReset";
            this.btnReset.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnReset.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnReset.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnReset.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReset.OverrideDefault.Border.Rounding = 3;
            this.btnReset.OverrideDefault.Border.Width = 1;
            this.btnReset.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnReset.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnReset.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnReset.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReset.OverrideFocus.Border.Rounding = 3;
            this.btnReset.OverrideFocus.Border.Width = 1;
            this.btnReset.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Size = new System.Drawing.Size(90, 30);
            this.btnReset.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReset.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReset.StateCommon.Border.Rounding = 3;
            this.btnReset.StateCommon.Border.Width = 1;
            this.btnReset.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReset.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReset.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnReset.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnReset.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReset.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReset.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReset.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.TabIndex = 3;
            this.btnReset.Values.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(85, 14);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(280, 23);
            this.txtInvoiceNo.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(13, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(66, 18);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // dgvShippiedInvoiceList
            // 
            this.dgvShippiedInvoiceList.AllowUserToAddRows = false;
            this.dgvShippiedInvoiceList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvShippiedInvoiceList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShippiedInvoiceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShippiedInvoiceList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvShippiedInvoiceList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvShippiedInvoiceList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShippiedInvoiceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShippiedInvoiceList.ColumnHeadersHeight = 30;
            this.dgvShippiedInvoiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CustomerName,
            this.InvoiceNo,
            this.TrackingNumber,
            this.ShipDate,
            this.TxnDate,
            this.Weight,
            this.Services,
            this.ESTCharges,
            this.COD,
            this.Void,
            this.ID1,
            this.ShippingPrint});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShippiedInvoiceList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvShippiedInvoiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShippiedInvoiceList.GridColor = System.Drawing.SystemColors.Control;
            this.dgvShippiedInvoiceList.Location = new System.Drawing.Point(0, 78);
            this.dgvShippiedInvoiceList.Name = "dgvShippiedInvoiceList";
            this.dgvShippiedInvoiceList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShippiedInvoiceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvShippiedInvoiceList.RowHeadersVisible = false;
            this.dgvShippiedInvoiceList.RowHeadersWidth = 15;
            this.dgvShippiedInvoiceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShippiedInvoiceList.Size = new System.Drawing.Size(1139, 415);
            this.dgvShippiedInvoiceList.TabIndex = 4;
            this.dgvShippiedInvoiceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShippiedInvoiceList_CellContentClick);
            this.dgvShippiedInvoiceList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvShippiedInvoiceList_MouseClick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlBottom.Controls.Add(this.lblTotal);
            this.pnlBottom.Controls.Add(this.lblTotalHeader);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 448);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1139, 45);
            this.pnlBottom.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(65, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 9;
            // 
            // lblTotalHeader
            // 
            this.lblTotalHeader.Location = new System.Drawing.Point(12, 9);
            this.lblTotalHeader.Name = "lblTotalHeader";
            this.lblTotalHeader.Size = new System.Drawing.Size(55, 19);
            this.lblTotalHeader.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.TabIndex = 8;
            this.lblTotalHeader.TabStop = false;
            this.lblTotalHeader.Values.Text = "Total :";
            // 
            // dtTranTo
            // 
            this.dtTranTo.CalendarTrailingForeColor = System.Drawing.Color.Gainsboro;
            this.dtTranTo.CustomFormat = "MM-dd-yyyy";
            this.dtTranTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTranTo.Location = new System.Drawing.Point(494, 49);
            this.dtTranTo.Name = "dtTranTo";
            this.dtTranTo.Size = new System.Drawing.Size(109, 20);
            this.dtTranTo.TabIndex = 15;
            this.dtTranTo.Visible = false;
            this.dtTranTo.Leave += new System.EventHandler(this.dtTranTo_Leave);
            // 
            // dtTranFrom
            // 
            this.dtTranFrom.CalendarTrailingForeColor = System.Drawing.Color.Gainsboro;
            this.dtTranFrom.CustomFormat = "MM-dd-yyyy";
            this.dtTranFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTranFrom.Location = new System.Drawing.Point(342, 48);
            this.dtTranFrom.Name = "dtTranFrom";
            this.dtTranFrom.Size = new System.Drawing.Size(109, 20);
            this.dtTranFrom.TabIndex = 14;
            this.dtTranFrom.Visible = false;
            // 
            // cmbTransactionsFilterDate
            // 
            this.cmbTransactionsFilterDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransactionsFilterDate.DropDownWidth = 150;
            this.cmbTransactionsFilterDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTransactionsFilterDate.FormattingEnabled = true;
            this.cmbTransactionsFilterDate.Items.AddRange(new object[] {
            "Today ",
            "Yesterday ",
            "This Month",
            "This Week ",
            "Last Month ",
            "This Fiscal Year ",
            "ALL",
            "Custom "});
            this.cmbTransactionsFilterDate.Location = new System.Drawing.Point(68, 47);
            this.cmbTransactionsFilterDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbTransactionsFilterDate.Name = "cmbTransactionsFilterDate";
            this.cmbTransactionsFilterDate.Size = new System.Drawing.Size(197, 22);
            this.cmbTransactionsFilterDate.TabIndex = 13;
            this.cmbTransactionsFilterDate.SelectedIndexChanged += new System.EventHandler(this.cmbTransactionsFilterDate_SelectedIndexChanged);
            // 
            // radLabel60
            // 
            this.radLabel60.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel60.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel60.ForeColor = System.Drawing.Color.Gray;
            this.radLabel60.Location = new System.Drawing.Point(267, 8);
            this.radLabel60.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radLabel60.Name = "radLabel60";
            // 
            // 
            // 
            this.radLabel60.RootElement.ControlBounds = new System.Drawing.Rectangle(267, 8, 100, 18);
            this.radLabel60.Size = new System.Drawing.Size(37, 17);
            this.radLabel60.TabIndex = 2;
            this.radLabel60.Text = "DATE";
            // 
            // radLabel61
            // 
            this.radLabel61.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel61.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel61.ForeColor = System.Drawing.Color.Gray;
            this.radLabel61.Location = new System.Drawing.Point(10, 8);
            this.radLabel61.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radLabel61.Name = "radLabel61";
            // 
            // 
            // 
            this.radLabel61.RootElement.ControlBounds = new System.Drawing.Rectangle(10, 8, 100, 18);
            this.radLabel61.Size = new System.Drawing.Size(65, 17);
            this.radLabel61.TabIndex = 0;
            this.radLabel61.Text = "FILTER BY";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.Location = new System.Drawing.Point(19, 52);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(43, 14);
            this.lbldate.TabIndex = 17;
            this.lbldate.Text = "Filter:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(289, 50);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(47, 14);
            this.lblFrom.TabIndex = 18;
            this.lblFrom.Text = "FROM:";
            // 
            // lblto
            // 
            this.lblto.AutoSize = true;
            this.lblto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblto.Location = new System.Drawing.Point(459, 51);
            this.lblto.Name = "lblto";
            this.lblto.Size = new System.Drawing.Size(29, 14);
            this.lblto.TabIndex = 19;
            this.lblto.Text = "TO:";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.FillWeight = 102.6831F;
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.FillWeight = 102.6831F;
            this.InvoiceNo.HeaderText = "InvoiceNo.";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            // 
            // TrackingNumber
            // 
            this.TrackingNumber.FillWeight = 102.6831F;
            this.TrackingNumber.HeaderText = "Tracking Number";
            this.TrackingNumber.Name = "TrackingNumber";
            this.TrackingNumber.ReadOnly = true;
            this.TrackingNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TrackingNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ShipDate
            // 
            this.ShipDate.FillWeight = 102.6831F;
            this.ShipDate.HeaderText = "ShipDate";
            this.ShipDate.Name = "ShipDate";
            this.ShipDate.ReadOnly = true;
            // 
            // TxnDate
            // 
            this.TxnDate.FillWeight = 102.6831F;
            this.TxnDate.HeaderText = "ShipTime";
            this.TxnDate.Name = "TxnDate";
            this.TxnDate.ReadOnly = true;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            // 
            // Services
            // 
            this.Services.HeaderText = "Services";
            this.Services.Name = "Services";
            this.Services.ReadOnly = true;
            // 
            // ESTCharges
            // 
            this.ESTCharges.HeaderText = "EST.Charges";
            this.ESTCharges.Name = "ESTCharges";
            this.ESTCharges.ReadOnly = true;
            // 
            // COD
            // 
            this.COD.HeaderText = "COD";
            this.COD.Name = "COD";
            this.COD.ReadOnly = true;
            // 
            // Void
            // 
            this.Void.HeaderText = "Void";
            this.Void.Name = "Void";
            this.Void.ReadOnly = true;
            this.Void.Text = "Void";
            this.Void.ToolTipText = "Void";
            this.Void.UseColumnTextForLinkValue = true;
            // 
            // ID1
            // 
            this.ID1.HeaderText = "ID1";
            this.ID1.Name = "ID1";
            this.ID1.ReadOnly = true;
            this.ID1.Visible = false;
            // 
            // ShippingPrint
            // 
            this.ShippingPrint.HeaderText = "ShipPrint";
            this.ShippingPrint.Name = "ShippingPrint";
            this.ShippingPrint.ReadOnly = true;
            this.ShippingPrint.Text = "ShipPrint";
            this.ShippingPrint.ToolTipText = "ShipPrint";
            this.ShippingPrint.UseColumnTextForLinkValue = true;
            // 
            // FrmShippedInvoiceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1139, 493);
            this.Controls.Add(this.lblto);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.dtTranTo);
            this.Controls.Add(this.dtTranFrom);
            this.Controls.Add(this.cmbTransactionsFilterDate);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvShippiedInvoiceList);
            this.Controls.Add(this.PnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmShippedInvoiceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateActive.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateActive.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateActive.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateActive.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateActive.Header.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.StateActive.Header.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StateInactive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateInactive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateInactive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateInactive.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateInactive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateInactive.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateInactive.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(96)))));
            this.StateInactive.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateInactive.Header.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.StateInactive.Header.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text = "Shipped Invoice List";
            this.Load += new System.EventHandler(this.FrmShippedInvoiceReport_Load);
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShippiedInvoiceList)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel61)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvShippiedInvoiceList;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTotal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotalHeader;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btmClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnReset;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRefresh;
        private System.Windows.Forms.DateTimePicker dtTranTo;
        private System.Windows.Forms.DateTimePicker dtTranFrom;
        private System.Windows.Forms.ComboBox cmbTransactionsFilterDate;
        private Telerik.WinControls.UI.RadLabel radLabel60;
        private Telerik.WinControls.UI.RadLabel radLabel61;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblto;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewLinkColumn TrackingNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TxnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Services;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTCharges;
        private System.Windows.Forms.DataGridViewTextBoxColumn COD;
        private System.Windows.Forms.DataGridViewLinkColumn Void;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID1;
        private System.Windows.Forms.DataGridViewLinkColumn ShippingPrint;
    }
}

