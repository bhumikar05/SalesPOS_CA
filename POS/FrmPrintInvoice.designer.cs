namespace POS
{
    partial class FrmPrintInvoice
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
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.dgvInvoiceList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REFNUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TXNDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALESREP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoad = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblErrorMsg = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.btnPrint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnPrinterSettings = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.chkAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceList)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.Enabled = false;
            this.cmbCustomer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(87, 57);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(220, 24);
            this.cmbCustomer.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Customer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(338, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "InvoiceNo";
            // 
            // txtRefNo
            // 
            this.txtRefNo.Enabled = false;
            this.txtRefNo.Location = new System.Drawing.Point(413, 25);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(122, 20);
            this.txtRefNo.TabIndex = 29;
            // 
            // dgvInvoiceList
            // 
            this.dgvInvoiceList.AllowUserToAddRows = false;
            this.dgvInvoiceList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvInvoiceList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoiceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoiceList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInvoiceList.ColumnHeadersHeight = 30;
            this.dgvInvoiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.chkSelect,
            this.CustomerName,
            this.REFNUMBER,
            this.TXNDATE,
            this.SALESREP,
            this.TOTAL});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoiceList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInvoiceList.GridColor = System.Drawing.SystemColors.Control;
            this.dgvInvoiceList.Location = new System.Drawing.Point(12, 110);
            this.dgvInvoiceList.MultiSelect = false;
            this.dgvInvoiceList.Name = "dgvInvoiceList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInvoiceList.RowHeadersVisible = false;
            this.dgvInvoiceList.RowHeadersWidth = 15;
            this.dgvInvoiceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceList.Size = new System.Drawing.Size(851, 275);
            this.dgvInvoiceList.TabIndex = 30;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // chkSelect
            // 
            this.chkSelect.HeaderText = "";
            this.chkSelect.Name = "chkSelect";
            // 
            // CustomerName
            // 
            this.CustomerName.FillWeight = 113.9086F;
            this.CustomerName.HeaderText = "NAME";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // REFNUMBER
            // 
            this.REFNUMBER.HeaderText = "REFNUMBER";
            this.REFNUMBER.Name = "REFNUMBER";
            // 
            // TXNDATE
            // 
            this.TXNDATE.HeaderText = "TXNDATE";
            this.TXNDATE.Name = "TXNDATE";
            // 
            // SALESREP
            // 
            this.SALESREP.HeaderText = "SALESREP";
            this.SALESREP.Name = "SALESREP";
            // 
            // TOTAL
            // 
            this.TOTAL.HeaderText = "TOTAL";
            this.TOTAL.Name = "TOTAL";
            // 
            // btnLoad
            // 
            this.btnLoad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoad.Location = new System.Drawing.Point(541, 57);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnLoad.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnLoad.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLoad.OverrideDefault.Border.Rounding = 3;
            this.btnLoad.OverrideDefault.Border.Width = 1;
            this.btnLoad.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnLoad.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnLoad.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLoad.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnLoad.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnLoad.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLoad.OverrideFocus.Border.Rounding = 3;
            this.btnLoad.OverrideFocus.Border.Width = 1;
            this.btnLoad.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnLoad.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnLoad.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Size = new System.Drawing.Size(85, 32);
            this.btnLoad.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.btnLoad.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.btnLoad.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLoad.StateCommon.Border.Rounding = 3;
            this.btnLoad.StateCommon.Border.Width = 1;
            this.btnLoad.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnLoad.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnLoad.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnLoad.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnLoad.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnLoad.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnLoad.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLoad.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnLoad.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnLoad.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnLoad.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnLoad.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnLoad.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnLoad.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnLoad.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.TabIndex = 31;
            this.btnLoad.Values.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(87, 22);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(168, 24);
            this.cmbFilter.TabIndex = 331;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 332;
            this.label1.Text = "FilterType";
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = false;
            this.lblErrorMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblErrorMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMsg.Location = new System.Drawing.Point(0, 386);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(881, 30);
            this.lblErrorMsg.StateCommon.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMsg.StateNormal.TextColor = System.Drawing.Color.Red;
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(778, 57);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPrint.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPrint.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrint.OverrideDefault.Border.Rounding = 3;
            this.btnPrint.OverrideDefault.Border.Width = 1;
            this.btnPrint.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrint.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrint.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPrint.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPrint.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrint.OverrideFocus.Border.Rounding = 3;
            this.btnPrint.OverrideFocus.Border.Width = 1;
            this.btnPrint.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrint.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrint.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Size = new System.Drawing.Size(85, 32);
            this.btnPrint.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.btnPrint.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.btnPrint.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrint.StateCommon.Border.Rounding = 3;
            this.btnPrint.StateCommon.Border.Width = 1;
            this.btnPrint.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrint.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrint.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrint.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrint.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPrint.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPrint.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrint.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrint.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrint.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrint.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrint.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrint.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrint.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.TabIndex = 333;
            this.btnPrint.Values.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrinterSettings
            // 
            this.btnPrinterSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrinterSettings.Location = new System.Drawing.Point(632, 57);
            this.btnPrinterSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrinterSettings.Name = "btnPrinterSettings";
            this.btnPrinterSettings.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPrinterSettings.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPrinterSettings.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrinterSettings.OverrideDefault.Border.Rounding = 3;
            this.btnPrinterSettings.OverrideDefault.Border.Width = 1;
            this.btnPrinterSettings.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrinterSettings.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrinterSettings.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrinterSettings.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPrinterSettings.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPrinterSettings.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrinterSettings.OverrideFocus.Border.Rounding = 3;
            this.btnPrinterSettings.OverrideFocus.Border.Width = 1;
            this.btnPrinterSettings.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrinterSettings.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrinterSettings.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinterSettings.Size = new System.Drawing.Size(140, 32);
            this.btnPrinterSettings.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.btnPrinterSettings.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.btnPrinterSettings.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrinterSettings.StateCommon.Border.Rounding = 3;
            this.btnPrinterSettings.StateCommon.Border.Width = 1;
            this.btnPrinterSettings.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrinterSettings.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrinterSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinterSettings.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrinterSettings.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrinterSettings.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinterSettings.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPrinterSettings.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPrinterSettings.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrinterSettings.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrinterSettings.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrinterSettings.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinterSettings.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrinterSettings.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrinterSettings.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinterSettings.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrinterSettings.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnPrinterSettings.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnPrinterSettings.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinterSettings.TabIndex = 334;
            this.btnPrinterSettings.Values.Text = "Printer Settings";
            this.btnPrinterSettings.Click += new System.EventHandler(this.btnPrinterSettings_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(42, 119);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(71, 17);
            this.chkAll.TabIndex = 336;
            this.chkAll.Text = "Check All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // FrmPrintInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 416);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnPrinterSettings);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblErrorMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgvInvoiceList);
            this.Controls.Add(this.txtRefNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmPrintInvoice";
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
            this.Text = "Multiple Invoice Print";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrintInvoice_FormClosing);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.DataGridView dgvInvoiceList;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLoad;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lblErrorMsg;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrint;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrinterSettings;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn REFNUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn TXNDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALESREP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.CheckBox chkAll;
    }
}

