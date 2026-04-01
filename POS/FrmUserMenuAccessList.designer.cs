namespace POS
{
    partial class FrmUserMenuAccessList
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnReloadData = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dgUserAccess = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUserAccess)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(79, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(282, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnReloadData
            // 
            this.btnReloadData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReloadData.Location = new System.Drawing.Point(378, 16);
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnReloadData.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnReloadData.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnReloadData.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnReloadData.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReloadData.OverrideDefault.Border.Rounding = 3;
            this.btnReloadData.OverrideDefault.Border.Width = 1;
            this.btnReloadData.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReloadData.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReloadData.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReloadData.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnReloadData.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnReloadData.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnReloadData.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnReloadData.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReloadData.OverrideFocus.Border.Rounding = 3;
            this.btnReloadData.OverrideFocus.Border.Width = 1;
            this.btnReloadData.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReloadData.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReloadData.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadData.Size = new System.Drawing.Size(104, 30);
            this.btnReloadData.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReloadData.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnReloadData.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnReloadData.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnReloadData.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReloadData.StateCommon.Border.Rounding = 3;
            this.btnReloadData.StateCommon.Border.Width = 1;
            this.btnReloadData.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReloadData.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReloadData.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadData.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReloadData.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnReloadData.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReloadData.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReloadData.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadData.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReloadData.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnReloadData.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnReloadData.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnReloadData.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnReloadData.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReloadData.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReloadData.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadData.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReloadData.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnReloadData.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReloadData.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReloadData.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadData.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnReloadData.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnReloadData.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnReloadData.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnReloadData.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadData.TabIndex = 2;
            this.btnReloadData.Values.Text = "Reload Data";
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Location = new System.Drawing.Point(488, 16);
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
            this.btnClose.TabIndex = 3;
            this.btnClose.Values.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.btnReloadData);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UserMenu Access";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 25);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(67, 19);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Search :";
            // 
            // dgUserAccess
            // 
            this.dgUserAccess.AllowUserToAddRows = false;
            this.dgUserAccess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgUserAccess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.User,
            this.Edit,
            this.Delete});
            this.dgUserAccess.Location = new System.Drawing.Point(12, 83);
            this.dgUserAccess.Name = "dgUserAccess";
            this.dgUserAccess.RowHeadersVisible = false;
            this.dgUserAccess.Size = new System.Drawing.Size(594, 235);
            this.dgUserAccess.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgUserAccess.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgUserAccess.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgUserAccess.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.White;
            this.dgUserAccess.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.White;
            this.dgUserAccess.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black;
            this.dgUserAccess.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgUserAccess.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.Black;
            this.dgUserAccess.StateCommon.HeaderRow.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgUserAccess.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgUserAccess.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.White;
            this.dgUserAccess.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.White;
            this.dgUserAccess.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.White;
            this.dgUserAccess.StateSelected.HeaderColumn.Border.Color1 = System.Drawing.Color.Black;
            this.dgUserAccess.StateSelected.HeaderColumn.Border.Color2 = System.Drawing.Color.Black;
            this.dgUserAccess.StateSelected.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgUserAccess.StateSelected.HeaderColumn.Content.Color1 = System.Drawing.Color.Black;
            this.dgUserAccess.StateSelected.HeaderColumn.Content.Color2 = System.Drawing.Color.Black;
            this.dgUserAccess.TabIndex = 1;
            this.dgUserAccess.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUserAccess_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // User
            // 
            this.User.FillWeight = 218.2252F;
            this.User.HeaderText = "User";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            this.User.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Edit
            // 
            this.Edit.FillWeight = 75.18411F;
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 74.75397F;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            // 
            // FrmUserMenuAccessList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(618, 361);
            this.Controls.Add(this.dgUserAccess);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmUserMenuAccessList";
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
            this.Text = "User Menu Access List";
            this.Load += new System.EventHandler(this.FrmUserMenuAccessList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUserAccess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.TextBox txtSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnReloadData;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgUserAccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
}

