namespace POS
{
    partial class FrmSalesRepList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSalesRep = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalHeader = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnReset = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btmClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtSalesRepName = new System.Windows.Forms.TextBox();
            this.btnAddNew = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesRepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.PriceTier = new System.Windows.Forms.DataGridViewLinkColumn();
            this.AllowLowestPrice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesRep)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.dgvSalesRep);
            this.panel1.Controls.Add(this.pnlBottom);
            this.panel1.Controls.Add(this.PnlTop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 427);
            this.panel1.TabIndex = 0;
            // 
            // dgvSalesRep
            // 
            this.dgvSalesRep.AllowUserToAddRows = false;
            this.dgvSalesRep.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvSalesRep.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesRep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesRep.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesRep.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesRep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.InActive,
            this.SalesRepName,
            this.UserName,
            this.CompanyName,
            this.Phone,
            this.Email,
            this.UserType,
            this.Edit,
            this.PriceTier,
            this.AllowLowestPrice});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesRep.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalesRep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesRep.GridColor = System.Drawing.SystemColors.Control;
            this.dgvSalesRep.Location = new System.Drawing.Point(0, 55);
            this.dgvSalesRep.MultiSelect = false;
            this.dgvSalesRep.Name = "dgvSalesRep";
            this.dgvSalesRep.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesRep.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSalesRep.RowHeadersVisible = false;
            this.dgvSalesRep.RowHeadersWidth = 15;
            this.dgvSalesRep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesRep.Size = new System.Drawing.Size(983, 326);
            this.dgvSalesRep.TabIndex = 5;
            this.dgvSalesRep.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesRep_CellContentClick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlBottom.Controls.Add(this.panel2);
            this.pnlBottom.Controls.Add(this.chkActive);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 381);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(983, 46);
            this.pnlBottom.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTotalHeader);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(842, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 46);
            this.panel2.TabIndex = 13;
            // 
            // lblTotalHeader
            // 
            this.lblTotalHeader.Location = new System.Drawing.Point(55, 13);
            this.lblTotalHeader.Name = "lblTotalHeader";
            this.lblTotalHeader.Size = new System.Drawing.Size(51, 17);
            this.lblTotalHeader.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.TabIndex = 11;
            this.lblTotalHeader.TabStop = false;
            this.lblTotalHeader.Values.Text = "Total :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(106, 14);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 12;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Location = new System.Drawing.Point(15, 11);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(126, 18);
            this.chkActive.TabIndex = 2;
            this.chkActive.Text = "Include Inactive";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // PnlTop
            // 
            this.PnlTop.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PnlTop.Controls.Add(this.kryptonLabel1);
            this.PnlTop.Controls.Add(this.btnReset);
            this.PnlTop.Controls.Add(this.btmClose);
            this.PnlTop.Controls.Add(this.txtSalesRepName);
            this.PnlTop.Controls.Add(this.btnAddNew);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(983, 55);
            this.PnlTop.TabIndex = 3;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(8, 17);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(127, 19);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.TabStop = false;
            this.kryptonLabel1.Values.Text = "SalesRep Name :";
            // 
            // btnReset
            // 
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.Location = new System.Drawing.Point(511, 12);
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
            this.btnReset.Size = new System.Drawing.Size(90, 30);
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
            this.btnReset.TabIndex = 2;
            this.btnReset.Values.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btmClose
            // 
            this.btmClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btmClose.Location = new System.Drawing.Point(703, 12);
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
            this.btmClose.TabIndex = 4;
            this.btmClose.Values.Text = "Close";
            this.btmClose.Click += new System.EventHandler(this.btmClose_Click);
            // 
            // txtSalesRepName
            // 
            this.txtSalesRepName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesRepName.Location = new System.Drawing.Point(142, 17);
            this.txtSalesRepName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSalesRepName.Name = "txtSalesRepName";
            this.txtSalesRepName.Size = new System.Drawing.Size(359, 21);
            this.txtSalesRepName.TabIndex = 1;
            this.txtSalesRepName.TextChanged += new System.EventHandler(this.txtSalesRepName_TextChanged);
            // 
            // btnAddNew
            // 
            this.btnAddNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddNew.Location = new System.Drawing.Point(607, 12);
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
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Values.Text = "Add New";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // InActive
            // 
            this.InActive.FillWeight = 21.68638F;
            this.InActive.HeaderText = "X";
            this.InActive.Name = "InActive";
            this.InActive.ReadOnly = true;
            // 
            // SalesRepName
            // 
            this.SalesRepName.FillWeight = 126.4655F;
            this.SalesRepName.HeaderText = "Name";
            this.SalesRepName.Name = "SalesRepName";
            this.SalesRepName.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.FillWeight = 94.93815F;
            this.UserName.HeaderText = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // CompanyName
            // 
            this.CompanyName.FillWeight = 94.93815F;
            this.CompanyName.HeaderText = "CompanyName";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.FillWeight = 94.93815F;
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.FillWeight = 94.93815F;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // UserType
            // 
            this.UserType.FillWeight = 94.93815F;
            this.UserType.HeaderText = "UserType";
            this.UserType.Name = "UserType";
            this.UserType.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            // 
            // PriceTier
            // 
            this.PriceTier.HeaderText = "PriceTier";
            this.PriceTier.Name = "PriceTier";
            this.PriceTier.ReadOnly = true;
            this.PriceTier.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PriceTier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PriceTier.Text = "PriceTier";
            this.PriceTier.ToolTipText = "PriceTier";
            this.PriceTier.UseColumnTextForLinkValue = true;
            // 
            // AllowLowestPrice
            // 
            this.AllowLowestPrice.FillWeight = 110F;
            this.AllowLowestPrice.HeaderText = "AllowLowestPrice";
            this.AllowLowestPrice.Name = "AllowLowestPrice";
            this.AllowLowestPrice.ReadOnly = true;
            // 
            // FrmSalesRepList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(983, 427);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmSalesRepList";
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
            this.Text = "Sales Rep List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSalesRepList_FormClosing);
            this.Load += new System.EventHandler(this.FrmSalesRepList_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesRep)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSalesRepName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnReset;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddNew;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btmClose;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.DataGridView dgvSalesRep;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotalHeader;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesRepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn PriceTier;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowLowestPrice;
    }
}

