namespace POS
{
    partial class FrmUserTypeList
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
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.btnAddNew = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.grpUserType = new System.Windows.Forms.GroupBox();
            this.dgvUserType = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalHeader = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.grpUserType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserType)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddNew.Location = new System.Drawing.Point(339, 18);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnAddNew.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnAddNew.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnAddNew.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnAddNew.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAddNew.OverrideDefault.Border.Rounding = 3;
            this.btnAddNew.OverrideDefault.Border.Width = 1;
            this.btnAddNew.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnAddNew.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnAddNew.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnAddNew.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnAddNew.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnAddNew.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnAddNew.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAddNew.OverrideFocus.Border.Rounding = 3;
            this.btnAddNew.OverrideFocus.Border.Width = 1;
            this.btnAddNew.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnAddNew.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnAddNew.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Size = new System.Drawing.Size(90, 30);
            this.btnAddNew.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnAddNew.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnAddNew.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnAddNew.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnAddNew.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAddNew.StateCommon.Border.Rounding = 3;
            this.btnAddNew.StateCommon.Border.Width = 1;
            this.btnAddNew.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnAddNew.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnAddNew.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnAddNew.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnAddNew.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnAddNew.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnAddNew.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnAddNew.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnAddNew.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnAddNew.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnAddNew.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAddNew.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnAddNew.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnAddNew.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnAddNew.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnAddNew.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnAddNew.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnAddNew.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnAddNew.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnAddNew.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnAddNew.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnAddNew.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Values.Text = "Add New";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // grpUserType
            // 
            this.grpUserType.Controls.Add(this.dgvUserType);
            this.grpUserType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUserType.Location = new System.Drawing.Point(12, 81);
            this.grpUserType.Name = "grpUserType";
            this.grpUserType.Size = new System.Drawing.Size(437, 205);
            this.grpUserType.TabIndex = 1;
            this.grpUserType.TabStop = false;
            this.grpUserType.Text = "UserType Details";
            // 
            // dgvUserType
            // 
            this.dgvUserType.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvUserType.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.UserType,
            this.Edit,
            this.Delete});
            this.dgvUserType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserType.Location = new System.Drawing.Point(3, 18);
            this.dgvUserType.Name = "dgvUserType";
            this.dgvUserType.RowHeadersVisible = false;
            this.dgvUserType.Size = new System.Drawing.Size(431, 184);
            this.dgvUserType.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvUserType.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvUserType.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvUserType.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.White;
            this.dgvUserType.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.White;
            this.dgvUserType.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black;
            this.dgvUserType.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUserType.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.Black;
            this.dgvUserType.StateCommon.HeaderRow.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUserType.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgvUserType.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.White;
            this.dgvUserType.StateSelected.HeaderColumn.Back.Color1 = System.Drawing.Color.White;
            this.dgvUserType.StateSelected.HeaderColumn.Back.Color2 = System.Drawing.Color.White;
            this.dgvUserType.StateSelected.HeaderColumn.Border.Color1 = System.Drawing.Color.Black;
            this.dgvUserType.StateSelected.HeaderColumn.Border.Color2 = System.Drawing.Color.Black;
            this.dgvUserType.StateSelected.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dgvUserType.StateSelected.HeaderColumn.Content.Color1 = System.Drawing.Color.Black;
            this.dgvUserType.StateSelected.HeaderColumn.Content.Color2 = System.Drawing.Color.Black;
            this.dgvUserType.TabIndex = 0;
            this.dgvUserType.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserType_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // UserType
            // 
            this.UserType.FillWeight = 169.5432F;
            this.UserType.HeaderText = "UserType";
            this.UserType.Name = "UserType";
            this.UserType.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddNew);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UserType";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBottom.Controls.Add(this.lblTotal);
            this.pnlBottom.Controls.Add(this.lblTotalHeader);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 301);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(463, 46);
            this.pnlBottom.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(72, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 2;
            // 
            // lblTotalHeader
            // 
            this.lblTotalHeader.Location = new System.Drawing.Point(15, 6);
            this.lblTotalHeader.Name = "lblTotalHeader";
            this.lblTotalHeader.Size = new System.Drawing.Size(55, 19);
            this.lblTotalHeader.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.TabIndex = 1;
            this.lblTotalHeader.TabStop = false;
            this.lblTotalHeader.Values.Text = "Total :";
            // 
            // FrmUserTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(463, 347);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpUserType);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmUserTypeList";
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
            this.Text = "UserType List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUserTypeList_FormClosing);
            this.Load += new System.EventHandler(this.FrmUserTypeList_Load);
            this.grpUserType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserType)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddNew;
        private System.Windows.Forms.GroupBox grpUserType;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvUserType;
        private System.Windows.Forms.Panel pnlBottom;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotalHeader;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
}

