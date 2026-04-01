namespace POS
{
    partial class FrmUserAccess
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
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbUserName = new System.Windows.Forms.ComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.treeMenu = new System.Windows.Forms.TreeView();
            this.kryptonLabel13 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnUpdate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnReset = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtID = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(28, 33);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(96, 19);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "User Name :";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(8, 33);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(18, 17);
            this.kryptonLabel5.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel5.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.StateNormal.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel5.StateNormal.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonLabel5.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 0;
            this.kryptonLabel5.Values.Text = "*";
            // 
            // cmbUserName
            // 
            this.cmbUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserName.FormattingEnabled = true;
            this.cmbUserName.Location = new System.Drawing.Point(138, 31);
            this.cmbUserName.Name = "cmbUserName";
            this.cmbUserName.Size = new System.Drawing.Size(297, 22);
            this.cmbUserName.TabIndex = 2;
            this.cmbUserName.SelectedIndexChanged += new System.EventHandler(this.cmbUserName_SelectedIndexChanged);
            this.cmbUserName.Leave += new System.EventHandler(this.cmbUserName_Leave);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(28, 72);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(18, 17);
            this.kryptonLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel2.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.StateNormal.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel2.StateNormal.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonLabel2.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "*";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(63, 72);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(57, 19);
            this.kryptonLabel3.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Menu :";
            // 
            // treeMenu
            // 
            this.treeMenu.CheckBoxes = true;
            this.treeMenu.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeMenu.Location = new System.Drawing.Point(138, 60);
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.Size = new System.Drawing.Size(297, 243);
            this.treeMenu.TabIndex = 6;
            this.treeMenu.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeMenu_DrawNode);
            // 
            // kryptonLabel13
            // 
            this.kryptonLabel13.Location = new System.Drawing.Point(28, 384);
            this.kryptonLabel13.Name = "kryptonLabel13";
            this.kryptonLabel13.Size = new System.Drawing.Size(200, 19);
            this.kryptonLabel13.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel13.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonLabel13.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel13.StateNormal.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonLabel13.StateNormal.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonLabel13.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel13.TabIndex = 11;
            this.kryptonLabel13.Values.Text = "* Field Require compulsory";
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdate.Location = new System.Drawing.Point(162, 309);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnUpdate.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdate.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnUpdate.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnUpdate.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUpdate.OverrideDefault.Border.Rounding = 3;
            this.btnUpdate.OverrideDefault.Border.Width = 1;
            this.btnUpdate.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdate.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdate.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnUpdate.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdate.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnUpdate.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnUpdate.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUpdate.OverrideFocus.Border.Rounding = 3;
            this.btnUpdate.OverrideFocus.Border.Width = 1;
            this.btnUpdate.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdate.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdate.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Size = new System.Drawing.Size(87, 30);
            this.btnUpdate.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnUpdate.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdate.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnUpdate.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUpdate.StateCommon.Border.Rounding = 3;
            this.btnUpdate.StateCommon.Border.Width = 1;
            this.btnUpdate.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdate.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnUpdate.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdate.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdate.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdate.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnUpdate.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdate.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnUpdate.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnUpdate.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnUpdate.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdate.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdate.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnUpdate.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdate.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdate.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdate.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnUpdate.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnUpdate.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnUpdate.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnUpdate.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Values.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnReset
            // 
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.Location = new System.Drawing.Point(255, 309);
            this.btnReset.Name = "btnReset";
            this.btnReset.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnReset.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnReset.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnReset.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReset.OverrideDefault.Border.Rounding = 3;
            this.btnReset.OverrideDefault.Border.Width = 1;
            this.btnReset.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnReset.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnReset.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnReset.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReset.OverrideFocus.Border.Rounding = 3;
            this.btnReset.OverrideFocus.Border.Width = 1;
            this.btnReset.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Size = new System.Drawing.Size(87, 30);
            this.btnReset.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReset.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnReset.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReset.StateCommon.Border.Rounding = 3;
            this.btnReset.StateCommon.Border.Width = 1;
            this.btnReset.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReset.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReset.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnReset.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnReset.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReset.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReset.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReset.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnReset.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReset.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReset.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.TabIndex = 8;
            this.btnReset.Values.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Location = new System.Drawing.Point(348, 309);
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
            this.btnClose.Size = new System.Drawing.Size(87, 30);
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
            this.btnClose.TabIndex = 9;
            this.btnClose.Values.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Location = new System.Drawing.Point(329, 345);
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
            this.btnSave.Size = new System.Drawing.Size(106, 30);
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
            this.btnSave.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSave.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnSave.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSave.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSave.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnSave.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSave.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSave.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSave.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSave.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSave.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnSave.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSave.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSave.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnSave.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnSave.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnSave.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.TabIndex = 10;
            this.btnSave.Values.Text = "Save && New";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(452, 32);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(43, 23);
            this.txtID.TabIndex = 3;
            this.txtID.TabStop = false;
            this.txtID.Visible = false;
            // 
            // FrmUserAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(531, 422);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.kryptonLabel13);
            this.Controls.Add(this.treeMenu);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.cmbUserName);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.kryptonLabel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmUserAccess";
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
            this.Text = "User Access";
            this.Load += new System.EventHandler(this.FrmUserMenuAccess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private System.Windows.Forms.ComboBox cmbUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private System.Windows.Forms.TreeView treeMenu;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel13;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUpdate;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnReset;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtID;
    }
}

