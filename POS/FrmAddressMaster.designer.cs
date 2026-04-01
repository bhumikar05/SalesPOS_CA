namespace POS
{
    partial class FrmAddressMaster
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
            this.pnlAddress = new System.Windows.Forms.Panel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtState = new System.Windows.Forms.TextBox();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtID = new System.Windows.Forms.TextBox();
            this.pnlAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAddress
            // 
            this.pnlAddress.Controls.Add(this.txtNote);
            this.pnlAddress.Controls.Add(this.radLabel3);
            this.pnlAddress.Controls.Add(this.txtCountry);
            this.pnlAddress.Controls.Add(this.radLabel2);
            this.pnlAddress.Controls.Add(this.txtZipCode);
            this.pnlAddress.Controls.Add(this.radLabel1);
            this.pnlAddress.Controls.Add(this.txtState);
            this.pnlAddress.Controls.Add(this.radLabel9);
            this.pnlAddress.Controls.Add(this.txtCity);
            this.pnlAddress.Controls.Add(this.radLabel8);
            this.pnlAddress.Controls.Add(this.txtAddress);
            this.pnlAddress.Controls.Add(this.radLabel7);
            this.pnlAddress.Location = new System.Drawing.Point(14, 12);
            this.pnlAddress.Name = "pnlAddress";
            this.pnlAddress.Size = new System.Drawing.Size(374, 231);
            this.pnlAddress.TabIndex = 0;
            this.pnlAddress.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAddress_Paint);
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.SystemColors.Control;
            this.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNote.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(142, 188);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(208, 23);
            this.txtNote.TabIndex = 11;
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.ForeColor = System.Drawing.Color.Black;
            this.radLabel3.Location = new System.Drawing.Point(12, 189);
            this.radLabel3.Name = "radLabel3";
            // 
            // 
            // 
            this.radLabel3.RootElement.ControlBounds = new System.Drawing.Rectangle(12, 189, 100, 18);
            this.radLabel3.Size = new System.Drawing.Size(40, 18);
            this.radLabel3.TabIndex = 10;
            this.radLabel3.Text = "Note";
            // 
            // txtCountry
            // 
            this.txtCountry.BackColor = System.Drawing.SystemColors.Control;
            this.txtCountry.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCountry.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountry.Location = new System.Drawing.Point(142, 162);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(208, 23);
            this.txtCountry.TabIndex = 9;
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.ForeColor = System.Drawing.Color.Black;
            this.radLabel2.Location = new System.Drawing.Point(12, 162);
            this.radLabel2.Name = "radLabel2";
            // 
            // 
            // 
            this.radLabel2.RootElement.ControlBounds = new System.Drawing.Rectangle(12, 162, 100, 18);
            this.radLabel2.Size = new System.Drawing.Size(135, 18);
            this.radLabel2.TabIndex = 8;
            this.radLabel2.Text = "Country / Region";
            // 
            // txtZipCode
            // 
            this.txtZipCode.BackColor = System.Drawing.SystemColors.Control;
            this.txtZipCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtZipCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZipCode.Location = new System.Drawing.Point(142, 136);
            this.txtZipCode.MaxLength = 13;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(208, 23);
            this.txtZipCode.TabIndex = 7;
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.Black;
            this.radLabel1.Location = new System.Drawing.Point(12, 136);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.ControlBounds = new System.Drawing.Rectangle(12, 136, 100, 18);
            this.radLabel1.Size = new System.Drawing.Size(130, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "Zip / Postal Code";
            // 
            // txtState
            // 
            this.txtState.BackColor = System.Drawing.SystemColors.Control;
            this.txtState.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtState.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtState.Location = new System.Drawing.Point(142, 110);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(208, 23);
            this.txtState.TabIndex = 5;
            // 
            // radLabel9
            // 
            this.radLabel9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel9.ForeColor = System.Drawing.Color.Black;
            this.radLabel9.Location = new System.Drawing.Point(12, 110);
            this.radLabel9.Name = "radLabel9";
            // 
            // 
            // 
            this.radLabel9.RootElement.ControlBounds = new System.Drawing.Rectangle(12, 110, 100, 18);
            this.radLabel9.Size = new System.Drawing.Size(125, 18);
            this.radLabel9.TabIndex = 4;
            this.radLabel9.Text = "State / Province";
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.SystemColors.Control;
            this.txtCity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(142, 84);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(208, 23);
            this.txtCity.TabIndex = 3;
            // 
            // radLabel8
            // 
            this.radLabel8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.ForeColor = System.Drawing.Color.Black;
            this.radLabel8.Location = new System.Drawing.Point(12, 82);
            this.radLabel8.Name = "radLabel8";
            // 
            // 
            // 
            this.radLabel8.RootElement.ControlBounds = new System.Drawing.Rectangle(12, 82, 100, 18);
            this.radLabel8.Size = new System.Drawing.Size(35, 18);
            this.radLabel8.TabIndex = 2;
            this.radLabel8.Text = "City";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.SystemColors.Control;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.Location = new System.Drawing.Point(142, 11);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(208, 67);
            this.txtAddress.TabIndex = 1;
            // 
            // radLabel7
            // 
            this.radLabel7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.ForeColor = System.Drawing.Color.Black;
            this.radLabel7.Location = new System.Drawing.Point(12, 12);
            this.radLabel7.Name = "radLabel7";
            // 
            // 
            // 
            this.radLabel7.RootElement.ControlBounds = new System.Drawing.Rectangle(12, 12, 100, 18);
            this.radLabel7.Size = new System.Drawing.Size(60, 18);
            this.radLabel7.TabIndex = 0;
            this.radLabel7.Text = "Address";
            // 
            // btnOK
            // 
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.Location = new System.Drawing.Point(394, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnOK.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnOK.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnOK.OverrideDefault.Border.Rounding = 3;
            this.btnOK.OverrideDefault.Border.Width = 1;
            this.btnOK.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnOK.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnOK.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOK.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnOK.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnOK.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnOK.OverrideFocus.Border.Rounding = 3;
            this.btnOK.OverrideFocus.Border.Width = 1;
            this.btnOK.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnOK.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnOK.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnOK.StateCommon.Border.Rounding = 3;
            this.btnOK.StateCommon.Border.Width = 1;
            this.btnOK.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnOK.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnOK.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnOK.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnOK.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnOK.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnOK.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnOK.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnOK.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnOK.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnOK.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnOK.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnOK.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnOK.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnOK.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.TabIndex = 1;
            this.btnOK.Values.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Location = new System.Drawing.Point(394, 50);
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
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
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
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Values.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Control;
            this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtID.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(394, 86);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(61, 26);
            this.txtID.TabIndex = 3;
            this.txtID.TabStop = false;
            this.txtID.Text = "0";
            this.txtID.Visible = false;
            // 
            // FrmAddressMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(514, 285);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlAddress);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmAddressMaster";
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
            this.Text = "Edit Address Information";
            this.Load += new System.EventHandler(this.FrmAddressMaster_Load);
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.Panel pnlAddress;
        private System.Windows.Forms.TextBox txtNote;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.TextBox txtCountry;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.TextBox txtZipCode;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.TextBox txtState;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private System.Windows.Forms.TextBox txtCity;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtAddress;
    }
}

