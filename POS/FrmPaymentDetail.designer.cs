namespace POS
{
    partial class FrmPaymentDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPaymentDetail));
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlEntry = new System.Windows.Forms.Panel();
            this.btnSaveAndNew = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblErrorMsg1 = new System.Windows.Forms.Label();
            this.btnApplyCredit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApplyCredit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblPayAmt = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblDueAmt = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblTotalAmt = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblDue = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblPay = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dgvCreditMemoPaymentList = new System.Windows.Forms.DataGridView();
            this.ID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditMemoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditPayAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnReset = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvApplyamount = new System.Windows.Forms.DataGridView();
            this.InvID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectAll = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmtApplied = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppliedBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Print = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvInvoicePaymentList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.IsQBSync = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvPrint = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnApplyCreditCard = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnUpdate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnlTopEntry = new System.Windows.Forms.Panel();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.lblRef = new System.Windows.Forms.Label();
            this.txtRemainingAmt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTranID = new System.Windows.Forms.TextBox();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.txtInvID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbPayMethod = new System.Windows.Forms.ComboBox();
            this.txtPaidAmt = new System.Windows.Forms.TextBox();
            this.txtunPaid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalamt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbInvoiceNo = new System.Windows.Forms.ComboBox();
            this.txtCreditAmt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSave1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblErrorMsg = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.pnlMain.SuspendLayout();
            this.pnlEntry.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditMemoPaymentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyamount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicePaymentList)).BeginInit();
            this.pnlTopEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlEntry);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1820, 926);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlEntry
            // 
            this.pnlEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEntry.Controls.Add(this.btnSaveAndNew);
            this.pnlEntry.Controls.Add(this.lblErrorMsg1);
            this.pnlEntry.Controls.Add(this.btnApplyCredit);
            this.pnlEntry.Controls.Add(this.label3);
            this.pnlEntry.Controls.Add(this.txtApplyCredit);
            this.pnlEntry.Controls.Add(this.label8);
            this.pnlEntry.Controls.Add(this.label6);
            this.pnlEntry.Controls.Add(this.groupBox3);
            this.pnlEntry.Controls.Add(this.dgvCreditMemoPaymentList);
            this.pnlEntry.Controls.Add(this.btnReset);
            this.pnlEntry.Controls.Add(this.splitContainer1);
            this.pnlEntry.Controls.Add(this.btnApplyCreditCard);
            this.pnlEntry.Controls.Add(this.btnUpdate);
            this.pnlEntry.Controls.Add(this.pnlTopEntry);
            this.pnlEntry.Controls.Add(this.btnSave1);
            this.pnlEntry.Location = new System.Drawing.Point(0, 0);
            this.pnlEntry.Name = "pnlEntry";
            this.pnlEntry.Size = new System.Drawing.Size(1820, 926);
            this.pnlEntry.TabIndex = 1;
            this.pnlEntry.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlEntry_Paint);
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveAndNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveAndNew.Location = new System.Drawing.Point(1416, 884);
            this.btnSaveAndNew.Name = "btnSaveAndNew";
            this.btnSaveAndNew.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnSaveAndNew.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnSaveAndNew.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSaveAndNew.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSaveAndNew.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSaveAndNew.OverrideDefault.Border.Rounding = 3;
            this.btnSaveAndNew.OverrideDefault.Border.Width = 1;
            this.btnSaveAndNew.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSaveAndNew.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSaveAndNew.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveAndNew.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnSaveAndNew.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnSaveAndNew.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSaveAndNew.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSaveAndNew.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSaveAndNew.OverrideFocus.Border.Rounding = 3;
            this.btnSaveAndNew.OverrideFocus.Border.Width = 1;
            this.btnSaveAndNew.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSaveAndNew.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSaveAndNew.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndNew.Size = new System.Drawing.Size(123, 30);
            this.btnSaveAndNew.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSaveAndNew.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnSaveAndNew.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSaveAndNew.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSaveAndNew.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSaveAndNew.StateCommon.Border.Rounding = 3;
            this.btnSaveAndNew.StateCommon.Border.Width = 1;
            this.btnSaveAndNew.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSaveAndNew.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSaveAndNew.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndNew.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSaveAndNew.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnSaveAndNew.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSaveAndNew.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSaveAndNew.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndNew.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSaveAndNew.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSaveAndNew.StateNormal.Border.Color1 = System.Drawing.Color.Transparent;
            this.btnSaveAndNew.StateNormal.Border.Color2 = System.Drawing.Color.Transparent;
            this.btnSaveAndNew.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSaveAndNew.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSaveAndNew.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSaveAndNew.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndNew.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSaveAndNew.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnSaveAndNew.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSaveAndNew.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSaveAndNew.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndNew.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSaveAndNew.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnSaveAndNew.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSaveAndNew.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSaveAndNew.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndNew.TabIndex = 257;
            this.btnSaveAndNew.Values.Text = "Save And New";
            this.btnSaveAndNew.Click += new System.EventHandler(this.btnSaveAndNew_Click_1);
            // 
            // lblErrorMsg1
            // 
            this.lblErrorMsg1.AutoSize = true;
            this.lblErrorMsg1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMsg1.ForeColor = System.Drawing.Color.Black;
            this.lblErrorMsg1.Location = new System.Drawing.Point(11, 891);
            this.lblErrorMsg1.Name = "lblErrorMsg1";
            this.lblErrorMsg1.Size = new System.Drawing.Size(0, 14);
            this.lblErrorMsg1.TabIndex = 255;
            // 
            // btnApplyCredit
            // 
            this.btnApplyCredit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApplyCredit.Location = new System.Drawing.Point(3, 785);
            this.btnApplyCredit.Margin = new System.Windows.Forms.Padding(0);
            this.btnApplyCredit.Name = "btnApplyCredit";
            this.btnApplyCredit.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnApplyCredit.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnApplyCredit.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnApplyCredit.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnApplyCredit.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnApplyCredit.OverrideDefault.Border.Rounding = 3;
            this.btnApplyCredit.OverrideDefault.Border.Width = 1;
            this.btnApplyCredit.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnApplyCredit.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCredit.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnApplyCredit.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnApplyCredit.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnApplyCredit.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnApplyCredit.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnApplyCredit.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnApplyCredit.OverrideFocus.Border.Rounding = 3;
            this.btnApplyCredit.OverrideFocus.Border.Width = 1;
            this.btnApplyCredit.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnApplyCredit.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCredit.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyCredit.Size = new System.Drawing.Size(131, 24);
            this.btnApplyCredit.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnApplyCredit.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnApplyCredit.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnApplyCredit.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnApplyCredit.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnApplyCredit.StateCommon.Border.Rounding = 3;
            this.btnApplyCredit.StateCommon.Border.Width = 1;
            this.btnApplyCredit.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnApplyCredit.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCredit.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyCredit.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnApplyCredit.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnApplyCredit.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnApplyCredit.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCredit.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyCredit.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.btnApplyCredit.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.btnApplyCredit.StateNormal.Border.Color1 = System.Drawing.Color.Transparent;
            this.btnApplyCredit.StateNormal.Border.Color2 = System.Drawing.Color.Transparent;
            this.btnApplyCredit.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnApplyCredit.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnApplyCredit.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCredit.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyCredit.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnApplyCredit.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnApplyCredit.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnApplyCredit.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCredit.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 1.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyCredit.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnApplyCredit.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnApplyCredit.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnApplyCredit.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCredit.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyCredit.TabIndex = 72;
            this.btnApplyCredit.Values.Text = "Apply CreditMemo";
            this.btnApplyCredit.Click += new System.EventHandler(this.btnApplyCredit_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.label3.Font = new System.Drawing.Font("Verdana", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 197);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(1821, 17);
            this.label3.TabIndex = 64;
            this.label3.Text = "Customer Invoice";
            // 
            // txtApplyCredit
            // 
            this.txtApplyCredit.Enabled = false;
            this.txtApplyCredit.Location = new System.Drawing.Point(181, 840);
            this.txtApplyCredit.Name = "txtApplyCredit";
            this.txtApplyCredit.ReadOnly = true;
            this.txtApplyCredit.Size = new System.Drawing.Size(101, 21);
            this.txtApplyCredit.TabIndex = 71;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.label8.Font = new System.Drawing.Font("Verdana", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 597);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.label8.Size = new System.Drawing.Size(1821, 20);
            this.label8.TabIndex = 72;
            this.label8.Text = "Credit Memo PaymentDetail";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(6, 840);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 16);
            this.label6.TabIndex = 70;
            this.label6.Text = "CreditMemo TotalAmount :-";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.lblPayAmt);
            this.groupBox3.Controls.Add(this.lblDueAmt);
            this.groupBox3.Controls.Add(this.lblTotalAmt);
            this.groupBox3.Controls.Add(this.lblDue);
            this.groupBox3.Controls.Add(this.lblPay);
            this.groupBox3.Location = new System.Drawing.Point(1416, 788);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 90);
            this.groupBox3.TabIndex = 254;
            this.groupBox3.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(113, 20);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(82, 19);
            this.lblTotal.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotal.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotal.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotal.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotal.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.TabIndex = 58;
            this.lblTotal.TabStop = false;
            this.lblTotal.Values.Text = "Total Amt:-";
            // 
            // lblPayAmt
            // 
            this.lblPayAmt.Location = new System.Drawing.Point(348, 70);
            this.lblPayAmt.Name = "lblPayAmt";
            this.lblPayAmt.Size = new System.Drawing.Size(39, 19);
            this.lblPayAmt.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblPayAmt.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblPayAmt.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayAmt.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblPayAmt.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblPayAmt.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayAmt.TabIndex = 63;
            this.lblPayAmt.TabStop = false;
            this.lblPayAmt.Values.Text = "0.00";
            // 
            // lblDueAmt
            // 
            this.lblDueAmt.Location = new System.Drawing.Point(348, 45);
            this.lblDueAmt.Name = "lblDueAmt";
            this.lblDueAmt.Size = new System.Drawing.Size(39, 19);
            this.lblDueAmt.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblDueAmt.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblDueAmt.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueAmt.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblDueAmt.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblDueAmt.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueAmt.TabIndex = 61;
            this.lblDueAmt.TabStop = false;
            this.lblDueAmt.Values.Text = "0.00";
            // 
            // lblTotalAmt
            // 
            this.lblTotalAmt.Location = new System.Drawing.Point(348, 20);
            this.lblTotalAmt.Name = "lblTotalAmt";
            this.lblTotalAmt.Size = new System.Drawing.Size(39, 19);
            this.lblTotalAmt.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalAmt.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalAmt.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmt.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalAmt.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalAmt.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmt.TabIndex = 59;
            this.lblTotalAmt.TabStop = false;
            this.lblTotalAmt.Values.Text = "0.00";
            // 
            // lblDue
            // 
            this.lblDue.Location = new System.Drawing.Point(113, 45);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(107, 19);
            this.lblDue.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblDue.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblDue.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDue.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblDue.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblDue.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDue.TabIndex = 60;
            this.lblDue.TabStop = false;
            this.lblDue.Values.Text = "Total DueAmt:-";
            // 
            // lblPay
            // 
            this.lblPay.Location = new System.Drawing.Point(116, 70);
            this.lblPay.Name = "lblPay";
            this.lblPay.Size = new System.Drawing.Size(104, 19);
            this.lblPay.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblPay.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblPay.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPay.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblPay.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblPay.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPay.TabIndex = 62;
            this.lblPay.TabStop = false;
            this.lblPay.Values.Text = "Total PayAmt:-";
            // 
            // dgvCreditMemoPaymentList
            // 
            this.dgvCreditMemoPaymentList.AllowUserToAddRows = false;
            this.dgvCreditMemoPaymentList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvCreditMemoPaymentList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCreditMemoPaymentList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCreditMemoPaymentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCreditMemoPaymentList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCreditMemoPaymentList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCreditMemoPaymentList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCreditMemoPaymentList.ColumnHeadersHeight = 30;
            this.dgvCreditMemoPaymentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID1,
            this.CreditMemoID,
            this.CreditNumber,
            this.CreditDate,
            this.CreditPayAmount,
            this.CreditDelete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCreditMemoPaymentList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCreditMemoPaymentList.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCreditMemoPaymentList.Location = new System.Drawing.Point(-1, 615);
            this.dgvCreditMemoPaymentList.MultiSelect = false;
            this.dgvCreditMemoPaymentList.Name = "dgvCreditMemoPaymentList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCreditMemoPaymentList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCreditMemoPaymentList.RowHeadersVisible = false;
            this.dgvCreditMemoPaymentList.RowHeadersWidth = 15;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvCreditMemoPaymentList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCreditMemoPaymentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCreditMemoPaymentList.Size = new System.Drawing.Size(1822, 167);
            this.dgvCreditMemoPaymentList.TabIndex = 68;
            this.dgvCreditMemoPaymentList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCreditMemoPaymentList_CellContentClick);
            // 
            // ID1
            // 
            this.ID1.HeaderText = "ID";
            this.ID1.Name = "ID1";
            this.ID1.Visible = false;
            // 
            // CreditMemoID
            // 
            this.CreditMemoID.HeaderText = "CreditMemoID";
            this.CreditMemoID.Name = "CreditMemoID";
            this.CreditMemoID.Visible = false;
            // 
            // CreditNumber
            // 
            this.CreditNumber.HeaderText = "CreditNumber";
            this.CreditNumber.Name = "CreditNumber";
            // 
            // CreditDate
            // 
            this.CreditDate.HeaderText = "CreditDate";
            this.CreditDate.Name = "CreditDate";
            // 
            // CreditPayAmount
            // 
            this.CreditPayAmount.HeaderText = "CreditAmount";
            this.CreditPayAmount.Name = "CreditPayAmount";
            // 
            // CreditDelete
            // 
            this.CreditDelete.HeaderText = "Delete";
            this.CreditDelete.Name = "CreditDelete";
            this.CreditDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CreditDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CreditDelete.Text = "Delete";
            this.CreditDelete.ToolTipText = "Delete";
            this.CreditDelete.UseColumnTextForLinkValue = true;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.Location = new System.Drawing.Point(1724, 884);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnReset.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnReset.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReset.OverrideDefault.Border.Rounding = 3;
            this.btnReset.OverrideDefault.Border.Width = 1;
            this.btnReset.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnReset.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnReset.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnReset.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnReset.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReset.OverrideFocus.Border.Rounding = 3;
            this.btnReset.OverrideFocus.Border.Width = 1;
            this.btnReset.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnReset.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnReset.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Size = new System.Drawing.Size(85, 32);
            this.btnReset.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.btnReset.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.btnReset.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReset.StateCommon.Border.Rounding = 3;
            this.btnReset.StateCommon.Border.Width = 1;
            this.btnReset.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnReset.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnReset.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnReset.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnReset.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnReset.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnReset.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReset.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnReset.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnReset.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnReset.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnReset.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnReset.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnReset.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.TabIndex = 253;
            this.btnReset.Values.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(-1, 213);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1817, 381);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvApplyamount);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2321, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvApplyamount
            // 
            this.dgvApplyamount.AllowUserToAddRows = false;
            this.dgvApplyamount.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dgvApplyamount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvApplyamount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApplyamount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplyamount.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvApplyamount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApplyamount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvApplyamount.ColumnHeadersHeight = 30;
            this.dgvApplyamount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvID,
            this.SelectAll,
            this.Date,
            this.Number,
            this.TotalAmt,
            this.AvailableBalance,
            this.AmtApplied,
            this.AppliedBalance,
            this.Print});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvApplyamount.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvApplyamount.GridColor = System.Drawing.SystemColors.Control;
            this.dgvApplyamount.Location = new System.Drawing.Point(-3, -3);
            this.dgvApplyamount.MultiSelect = false;
            this.dgvApplyamount.Name = "dgvApplyamount";
            this.dgvApplyamount.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApplyamount.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvApplyamount.RowHeadersVisible = false;
            this.dgvApplyamount.RowHeadersWidth = 15;
            this.dgvApplyamount.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvApplyamount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplyamount.Size = new System.Drawing.Size(1822, 183);
            this.dgvApplyamount.TabIndex = 57;
            this.dgvApplyamount.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplyamount_CellContentClick);
            this.dgvApplyamount.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplyamount_CellDoubleClick);
            this.dgvApplyamount.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplyamount_CellEndEdit);
            this.dgvApplyamount.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplyamount_CellValueChanged);
            // 
            // InvID
            // 
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.InvID.DefaultCellStyle = dataGridViewCellStyle8;
            this.InvID.HeaderText = "ID";
            this.InvID.Name = "InvID";
            this.InvID.ReadOnly = true;
            this.InvID.Visible = false;
            // 
            // SelectAll
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.NullValue = false;
            this.SelectAll.DefaultCellStyle = dataGridViewCellStyle9;
            this.SelectAll.FillWeight = 30.45685F;
            this.SelectAll.HeaderText = "✔";
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.ReadOnly = true;
            this.SelectAll.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectAll.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Date
            // 
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.Date.DefaultCellStyle = dataGridViewCellStyle10;
            this.Date.FillWeight = 113.9086F;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Number
            // 
            this.Number.FillWeight = 113.9086F;
            this.Number.HeaderText = "RefNumber";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // TotalAmt
            // 
            this.TotalAmt.FillWeight = 113.9086F;
            this.TotalAmt.HeaderText = "Total Amt";
            this.TotalAmt.Name = "TotalAmt";
            this.TotalAmt.ReadOnly = true;
            // 
            // AvailableBalance
            // 
            this.AvailableBalance.FillWeight = 113.9086F;
            this.AvailableBalance.HeaderText = "Due Balance";
            this.AvailableBalance.Name = "AvailableBalance";
            this.AvailableBalance.ReadOnly = true;
            // 
            // AmtApplied
            // 
            this.AmtApplied.FillWeight = 113.9086F;
            this.AmtApplied.HeaderText = "Amt.Applied";
            this.AmtApplied.Name = "AmtApplied";
            this.AmtApplied.ReadOnly = true;
            // 
            // AppliedBalance
            // 
            this.AppliedBalance.HeaderText = "AppliedBalance";
            this.AppliedBalance.Name = "AppliedBalance";
            this.AppliedBalance.ReadOnly = true;
            this.AppliedBalance.Visible = false;
            // 
            // Print
            // 
            this.Print.HeaderText = "Invoice Print";
            this.Print.Name = "Print";
            this.Print.ReadOnly = true;
            this.Print.Text = "Print";
            this.Print.ToolTipText = "Print";
            this.Print.UseColumnTextForLinkValue = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.label5.Font = new System.Drawing.Font("Verdana", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 11);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(1817, 21);
            this.label5.TabIndex = 67;
            this.label5.Text = "Payment History";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvInvoicePaymentList);
            this.groupBox2.Location = new System.Drawing.Point(0, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(2324, 145);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dgvInvoicePaymentList
            // 
            this.dgvInvoicePaymentList.AllowUserToAddRows = false;
            this.dgvInvoicePaymentList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Lavender;
            this.dgvInvoicePaymentList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvInvoicePaymentList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoicePaymentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoicePaymentList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInvoicePaymentList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoicePaymentList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvInvoicePaymentList.ColumnHeadersHeight = 30;
            this.dgvInvoicePaymentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.InvoiceNo,
            this.PaymentMethod,
            this.PaymentDate,
            this.PaidAmount,
            this.CreditAmount,
            this.Delete,
            this.IsQBSync,
            this.InvoiceID,
            this.InvPrint});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoicePaymentList.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvInvoicePaymentList.GridColor = System.Drawing.SystemColors.Control;
            this.dgvInvoicePaymentList.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoicePaymentList.MultiSelect = false;
            this.dgvInvoicePaymentList.Name = "dgvInvoicePaymentList";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoicePaymentList.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvInvoicePaymentList.RowHeadersVisible = false;
            this.dgvInvoicePaymentList.RowHeadersWidth = 15;
            this.dgvInvoicePaymentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoicePaymentList.Size = new System.Drawing.Size(1822, 145);
            this.dgvInvoicePaymentList.TabIndex = 33;
            this.dgvInvoicePaymentList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoicePaymentList_CellContentClick);
            this.dgvInvoicePaymentList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoicePaymentList_CellContentDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.FillWeight = 93.50809F;
            this.InvoiceNo.HeaderText = "InvoiceNo";
            this.InvoiceNo.Name = "InvoiceNo";
            // 
            // PaymentMethod
            // 
            this.PaymentMethod.FillWeight = 93.50809F;
            this.PaymentMethod.HeaderText = "PaymentMethod";
            this.PaymentMethod.Name = "PaymentMethod";
            // 
            // PaymentDate
            // 
            this.PaymentDate.FillWeight = 67.19144F;
            this.PaymentDate.HeaderText = "PaymentDate";
            this.PaymentDate.Name = "PaymentDate";
            // 
            // PaidAmount
            // 
            this.PaidAmount.HeaderText = "PaidAmount";
            this.PaidAmount.Name = "PaidAmount";
            // 
            // CreditAmount
            // 
            this.CreditAmount.HeaderText = "CreditAmount";
            this.CreditAmount.Name = "CreditAmount";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.ToolTipText = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            // 
            // IsQBSync
            // 
            this.IsQBSync.HeaderText = "IsQBSync";
            this.IsQBSync.Name = "IsQBSync";
            this.IsQBSync.Visible = false;
            // 
            // InvoiceID
            // 
            this.InvoiceID.HeaderText = "InvoiceID";
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.Visible = false;
            // 
            // InvPrint
            // 
            this.InvPrint.HeaderText = "Invoice Print";
            this.InvPrint.Name = "InvPrint";
            this.InvPrint.Text = "Print";
            this.InvPrint.ToolTipText = "Print";
            this.InvPrint.UseColumnTextForLinkValue = true;
            // 
            // btnApplyCreditCard
            // 
            this.btnApplyCreditCard.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnApplyCreditCard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApplyCreditCard.Location = new System.Drawing.Point(1259, 886);
            this.btnApplyCreditCard.Name = "btnApplyCreditCard";
            this.btnApplyCreditCard.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnApplyCreditCard.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnApplyCreditCard.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnApplyCreditCard.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnApplyCreditCard.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnApplyCreditCard.OverrideDefault.Border.Rounding = 3;
            this.btnApplyCreditCard.OverrideDefault.Border.Width = 1;
            this.btnApplyCreditCard.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnApplyCreditCard.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCreditCard.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnApplyCreditCard.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnApplyCreditCard.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnApplyCreditCard.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnApplyCreditCard.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnApplyCreditCard.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnApplyCreditCard.OverrideFocus.Border.Rounding = 3;
            this.btnApplyCreditCard.OverrideFocus.Border.Width = 1;
            this.btnApplyCreditCard.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnApplyCreditCard.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCreditCard.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyCreditCard.Size = new System.Drawing.Size(151, 30);
            this.btnApplyCreditCard.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnApplyCreditCard.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnApplyCreditCard.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnApplyCreditCard.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnApplyCreditCard.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnApplyCreditCard.StateCommon.Border.Rounding = 3;
            this.btnApplyCreditCard.StateCommon.Border.Width = 1;
            this.btnApplyCreditCard.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnApplyCreditCard.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCreditCard.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyCreditCard.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnApplyCreditCard.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnApplyCreditCard.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnApplyCreditCard.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCreditCard.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyCreditCard.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnApplyCreditCard.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnApplyCreditCard.StateNormal.Border.Color1 = System.Drawing.Color.Transparent;
            this.btnApplyCreditCard.StateNormal.Border.Color2 = System.Drawing.Color.Transparent;
            this.btnApplyCreditCard.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnApplyCreditCard.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnApplyCreditCard.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCreditCard.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyCreditCard.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnApplyCreditCard.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnApplyCreditCard.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnApplyCreditCard.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCreditCard.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyCreditCard.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnApplyCreditCard.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnApplyCreditCard.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnApplyCreditCard.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnApplyCreditCard.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyCreditCard.TabIndex = 250;
            this.btnApplyCreditCard.Values.Text = "Apply CreditCard";
            this.btnApplyCreditCard.Click += new System.EventHandler(this.btnApplyCreditCard_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(1633, 884);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnUpdate.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnUpdate.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUpdate.OverrideDefault.Border.Rounding = 3;
            this.btnUpdate.OverrideDefault.Border.Width = 1;
            this.btnUpdate.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnUpdate.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnUpdate.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnUpdate.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnUpdate.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUpdate.OverrideFocus.Border.Rounding = 3;
            this.btnUpdate.OverrideFocus.Border.Width = 1;
            this.btnUpdate.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnUpdate.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnUpdate.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Size = new System.Drawing.Size(85, 32);
            this.btnUpdate.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.btnUpdate.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.btnUpdate.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUpdate.StateCommon.Border.Rounding = 3;
            this.btnUpdate.StateCommon.Border.Width = 1;
            this.btnUpdate.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnUpdate.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnUpdate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnUpdate.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnUpdate.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnUpdate.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnUpdate.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUpdate.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnUpdate.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnUpdate.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnUpdate.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnUpdate.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnUpdate.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnUpdate.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.TabIndex = 252;
            this.btnUpdate.Values.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlTopEntry
            // 
            this.pnlTopEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopEntry.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlTopEntry.Controls.Add(this.txtRef);
            this.pnlTopEntry.Controls.Add(this.lblRef);
            this.pnlTopEntry.Controls.Add(this.txtRemainingAmt);
            this.pnlTopEntry.Controls.Add(this.label11);
            this.pnlTopEntry.Controls.Add(this.txtTranID);
            this.pnlTopEntry.Controls.Add(this.btnClose);
            this.pnlTopEntry.Controls.Add(this.cmbCustomerName);
            this.pnlTopEntry.Controls.Add(this.txtPaid);
            this.pnlTopEntry.Controls.Add(this.txtInvID);
            this.pnlTopEntry.Controls.Add(this.label10);
            this.pnlTopEntry.Controls.Add(this.cmbPayMethod);
            this.pnlTopEntry.Controls.Add(this.txtPaidAmt);
            this.pnlTopEntry.Controls.Add(this.txtunPaid);
            this.pnlTopEntry.Controls.Add(this.label9);
            this.pnlTopEntry.Controls.Add(this.lblCustomerName);
            this.pnlTopEntry.Controls.Add(this.label4);
            this.pnlTopEntry.Controls.Add(this.txtTotalamt);
            this.pnlTopEntry.Controls.Add(this.label2);
            this.pnlTopEntry.Controls.Add(this.label1);
            this.pnlTopEntry.Controls.Add(this.label12);
            this.pnlTopEntry.Controls.Add(this.cmbInvoiceNo);
            this.pnlTopEntry.Controls.Add(this.txtCreditAmt);
            this.pnlTopEntry.Controls.Add(this.label7);
            this.pnlTopEntry.Controls.Add(this.label14);
            this.pnlTopEntry.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTopEntry.Location = new System.Drawing.Point(0, 0);
            this.pnlTopEntry.Name = "pnlTopEntry";
            this.pnlTopEntry.Size = new System.Drawing.Size(1820, 194);
            this.pnlTopEntry.TabIndex = 2;
            // 
            // txtRef
            // 
            this.txtRef.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRef.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRef.Location = new System.Drawing.Point(1108, 101);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(148, 21);
            this.txtRef.TabIndex = 346;
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRef.ForeColor = System.Drawing.Color.Black;
            this.lblRef.Location = new System.Drawing.Point(1006, 101);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(96, 16);
            this.lblRef.TabIndex = 345;
            this.lblRef.Text = "REFERENCE #";
            // 
            // txtRemainingAmt
            // 
            this.txtRemainingAmt.Location = new System.Drawing.Point(1518, 100);
            this.txtRemainingAmt.Name = "txtRemainingAmt";
            this.txtRemainingAmt.Size = new System.Drawing.Size(100, 23);
            this.txtRemainingAmt.TabIndex = 344;
            this.txtRemainingAmt.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(124)))), ((int)(((byte)(166)))));
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(-3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(2155, 21);
            this.label11.TabIndex = 343;
            this.label11.Text = "Customer Payment";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTranID
            // 
            this.txtTranID.Location = new System.Drawing.Point(1362, 98);
            this.txtTranID.Name = "txtTranID";
            this.txtTranID.Size = new System.Drawing.Size(58, 23);
            this.txtTranID.TabIndex = 166;
            this.txtTranID.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Location = new System.Drawing.Point(2050, 44);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnClose.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnClose.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClose.OverrideDefault.Border.Rounding = 3;
            this.btnClose.OverrideDefault.Border.Width = 1;
            this.btnClose.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnClose.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnClose.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClose.OverrideFocus.Border.Rounding = 3;
            this.btnClose.OverrideFocus.Border.Width = 1;
            this.btnClose.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Size = new System.Drawing.Size(95, 32);
            this.btnClose.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.btnClose.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.btnClose.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClose.StateCommon.Border.Rounding = 3;
            this.btnClose.StateCommon.Border.Width = 1;
            this.btnClose.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnClose.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnClose.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClose.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.TabIndex = 342;
            this.btnClose.Values.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomerName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbCustomerName.DropDownWidth = 300;
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(144, 97);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(178, 24);
            this.cmbCustomerName.TabIndex = 1;
            this.cmbCustomerName.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerName_SelectedIndexChanged);
            // 
            // txtPaid
            // 
            this.txtPaid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPaid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.Location = new System.Drawing.Point(102, 140);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Size = new System.Drawing.Size(125, 21);
            this.txtPaid.TabIndex = 170;
            this.txtPaid.Visible = false;
            this.txtPaid.Leave += new System.EventHandler(this.txtPaid_Leave);
            // 
            // txtInvID
            // 
            this.txtInvID.Location = new System.Drawing.Point(1426, 98);
            this.txtInvID.Name = "txtInvID";
            this.txtInvID.Size = new System.Drawing.Size(60, 23);
            this.txtInvID.TabIndex = 165;
            this.txtInvID.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(7, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 16);
            this.label10.TabIndex = 169;
            this.label10.Text = "Paid Amount";
            this.label10.Visible = false;
            // 
            // cmbPayMethod
            // 
            this.cmbPayMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPayMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPayMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayMethod.DropDownWidth = 200;
            this.cmbPayMethod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPayMethod.FormattingEnabled = true;
            this.cmbPayMethod.Location = new System.Drawing.Point(484, 99);
            this.cmbPayMethod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPayMethod.Name = "cmbPayMethod";
            this.cmbPayMethod.Size = new System.Drawing.Size(178, 21);
            this.cmbPayMethod.TabIndex = 247;
            this.cmbPayMethod.SelectedIndexChanged += new System.EventHandler(this.cmbPayMethod_SelectedIndexChanged);
            // 
            // txtPaidAmt
            // 
            this.txtPaidAmt.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPaidAmt.Location = new System.Drawing.Point(798, 98);
            this.txtPaidAmt.Name = "txtPaidAmt";
            this.txtPaidAmt.Size = new System.Drawing.Size(178, 23);
            this.txtPaidAmt.TabIndex = 249;
            this.txtPaidAmt.TextChanged += new System.EventHandler(this.txtPaidAmt_TextChanged);
            this.txtPaidAmt.DragLeave += new System.EventHandler(this.txtPaidAmt_DragLeave);
            this.txtPaidAmt.DoubleClick += new System.EventHandler(this.txtPaidAmt_DoubleClick);
            this.txtPaidAmt.Enter += new System.EventHandler(this.txtPaidAmt_Enter);
            this.txtPaidAmt.Leave += new System.EventHandler(this.txtPaidAmt_Leave);
            // 
            // txtunPaid
            // 
            this.txtunPaid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtunPaid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtunPaid.Location = new System.Drawing.Point(1079, 140);
            this.txtunPaid.Name = "txtunPaid";
            this.txtunPaid.Size = new System.Drawing.Size(125, 21);
            this.txtunPaid.TabIndex = 168;
            this.txtunPaid.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(967, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 16);
            this.label9.TabIndex = 167;
            this.label9.Text = "UnPaid Amount";
            this.label9.Visible = false;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerName.Location = new System.Drawing.Point(6, 100);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(131, 18);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(694, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 248;
            this.label4.Text = "Enter Amount";
            // 
            // txtTotalamt
            // 
            this.txtTotalamt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalamt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalamt.Location = new System.Drawing.Point(819, 140);
            this.txtTotalamt.Name = "txtTotalamt";
            this.txtTotalamt.Size = new System.Drawing.Size(125, 21);
            this.txtTotalamt.TabIndex = 164;
            this.txtTotalamt.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(358, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 246;
            this.label2.Text = "Payment Method";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(718, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Amount";
            this.label1.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(462, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Invoice No";
            this.label12.Visible = false;
            // 
            // cmbInvoiceNo
            // 
            this.cmbInvoiceNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInvoiceNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInvoiceNo.FormattingEnabled = true;
            this.cmbInvoiceNo.Location = new System.Drawing.Point(545, 138);
            this.cmbInvoiceNo.Name = "cmbInvoiceNo";
            this.cmbInvoiceNo.Size = new System.Drawing.Size(145, 24);
            this.cmbInvoiceNo.TabIndex = 0;
            this.cmbInvoiceNo.Visible = false;
            this.cmbInvoiceNo.SelectedValueChanged += new System.EventHandler(this.cmbInvoiceNo_SelectedValueChanged);
            // 
            // txtCreditAmt
            // 
            this.txtCreditAmt.Enabled = false;
            this.txtCreditAmt.Location = new System.Drawing.Point(345, 139);
            this.txtCreditAmt.Name = "txtCreditAmt";
            this.txtCreditAmt.ReadOnly = true;
            this.txtCreditAmt.Size = new System.Drawing.Size(95, 23);
            this.txtCreditAmt.TabIndex = 245;
            this.txtCreditAmt.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(252, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 16);
            this.label7.TabIndex = 244;
            this.label7.Text = "CreditAmount";
            this.label7.UseWaitCursor = true;
            this.label7.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(0, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(282, 32);
            this.label14.TabIndex = 0;
            this.label14.Text = "Customer Payment ";
            // 
            // btnSave1
            // 
            this.btnSave1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave1.Location = new System.Drawing.Point(1543, 884);
            this.btnSave1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave1.Name = "btnSave1";
            this.btnSave1.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSave1.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSave1.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSave1.OverrideDefault.Border.Rounding = 3;
            this.btnSave1.OverrideDefault.Border.Width = 1;
            this.btnSave1.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSave1.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSave1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave1.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSave1.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSave1.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSave1.OverrideFocus.Border.Rounding = 3;
            this.btnSave1.OverrideFocus.Border.Width = 1;
            this.btnSave1.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSave1.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSave1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave1.Size = new System.Drawing.Size(85, 32);
            this.btnSave1.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.btnSave1.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.btnSave1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSave1.StateCommon.Border.Rounding = 3;
            this.btnSave1.StateCommon.Border.Width = 1;
            this.btnSave1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSave1.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSave1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave1.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSave1.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSave1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave1.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSave1.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSave1.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSave1.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSave1.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSave1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave1.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSave1.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSave1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave1.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSave1.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSave1.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSave1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave1.TabIndex = 251;
            this.btnSave1.Values.Text = "Save";
            this.btnSave1.Click += new System.EventHandler(this.btnSave1_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(485, 22);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(35, 32);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.Visible = false;
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = false;
            this.lblErrorMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblErrorMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblErrorMsg.Location = new System.Drawing.Point(7, 857);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(851, 30);
            this.lblErrorMsg.StateCommon.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // FrmPaymentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1820, 926);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmPaymentDetail";
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
            this.Text = resources.GetString("$this.Text");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPaymentDetail_FormClosing);
            this.Load += new System.EventHandler(this.FrmPaymentDetail_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlEntry.ResumeLayout(false);
            this.pnlEntry.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditMemoPaymentList)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyamount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicePaymentList)).EndInit();
            this.pnlTopEntry.ResumeLayout(false);
            this.pnlTopEntry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.Panel pnlMain;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtInvID;
        private System.Windows.Forms.TextBox txtTranID;
        private System.Windows.Forms.Panel pnlEntry;
        private System.Windows.Forms.Panel pnlTopEntry;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnReset;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUpdate;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnApplyCreditCard;
        private System.Windows.Forms.TextBox txtPaidAmt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPayMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCreditAmt;
        private System.Windows.Forms.Label label7;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtunPaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalamt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbInvoiceNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvApplyamount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotal;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotalAmt;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblDue;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblDueAmt;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPay;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPayAmt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvInvoicePaymentList;
        private System.Windows.Forms.DataGridView dgvCreditMemoPaymentList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditMemoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditPayAmount;
        private System.Windows.Forms.DataGridViewLinkColumn CreditDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtApplyCredit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnApplyCredit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lblErrorMsg;
        private System.Windows.Forms.Label lblErrorMsg1;
        private System.Windows.Forms.TextBox txtRemainingAmt;
        private System.Windows.Forms.TextBox txtRef;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditAmount;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsQBSync;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewLinkColumn InvPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailableBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmtApplied;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppliedBalance;
        private System.Windows.Forms.DataGridViewLinkColumn Print;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSaveAndNew;
    }
}

