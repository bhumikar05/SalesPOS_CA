namespace POS
{
    partial class FrmIMEIDetailsReport
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
            this.grpCustomerDetails = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnPrint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dtpToDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtpFromDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnPrint1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnExport1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpCustomerDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpCustomerDetails.Panel)).BeginInit();
            this.grpCustomerDetails.Panel.SuspendLayout();
            this.grpCustomerDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCustomerDetails
            // 
            this.grpCustomerDetails.Location = new System.Drawing.Point(12, 12);
            this.grpCustomerDetails.Name = "grpCustomerDetails";
            // 
            // grpCustomerDetails.Panel
            // 
            this.grpCustomerDetails.Panel.Controls.Add(this.btnPrint);
            this.grpCustomerDetails.Panel.Controls.Add(this.btnExport);
            this.grpCustomerDetails.Panel.Controls.Add(this.dtpToDate);
            this.grpCustomerDetails.Panel.Controls.Add(this.kryptonLabel2);
            this.grpCustomerDetails.Panel.Controls.Add(this.dtpFromDate);
            this.grpCustomerDetails.Panel.Controls.Add(this.kryptonLabel1);
            this.grpCustomerDetails.Size = new System.Drawing.Size(652, 117);
            this.grpCustomerDetails.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.grpCustomerDetails.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.grpCustomerDetails.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.grpCustomerDetails.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.grpCustomerDetails.StateCommon.Border.Rounding = 3;
            this.grpCustomerDetails.StateCommon.Border.Width = 1;
            this.grpCustomerDetails.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.grpCustomerDetails.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCustomerDetails.StateNormal.Back.Color1 = System.Drawing.Color.Transparent;
            this.grpCustomerDetails.StateNormal.Border.Color1 = System.Drawing.Color.Black;
            this.grpCustomerDetails.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.grpCustomerDetails.StateNormal.Border.Rounding = 3;
            this.grpCustomerDetails.StateNormal.Border.Width = 1;
            this.grpCustomerDetails.TabIndex = 0;
            this.grpCustomerDetails.Values.Heading = "Select options for history periods";
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrint.Location = new System.Drawing.Point(539, 43);
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
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Values.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExport
            // 
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.Location = new System.Drawing.Point(539, 7);
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
            this.btnExport.Size = new System.Drawing.Size(100, 30);
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
            this.btnExport.TabIndex = 2;
            this.btnExport.Values.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CalendarTodayDate = new System.DateTime(2024, 9, 7, 0, 0, 0, 0);
            this.dtpToDate.CustomFormat = "MM-dd-yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(371, 25);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(159, 21);
            this.dtpToDate.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(283, 27);
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
            this.dtpFromDate.CalendarTodayDate = new System.DateTime(2024, 9, 7, 0, 0, 0, 0);
            this.dtpFromDate.CustomFormat = "MM-dd-yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(112, 25);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(159, 21);
            this.dtpFromDate.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(15, 27);
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
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 135);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnPrint1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtSearch);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnExport1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(652, 108);
            this.kryptonGroupBox1.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonGroupBox1.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.kryptonGroupBox1.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.kryptonGroupBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonGroupBox1.StateCommon.Border.Rounding = 3;
            this.kryptonGroupBox1.StateCommon.Border.Width = 1;
            this.kryptonGroupBox1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonGroupBox1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBox1.StateNormal.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonGroupBox1.StateNormal.Border.Color1 = System.Drawing.Color.Black;
            this.kryptonGroupBox1.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonGroupBox1.StateNormal.Border.Rounding = 3;
            this.kryptonGroupBox1.StateNormal.Border.Width = 1;
            this.kryptonGroupBox1.TabIndex = 1;
            this.kryptonGroupBox1.Values.Heading = "Search IMEI";
            // 
            // btnPrint1
            // 
            this.btnPrint1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrint1.Location = new System.Drawing.Point(539, 43);
            this.btnPrint1.Name = "btnPrint1";
            this.btnPrint1.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnPrint1.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint1.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPrint1.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPrint1.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrint1.OverrideDefault.Border.Rounding = 3;
            this.btnPrint1.OverrideDefault.Border.Width = 1;
            this.btnPrint1.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint1.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint1.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnPrint1.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint1.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPrint1.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPrint1.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrint1.OverrideFocus.Border.Rounding = 3;
            this.btnPrint1.OverrideFocus.Border.Width = 1;
            this.btnPrint1.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint1.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint1.Size = new System.Drawing.Size(100, 30);
            this.btnPrint1.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPrint1.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint1.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint1.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPrint1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrint1.StateCommon.Border.Rounding = 3;
            this.btnPrint1.StateCommon.Border.Width = 1;
            this.btnPrint1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint1.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint1.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPrint1.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint1.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint1.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint1.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPrint1.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint1.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPrint1.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPrint1.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPrint1.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint1.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint1.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPrint1.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint1.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint1.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint1.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPrint1.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnPrint1.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPrint1.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPrint1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint1.TabIndex = 32;
            this.btnPrint1.Values.Text = "Print";
            this.btnPrint1.Click += new System.EventHandler(this.btnPrint1_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AcceptsReturn = true;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.Location = new System.Drawing.Point(153, 11);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(377, 58);
            this.txtSearch.TabIndex = 31;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(18, 16);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(138, 20);
            this.kryptonLabel3.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 3;
            this.kryptonLabel3.Values.Text = "Search IMEI No : ";
            // 
            // btnExport1
            // 
            this.btnExport1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport1.Location = new System.Drawing.Point(539, 6);
            this.btnExport1.Name = "btnExport1";
            this.btnExport1.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnExport1.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnExport1.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExport1.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExport1.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExport1.OverrideDefault.Border.Rounding = 3;
            this.btnExport1.OverrideDefault.Border.Width = 1;
            this.btnExport1.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport1.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExport1.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnExport1.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnExport1.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExport1.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExport1.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExport1.OverrideFocus.Border.Rounding = 3;
            this.btnExport1.OverrideFocus.Border.Width = 1;
            this.btnExport1.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport1.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport1.Size = new System.Drawing.Size(100, 30);
            this.btnExport1.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExport1.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnExport1.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExport1.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExport1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExport1.StateCommon.Border.Rounding = 3;
            this.btnExport1.StateCommon.Border.Width = 1;
            this.btnExport1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport1.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport1.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExport1.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnExport1.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport1.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport1.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExport1.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnExport1.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnExport1.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnExport1.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnExport1.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport1.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport1.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExport1.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnExport1.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport1.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport1.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnExport1.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnExport1.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnExport1.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnExport1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport1.TabIndex = 2;
            this.btnExport1.Values.Text = "Export";
            this.btnExport1.Click += new System.EventHandler(this.btnExport1_Click);
            // 
            // FrmIMEIDetailsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(680, 257);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.grpCustomerDetails);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmIMEIDetailsReport";
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
            this.Text = "IMEIDetails Report";
            this.Load += new System.EventHandler(this.FrmInvoiceAuditReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpCustomerDetails.Panel)).EndInit();
            this.grpCustomerDetails.Panel.ResumeLayout(false);
            this.grpCustomerDetails.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCustomerDetails)).EndInit();
            this.grpCustomerDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpCustomerDetails;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpToDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpFromDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExport;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExport1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private System.Windows.Forms.TextBox txtSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrint;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrint1;
    }
}

