namespace POS
{
    partial class FrmItemSaleHistoryReport
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
            this.grpPersonal = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel20 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbItemName = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpToDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpFromDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnPrint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnExpot = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dgvAllInvoiceList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonal.Panel)).BeginInit();
            this.grpPersonal.Panel.SuspendLayout();
            this.grpPersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbItemName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInvoiceList)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPersonal
            // 
            this.grpPersonal.Location = new System.Drawing.Point(12, 12);
            this.grpPersonal.Name = "grpPersonal";
            // 
            // grpPersonal.Panel
            // 
            this.grpPersonal.Panel.Controls.Add(this.kryptonLabel20);
            this.grpPersonal.Panel.Controls.Add(this.cmbItemName);
            this.grpPersonal.Panel.Controls.Add(this.kryptonLabel3);
            this.grpPersonal.Panel.Controls.Add(this.dtpToDate);
            this.grpPersonal.Panel.Controls.Add(this.kryptonLabel2);
            this.grpPersonal.Panel.Controls.Add(this.dtpFromDate);
            this.grpPersonal.Panel.Controls.Add(this.kryptonLabel1);
            this.grpPersonal.Size = new System.Drawing.Size(865, 79);
            this.grpPersonal.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.grpPersonal.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.grpPersonal.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.grpPersonal.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.grpPersonal.StateCommon.Border.Rounding = 3;
            this.grpPersonal.StateCommon.Border.Width = 1;
            this.grpPersonal.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.grpPersonal.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPersonal.StateNormal.Back.Color1 = System.Drawing.Color.Transparent;
            this.grpPersonal.StateNormal.Border.Color1 = System.Drawing.Color.Black;
            this.grpPersonal.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.grpPersonal.StateNormal.Border.Rounding = 3;
            this.grpPersonal.StateNormal.Border.Width = 1;
            this.grpPersonal.TabIndex = 0;
            this.grpPersonal.Values.Heading = "Item Sale Details";
            // 
            // kryptonLabel20
            // 
            this.kryptonLabel20.Location = new System.Drawing.Point(552, 17);
            this.kryptonLabel20.Name = "kryptonLabel20";
            this.kryptonLabel20.Size = new System.Drawing.Size(18, 17);
            this.kryptonLabel20.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel20.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonLabel20.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel20.StateNormal.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel20.StateNormal.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonLabel20.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel20.TabIndex = 6;
            this.kryptonLabel20.Values.Text = "*";
            // 
            // cmbItemName
            // 
            this.cmbItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemName.DropDownWidth = 250;
            this.cmbItemName.FormattingEnabled = true;
            this.cmbItemName.Location = new System.Drawing.Point(675, 12);
            this.cmbItemName.Name = "cmbItemName";
            this.cmbItemName.Size = new System.Drawing.Size(159, 21);
            this.cmbItemName.TabIndex = 5;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(567, 14);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(105, 20);
            this.kryptonLabel3.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Item Name :";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "MM-dd-yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(376, 14);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(159, 21);
            this.dtpToDate.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(296, 16);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(74, 20);
            this.kryptonLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel2.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel2.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel2.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "ToDate :";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "MM-dd-yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(126, 14);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(159, 21);
            this.dtpFromDate.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(28, 14);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(95, 20);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "FromDate :";
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrint.Location = new System.Drawing.Point(777, 97);
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
            this.btnPrint.Size = new System.Drawing.Size(100, 30);
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
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Values.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExpot
            // 
            this.btnExpot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExpot.Location = new System.Drawing.Point(671, 97);
            this.btnExpot.Name = "btnExpot";
            this.btnExpot.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnExpot.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnExpot.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExpot.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExpot.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExpot.OverrideDefault.Border.Rounding = 3;
            this.btnExpot.OverrideDefault.Border.Width = 1;
            this.btnExpot.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExpot.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExpot.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExpot.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnExpot.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnExpot.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExpot.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExpot.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExpot.OverrideFocus.Border.Rounding = 3;
            this.btnExpot.OverrideFocus.Border.Width = 1;
            this.btnExpot.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExpot.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExpot.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpot.Size = new System.Drawing.Size(100, 30);
            this.btnExpot.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExpot.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnExpot.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExpot.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExpot.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExpot.StateCommon.Border.Rounding = 3;
            this.btnExpot.StateCommon.Border.Width = 1;
            this.btnExpot.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExpot.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExpot.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpot.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExpot.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnExpot.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExpot.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExpot.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpot.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExpot.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnExpot.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExpot.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExpot.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExpot.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExpot.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExpot.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpot.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExpot.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnExpot.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExpot.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExpot.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpot.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExpot.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnExpot.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExpot.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExpot.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpot.TabIndex = 2;
            this.btnExpot.Values.Text = "Export";
            this.btnExpot.Click += new System.EventHandler(this.btnExpot_Click);
            // 
            // dgvAllInvoiceList
            // 
            this.dgvAllInvoiceList.AllowUserToAddRows = false;
            this.dgvAllInvoiceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllInvoiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ItemName,
            this.Quantity,
            this.Amount,
            this.View});
            this.dgvAllInvoiceList.Location = new System.Drawing.Point(24, 147);
            this.dgvAllInvoiceList.Name = "dgvAllInvoiceList";
            this.dgvAllInvoiceList.RowHeadersVisible = false;
            this.dgvAllInvoiceList.Size = new System.Drawing.Size(853, 184);
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
            this.dgvAllInvoiceList.TabIndex = 271;
            this.dgvAllInvoiceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllInvoiceList_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.Name = "ItemName";
            // 
            // Quantity
            // 
            this.Quantity.FillWeight = 35F;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // Amount
            // 
            this.Amount.FillWeight = 35F;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // View
            // 
            this.View.FillWeight = 25F;
            this.View.HeaderText = "View";
            this.View.Name = "View";
            this.View.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.View.Text = "View";
            this.View.ToolTipText = "View";
            this.View.UseColumnTextForLinkValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(21, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 18);
            this.label1.TabIndex = 272;
            this.label1.Text = "If you want to view specific item then select Item else click on print to view al" +
    "l item ";
            // 
            // FrmItemSaleHistoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(893, 385);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAllInvoiceList);
            this.Controls.Add(this.btnExpot);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grpPersonal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmItemSaleHistoryReport";
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
            this.Text = "Item Sale History Report";
            this.Load += new System.EventHandler(this.FrmItemSaleHistoryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonal.Panel)).EndInit();
            this.grpPersonal.Panel.ResumeLayout(false);
            this.grpPersonal.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonal)).EndInit();
            this.grpPersonal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbItemName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInvoiceList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpPersonal;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpToDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpFromDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbItemName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrint;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel20;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExpot;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvAllInvoiceList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewLinkColumn View;
        private System.Windows.Forms.Label label1;
    }
}

