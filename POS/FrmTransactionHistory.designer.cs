namespace POS
{
    partial class FrmTransactionHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtID = new System.Windows.Forms.TextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.pnlInvoiceDetails = new System.Windows.Forms.Panel();
            this.lblInvoiceTotal = new System.Windows.Forms.Label();
            this.lblMemo = new System.Windows.Forms.Label();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.btnPrint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.dgvPaymentList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            this.pnlInvoiceDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Location = new System.Drawing.Point(549, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnCancel.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnCancel.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnCancel.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnCancel.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancel.OverrideDefault.Border.Rounding = 3;
            this.btnCancel.OverrideDefault.Border.Width = 1;
            this.btnCancel.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnCancel.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnCancel.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnCancel.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnCancel.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnCancel.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancel.OverrideFocus.Border.Rounding = 3;
            this.btnCancel.OverrideFocus.Border.Width = 1;
            this.btnCancel.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnCancel.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnCancel.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnCancel.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnCancel.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnCancel.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnCancel.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancel.StateCommon.Border.Rounding = 3;
            this.btnCancel.StateCommon.Border.Width = 1;
            this.btnCancel.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnCancel.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnCancel.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnCancel.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnCancel.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnCancel.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnCancel.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnCancel.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnCancel.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnCancel.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancel.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnCancel.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnCancel.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnCancel.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnCancel.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnCancel.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnCancel.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnCancel.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnCancel.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnCancel.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Values.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Control;
            this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(435, 6);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(61, 22);
            this.txtID.TabIndex = 4;
            this.txtID.TabStop = false;
            this.txtID.Visible = false;
            // 
            // radLabel4
            // 
            this.radLabel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.ForeColor = System.Drawing.Color.Black;
            this.radLabel4.Location = new System.Drawing.Point(13, 10);
            this.radLabel4.Name = "radLabel4";
            // 
            // 
            // 
            this.radLabel4.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 18);
            this.radLabel4.Size = new System.Drawing.Size(140, 18);
            this.radLabel4.TabIndex = 0;
            this.radLabel4.Text = "Invoice Information";
            // 
            // pnlInvoiceDetails
            // 
            this.pnlInvoiceDetails.Controls.Add(this.lblInvoiceTotal);
            this.pnlInvoiceDetails.Controls.Add(this.lblMemo);
            this.pnlInvoiceDetails.Controls.Add(this.radLabel12);
            this.pnlInvoiceDetails.Controls.Add(this.lblInvoiceNo);
            this.pnlInvoiceDetails.Controls.Add(this.radLabel11);
            this.pnlInvoiceDetails.Controls.Add(this.lblInvoiceDate);
            this.pnlInvoiceDetails.Controls.Add(this.radLabel10);
            this.pnlInvoiceDetails.Controls.Add(this.radLabel6);
            this.pnlInvoiceDetails.Controls.Add(this.lblCustomer);
            this.pnlInvoiceDetails.Controls.Add(this.radLabel5);
            this.pnlInvoiceDetails.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlInvoiceDetails.Location = new System.Drawing.Point(13, 34);
            this.pnlInvoiceDetails.Name = "pnlInvoiceDetails";
            this.pnlInvoiceDetails.Size = new System.Drawing.Size(530, 116);
            this.pnlInvoiceDetails.TabIndex = 1;
            this.pnlInvoiceDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInvoiceDetails_Paint);
            // 
            // lblInvoiceTotal
            // 
            this.lblInvoiceTotal.AutoSize = true;
            this.lblInvoiceTotal.Location = new System.Drawing.Point(390, 66);
            this.lblInvoiceTotal.Name = "lblInvoiceTotal";
            this.lblInvoiceTotal.Size = new System.Drawing.Size(0, 14);
            this.lblInvoiceTotal.TabIndex = 7;
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.Location = new System.Drawing.Point(132, 87);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(0, 14);
            this.lblMemo.TabIndex = 9;
            // 
            // radLabel12
            // 
            this.radLabel12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel12.ForeColor = System.Drawing.Color.Black;
            this.radLabel12.Location = new System.Drawing.Point(270, 63);
            this.radLabel12.Name = "radLabel12";
            // 
            // 
            // 
            this.radLabel12.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 18);
            this.radLabel12.Size = new System.Drawing.Size(87, 18);
            this.radLabel12.TabIndex = 6;
            this.radLabel12.Text = "Invoice Total";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(132, 63);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(0, 14);
            this.lblInvoiceNo.TabIndex = 5;
            // 
            // radLabel11
            // 
            this.radLabel11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel11.ForeColor = System.Drawing.Color.Black;
            this.radLabel11.Location = new System.Drawing.Point(12, 84);
            this.radLabel11.Name = "radLabel11";
            // 
            // 
            // 
            this.radLabel11.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 18);
            this.radLabel11.Size = new System.Drawing.Size(44, 18);
            this.radLabel11.TabIndex = 8;
            this.radLabel11.Text = "Memo";
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Location = new System.Drawing.Point(132, 39);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(0, 14);
            this.lblInvoiceDate.TabIndex = 3;
            // 
            // radLabel10
            // 
            this.radLabel10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel10.ForeColor = System.Drawing.Color.Black;
            this.radLabel10.Location = new System.Drawing.Point(12, 60);
            this.radLabel10.Name = "radLabel10";
            // 
            // 
            // 
            this.radLabel10.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 18);
            this.radLabel10.Size = new System.Drawing.Size(77, 18);
            this.radLabel10.TabIndex = 4;
            this.radLabel10.Text = "Invoice No.";
            // 
            // radLabel6
            // 
            this.radLabel6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.ForeColor = System.Drawing.Color.Black;
            this.radLabel6.Location = new System.Drawing.Point(12, 36);
            this.radLabel6.Name = "radLabel6";
            // 
            // 
            // 
            this.radLabel6.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 18);
            this.radLabel6.Size = new System.Drawing.Size(85, 18);
            this.radLabel6.TabIndex = 2;
            this.radLabel6.Text = "Invoice Date";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(132, 15);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(0, 14);
            this.lblCustomer.TabIndex = 1;
            // 
            // radLabel5
            // 
            this.radLabel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.ForeColor = System.Drawing.Color.Black;
            this.radLabel5.Location = new System.Drawing.Point(12, 12);
            this.radLabel5.Name = "radLabel5";
            // 
            // 
            // 
            this.radLabel5.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 18);
            this.radLabel5.Size = new System.Drawing.Size(99, 18);
            this.radLabel5.TabIndex = 0;
            this.radLabel5.Text = "Customer:Jobs";
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrint.Location = new System.Drawing.Point(549, 48);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnPrint.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPrint.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPrint.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrint.OverrideDefault.Border.Rounding = 3;
            this.btnPrint.OverrideDefault.Border.Width = 1;
            this.btnPrint.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnPrint.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPrint.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPrint.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrint.OverrideFocus.Border.Rounding = 3;
            this.btnPrint.OverrideFocus.Border.Width = 1;
            this.btnPrint.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Size = new System.Drawing.Size(110, 30);
            this.btnPrint.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPrint.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrint.StateCommon.Border.Rounding = 3;
            this.btnPrint.StateCommon.Border.Width = 1;
            this.btnPrint.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPrint.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPrint.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPrint.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPrint.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrint.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPrint.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPrint.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Values.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.Black;
            this.radLabel1.Location = new System.Drawing.Point(13, 156);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 18);
            this.radLabel1.Size = new System.Drawing.Size(450, 18);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Payments, Deposits of payment line items, credits and discounts";
            // 
            // dgvPaymentList
            // 
            this.dgvPaymentList.AllowUserToAddRows = false;
            this.dgvPaymentList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Lavender;
            this.dgvPaymentList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPaymentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaymentList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPaymentList.ColumnHeadersHeight = 30;
            this.dgvPaymentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Type,
            this.Date,
            this.Total,
            this.Amount,
            this.InvoiceBalance});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaymentList.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPaymentList.GridColor = System.Drawing.SystemColors.Control;
            this.dgvPaymentList.Location = new System.Drawing.Point(8, 180);
            this.dgvPaymentList.MultiSelect = false;
            this.dgvPaymentList.Name = "dgvPaymentList";
            this.dgvPaymentList.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentList.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPaymentList.RowHeadersVisible = false;
            this.dgvPaymentList.RowHeadersWidth = 15;
            this.dgvPaymentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymentList.Size = new System.Drawing.Size(535, 155);
            this.dgvPaymentList.TabIndex = 3;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Applied Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // InvoiceBalance
            // 
            this.InvoiceBalance.HeaderText = "Balance Due";
            this.InvoiceBalance.Name = "InvoiceBalance";
            this.InvoiceBalance.ReadOnly = true;
            // 
            // FrmTransactionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(676, 359);
            this.Controls.Add(this.dgvPaymentList);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pnlInvoiceDetails);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmTransactionHistory";
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
            this.Text = "Transaction History - Invoice";
            this.Load += new System.EventHandler(this.FrmTransactionHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            this.pnlInvoiceDetails.ResumeLayout(false);
            this.pnlInvoiceDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private System.Windows.Forms.TextBox txtID;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private System.Windows.Forms.Panel pnlInvoiceDetails;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblInvoiceDate;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private System.Windows.Forms.Label lblInvoiceNo;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private System.Windows.Forms.Label lblMemo;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private System.Windows.Forms.Label lblInvoiceTotal;
        private Telerik.WinControls.UI.RadLabel radLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrint;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.DataGridView dgvPaymentList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceBalance;
    }
}

