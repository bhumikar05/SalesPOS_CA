namespace POS
{
    partial class FrmCustomerStatement
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
            this.btnNew = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.btnprint = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEmail = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNew.Location = new System.Drawing.Point(468, -91);
            this.btnNew.Name = "btnNew";
            this.btnNew.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnNew.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnNew.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNew.OverrideDefault.Border.Rounding = 3;
            this.btnNew.OverrideDefault.Border.Width = 1;
            this.btnNew.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnNew.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnNew.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNew.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnNew.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnNew.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNew.OverrideFocus.Border.Rounding = 3;
            this.btnNew.OverrideFocus.Border.Width = 1;
            this.btnNew.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnNew.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnNew.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Size = new System.Drawing.Size(93, 30);
            this.btnNew.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNew.StateCommon.Border.Rounding = 3;
            this.btnNew.StateCommon.Border.Width = 1;
            this.btnNew.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnNew.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnNew.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnNew.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnNew.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnNew.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnNew.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnNew.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnNew.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnNew.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnNew.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnNew.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnNew.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnNew.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnNew.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.TabIndex = 280;
            this.btnNew.Values.Text = "AddNew";
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Location = new System.Drawing.Point(1235, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnAdd.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnAdd.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAdd.OverrideDefault.Border.Rounding = 3;
            this.btnAdd.OverrideDefault.Border.Width = 1;
            this.btnAdd.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnAdd.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnAdd.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnAdd.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnAdd.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAdd.OverrideFocus.Border.Rounding = 3;
            this.btnAdd.OverrideFocus.Border.Width = 1;
            this.btnAdd.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnAdd.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnAdd.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Size = new System.Drawing.Size(93, 30);
            this.btnAdd.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAdd.StateCommon.Border.Rounding = 3;
            this.btnAdd.StateCommon.Border.Width = 1;
            this.btnAdd.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnAdd.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnAdd.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnAdd.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnAdd.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnAdd.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnAdd.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAdd.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnAdd.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnAdd.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnAdd.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnAdd.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnAdd.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnAdd.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Values.Text = "AddNew";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.DropDownWidth = 300;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(163, 34);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(199, 21);
            this.cmbCustomer.TabIndex = 281;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(28, 34);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(101, 17);
            this.lblCustomer.TabIndex = 282;
            this.lblCustomer.Text = "CUSTOMER:-";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(163, 84);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(216, 21);
            this.dtpFromDate.TabIndex = 283;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(163, 133);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(215, 21);
            this.dtpToDate.TabIndex = 284;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.ForeColor = System.Drawing.Color.Black;
            this.lblToDate.Location = new System.Drawing.Point(28, 133);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(75, 17);
            this.lblToDate.TabIndex = 285;
            this.lblToDate.Text = "To Date:-";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.Black;
            this.lblFromDate.Location = new System.Drawing.Point(28, 84);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(95, 17);
            this.lblFromDate.TabIndex = 286;
            this.lblFromDate.Text = "From Date:-";
            // 
            // btnprint
            // 
            this.btnprint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnprint.Location = new System.Drawing.Point(171, 195);
            this.btnprint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnprint.Name = "btnprint";
            this.btnprint.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnprint.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnprint.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnprint.OverrideDefault.Border.Rounding = 3;
            this.btnprint.OverrideDefault.Border.Width = 1;
            this.btnprint.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnprint.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnprint.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnprint.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnprint.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnprint.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnprint.OverrideFocus.Border.Rounding = 3;
            this.btnprint.OverrideFocus.Border.Width = 1;
            this.btnprint.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnprint.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnprint.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.Size = new System.Drawing.Size(95, 32);
            this.btnprint.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.btnprint.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.btnprint.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnprint.StateCommon.Border.Rounding = 3;
            this.btnprint.StateCommon.Border.Width = 1;
            this.btnprint.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnprint.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnprint.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnprint.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnprint.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnprint.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnprint.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnprint.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnprint.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnprint.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnprint.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnprint.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnprint.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnprint.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnprint.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.TabIndex = 343;
            this.btnprint.Values.Text = "Print";
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnExport
            // 
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.Location = new System.Drawing.Point(70, 195);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.btnExport.Size = new System.Drawing.Size(95, 32);
            this.btnExport.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnExport.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.btnExport.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
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
            this.btnExport.TabIndex = 344;
            this.btnExport.Values.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEmail.Location = new System.Drawing.Point(273, 195);
            this.btnEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnEmail.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnEmail.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEmail.OverrideDefault.Border.Rounding = 3;
            this.btnEmail.OverrideDefault.Border.Width = 1;
            this.btnEmail.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnEmail.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnEmail.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnEmail.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnEmail.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnEmail.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEmail.OverrideFocus.Border.Rounding = 3;
            this.btnEmail.OverrideFocus.Border.Width = 1;
            this.btnEmail.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnEmail.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnEmail.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.Size = new System.Drawing.Size(95, 32);
            this.btnEmail.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.btnEmail.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.btnEmail.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEmail.StateCommon.Border.Rounding = 3;
            this.btnEmail.StateCommon.Border.Width = 1;
            this.btnEmail.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnEmail.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnEmail.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnEmail.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnEmail.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnEmail.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnEmail.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEmail.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnEmail.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnEmail.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnEmail.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnEmail.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnEmail.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnEmail.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnEmail.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.TabIndex = 345;
            this.btnEmail.Values.Text = "Email";
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // FrmCustomerStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(432, 305);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.btnNew);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmCustomerStatement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
            this.Text = "Customer Statement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNew;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAdd;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnprint;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExport;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEmail;
    }
}

