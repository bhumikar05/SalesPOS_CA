namespace POS
{
    partial class FrmResultUPS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalCharge = new System.Windows.Forms.Label();
            this.lblServiceOptionCharge = new System.Windows.Forms.Label();
            this.lblTransaportationCharge = new System.Windows.Forms.Label();
            this.radLabel19 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel18 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.grpAddressList = new System.Windows.Forms.GroupBox();
            this.dgTrackingCodes = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionPrint = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnUpdateInDB = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.grpAddressList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTrackingCodes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalCharge);
            this.groupBox1.Controls.Add(this.lblServiceOptionCharge);
            this.groupBox1.Controls.Add(this.lblTransaportationCharge);
            this.groupBox1.Controls.Add(this.radLabel19);
            this.groupBox1.Controls.Add(this.radLabel18);
            this.groupBox1.Controls.Add(this.radLabel1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UPS Tracking Info";
            // 
            // lblTotalCharge
            // 
            this.lblTotalCharge.AutoSize = true;
            this.lblTotalCharge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCharge.Location = new System.Drawing.Point(191, 87);
            this.lblTotalCharge.Name = "lblTotalCharge";
            this.lblTotalCharge.Size = new System.Drawing.Size(0, 13);
            this.lblTotalCharge.TabIndex = 5;
            // 
            // lblServiceOptionCharge
            // 
            this.lblServiceOptionCharge.AutoSize = true;
            this.lblServiceOptionCharge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceOptionCharge.Location = new System.Drawing.Point(191, 61);
            this.lblServiceOptionCharge.Name = "lblServiceOptionCharge";
            this.lblServiceOptionCharge.Size = new System.Drawing.Size(0, 13);
            this.lblServiceOptionCharge.TabIndex = 3;
            // 
            // lblTransaportationCharge
            // 
            this.lblTransaportationCharge.AutoSize = true;
            this.lblTransaportationCharge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransaportationCharge.Location = new System.Drawing.Point(191, 35);
            this.lblTransaportationCharge.Name = "lblTransaportationCharge";
            this.lblTransaportationCharge.Size = new System.Drawing.Size(0, 13);
            this.lblTransaportationCharge.TabIndex = 1;
            // 
            // radLabel19
            // 
            this.radLabel19.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel19.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel19.ForeColor = System.Drawing.Color.Black;
            this.radLabel19.Location = new System.Drawing.Point(74, 85);
            this.radLabel19.Name = "radLabel19";
            // 
            // 
            // 
            this.radLabel19.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 18);
            this.radLabel19.Size = new System.Drawing.Size(120, 17);
            this.radLabel19.TabIndex = 4;
            this.radLabel19.Text = "Total Charge :";
            // 
            // radLabel18
            // 
            this.radLabel18.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel18.ForeColor = System.Drawing.Color.Black;
            this.radLabel18.Location = new System.Drawing.Point(15, 59);
            this.radLabel18.Name = "radLabel18";
            // 
            // 
            // 
            this.radLabel18.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 18);
            this.radLabel18.Size = new System.Drawing.Size(165, 17);
            this.radLabel18.TabIndex = 2;
            this.radLabel18.Text = "ServiceOption Charge :";
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.Black;
            this.radLabel1.Location = new System.Drawing.Point(10, 33);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 18);
            this.radLabel1.Size = new System.Drawing.Size(190, 17);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Transportation Charge :";
            // 
            // grpAddressList
            // 
            this.grpAddressList.Controls.Add(this.dgTrackingCodes);
            this.grpAddressList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAddressList.Location = new System.Drawing.Point(12, 135);
            this.grpAddressList.Name = "grpAddressList";
            this.grpAddressList.Size = new System.Drawing.Size(433, 201);
            this.grpAddressList.TabIndex = 1;
            this.grpAddressList.TabStop = false;
            this.grpAddressList.Text = "UPS Info";
            // 
            // dgTrackingCodes
            // 
            this.dgTrackingCodes.AllowUserToAddRows = false;
            this.dgTrackingCodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.ActionPrint});
            this.dgTrackingCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTrackingCodes.Location = new System.Drawing.Point(3, 19);
            this.dgTrackingCodes.Name = "dgTrackingCodes";
            this.dgTrackingCodes.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTrackingCodes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgTrackingCodes.Size = new System.Drawing.Size(427, 179);
            this.dgTrackingCodes.StateCommon.Background.Color1 = System.Drawing.SystemColors.ControlLightLight;
            this.dgTrackingCodes.StateCommon.Background.Color2 = System.Drawing.SystemColors.ControlLightLight;
            this.dgTrackingCodes.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgTrackingCodes.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgTrackingCodes.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.Gray;
            this.dgTrackingCodes.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.Gray;
            this.dgTrackingCodes.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgTrackingCodes.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgTrackingCodes.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgTrackingCodes.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.Black;
            this.dgTrackingCodes.StateNormal.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgTrackingCodes.TabIndex = 73;
            this.dgTrackingCodes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTrackingCodes_CellContentClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Select";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Tracking Number";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // ActionPrint
            // 
            this.ActionPrint.HeaderText = "Print Action";
            this.ActionPrint.Name = "ActionPrint";
            this.ActionPrint.Text = "Print Receipt";
            this.ActionPrint.UseColumnTextForLinkValue = true;
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Location = new System.Drawing.Point(15, 342);
            this.btnClose.Name = "btnClose";
            this.btnClose.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnClose.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnClose.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnClose.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnClose.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClose.OverrideDefault.Border.Rounding = 3;
            this.btnClose.OverrideDefault.Border.Width = 1;
            this.btnClose.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnClose.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnClose.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnClose.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnClose.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnClose.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnClose.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClose.OverrideFocus.Border.Rounding = 3;
            this.btnClose.OverrideFocus.Border.Width = 1;
            this.btnClose.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnClose.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnClose.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Size = new System.Drawing.Size(90, 30);
            this.btnClose.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnClose.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnClose.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClose.StateCommon.Border.Rounding = 3;
            this.btnClose.StateCommon.Border.Width = 1;
            this.btnClose.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnClose.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnClose.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnClose.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnClose.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnClose.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnClose.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnClose.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnClose.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnClose.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnClose.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClose.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnClose.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnClose.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnClose.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnClose.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnClose.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnClose.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnClose.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnClose.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnClose.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnClose.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.TabIndex = 2;
            this.btnClose.Values.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdateInDB
            // 
            this.btnUpdateInDB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdateInDB.Location = new System.Drawing.Point(111, 342);
            this.btnUpdateInDB.Name = "btnUpdateInDB";
            this.btnUpdateInDB.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnUpdateInDB.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdateInDB.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnUpdateInDB.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnUpdateInDB.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUpdateInDB.OverrideDefault.Border.Rounding = 3;
            this.btnUpdateInDB.OverrideDefault.Border.Width = 1;
            this.btnUpdateInDB.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdateInDB.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnUpdateInDB.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdateInDB.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnUpdateInDB.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnUpdateInDB.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUpdateInDB.OverrideFocus.Border.Rounding = 3;
            this.btnUpdateInDB.OverrideFocus.Border.Width = 1;
            this.btnUpdateInDB.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateInDB.Size = new System.Drawing.Size(119, 30);
            this.btnUpdateInDB.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnUpdateInDB.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdateInDB.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdateInDB.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdateInDB.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUpdateInDB.StateCommon.Border.Rounding = 3;
            this.btnUpdateInDB.StateCommon.Border.Width = 1;
            this.btnUpdateInDB.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateInDB.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnUpdateInDB.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdateInDB.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateInDB.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnUpdateInDB.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdateInDB.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnUpdateInDB.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnUpdateInDB.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUpdateInDB.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateInDB.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnUpdateInDB.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdateInDB.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateInDB.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnUpdateInDB.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdateInDB.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdateInDB.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateInDB.TabIndex = 3;
            this.btnUpdateInDB.Values.Text = "Update in DB";
            this.btnUpdateInDB.Visible = false;
            this.btnUpdateInDB.Click += new System.EventHandler(this.btnUpdateInInvoice_Click);
            // 
            // FrmResultUPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(460, 394);
            this.Controls.Add(this.btnUpdateInDB);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpAddressList);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmResultUPS";
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
            this.Text = "UPS Result";
            this.Load += new System.EventHandler(this.FrmResultUPS_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.grpAddressList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTrackingCodes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel18;
        private Telerik.WinControls.UI.RadLabel radLabel19;
        private System.Windows.Forms.GroupBox grpAddressList;
        private System.Windows.Forms.Label lblTransaportationCharge;
        private System.Windows.Forms.Label lblServiceOptionCharge;
        private System.Windows.Forms.Label lblTotalCharge;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUpdateInDB;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgTrackingCodes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn ActionPrint;
    }
}

