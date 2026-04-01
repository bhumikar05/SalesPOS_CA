namespace POS
{
    partial class FrmAdminRequestList
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvRequestList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesRepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComparativePrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComparativePrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComparativePrice3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComparativePrice4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComparativePrice5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentLowestPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserLowestPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Remove = new System.Windows.Forms.DataGridViewLinkColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalHeader = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.lblto = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtTranTo = new System.Windows.Forms.DateTimePicker();
            this.dtTranFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbTransactionsFilterDate = new System.Windows.Forms.ComboBox();
            this.btnExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btmClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSearch = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnReset = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestList)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Controls.Add(this.PnlTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1119, 462);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvRequestList);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 97);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1119, 319);
            this.pnlGrid.TabIndex = 143;
            // 
            // dgvRequestList
            // 
            this.dgvRequestList.AllowUserToAddRows = false;
            this.dgvRequestList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvRequestList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRequestList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequestList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequestList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRequestList.ColumnHeadersHeight = 30;
            this.dgvRequestList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.InvoiceID,
            this.CustomerName,
            this.InvoiceNo,
            this.ItemName,
            this.Date,
            this.SalesRepName,
            this.PurchaseCost,
            this.ComparativePrice1,
            this.ComparativePrice2,
            this.ComparativePrice3,
            this.ComparativePrice4,
            this.ComparativePrice5,
            this.CurrentLowestPrice,
            this.UserLowestPrice,
            this.Status,
            this.View,
            this.Remove});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRequestList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRequestList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRequestList.GridColor = System.Drawing.SystemColors.Control;
            this.dgvRequestList.Location = new System.Drawing.Point(0, 0);
            this.dgvRequestList.MultiSelect = false;
            this.dgvRequestList.Name = "dgvRequestList";
            this.dgvRequestList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequestList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRequestList.RowHeadersVisible = false;
            this.dgvRequestList.RowHeadersWidth = 15;
            this.dgvRequestList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequestList.Size = new System.Drawing.Size(1119, 319);
            this.dgvRequestList.TabIndex = 0;
            this.dgvRequestList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequestList_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // InvoiceID
            // 
            this.InvoiceID.HeaderText = "InvoiceID";
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.ReadOnly = true;
            this.InvoiceID.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.HeaderText = "InvoiceNumber";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // SalesRepName
            // 
            this.SalesRepName.HeaderText = "SalesRepName";
            this.SalesRepName.Name = "SalesRepName";
            this.SalesRepName.ReadOnly = true;
            // 
            // PurchaseCost
            // 
            this.PurchaseCost.HeaderText = "PurchaseCost";
            this.PurchaseCost.Name = "PurchaseCost";
            this.PurchaseCost.ReadOnly = true;
            // 
            // ComparativePrice1
            // 
            this.ComparativePrice1.HeaderText = "Ms";
            this.ComparativePrice1.Name = "ComparativePrice1";
            this.ComparativePrice1.ReadOnly = true;
            // 
            // ComparativePrice2
            // 
            this.ComparativePrice2.HeaderText = "P4s";
            this.ComparativePrice2.Name = "ComparativePrice2";
            this.ComparativePrice2.ReadOnly = true;
            // 
            // ComparativePrice3
            // 
            this.ComparativePrice3.HeaderText = "Gf";
            this.ComparativePrice3.Name = "ComparativePrice3";
            this.ComparativePrice3.ReadOnly = true;
            // 
            // ComparativePrice4
            // 
            this.ComparativePrice4.HeaderText = "XCELL";
            this.ComparativePrice4.Name = "ComparativePrice4";
            this.ComparativePrice4.ReadOnly = true;
            // 
            // ComparativePrice5
            // 
            this.ComparativePrice5.HeaderText = "P4s-D";
            this.ComparativePrice5.Name = "ComparativePrice5";
            this.ComparativePrice5.ReadOnly = true;
            // 
            // CurrentLowestPrice
            // 
            this.CurrentLowestPrice.HeaderText = "CurrentLowestPrice";
            this.CurrentLowestPrice.Name = "CurrentLowestPrice";
            this.CurrentLowestPrice.ReadOnly = true;
            // 
            // UserLowestPrice
            // 
            this.UserLowestPrice.HeaderText = "UserLowestPrice";
            this.UserLowestPrice.Name = "UserLowestPrice";
            this.UserLowestPrice.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // View
            // 
            this.View.HeaderText = "View";
            this.View.Name = "View";
            this.View.ReadOnly = true;
            this.View.Text = "View";
            this.View.ToolTipText = "View";
            this.View.UseColumnTextForLinkValue = true;
            // 
            // Remove
            // 
            this.Remove.HeaderText = "Remove";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.Text = "Remove";
            this.Remove.ToolTipText = "Remove";
            this.Remove.UseColumnTextForLinkValue = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlBottom.Controls.Add(this.lblTotal);
            this.pnlBottom.Controls.Add(this.lblTotalHeader);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBottom.Location = new System.Drawing.Point(0, 416);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1119, 46);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(69, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 3;
            // 
            // lblTotalHeader
            // 
            this.lblTotalHeader.Location = new System.Drawing.Point(15, 6);
            this.lblTotalHeader.Name = "lblTotalHeader";
            this.lblTotalHeader.Size = new System.Drawing.Size(59, 20);
            this.lblTotalHeader.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.TabIndex = 2;
            this.lblTotalHeader.TabStop = false;
            this.lblTotalHeader.Values.Text = "Total :";
            // 
            // PnlTop
            // 
            this.PnlTop.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PnlTop.Controls.Add(this.lblto);
            this.PnlTop.Controls.Add(this.lblFrom);
            this.PnlTop.Controls.Add(this.label1);
            this.PnlTop.Controls.Add(this.dtTranTo);
            this.PnlTop.Controls.Add(this.dtTranFrom);
            this.PnlTop.Controls.Add(this.cmbTransactionsFilterDate);
            this.PnlTop.Controls.Add(this.btnExport);
            this.PnlTop.Controls.Add(this.btmClose);
            this.PnlTop.Controls.Add(this.btnSearch);
            this.PnlTop.Controls.Add(this.btnReset);
            this.PnlTop.Controls.Add(this.txtSearch);
            this.PnlTop.Controls.Add(this.label4);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(1119, 97);
            this.PnlTop.TabIndex = 0;
            this.PnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlTop_Paint);
            // 
            // lblto
            // 
            this.lblto.AutoSize = true;
            this.lblto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblto.Location = new System.Drawing.Point(458, 57);
            this.lblto.Name = "lblto";
            this.lblto.Size = new System.Drawing.Size(29, 14);
            this.lblto.TabIndex = 25;
            this.lblto.Text = "TO:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(288, 56);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(47, 14);
            this.lblFrom.TabIndex = 24;
            this.lblFrom.Text = "FROM:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "Filter:";
            // 
            // dtTranTo
            // 
            this.dtTranTo.CalendarTrailingForeColor = System.Drawing.Color.Gainsboro;
            this.dtTranTo.CustomFormat = "MM-dd-yyyy";
            this.dtTranTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTranTo.Location = new System.Drawing.Point(493, 53);
            this.dtTranTo.Name = "dtTranTo";
            this.dtTranTo.Size = new System.Drawing.Size(109, 23);
            this.dtTranTo.TabIndex = 22;
            this.dtTranTo.Visible = false;
            this.dtTranTo.Leave += new System.EventHandler(this.dtTranTo_Leave);
            // 
            // dtTranFrom
            // 
            this.dtTranFrom.CalendarTrailingForeColor = System.Drawing.Color.Gainsboro;
            this.dtTranFrom.CustomFormat = "MM-dd-yyyy";
            this.dtTranFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTranFrom.Location = new System.Drawing.Point(341, 53);
            this.dtTranFrom.Name = "dtTranFrom";
            this.dtTranFrom.Size = new System.Drawing.Size(109, 23);
            this.dtTranFrom.TabIndex = 21;
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
            this.cmbTransactionsFilterDate.Location = new System.Drawing.Point(67, 53);
            this.cmbTransactionsFilterDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbTransactionsFilterDate.Name = "cmbTransactionsFilterDate";
            this.cmbTransactionsFilterDate.Size = new System.Drawing.Size(197, 22);
            this.cmbTransactionsFilterDate.TabIndex = 20;
            this.cmbTransactionsFilterDate.SelectedIndexChanged += new System.EventHandler(this.cmbTransactionsFilterDate_SelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.Location = new System.Drawing.Point(1017, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExport.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExport.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExport.OverrideDefault.Border.Rounding = 3;
            this.btnExport.OverrideDefault.Border.Width = 1;
            this.btnExport.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnExport.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnExport.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExport.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExport.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExport.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExport.OverrideFocus.Border.Rounding = 3;
            this.btnExport.OverrideFocus.Border.Width = 1;
            this.btnExport.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnExport.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnExport.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Size = new System.Drawing.Size(90, 30);
            this.btnExport.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExport.StateCommon.Border.Rounding = 3;
            this.btnExport.StateCommon.Border.Width = 1;
            this.btnExport.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnExport.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnExport.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnExport.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnExport.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExport.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExport.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExport.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnExport.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnExport.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnExport.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnExport.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnExport.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnExport.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.TabIndex = 8;
            this.btnExport.Values.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btmClose
            // 
            this.btmClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btmClose.Location = new System.Drawing.Point(576, 7);
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
            this.btmClose.TabIndex = 4;
            this.btmClose.Values.Text = "Close";
            this.btmClose.Click += new System.EventHandler(this.btmClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Location = new System.Drawing.Point(384, 7);
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
            this.btnReset.Location = new System.Drawing.Point(480, 7);
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
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(90, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(280, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Look for";
            // 
            // FrmAdminRequestList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1119, 462);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmAdminRequestList";
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
            this.Text = "Request List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAdminRequestList_FormClosing);
            this.Load += new System.EventHandler(this.FrmAdminRequestList_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestList)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlGrid;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnReset;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btmClose;
        private System.Windows.Forms.DataGridView dgvRequestList;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotalHeader;
        private System.Windows.Forms.Label lblTotal;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExport;
        private System.Windows.Forms.Label lblto;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtTranTo;
        private System.Windows.Forms.DateTimePicker dtTranFrom;
        private System.Windows.Forms.ComboBox cmbTransactionsFilterDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesRepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComparativePrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComparativePrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComparativePrice3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComparativePrice4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComparativePrice5;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentLowestPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserLowestPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewLinkColumn View;
        private System.Windows.Forms.DataGridViewLinkColumn Remove;
    }
}

