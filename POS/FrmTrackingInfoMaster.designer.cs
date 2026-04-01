namespace POS
{
    partial class FrmTrackingInfoMaster
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
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnlInvDetails = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgInvDetail = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgUser = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VillageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Print = new System.Windows.Forms.DataGridViewLinkColumn();
            this.UdateTrack = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnSe = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbInvoiceDate = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.pnlInvDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.Location = new System.Drawing.Point(941, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnRefresh.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnRefresh.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRefresh.OverrideDefault.Border.Rounding = 3;
            this.btnRefresh.OverrideDefault.Border.Width = 1;
            this.btnRefresh.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnRefresh.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnRefresh.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRefresh.OverrideFocus.Border.Rounding = 3;
            this.btnRefresh.OverrideFocus.Border.Width = 1;
            this.btnRefresh.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRefresh.StateCommon.Border.Rounding = 3;
            this.btnRefresh.StateCommon.Border.Width = 1;
            this.btnRefresh.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnRefresh.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnRefresh.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRefresh.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnRefresh.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnRefresh.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Values.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlInvDetails
            // 
            this.pnlInvDetails.Controls.Add(this.btnclose);
            this.pnlInvDetails.Controls.Add(this.panel8);
            this.pnlInvDetails.Controls.Add(this.panel7);
            this.pnlInvDetails.Controls.Add(this.panel6);
            this.pnlInvDetails.Controls.Add(this.panel5);
            this.pnlInvDetails.Controls.Add(this.dgInvDetail);
            this.pnlInvDetails.Location = new System.Drawing.Point(101, 194);
            this.pnlInvDetails.Name = "pnlInvDetails";
            this.pnlInvDetails.Size = new System.Drawing.Size(696, 283);
            this.pnlInvDetails.TabIndex = 317;
            this.pnlInvDetails.Visible = false;
            // 
            // btnclose
            // 
            this.btnclose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnclose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.White;
            this.btnclose.Location = new System.Drawing.Point(582, 11);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(80, 30);
            this.btnclose.TabIndex = 232;
            this.btnclose.Tag = "";
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(5, 278);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(681, 5);
            this.panel8.TabIndex = 231;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(686, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 278);
            this.panel7.TabIndex = 230;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(5, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(691, 5);
            this.panel6.TabIndex = 229;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(5, 283);
            this.panel5.TabIndex = 228;
            // 
            // dgInvDetail
            // 
            this.dgInvDetail.AllowUserToAddRows = false;
            this.dgInvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInvDetail.ColumnHeadersHeight = 29;
            this.dgInvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ItemName,
            this.Qty,
            this.Rate,
            this.Amount});
            this.dgInvDetail.Location = new System.Drawing.Point(37, 47);
            this.dgInvDetail.Name = "dgInvDetail";
            this.dgInvDetail.RowHeadersVisible = false;
            this.dgInvDetail.RowHeadersWidth = 51;
            this.dgInvDetail.Size = new System.Drawing.Size(625, 203);
            this.dgInvDetail.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgInvDetail.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgInvDetail.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgInvDetail.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.dgInvDetail.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.dgInvDetail.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgInvDetail.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgInvDetail.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.Black;
            this.dgInvDetail.TabIndex = 227;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.MinimumWidth = 6;
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.MinimumWidth = 6;
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.MinimumWidth = 6;
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlInvDetails);
            this.panel1.Controls.Add(this.dgUser);
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 507);
            this.panel1.TabIndex = 318;
            // 
            // dgUser
            // 
            this.dgUser.AllowUserToAddRows = false;
            this.dgUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgUser.ColumnHeadersHeight = 29;
            this.dgUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Mobile,
            this.Date,
            this.CustomerName,
            this.VillageName,
            this.View,
            this.Print,
            this.UdateTrack});
            this.dgUser.Location = new System.Drawing.Point(3, 0);
            this.dgUser.Name = "dgUser";
            this.dgUser.RowHeadersVisible = false;
            this.dgUser.RowHeadersWidth = 51;
            this.dgUser.Size = new System.Drawing.Size(1025, 504);
            this.dgUser.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgUser.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgUser.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgUser.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.dgUser.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.dgUser.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgUser.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgUser.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.Black;
            this.dgUser.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.White;
            this.dgUser.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.White;
            this.dgUser.TabIndex = 277;
            this.dgUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTracking_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Mobile
            // 
            this.Mobile.HeaderText = "RefNumber";
            this.Mobile.MinimumWidth = 6;
            this.Mobile.Name = "Mobile";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "CustomerName";
            this.CustomerName.MinimumWidth = 6;
            this.CustomerName.Name = "CustomerName";
            // 
            // VillageName
            // 
            this.VillageName.HeaderText = "Total";
            this.VillageName.MinimumWidth = 6;
            this.VillageName.Name = "VillageName";
            // 
            // View
            // 
            this.View.HeaderText = "View";
            this.View.MinimumWidth = 6;
            this.View.Name = "View";
            this.View.Text = "View";
            this.View.ToolTipText = "View";
            this.View.UseColumnTextForLinkValue = true;
            // 
            // Print
            // 
            this.Print.HeaderText = "Print";
            this.Print.MinimumWidth = 6;
            this.Print.Name = "Print";
            this.Print.Text = "Print";
            this.Print.ToolTipText = "Print";
            this.Print.UseColumnTextForLinkValue = true;
            // 
            // UdateTrack
            // 
            this.UdateTrack.HeaderText = "Tracking";
            this.UdateTrack.MinimumWidth = 6;
            this.UdateTrack.Name = "UdateTrack";
            this.UdateTrack.Text = "Update Tracking ";
            this.UdateTrack.ToolTipText = "Update Tracking ";
            this.UdateTrack.UseColumnTextForLinkValue = true;
            // 
            // btnSe
            // 
            this.btnSe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSe.Location = new System.Drawing.Point(853, 3);
            this.btnSe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSe.Name = "btnSe";
            this.btnSe.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSe.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSe.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSe.OverrideDefault.Border.Rounding = 3;
            this.btnSe.OverrideDefault.Border.Width = 1;
            this.btnSe.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSe.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSe.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSe.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSe.OverrideFocus.Border.Rounding = 3;
            this.btnSe.OverrideFocus.Border.Width = 1;
            this.btnSe.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSe.Size = new System.Drawing.Size(82, 29);
            this.btnSe.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.btnSe.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.btnSe.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSe.StateCommon.Border.Rounding = 3;
            this.btnSe.StateCommon.Border.Width = 1;
            this.btnSe.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSe.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSe.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnSe.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnSe.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSe.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSe.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSe.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnSe.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSe.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSe.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSe.TabIndex = 341;
            this.btnSe.Values.Text = "Search";
            this.btnSe.Click += new System.EventHandler(this.btnSe_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(27, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 340;
            this.label3.Text = "Filter By";
            // 
            // txtSearch
            // 
            this.txtSearch.AcceptsReturn = true;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.Location = new System.Drawing.Point(683, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(154, 24);
            this.txtSearch.TabIndex = 339;
            // 
            // dtTo
            // 
            this.dtTo.CalendarTrailingForeColor = System.Drawing.Color.Gainsboro;
            this.dtTo.CustomFormat = "MM-dd-yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(447, 11);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(100, 24);
            this.dtTo.TabIndex = 337;
            this.dtTo.Visible = false;
            this.dtTo.Leave += new System.EventHandler(this.dtTo_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(628, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 338;
            this.label6.Text = "Search";
            // 
            // dtFrom
            // 
            this.dtFrom.CalendarTrailingForeColor = System.Drawing.Color.Gainsboro;
            this.dtFrom.CustomFormat = "MM-dd-yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(310, 12);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(100, 24);
            this.dtFrom.TabIndex = 336;
            this.dtFrom.Visible = false;
            // 
            // cmbInvoiceDate
            // 
            this.cmbInvoiceDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInvoiceDate.FormattingEnabled = true;
            this.cmbInvoiceDate.Items.AddRange(new object[] {
            "Today ",
            "Yesterday ",
            "This Month",
            "This Week ",
            "Last Month ",
            "This Fiscal Year ",
            "ALL",
            "Custom "});
            this.cmbInvoiceDate.Location = new System.Drawing.Point(77, 9);
            this.cmbInvoiceDate.Name = "cmbInvoiceDate";
            this.cmbInvoiceDate.Size = new System.Drawing.Size(153, 26);
            this.cmbInvoiceDate.TabIndex = 335;
            this.cmbInvoiceDate.SelectedIndexChanged += new System.EventHandler(this.cmbInvoiceDate_SelectedIndexChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFrom.Location = new System.Drawing.Point(265, 15);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(48, 20);
            this.lblFrom.TabIndex = 342;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTo.Location = new System.Drawing.Point(416, 15);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(28, 20);
            this.lblTo.TabIndex = 343;
            this.lblTo.Text = "To";
            // 
            // FrmTrackingInfoMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1043, 580);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.btnSe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.cmbInvoiceDate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmTrackingInfoMaster";
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
            this.Text = "TrackingInfo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTrackingInfoMaster_FormClosing);
            this.Load += new System.EventHandler(this.FrmTrackingMaster_Load);
            this.pnlInvDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRefresh;
        private System.Windows.Forms.Panel pnlInvDetails;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgInvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VillageName;
        private System.Windows.Forms.DataGridViewLinkColumn View;
        private System.Windows.Forms.DataGridViewLinkColumn Print;
        private System.Windows.Forms.DataGridViewLinkColumn UdateTrack;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.ComboBox cmbInvoiceDate;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
    }
}

