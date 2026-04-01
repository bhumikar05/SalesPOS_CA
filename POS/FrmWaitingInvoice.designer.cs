namespace POS
{
    partial class FrmWaitingInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.radLabel60 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel61 = new Telerik.WinControls.UI.RadLabel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.dgvAllInvoiceList = new System.Windows.Forms.DataGridView();
            this.InvID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOfInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Term = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIA_Services = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PendingInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Print1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Paid = new System.Windows.Forms.DataGridViewLinkColumn();
            this.InvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfitPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipped = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ShipCharges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInvoiceList)).BeginInit();
            this.SuspendLayout();
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
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // dgvAllInvoiceList
            // 
            this.dgvAllInvoiceList.AllowUserToAddRows = false;
            this.dgvAllInvoiceList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Lavender;
            this.dgvAllInvoiceList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvAllInvoiceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllInvoiceList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllInvoiceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvAllInvoiceList.ColumnHeadersHeight = 29;
            this.dgvAllInvoiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvID,
            this.CustomerID,
            this.NoOfInvoice,
            this.CountEdit,
            this.OpenBalance,
            this.Profit,
            this.InvoiceDate,
            this.TIME,
            this.CustomerNm,
            this.InvoiceNum,
            this.DueDate,
            this.Term,
            this.Rep,
            this.VIA_Services,
            this.Error,
            this.PaidStatus,
            this.PendingInvoice,
            this.Print1,
            this.Paid,
            this.InvoiceAmount,
            this.ShippingCost,
            this.ProfitPercentage,
            this.Shipped,
            this.ShipCharges,
            this.ShipStatus,
            this.Add});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllInvoiceList.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvAllInvoiceList.GridColor = System.Drawing.SystemColors.Control;
            this.dgvAllInvoiceList.Location = new System.Drawing.Point(0, 65);
            this.dgvAllInvoiceList.MultiSelect = false;
            this.dgvAllInvoiceList.Name = "dgvAllInvoiceList";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllInvoiceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvAllInvoiceList.RowHeadersVisible = false;
            this.dgvAllInvoiceList.RowHeadersWidth = 15;
            this.dgvAllInvoiceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllInvoiceList.Size = new System.Drawing.Size(1442, 433);
            this.dgvAllInvoiceList.TabIndex = 2;
            this.dgvAllInvoiceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllInvoiceList_CellContentClick);
            this.dgvAllInvoiceList.DoubleClick += new System.EventHandler(this.dgvAllInvoiceList_DoubleClick);
            // 
            // InvID
            // 
            this.InvID.HeaderText = "ID";
            this.InvID.Name = "InvID";
            this.InvID.Visible = false;
            // 
            // CustomerID
            // 
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Visible = false;
            // 
            // NoOfInvoice
            // 
            this.NoOfInvoice.HeaderText = "NoOfInvoice";
            this.NoOfInvoice.Name = "NoOfInvoice";
            // 
            // CountEdit
            // 
            this.CountEdit.HeaderText = "No Of Times Edit";
            this.CountEdit.Name = "CountEdit";
            // 
            // OpenBalance
            // 
            this.OpenBalance.HeaderText = "OPEN BALANCE";
            this.OpenBalance.Name = "OpenBalance";
            // 
            // Profit
            // 
            this.Profit.HeaderText = "Profit";
            this.Profit.Name = "Profit";
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.HeaderText = "DATE";
            this.InvoiceDate.Name = "InvoiceDate";
            // 
            // TIME
            // 
            this.TIME.HeaderText = "TIME";
            this.TIME.Name = "TIME";
            // 
            // CustomerNm
            // 
            this.CustomerNm.HeaderText = "CUSTOMER";
            this.CustomerNm.Name = "CustomerNm";
            // 
            // InvoiceNum
            // 
            this.InvoiceNum.HeaderText = "NUM";
            this.InvoiceNum.Name = "InvoiceNum";
            // 
            // DueDate
            // 
            this.DueDate.HeaderText = "DUE DATE";
            this.DueDate.Name = "DueDate";
            // 
            // Term
            // 
            this.Term.HeaderText = "TERMS";
            this.Term.Name = "Term";
            // 
            // Rep
            // 
            this.Rep.HeaderText = "SalesRep";
            this.Rep.Name = "Rep";
            // 
            // VIA_Services
            // 
            this.VIA_Services.HeaderText = "VIA_Services";
            this.VIA_Services.Name = "VIA_Services";
            // 
            // Error
            // 
            this.Error.HeaderText = "ErrorLog";
            this.Error.Name = "Error";
            // 
            // PaidStatus
            // 
            this.PaidStatus.HeaderText = "PaidStatus";
            this.PaidStatus.Name = "PaidStatus";
            // 
            // PendingInvoice
            // 
            this.PendingInvoice.HeaderText = "PendingInvoice";
            this.PendingInvoice.Name = "PendingInvoice";
            // 
            // Print1
            // 
            this.Print1.HeaderText = "Print";
            this.Print1.Name = "Print1";
            this.Print1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Print1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Print1.Text = "Print";
            this.Print1.ToolTipText = "Print";
            this.Print1.UseColumnTextForLinkValue = true;
            // 
            // Paid
            // 
            this.Paid.HeaderText = "Pay it";
            this.Paid.Name = "Paid";
            this.Paid.Text = "Pay it";
            this.Paid.ToolTipText = "Pay it";
            this.Paid.UseColumnTextForLinkValue = true;
            // 
            // InvoiceAmount
            // 
            this.InvoiceAmount.HeaderText = "AMOUNT";
            this.InvoiceAmount.Name = "InvoiceAmount";
            // 
            // ShippingCost
            // 
            this.ShippingCost.HeaderText = "ShippingCost";
            this.ShippingCost.Name = "ShippingCost";
            // 
            // ProfitPercentage
            // 
            this.ProfitPercentage.HeaderText = "Profit %";
            this.ProfitPercentage.Name = "ProfitPercentage";
            // 
            // Shipped
            // 
            this.Shipped.HeaderText = "Ship it";
            this.Shipped.Name = "Shipped";
            this.Shipped.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Shipped.Text = "Ship it";
            this.Shipped.ToolTipText = "Ship it";
            this.Shipped.UseColumnTextForLinkValue = true;
            // 
            // ShipCharges
            // 
            this.ShipCharges.HeaderText = "ShipCharges";
            this.ShipCharges.Name = "ShipCharges";
            // 
            // ShipStatus
            // 
            this.ShipStatus.HeaderText = "ShipStatus";
            this.ShipStatus.Name = "ShipStatus";
            this.ShipStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ShipStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Add
            // 
            this.Add.HeaderText = "Add Status";
            this.Add.Name = "Add";
            this.Add.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Add.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Add.Text = "Add";
            this.Add.ToolTipText = "Add ";
            this.Add.UseColumnTextForButtonValue = true;
            // 
            // btnExport
            // 
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.Location = new System.Drawing.Point(1340, 12);
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
            this.btnExport.TabIndex = 9;
            this.btnExport.Values.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FrmWaitingInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1442, 498);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvAllInvoiceList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmWaitingInvoice";
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
            this.Text = "Waiting Invoice";
            this.Load += new System.EventHandler(this.FrmWaitingInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInvoiceList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private Telerik.WinControls.UI.RadLabel radLabel60;
        private Telerik.WinControls.UI.RadLabel radLabel61;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.DataGridView dgvAllInvoiceList;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOfInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Term;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rep;
        private System.Windows.Forms.DataGridViewTextBoxColumn VIA_Services;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PendingInvoice;
        private System.Windows.Forms.DataGridViewLinkColumn Print1;
        private System.Windows.Forms.DataGridViewLinkColumn Paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippingCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfitPercentage;
        private System.Windows.Forms.DataGridViewLinkColumn Shipped;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipCharges;
        private System.Windows.Forms.DataGridViewComboBoxColumn ShipStatus;
        private System.Windows.Forms.DataGridViewButtonColumn Add;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExport;
    }
}

