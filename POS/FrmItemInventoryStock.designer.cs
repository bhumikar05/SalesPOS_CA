namespace POS
{
    partial class FrmItemInventoryStock
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.pnlItem = new System.Windows.Forms.Panel();
            this.btnpnlClose = new System.Windows.Forms.Button();
            this.grpPersonal = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnImport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.rdbIncrement = new System.Windows.Forms.RadioButton();
            this.rdbRecreate = new System.Windows.Forms.RadioButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvItemInventoryList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalQtyOnHand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalHeader = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.btnBrowse = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btmClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.rdbPrice = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonal.Panel)).BeginInit();
            this.grpPersonal.Panel.SuspendLayout();
            this.grpPersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemInventoryList)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Controls.Add(this.PnlTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1109, 462);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.pnlItem);
            this.pnlGrid.Controls.Add(this.dgvItemInventoryList);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 47);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1109, 369);
            this.pnlGrid.TabIndex = 143;
            // 
            // pnlItem
            // 
            this.pnlItem.Controls.Add(this.btnpnlClose);
            this.pnlItem.Controls.Add(this.grpPersonal);
            this.pnlItem.Controls.Add(this.panel8);
            this.pnlItem.Controls.Add(this.panel7);
            this.pnlItem.Controls.Add(this.panel6);
            this.pnlItem.Controls.Add(this.panel5);
            this.pnlItem.Location = new System.Drawing.Point(229, 61);
            this.pnlItem.Name = "pnlItem";
            this.pnlItem.Size = new System.Drawing.Size(557, 253);
            this.pnlItem.TabIndex = 317;
            this.pnlItem.Visible = false;
            // 
            // btnpnlClose
            // 
            this.btnpnlClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnpnlClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnpnlClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpnlClose.FlatAppearance.BorderSize = 0;
            this.btnpnlClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnpnlClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpnlClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpnlClose.ForeColor = System.Drawing.Color.White;
            this.btnpnlClose.Location = new System.Drawing.Point(433, 11);
            this.btnpnlClose.Name = "btnpnlClose";
            this.btnpnlClose.Size = new System.Drawing.Size(81, 31);
            this.btnpnlClose.TabIndex = 319;
            this.btnpnlClose.Tag = "";
            this.btnpnlClose.Text = "Close";
            this.btnpnlClose.UseVisualStyleBackColor = false;
            this.btnpnlClose.Click += new System.EventHandler(this.btnpnlClose_Click);
            // 
            // grpPersonal
            // 
            this.grpPersonal.Location = new System.Drawing.Point(24, 61);
            this.grpPersonal.Name = "grpPersonal";
            // 
            // grpPersonal.Panel
            // 
            this.grpPersonal.Panel.Controls.Add(this.rdbPrice);
            this.grpPersonal.Panel.Controls.Add(this.btnImport);
            this.grpPersonal.Panel.Controls.Add(this.rdbIncrement);
            this.grpPersonal.Panel.Controls.Add(this.rdbRecreate);
            this.grpPersonal.Size = new System.Drawing.Size(490, 156);
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
            this.grpPersonal.TabIndex = 234;
            this.grpPersonal.Values.Heading = "Select option for stock";
            // 
            // btnImport
            // 
            this.btnImport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnImport.Location = new System.Drawing.Point(363, 77);
            this.btnImport.Name = "btnImport";
            this.btnImport.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnImport.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnImport.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnImport.OverrideDefault.Border.Rounding = 3;
            this.btnImport.OverrideDefault.Border.Width = 1;
            this.btnImport.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnImport.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnImport.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnImport.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnImport.OverrideFocus.Border.Rounding = 3;
            this.btnImport.OverrideFocus.Border.Width = 1;
            this.btnImport.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Size = new System.Drawing.Size(90, 30);
            this.btnImport.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnImport.StateCommon.Border.Rounding = 3;
            this.btnImport.StateCommon.Border.Width = 1;
            this.btnImport.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnImport.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnImport.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnImport.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.TabIndex = 235;
            this.btnImport.Values.Text = "Browse";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // rdbIncrement
            // 
            this.rdbIncrement.AutoSize = true;
            this.rdbIncrement.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbIncrement.Location = new System.Drawing.Point(19, 52);
            this.rdbIncrement.Name = "rdbIncrement";
            this.rdbIncrement.Size = new System.Drawing.Size(323, 20);
            this.rdbIncrement.TabIndex = 1;
            this.rdbIncrement.Text = "Would you like to increment in old Stock?";
            this.rdbIncrement.UseVisualStyleBackColor = true;
            // 
            // rdbRecreate
            // 
            this.rdbRecreate.AutoSize = true;
            this.rdbRecreate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbRecreate.Location = new System.Drawing.Point(19, 17);
            this.rdbRecreate.Name = "rdbRecreate";
            this.rdbRecreate.Size = new System.Drawing.Size(268, 20);
            this.rdbRecreate.TabIndex = 0;
            this.rdbRecreate.Text = "Would you like to recreate Stock?";
            this.rdbRecreate.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(5, 248);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(542, 5);
            this.panel8.TabIndex = 231;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(547, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 248);
            this.panel7.TabIndex = 230;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(5, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(552, 5);
            this.panel6.TabIndex = 229;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 253);
            this.panel5.TabIndex = 228;
            // 
            // dgvItemInventoryList
            // 
            this.dgvItemInventoryList.AllowUserToAddRows = false;
            this.dgvItemInventoryList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvItemInventoryList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemInventoryList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItemInventoryList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemInventoryList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItemInventoryList.ColumnHeadersHeight = 30;
            this.dgvItemInventoryList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ItemName,
            this.Description,
            this.Type,
            this.Account,
            this.TotalQtyOnHand,
            this.Price});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemInventoryList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItemInventoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemInventoryList.GridColor = System.Drawing.SystemColors.Control;
            this.dgvItemInventoryList.Location = new System.Drawing.Point(0, 0);
            this.dgvItemInventoryList.MultiSelect = false;
            this.dgvItemInventoryList.Name = "dgvItemInventoryList";
            this.dgvItemInventoryList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemInventoryList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItemInventoryList.RowHeadersVisible = false;
            this.dgvItemInventoryList.RowHeadersWidth = 15;
            this.dgvItemInventoryList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemInventoryList.Size = new System.Drawing.Size(1109, 369);
            this.dgvItemInventoryList.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.FillWeight = 132.9511F;
            this.ItemName.HeaderText = "NAME";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.FillWeight = 132.9511F;
            this.Description.HeaderText = "DESCRIPTION";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.FillWeight = 95.93909F;
            this.Type.HeaderText = "TYPE";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Account
            // 
            this.Account.FillWeight = 95.93909F;
            this.Account.HeaderText = "ACCOUNT";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            // 
            // TotalQtyOnHand
            // 
            this.TotalQtyOnHand.FillWeight = 124.3655F;
            this.TotalQtyOnHand.HeaderText = "TOTAL QUANTITY ON HAND";
            this.TotalQtyOnHand.Name = "TotalQtyOnHand";
            this.TotalQtyOnHand.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.FillWeight = 95.93909F;
            this.Price.HeaderText = "PRICE";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlBottom.Controls.Add(this.lblTotal);
            this.pnlBottom.Controls.Add(this.lblTotalHeader);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 416);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1109, 46);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(65, 11);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 9;
            // 
            // lblTotalHeader
            // 
            this.lblTotalHeader.Location = new System.Drawing.Point(12, 9);
            this.lblTotalHeader.Name = "lblTotalHeader";
            this.lblTotalHeader.Size = new System.Drawing.Size(59, 20);
            this.lblTotalHeader.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.TabIndex = 8;
            this.lblTotalHeader.TabStop = false;
            this.lblTotalHeader.Values.Text = "Total :";
            // 
            // PnlTop
            // 
            this.PnlTop.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PnlTop.Controls.Add(this.btnBrowse);
            this.PnlTop.Controls.Add(this.btnExport);
            this.PnlTop.Controls.Add(this.btmClose);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(1109, 47);
            this.PnlTop.TabIndex = 2;
            this.PnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlTop_Paint);
            // 
            // btnBrowse
            // 
            this.btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowse.Location = new System.Drawing.Point(108, 11);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnBrowse.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnBrowse.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnBrowse.OverrideDefault.Border.Rounding = 3;
            this.btnBrowse.OverrideDefault.Border.Width = 1;
            this.btnBrowse.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnBrowse.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnBrowse.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnBrowse.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnBrowse.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnBrowse.OverrideFocus.Border.Rounding = 3;
            this.btnBrowse.OverrideFocus.Border.Width = 1;
            this.btnBrowse.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnBrowse.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnBrowse.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Size = new System.Drawing.Size(90, 30);
            this.btnBrowse.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnBrowse.StateCommon.Border.Rounding = 3;
            this.btnBrowse.StateCommon.Border.Width = 1;
            this.btnBrowse.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnBrowse.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnBrowse.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnBrowse.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnBrowse.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnBrowse.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnBrowse.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnBrowse.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnBrowse.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnBrowse.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnBrowse.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnBrowse.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnBrowse.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnBrowse.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnBrowse.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.TabIndex = 236;
            this.btnBrowse.Values.Text = "Import";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnExport
            // 
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.Location = new System.Drawing.Point(12, 11);
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
            this.btnExport.Size = new System.Drawing.Size(90, 30);
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
            this.btnExport.TabIndex = 4;
            this.btnExport.Values.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btmClose
            // 
            this.btmClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btmClose.Location = new System.Drawing.Point(994, 11);
            this.btmClose.Name = "btmClose";
            this.btmClose.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btmClose.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btmClose.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btmClose.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btmClose.OverrideDefault.Border.Rounding = 3;
            this.btmClose.OverrideDefault.Border.Width = 1;
            this.btmClose.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btmClose.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btmClose.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btmClose.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btmClose.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btmClose.OverrideFocus.Border.Rounding = 3;
            this.btmClose.OverrideFocus.Border.Width = 1;
            this.btmClose.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmClose.Size = new System.Drawing.Size(90, 30);
            this.btmClose.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btmClose.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btmClose.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btmClose.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btmClose.StateCommon.Border.Rounding = 3;
            this.btmClose.StateCommon.Border.Width = 1;
            this.btmClose.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmClose.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btmClose.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmClose.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btmClose.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btmClose.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btmClose.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btmClose.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmClose.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btmClose.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmClose.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btmClose.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btmClose.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btmClose.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btmClose.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmClose.TabIndex = 5;
            this.btmClose.Values.Text = "Close";
            this.btmClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rdbPrice
            // 
            this.rdbPrice.AutoSize = true;
            this.rdbPrice.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPrice.Location = new System.Drawing.Point(19, 87);
            this.rdbPrice.Name = "rdbPrice";
            this.rdbPrice.Size = new System.Drawing.Size(302, 20);
            this.rdbPrice.TabIndex = 236;
            this.rdbPrice.Text = "Whould you like to Update SalesPrice?";
            this.rdbPrice.UseVisualStyleBackColor = true;
            // 
            // FrmItemInventoryStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1109, 462);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmItemInventoryStock";
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
            this.Text = "Item Inventory Stock";
            this.Load += new System.EventHandler(this.FrmItemList_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonal.Panel)).EndInit();
            this.grpPersonal.Panel.ResumeLayout(false);
            this.grpPersonal.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonal)).EndInit();
            this.grpPersonal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemInventoryList)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.PnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlGrid;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btmClose;
        private System.Windows.Forms.DataGridView dgvItemInventoryList;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnExport;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotalHeader;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalQtyOnHand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Panel pnlItem;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpPersonal;
        private System.Windows.Forms.RadioButton rdbIncrement;
        private System.Windows.Forms.RadioButton rdbRecreate;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnImport;
        private System.Windows.Forms.Button btnpnlClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBrowse;
        private System.Windows.Forms.RadioButton rdbPrice;
    }
}

