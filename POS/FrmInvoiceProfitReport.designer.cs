namespace POS
{
    partial class FrmInvoiceProfitMaster
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
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbInvoiceDate = new System.Windows.Forms.ComboBox();
            this.dgvAllInvoiceList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesRep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View = new System.Windows.Forms.DataGridViewLinkColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnExportWithCustomerNumberOnly = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnImportCPrice = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnExportCPrice = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSe = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlInvDetails = new System.Windows.Forms.Panel();
            this.lblRefno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalProfit = new System.Windows.Forms.Label();
            this.lblProfit = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblErrorMsg = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.dgInvDetail = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComparativePrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComparativePrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComparativePrice3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComparativePrice4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComparativePrice5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LowestPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfitPerPiece = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfitPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInvoiceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlInvDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTo.Location = new System.Drawing.Point(426, 16);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(24, 16);
            this.lblTo.TabIndex = 349;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFrom.Location = new System.Drawing.Point(275, 16);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(38, 16);
            this.lblFrom.TabIndex = 348;
            this.lblFrom.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(37, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 347;
            this.label3.Text = "Filter By";
            // 
            // dtTo
            // 
            this.dtTo.CalendarTrailingForeColor = System.Drawing.Color.Gainsboro;
            this.dtTo.CustomFormat = "MM-dd-yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(457, 14);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(100, 20);
            this.dtTo.TabIndex = 346;
            this.dtTo.Visible = false;
            this.dtTo.Leave += new System.EventHandler(this.dtTo_Leave);
            // 
            // dtFrom
            // 
            this.dtFrom.CalendarTrailingForeColor = System.Drawing.Color.Gainsboro;
            this.dtFrom.CustomFormat = "MM-dd-yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(320, 14);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(100, 20);
            this.dtFrom.TabIndex = 345;
            this.dtFrom.Visible = false;
            this.dtFrom.Leave += new System.EventHandler(this.dtFrom_Leave);
            // 
            // cmbInvoiceDate
            // 
            this.cmbInvoiceDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInvoiceDate.FormattingEnabled = true;
            this.cmbInvoiceDate.Items.AddRange(new object[] {
            "Today ",
            "Yesterday ",
            "This Month",
            "This Week ",
            "Last Month ",
            "This Fiscal Year ",
            "ALL",
            "Custom "});
            this.cmbInvoiceDate.Location = new System.Drawing.Point(87, 11);
            this.cmbInvoiceDate.Name = "cmbInvoiceDate";
            this.cmbInvoiceDate.Size = new System.Drawing.Size(153, 24);
            this.cmbInvoiceDate.TabIndex = 344;
            this.cmbInvoiceDate.SelectedIndexChanged += new System.EventHandler(this.cmbInvoiceDate_SelectedIndexChanged);
            // 
            // dgvAllInvoiceList
            // 
            this.dgvAllInvoiceList.AllowUserToAddRows = false;
            this.dgvAllInvoiceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllInvoiceList.ColumnHeadersHeight = 29;
            this.dgvAllInvoiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Customer,
            this.Num,
            this.Date,
            this.Amount,
            this.SalesRep,
            this.Profit,
            this.TotalProfit,
            this.View});
            this.dgvAllInvoiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllInvoiceList.Location = new System.Drawing.Point(0, 0);
            this.dgvAllInvoiceList.Name = "dgvAllInvoiceList";
            this.dgvAllInvoiceList.RowHeadersVisible = false;
            this.dgvAllInvoiceList.RowHeadersWidth = 51;
            this.dgvAllInvoiceList.Size = new System.Drawing.Size(1576, 625);
            this.dgvAllInvoiceList.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvAllInvoiceList.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvAllInvoiceList.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvAllInvoiceList.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.Black;
            this.dgvAllInvoiceList.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvAllInvoiceList.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.dgvAllInvoiceList.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.dgvAllInvoiceList.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgvAllInvoiceList.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAllInvoiceList.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.Black;
            this.dgvAllInvoiceList.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgvAllInvoiceList.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.White;
            this.dgvAllInvoiceList.TabIndex = 270;
            this.dgvAllInvoiceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllInvoiceList_CellContentClick);
            this.dgvAllInvoiceList.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvAllInvoiceList_SortCompare);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Customer
            // 
            this.Customer.HeaderText = "Customer";
            this.Customer.MinimumWidth = 6;
            this.Customer.Name = "Customer";
            // 
            // Num
            // 
            this.Num.HeaderText = "Num";
            this.Num.MinimumWidth = 6;
            this.Num.Name = "Num";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            // 
            // SalesRep
            // 
            this.SalesRep.HeaderText = "SalesRep";
            this.SalesRep.MinimumWidth = 6;
            this.SalesRep.Name = "SalesRep";
            // 
            // Profit
            // 
            this.Profit.HeaderText = "Profit";
            this.Profit.MinimumWidth = 6;
            this.Profit.Name = "Profit";
            // 
            // TotalProfit
            // 
            this.TotalProfit.HeaderText = "Profit%";
            this.TotalProfit.MinimumWidth = 6;
            this.TotalProfit.Name = "TotalProfit";
            // 
            // View
            // 
            this.View.HeaderText = "View";
            this.View.MinimumWidth = 6;
            this.View.Name = "View";
            this.View.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.View.Text = "View";
            this.View.ToolTipText = "View";
            this.View.UseColumnTextForLinkValue = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnExportWithCustomerNumberOnly);
            this.splitContainer1.Panel1.Controls.Add(this.btnImportCPrice);
            this.splitContainer1.Panel1.Controls.Add(this.btnExportCPrice);
            this.splitContainer1.Panel1.Controls.Add(this.btnExport);
            this.splitContainer1.Panel1.Controls.Add(this.btnSe);
            this.splitContainer1.Panel1.Controls.Add(this.cmbInvoiceDate);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer1.Panel1.Controls.Add(this.lblTo);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.dtFrom);
            this.splitContainer1.Panel1.Controls.Add(this.lblFrom);
            this.splitContainer1.Panel1.Controls.Add(this.dtTo);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlInvDetails);
            this.splitContainer1.Panel2.Controls.Add(this.dgvAllInvoiceList);
            this.splitContainer1.Size = new System.Drawing.Size(1576, 692);
            this.splitContainer1.SplitterDistance = 63;
            this.splitContainer1.TabIndex = 350;
            // 
            // btnExportWithCustomerNumberOnly
            // 
            this.btnExportWithCustomerNumberOnly.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExportWithCustomerNumberOnly.Location = new System.Drawing.Point(1385, 7);
            this.btnExportWithCustomerNumberOnly.Name = "btnExportWithCustomerNumberOnly";
            this.btnExportWithCustomerNumberOnly.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnExportWithCustomerNumberOnly.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnExportWithCustomerNumberOnly.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExportWithCustomerNumberOnly.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExportWithCustomerNumberOnly.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExportWithCustomerNumberOnly.OverrideDefault.Border.Rounding = 3;
            this.btnExportWithCustomerNumberOnly.OverrideDefault.Border.Width = 1;
            this.btnExportWithCustomerNumberOnly.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExportWithCustomerNumberOnly.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnExportWithCustomerNumberOnly.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnExportWithCustomerNumberOnly.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExportWithCustomerNumberOnly.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExportWithCustomerNumberOnly.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExportWithCustomerNumberOnly.OverrideFocus.Border.Rounding = 3;
            this.btnExportWithCustomerNumberOnly.OverrideFocus.Border.Width = 1;
            this.btnExportWithCustomerNumberOnly.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportWithCustomerNumberOnly.Size = new System.Drawing.Size(183, 43);
            this.btnExportWithCustomerNumberOnly.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExportWithCustomerNumberOnly.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnExportWithCustomerNumberOnly.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExportWithCustomerNumberOnly.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExportWithCustomerNumberOnly.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExportWithCustomerNumberOnly.StateCommon.Border.Rounding = 3;
            this.btnExportWithCustomerNumberOnly.StateCommon.Border.Width = 1;
            this.btnExportWithCustomerNumberOnly.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportWithCustomerNumberOnly.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExportWithCustomerNumberOnly.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnExportWithCustomerNumberOnly.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportWithCustomerNumberOnly.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExportWithCustomerNumberOnly.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnExportWithCustomerNumberOnly.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExportWithCustomerNumberOnly.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExportWithCustomerNumberOnly.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExportWithCustomerNumberOnly.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportWithCustomerNumberOnly.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExportWithCustomerNumberOnly.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnExportWithCustomerNumberOnly.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportWithCustomerNumberOnly.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExportWithCustomerNumberOnly.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnExportWithCustomerNumberOnly.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportWithCustomerNumberOnly.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportWithCustomerNumberOnly.TabIndex = 353;
            this.btnExportWithCustomerNumberOnly.Values.Text = "Export With \r\nCustomer Number Only\r\n";
            this.btnExportWithCustomerNumberOnly.Click += new System.EventHandler(this.btnExportWithCustomerNumberOnly_Click_1);
            // 
            // btnImportCPrice
            // 
            this.btnImportCPrice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnImportCPrice.Location = new System.Drawing.Point(785, 11);
            this.btnImportCPrice.Name = "btnImportCPrice";
            this.btnImportCPrice.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnImportCPrice.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnImportCPrice.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnImportCPrice.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnImportCPrice.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnImportCPrice.OverrideDefault.Border.Rounding = 3;
            this.btnImportCPrice.OverrideDefault.Border.Width = 1;
            this.btnImportCPrice.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnImportCPrice.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnImportCPrice.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnImportCPrice.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnImportCPrice.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnImportCPrice.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnImportCPrice.OverrideFocus.Border.Rounding = 3;
            this.btnImportCPrice.OverrideFocus.Border.Width = 1;
            this.btnImportCPrice.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCPrice.Size = new System.Drawing.Size(142, 36);
            this.btnImportCPrice.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnImportCPrice.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnImportCPrice.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImportCPrice.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImportCPrice.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnImportCPrice.StateCommon.Border.Rounding = 3;
            this.btnImportCPrice.StateCommon.Border.Width = 1;
            this.btnImportCPrice.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCPrice.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnImportCPrice.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnImportCPrice.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCPrice.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnImportCPrice.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnImportCPrice.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnImportCPrice.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnImportCPrice.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnImportCPrice.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCPrice.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnImportCPrice.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnImportCPrice.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCPrice.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnImportCPrice.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnImportCPrice.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnImportCPrice.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCPrice.TabIndex = 352;
            this.btnImportCPrice.Values.Text = "C.Price Import";
            this.btnImportCPrice.Click += new System.EventHandler(this.btnImportCPrice_Click);
            // 
            // btnExportCPrice
            // 
            this.btnExportCPrice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExportCPrice.Location = new System.Drawing.Point(644, 11);
            this.btnExportCPrice.Name = "btnExportCPrice";
            this.btnExportCPrice.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnExportCPrice.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnExportCPrice.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExportCPrice.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExportCPrice.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExportCPrice.OverrideDefault.Border.Rounding = 3;
            this.btnExportCPrice.OverrideDefault.Border.Width = 1;
            this.btnExportCPrice.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExportCPrice.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnExportCPrice.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnExportCPrice.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExportCPrice.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExportCPrice.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExportCPrice.OverrideFocus.Border.Rounding = 3;
            this.btnExportCPrice.OverrideFocus.Border.Width = 1;
            this.btnExportCPrice.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCPrice.Size = new System.Drawing.Size(135, 36);
            this.btnExportCPrice.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExportCPrice.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnExportCPrice.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExportCPrice.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExportCPrice.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExportCPrice.StateCommon.Border.Rounding = 3;
            this.btnExportCPrice.StateCommon.Border.Width = 1;
            this.btnExportCPrice.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCPrice.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExportCPrice.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnExportCPrice.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCPrice.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExportCPrice.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnExportCPrice.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExportCPrice.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExportCPrice.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExportCPrice.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCPrice.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExportCPrice.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnExportCPrice.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCPrice.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExportCPrice.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnExportCPrice.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExportCPrice.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCPrice.TabIndex = 351;
            this.btnExportCPrice.Values.Text = "C.Price Export";
            this.btnExportCPrice.Click += new System.EventHandler(this.btnExportCPrice_Click);
            // 
            // btnExport
            // 
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.Location = new System.Drawing.Point(1259, 9);
            this.btnExport.Name = "btnExport";
            this.btnExport.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnExport.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnExport.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExport.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExport.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExport.OverrideDefault.Border.Rounding = 3;
            this.btnExport.OverrideDefault.Border.Width = 1;
            this.btnExport.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExport.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnExport.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnExport.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExport.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExport.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExport.OverrideFocus.Border.Rounding = 3;
            this.btnExport.OverrideFocus.Border.Width = 1;
            this.btnExport.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Size = new System.Drawing.Size(120, 36);
            this.btnExport.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExport.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnExport.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExport.StateCommon.Border.Rounding = 3;
            this.btnExport.StateCommon.Border.Width = 1;
            this.btnExport.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExport.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnExport.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExport.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnExport.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExport.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExport.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExport.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExport.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnExport.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExport.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnExport.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.TabIndex = 350;
            this.btnExport.Values.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSe
            // 
            this.btnSe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSe.Location = new System.Drawing.Point(1186, 14);
            this.btnSe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSe.Name = "btnSe";
            this.btnSe.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSe.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSe.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSe.OverrideDefault.Border.Rounding = 3;
            this.btnSe.OverrideDefault.Border.Width = 1;
            this.btnSe.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSe.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSe.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSe.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSe.OverrideFocus.Border.Rounding = 3;
            this.btnSe.OverrideFocus.Border.Width = 1;
            this.btnSe.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSe.Size = new System.Drawing.Size(67, 26);
            this.btnSe.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.btnSe.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.btnSe.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSe.StateCommon.Border.Rounding = 3;
            this.btnSe.StateCommon.Border.Width = 1;
            this.btnSe.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSe.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSe.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSe.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSe.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSe.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSe.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSe.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSe.TabIndex = 337;
            this.btnSe.Values.Text = "Search";
            this.btnSe.Click += new System.EventHandler(this.btnSe_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AcceptsReturn = true;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.Location = new System.Drawing.Point(1013, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(154, 20);
            this.txtSearch.TabIndex = 336;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(959, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 335;
            this.label6.Text = "Search";
            // 
            // pnlInvDetails
            // 
            this.pnlInvDetails.Controls.Add(this.dgInvDetail);
            this.pnlInvDetails.Controls.Add(this.lblRefno);
            this.pnlInvDetails.Controls.Add(this.label1);
            this.pnlInvDetails.Controls.Add(this.lblTotalProfit);
            this.pnlInvDetails.Controls.Add(this.lblProfit);
            this.pnlInvDetails.Controls.Add(this.btnclose);
            this.pnlInvDetails.Controls.Add(this.panel8);
            this.pnlInvDetails.Controls.Add(this.panel7);
            this.pnlInvDetails.Controls.Add(this.panel6);
            this.pnlInvDetails.Controls.Add(this.panel5);
            this.pnlInvDetails.Location = new System.Drawing.Point(12, 3);
            this.pnlInvDetails.Name = "pnlInvDetails";
            this.pnlInvDetails.Size = new System.Drawing.Size(1545, 619);
            this.pnlInvDetails.TabIndex = 318;
            this.pnlInvDetails.Visible = false;
            // 
            // lblRefno
            // 
            this.lblRefno.AutoSize = true;
            this.lblRefno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefno.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRefno.Location = new System.Drawing.Point(92, 19);
            this.lblRefno.Name = "lblRefno";
            this.lblRefno.Size = new System.Drawing.Size(15, 16);
            this.lblRefno.TabIndex = 352;
            this.lblRefno.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(30, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 350;
            this.label1.Text = "Invoice No :";
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProfit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalProfit.Location = new System.Drawing.Point(1162, 580);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Size = new System.Drawing.Size(96, 16);
            this.lblTotalProfit.TabIndex = 351;
            this.lblTotalProfit.Text = "0";
            // 
            // lblProfit
            // 
            this.lblProfit.AutoSize = true;
            this.lblProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblProfit.Location = new System.Drawing.Point(1084, 580);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(77, 16);
            this.lblProfit.TabIndex = 350;
            this.lblProfit.Text = "Total Profit :";
            // 
            // btnclose
            // 
            this.btnclose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnclose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.White;
            this.btnclose.Location = new System.Drawing.Point(1449, 11);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(80, 30);
            this.btnclose.TabIndex = 232;
            this.btnclose.Tag = "";
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(5, 614);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1530, 5);
            this.panel8.TabIndex = 231;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(1535, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 614);
            this.panel7.TabIndex = 230;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(5, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1540, 5);
            this.panel6.TabIndex = 229;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 619);
            this.panel5.TabIndex = 228;
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = false;
            this.lblErrorMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblErrorMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblErrorMsg.Location = new System.Drawing.Point(0, 692);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(1576, 10);
            this.lblErrorMsg.StateCommon.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // dgInvDetail
            // 
            this.dgInvDetail.AllowUserToAddRows = false;
            this.dgInvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInvDetail.ColumnHeadersHeight = 29;
            this.dgInvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ItemName,
            this.ComparativePrice1,
            this.ComparativePrice2,
            this.ComparativePrice3,
            this.ComparativePrice4,
            this.ComparativePrice5,
            this.Qty,
            this.Rate,
            this.LowestPrice,
            this.Amt,
            this.Cost,
            this.Profit1,
            this.ProfitPerPiece,
            this.ProfitPercentage});
            this.dgInvDetail.Location = new System.Drawing.Point(24, 44);
            this.dgInvDetail.Name = "dgInvDetail";
            this.dgInvDetail.RowHeadersVisible = false;
            this.dgInvDetail.RowHeadersWidth = 51;
            this.dgInvDetail.Size = new System.Drawing.Size(1497, 530);
            this.dgInvDetail.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgInvDetail.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgInvDetail.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgInvDetail.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.dgInvDetail.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.dgInvDetail.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgInvDetail.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgInvDetail.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.Black;
            this.dgInvDetail.TabIndex = 353;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.MinimumWidth = 6;
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // ComparativePrice1
            // 
            this.ComparativePrice1.HeaderText = "Ms";
            this.ComparativePrice1.Name = "ComparativePrice1";
            // 
            // ComparativePrice2
            // 
            this.ComparativePrice2.HeaderText = "P4s";
            this.ComparativePrice2.Name = "ComparativePrice2";
            // 
            // ComparativePrice3
            // 
            this.ComparativePrice3.HeaderText = "Gf";
            this.ComparativePrice3.Name = "ComparativePrice3";
            // 
            // ComparativePrice4
            // 
            this.ComparativePrice4.HeaderText = "XCELL";
            this.ComparativePrice4.Name = "ComparativePrice4";
            // 
            // ComparativePrice5
            // 
            this.ComparativePrice5.HeaderText = "P4s-D";
            this.ComparativePrice5.Name = "ComparativePrice5";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.MinimumWidth = 6;
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.MinimumWidth = 6;
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            // 
            // LowestPrice
            // 
            this.LowestPrice.HeaderText = "LowestPrice";
            this.LowestPrice.Name = "LowestPrice";
            // 
            // Amt
            // 
            this.Amt.HeaderText = "Amount";
            this.Amt.MinimumWidth = 6;
            this.Amt.Name = "Amt";
            this.Amt.ReadOnly = true;
            // 
            // Cost
            // 
            this.Cost.HeaderText = "Cost";
            this.Cost.MinimumWidth = 6;
            this.Cost.Name = "Cost";
            // 
            // Profit1
            // 
            this.Profit1.HeaderText = "Profit";
            this.Profit1.MinimumWidth = 6;
            this.Profit1.Name = "Profit1";
            // 
            // ProfitPerPiece
            // 
            this.ProfitPerPiece.HeaderText = "ProfitPerPiece";
            this.ProfitPerPiece.Name = "ProfitPerPiece";
            // 
            // ProfitPercentage
            // 
            this.ProfitPercentage.HeaderText = "Profit %";
            this.ProfitPercentage.Name = "ProfitPercentage";
            // 
            // FrmInvoiceProfitMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1576, 702);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblErrorMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmInvoiceProfitMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateActive.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateActive.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateActive.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateActive.Header.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.StateActive.Header.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StateInactive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateInactive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateInactive.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateInactive.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateInactive.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateInactive.Header.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.StateInactive.Header.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text = "Invoice Profit Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInvoiceProfitMaster_FormClosing);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInvoiceList)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlInvDetails.ResumeLayout(false);
            this.pnlInvDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.ComboBox cmbInvoiceDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvAllInvoiceList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lblErrorMsg;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnlInvDetails;
        private System.Windows.Forms.Label lblProfit;
        private System.Windows.Forms.Label lblTotalProfit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRefno;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSe;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label6;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExport;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExportCPrice;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnImportCPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesRep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalProfit;
        private System.Windows.Forms.DataGridViewLinkColumn View;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExportWithCustomerNumberOnly;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgInvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComparativePrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComparativePrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComparativePrice3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComparativePrice4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComparativePrice5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LowestPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfitPerPiece;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfitPercentage;
    }
}

