namespace POS
{
    partial class FrmUPSSettings
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
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblRates = new System.Windows.Forms.Label();
            this.chkNegotiatedRate = new System.Windows.Forms.CheckBox();
            this.grpShip = new System.Windows.Forms.GroupBox();
            this.chkotherservice = new System.Windows.Forms.CheckBox();
            this.chkDeliveryConfirmation = new System.Windows.Forms.CheckBox();
            this.chkCOD = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrinterSettings = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpShip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.label1);
            this.grpGeneral.Controls.Add(this.pictureBox1);
            this.grpGeneral.Controls.Add(this.lblAccount);
            this.grpGeneral.Controls.Add(this.lblRates);
            this.grpGeneral.Controls.Add(this.chkNegotiatedRate);
            this.grpGeneral.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGeneral.Location = new System.Drawing.Point(25, 12);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(497, 101);
            this.grpGeneral.TabIndex = 7;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Account is ready to use";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS.Properties.Resources._6;
            this.pictureBox1.Location = new System.Drawing.Point(47, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 29);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.Location = new System.Drawing.Point(44, 27);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(161, 16);
            this.lblAccount.TabIndex = 10;
            this.lblAccount.Text = "UPS Account = 4E9A02";
            // 
            // lblRates
            // 
            this.lblRates.AutoSize = true;
            this.lblRates.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRates.Location = new System.Drawing.Point(283, 27);
            this.lblRates.Name = "lblRates";
            this.lblRates.Size = new System.Drawing.Size(44, 16);
            this.lblRates.TabIndex = 9;
            this.lblRates.Text = "Rates";
            // 
            // chkNegotiatedRate
            // 
            this.chkNegotiatedRate.AutoSize = true;
            this.chkNegotiatedRate.Location = new System.Drawing.Point(334, 29);
            this.chkNegotiatedRate.Name = "chkNegotiatedRate";
            this.chkNegotiatedRate.Size = new System.Drawing.Size(130, 17);
            this.chkNegotiatedRate.TabIndex = 0;
            this.chkNegotiatedRate.Text = "Negotiated Rate";
            this.chkNegotiatedRate.UseVisualStyleBackColor = true;
            // 
            // grpShip
            // 
            this.grpShip.Controls.Add(this.chkotherservice);
            this.grpShip.Controls.Add(this.chkDeliveryConfirmation);
            this.grpShip.Controls.Add(this.chkCOD);
            this.grpShip.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpShip.Location = new System.Drawing.Point(538, 12);
            this.grpShip.Name = "grpShip";
            this.grpShip.Size = new System.Drawing.Size(185, 112);
            this.grpShip.TabIndex = 8;
            this.grpShip.TabStop = false;
            this.grpShip.Text = "Ship";
            // 
            // chkotherservice
            // 
            this.chkotherservice.AutoSize = true;
            this.chkotherservice.Location = new System.Drawing.Point(6, 73);
            this.chkotherservice.Name = "chkotherservice";
            this.chkotherservice.Size = new System.Drawing.Size(115, 17);
            this.chkotherservice.TabIndex = 32;
            this.chkotherservice.Text = "Other Service";
            this.chkotherservice.UseVisualStyleBackColor = true;
            // 
            // chkDeliveryConfirmation
            // 
            this.chkDeliveryConfirmation.AutoSize = true;
            this.chkDeliveryConfirmation.Location = new System.Drawing.Point(6, 27);
            this.chkDeliveryConfirmation.Name = "chkDeliveryConfirmation";
            this.chkDeliveryConfirmation.Size = new System.Drawing.Size(169, 17);
            this.chkDeliveryConfirmation.TabIndex = 31;
            this.chkDeliveryConfirmation.Text = "Delivery Confirmation";
            this.chkDeliveryConfirmation.UseVisualStyleBackColor = true;
            // 
            // chkCOD
            // 
            this.chkCOD.AutoSize = true;
            this.chkCOD.Location = new System.Drawing.Point(6, 50);
            this.chkCOD.Name = "chkCOD";
            this.chkCOD.Size = new System.Drawing.Size(52, 17);
            this.chkCOD.TabIndex = 30;
            this.chkCOD.Text = "COD";
            this.chkCOD.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrinterSettings);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 134);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Printer Settings";
            // 
            // btnPrinterSettings
            // 
            this.btnPrinterSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrinterSettings.Location = new System.Drawing.Point(244, 72);
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
            this.btnPrinterSettings.Size = new System.Drawing.Size(141, 32);
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
            this.btnPrinterSettings.TabIndex = 338;
            this.btnPrinterSettings.Values.Text = "Printer Settings";
            this.btnPrinterSettings.Click += new System.EventHandler(this.btnPrinterSettings_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(131, 42);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(254, 23);
            this.txtName.TabIndex = 337;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(27, 44);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(103, 17);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(117)))));
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(117)))));
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(117)))));
            this.kryptonLabel1.StateNormal.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(117)))));
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 336;
            this.kryptonLabel1.Values.Text = "Printer Name :";
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Location = new System.Drawing.Point(506, 172);
            this.btnSave.Name = "btnSave";
            this.btnSave.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnSave.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnSave.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSave.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSave.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSave.OverrideDefault.Border.Rounding = 3;
            this.btnSave.OverrideDefault.Border.Width = 1;
            this.btnSave.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSave.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnSave.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnSave.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSave.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSave.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSave.OverrideFocus.Border.Rounding = 3;
            this.btnSave.OverrideFocus.Border.Width = 1;
            this.btnSave.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSave.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSave.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnSave.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSave.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSave.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSave.StateCommon.Border.Rounding = 3;
            this.btnSave.StateCommon.Border.Width = 1;
            this.btnSave.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSave.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSave.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnSave.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSave.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSave.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnSave.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSave.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSave.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSave.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSave.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSave.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnSave.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSave.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSave.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnSave.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSave.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.TabIndex = 11;
            this.btnSave.Values.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // FrmUPSSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(751, 313);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpShip);
            this.Controls.Add(this.grpGeneral);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmUPSSettings";
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
            this.Text = "UPS Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUPSSettings_FormClosing);
            this.Load += new System.EventHandler(this.FrmUPSSettings_Load);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpShip.ResumeLayout(false);
            this.grpShip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.CheckBox chkNegotiatedRate;
        private System.Windows.Forms.GroupBox grpShip;
        private System.Windows.Forms.CheckBox chkCOD;
        private System.Windows.Forms.CheckBox chkDeliveryConfirmation;
        private System.Windows.Forms.CheckBox chkotherservice;
        private System.Windows.Forms.Label lblRates;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrinterSettings;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}

