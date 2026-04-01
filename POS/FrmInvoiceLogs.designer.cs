namespace POS
{
    partial class FrmInvoiceLogs
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
            this.cmbInvoiceDate = new System.Windows.Forms.ComboBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvAllInvoiceList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlInvDetails = new System.Windows.Forms.Panel();
            this.dgInvDetail = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceEach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldPriceEach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditCount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRefno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewRefNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewPONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldPONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewTermsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldTermsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewSalesRepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldSalesRepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewshipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldShipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewShipping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldShipping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewAppliedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldAppliedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewBalanceDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldBalanceDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInvoiceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlInvDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvDetail)).BeginInit();
            this.SuspendLayout();
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
            this.cmbInvoiceDate.Location = new System.Drawing.Point(75, 14);
            this.cmbInvoiceDate.Name = "cmbInvoiceDate";
            this.cmbInvoiceDate.Size = new System.Drawing.Size(153, 24);
            this.cmbInvoiceDate.TabIndex = 350;
            this.cmbInvoiceDate.SelectedIndexChanged += new System.EventHandler(this.cmbInvoiceDate_SelectedIndexChanged);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTo.Location = new System.Drawing.Point(414, 19);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(24, 16);
            this.lblTo.TabIndex = 355;
            this.lblTo.Text = "To";
            this.lblTo.Visible = false;
            // 
            // dtFrom
            // 
            this.dtFrom.CalendarTrailingForeColor = System.Drawing.Color.Gainsboro;
            this.dtFrom.CustomFormat = "MM-dd-yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(308, 17);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(100, 20);
            this.dtFrom.TabIndex = 351;
            this.dtFrom.Visible = false;
            this.dtFrom.Leave += new System.EventHandler(this.dtFrom_Leave);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFrom.Location = new System.Drawing.Point(263, 19);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(38, 16);
            this.lblFrom.TabIndex = 354;
            this.lblFrom.Text = "From";
            this.lblFrom.Visible = false;
            // 
            // dtTo
            // 
            this.dtTo.CalendarTrailingForeColor = System.Drawing.Color.Gainsboro;
            this.dtTo.CustomFormat = "MM-dd-yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(445, 17);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(100, 20);
            this.dtTo.TabIndex = 352;
            this.dtTo.Visible = false;
            this.dtTo.Leave += new System.EventHandler(this.dtTo_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(25, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 353;
            this.label3.Text = "Filter By";
            // 
            // dgvAllInvoiceList
            // 
            this.dgvAllInvoiceList.AllowUserToAddRows = false;
            this.dgvAllInvoiceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllInvoiceList.ColumnHeadersHeight = 29;
            this.dgvAllInvoiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.InvoiceID,
            this.NewRefNumber,
            this.NewCustomerName,
            this.OldCustomerName,
            this.NewPONumber,
            this.OldPONumber,
            this.NewTermsName,
            this.OldTermsName,
            this.NewDueDate,
            this.OldDueDate,
            this.NewSalesRepName,
            this.OldSalesRepName,
            this.NewshipDate,
            this.OldShipDate,
            this.NewShipping,
            this.OldShipping,
            this.NewTotal,
            this.OldTotal,
            this.NewAppliedAmount,
            this.OldAppliedAmount,
            this.NewBalanceDue,
            this.OldBalanceDue,
            this.NewMemo,
            this.OldMemo,
            this.EditCount,
            this.UpdateDate,
            this.View,
            this.Delete});
            this.dgvAllInvoiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllInvoiceList.Location = new System.Drawing.Point(0, 0);
            this.dgvAllInvoiceList.Name = "dgvAllInvoiceList";
            this.dgvAllInvoiceList.RowHeadersVisible = false;
            this.dgvAllInvoiceList.RowHeadersWidth = 51;
            this.dgvAllInvoiceList.Size = new System.Drawing.Size(1749, 700);
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
            this.dgvAllInvoiceList.TabIndex = 356;
            this.dgvAllInvoiceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllInvoiceList_CellContentClick);
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
            this.splitContainer1.Panel1.Controls.Add(this.cmbInvoiceDate);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lblTo);
            this.splitContainer1.Panel1.Controls.Add(this.dtTo);
            this.splitContainer1.Panel1.Controls.Add(this.dtFrom);
            this.splitContainer1.Panel1.Controls.Add(this.lblFrom);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlInvDetails);
            this.splitContainer1.Panel2.Controls.Add(this.dgvAllInvoiceList);
            this.splitContainer1.Size = new System.Drawing.Size(1749, 760);
            this.splitContainer1.SplitterDistance = 56;
            this.splitContainer1.TabIndex = 357;
            // 
            // pnlInvDetails
            // 
            this.pnlInvDetails.Controls.Add(this.dgInvDetail);
            this.pnlInvDetails.Controls.Add(this.lblRefno);
            this.pnlInvDetails.Controls.Add(this.label1);
            this.pnlInvDetails.Controls.Add(this.btnclose);
            this.pnlInvDetails.Controls.Add(this.panel8);
            this.pnlInvDetails.Controls.Add(this.panel7);
            this.pnlInvDetails.Controls.Add(this.panel6);
            this.pnlInvDetails.Controls.Add(this.panel5);
            this.pnlInvDetails.Location = new System.Drawing.Point(50, 41);
            this.pnlInvDetails.Name = "pnlInvDetails";
            this.pnlInvDetails.Size = new System.Drawing.Size(1545, 619);
            this.pnlInvDetails.TabIndex = 357;
            this.pnlInvDetails.Visible = false;
            // 
            // dgInvDetail
            // 
            this.dgInvDetail.AllowUserToAddRows = false;
            this.dgInvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInvDetail.ColumnHeadersHeight = 29;
            this.dgInvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.OldItemName,
            this.Description,
            this.OldDescription,
            this.Qty,
            this.OldQty,
            this.PriceEach,
            this.OldPriceEach,
            this.Amount,
            this.OldAmount,
            this.EditCount1,
            this.EditMode,
            this.UpdateDate1});
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
            this.dgInvDetail.TabIndex = 359;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.Name = "ItemName";
            // 
            // OldItemName
            // 
            this.OldItemName.HeaderText = "OldItemName";
            this.OldItemName.Name = "OldItemName";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // OldDescription
            // 
            this.OldDescription.HeaderText = "OldDescription";
            this.OldDescription.Name = "OldDescription";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            // 
            // OldQty
            // 
            this.OldQty.HeaderText = "OldQty";
            this.OldQty.Name = "OldQty";
            // 
            // PriceEach
            // 
            this.PriceEach.HeaderText = "PriceEach";
            this.PriceEach.Name = "PriceEach";
            // 
            // OldPriceEach
            // 
            this.OldPriceEach.HeaderText = "OldPriceEach";
            this.OldPriceEach.Name = "OldPriceEach";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // OldAmount
            // 
            this.OldAmount.HeaderText = "OldAmount";
            this.OldAmount.Name = "OldAmount";
            // 
            // EditCount1
            // 
            this.EditCount1.HeaderText = "EditCount";
            this.EditCount1.Name = "EditCount1";
            // 
            // EditMode
            // 
            this.EditMode.HeaderText = "EditMode";
            this.EditMode.Name = "EditMode";
            // 
            // UpdateDate1
            // 
            this.UpdateDate1.HeaderText = "UpdateDate";
            this.UpdateDate1.Name = "UpdateDate1";
            // 
            // lblRefno
            // 
            this.lblRefno.AutoSize = true;
            this.lblRefno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefno.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRefno.Location = new System.Drawing.Point(120, 19);
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
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // InvoiceID
            // 
            this.InvoiceID.HeaderText = "InvoiceID";
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.Visible = false;
            // 
            // NewRefNumber
            // 
            this.NewRefNumber.FillWeight = 103.195F;
            this.NewRefNumber.HeaderText = "RefNumber";
            this.NewRefNumber.Name = "NewRefNumber";
            // 
            // NewCustomerName
            // 
            this.NewCustomerName.FillWeight = 103.195F;
            this.NewCustomerName.HeaderText = "CustomerName";
            this.NewCustomerName.Name = "NewCustomerName";
            // 
            // OldCustomerName
            // 
            this.OldCustomerName.FillWeight = 103.195F;
            this.OldCustomerName.HeaderText = "OldCustomerName";
            this.OldCustomerName.Name = "OldCustomerName";
            // 
            // NewPONumber
            // 
            this.NewPONumber.FillWeight = 103.195F;
            this.NewPONumber.HeaderText = "PONumber";
            this.NewPONumber.Name = "NewPONumber";
            // 
            // OldPONumber
            // 
            this.OldPONumber.FillWeight = 103.195F;
            this.OldPONumber.HeaderText = "OldPONumber";
            this.OldPONumber.Name = "OldPONumber";
            // 
            // NewTermsName
            // 
            this.NewTermsName.FillWeight = 103.195F;
            this.NewTermsName.HeaderText = "TermsName";
            this.NewTermsName.Name = "NewTermsName";
            // 
            // OldTermsName
            // 
            this.OldTermsName.FillWeight = 103.195F;
            this.OldTermsName.HeaderText = "OldTermsName";
            this.OldTermsName.Name = "OldTermsName";
            // 
            // NewDueDate
            // 
            this.NewDueDate.FillWeight = 103.195F;
            this.NewDueDate.HeaderText = "DueDate";
            this.NewDueDate.Name = "NewDueDate";
            // 
            // OldDueDate
            // 
            this.OldDueDate.FillWeight = 103.195F;
            this.OldDueDate.HeaderText = "OldDueDate";
            this.OldDueDate.Name = "OldDueDate";
            // 
            // NewSalesRepName
            // 
            this.NewSalesRepName.FillWeight = 103.195F;
            this.NewSalesRepName.HeaderText = "SalesRepName";
            this.NewSalesRepName.Name = "NewSalesRepName";
            // 
            // OldSalesRepName
            // 
            this.OldSalesRepName.FillWeight = 103.195F;
            this.OldSalesRepName.HeaderText = "OldSalesRepName";
            this.OldSalesRepName.Name = "OldSalesRepName";
            // 
            // NewshipDate
            // 
            this.NewshipDate.FillWeight = 103.195F;
            this.NewshipDate.HeaderText = "shipDate";
            this.NewshipDate.Name = "NewshipDate";
            // 
            // OldShipDate
            // 
            this.OldShipDate.FillWeight = 103.195F;
            this.OldShipDate.HeaderText = "OldShipDate";
            this.OldShipDate.Name = "OldShipDate";
            // 
            // NewShipping
            // 
            this.NewShipping.FillWeight = 103.195F;
            this.NewShipping.HeaderText = "ShippingVia";
            this.NewShipping.Name = "NewShipping";
            // 
            // OldShipping
            // 
            this.OldShipping.FillWeight = 103.195F;
            this.OldShipping.HeaderText = "OldShippingVia";
            this.OldShipping.Name = "OldShipping";
            // 
            // NewTotal
            // 
            this.NewTotal.HeaderText = "Total";
            this.NewTotal.Name = "NewTotal";
            // 
            // OldTotal
            // 
            this.OldTotal.HeaderText = "OldTotal";
            this.OldTotal.Name = "OldTotal";
            // 
            // NewAppliedAmount
            // 
            this.NewAppliedAmount.HeaderText = "AppliedAmount";
            this.NewAppliedAmount.Name = "NewAppliedAmount";
            // 
            // OldAppliedAmount
            // 
            this.OldAppliedAmount.HeaderText = "OldAppliedAmount";
            this.OldAppliedAmount.Name = "OldAppliedAmount";
            // 
            // NewBalanceDue
            // 
            this.NewBalanceDue.HeaderText = "BalanceDue";
            this.NewBalanceDue.Name = "NewBalanceDue";
            // 
            // OldBalanceDue
            // 
            this.OldBalanceDue.HeaderText = "OldBalanceDue";
            this.OldBalanceDue.Name = "OldBalanceDue";
            // 
            // NewMemo
            // 
            this.NewMemo.HeaderText = "Memo";
            this.NewMemo.Name = "NewMemo";
            // 
            // OldMemo
            // 
            this.OldMemo.HeaderText = "OldMemo";
            this.OldMemo.Name = "OldMemo";
            // 
            // EditCount
            // 
            this.EditCount.FillWeight = 103.195F;
            this.EditCount.HeaderText = "EditCount";
            this.EditCount.Name = "EditCount";
            // 
            // UpdateDate
            // 
            this.UpdateDate.FillWeight = 103.195F;
            this.UpdateDate.HeaderText = "UpdateDate";
            this.UpdateDate.Name = "UpdateDate";
            // 
            // View
            // 
            this.View.FillWeight = 45.68528F;
            this.View.HeaderText = "View";
            this.View.Name = "View";
            this.View.Text = "View";
            this.View.ToolTipText = "View";
            this.View.UseColumnTextForLinkValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.ToolTipText = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            // 
            // FrmInvoiceLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1749, 760);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmInvoiceLogs";
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
            this.Text = "Invoice Logs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCustomerLogs_FormClosing);
            this.Load += new System.EventHandler(this.FrmCustomerLogs_Load);
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
        private System.Windows.Forms.ComboBox cmbInvoiceDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvAllInvoiceList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlInvDetails;
        private System.Windows.Forms.Label lblRefno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgInvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceEach;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldPriceEach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditCount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewRefNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewPONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldPONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewTermsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldTermsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewDueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldDueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewSalesRepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldSalesRepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewshipDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldShipDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewShipping;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldShipping;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewAppliedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldAppliedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewBalanceDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldBalanceDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDate;
        private System.Windows.Forms.DataGridViewLinkColumn View;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
}

