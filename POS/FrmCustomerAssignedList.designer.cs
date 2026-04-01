namespace POS
{
    partial class FrmCustomerAssignedList
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
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalHeader = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnPullOut = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnPullIn = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.grpPersonal = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.rdbPullIn = new System.Windows.Forms.RadioButton();
            this.rdbPullOut = new System.Windows.Forms.RadioButton();
            this.cmbSalesRepName = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonal.Panel)).BeginInit();
            this.grpPersonal.Panel.SuspendLayout();
            this.grpPersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSalesRepName)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Controls.Add(this.PnlTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(979, 488);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.chkAll);
            this.pnlGrid.Controls.Add(this.dgvCustomer);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 143);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(979, 299);
            this.pnlGrid.TabIndex = 143;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(28, 7);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(80, 17);
            this.chkAll.TabIndex = 6;
            this.chkAll.Text = "Check All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomer.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomer.ColumnHeadersHeight = 30;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.chkSelect,
            this.CustomerName,
            this.CompanyName,
            this.Phone,
            this.Email});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomer.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomer.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCustomer.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomer.MultiSelect = false;
            this.dgvCustomer.Name = "dgvCustomer";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCustomer.RowHeadersVisible = false;
            this.dgvCustomer.RowHeadersWidth = 15;
            this.dgvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomer.Size = new System.Drawing.Size(979, 299);
            this.dgvCustomer.TabIndex = 0;
            this.dgvCustomer.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCustomer_DataError);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // chkSelect
            // 
            this.chkSelect.HeaderText = "";
            this.chkSelect.Name = "chkSelect";
            // 
            // CustomerName
            // 
            this.CustomerName.FillWeight = 113.9086F;
            this.CustomerName.HeaderText = "NAME";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // CompanyName
            // 
            this.CompanyName.FillWeight = 113.9086F;
            this.CompanyName.HeaderText = "COMPANY NAME";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.FillWeight = 113.9086F;
            this.Phone.HeaderText = "PHONE";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.FillWeight = 113.9086F;
            this.Email.HeaderText = "EMAIL";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlBottom.Controls.Add(this.lblTotal);
            this.pnlBottom.Controls.Add(this.lblTotalHeader);
            this.pnlBottom.Controls.Add(this.btnPullOut);
            this.pnlBottom.Controls.Add(this.btnPullIn);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 442);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(979, 46);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(69, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 6;
            // 
            // lblTotalHeader
            // 
            this.lblTotalHeader.Location = new System.Drawing.Point(12, 10);
            this.lblTotalHeader.Name = "lblTotalHeader";
            this.lblTotalHeader.Size = new System.Drawing.Size(59, 20);
            this.lblTotalHeader.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblTotalHeader.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.TabIndex = 5;
            this.lblTotalHeader.TabStop = false;
            this.lblTotalHeader.Values.Text = "Total :";
            // 
            // btnPullOut
            // 
            this.btnPullOut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPullOut.Location = new System.Drawing.Point(757, 6);
            this.btnPullOut.Name = "btnPullOut";
            this.btnPullOut.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnPullOut.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnPullOut.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPullOut.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPullOut.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPullOut.OverrideDefault.Border.Rounding = 3;
            this.btnPullOut.OverrideDefault.Border.Width = 1;
            this.btnPullOut.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullOut.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullOut.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPullOut.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnPullOut.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnPullOut.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPullOut.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPullOut.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPullOut.OverrideFocus.Border.Rounding = 3;
            this.btnPullOut.OverrideFocus.Border.Width = 1;
            this.btnPullOut.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullOut.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullOut.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullOut.Size = new System.Drawing.Size(100, 30);
            this.btnPullOut.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPullOut.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnPullOut.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPullOut.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPullOut.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPullOut.StateCommon.Border.Rounding = 3;
            this.btnPullOut.StateCommon.Border.Width = 1;
            this.btnPullOut.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullOut.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullOut.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullOut.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPullOut.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnPullOut.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullOut.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullOut.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullOut.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPullOut.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnPullOut.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPullOut.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPullOut.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPullOut.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullOut.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullOut.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullOut.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPullOut.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnPullOut.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullOut.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullOut.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullOut.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPullOut.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnPullOut.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullOut.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullOut.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullOut.TabIndex = 4;
            this.btnPullOut.Values.Text = "PullOut";
            this.btnPullOut.Click += new System.EventHandler(this.btnPullOut_Click);
            // 
            // btnPullIn
            // 
            this.btnPullIn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPullIn.Location = new System.Drawing.Point(863, 6);
            this.btnPullIn.Name = "btnPullIn";
            this.btnPullIn.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnPullIn.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnPullIn.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPullIn.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPullIn.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPullIn.OverrideDefault.Border.Rounding = 3;
            this.btnPullIn.OverrideDefault.Border.Width = 1;
            this.btnPullIn.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullIn.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullIn.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPullIn.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnPullIn.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnPullIn.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPullIn.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPullIn.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPullIn.OverrideFocus.Border.Rounding = 3;
            this.btnPullIn.OverrideFocus.Border.Width = 1;
            this.btnPullIn.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullIn.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullIn.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullIn.Size = new System.Drawing.Size(100, 30);
            this.btnPullIn.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPullIn.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnPullIn.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnPullIn.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnPullIn.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPullIn.StateCommon.Border.Rounding = 3;
            this.btnPullIn.StateCommon.Border.Width = 1;
            this.btnPullIn.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullIn.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullIn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullIn.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPullIn.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnPullIn.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullIn.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullIn.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullIn.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPullIn.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnPullIn.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnPullIn.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnPullIn.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnPullIn.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullIn.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullIn.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullIn.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPullIn.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnPullIn.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullIn.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullIn.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullIn.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnPullIn.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnPullIn.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnPullIn.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnPullIn.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullIn.TabIndex = 3;
            this.btnPullIn.Values.Text = "PullIn";
            this.btnPullIn.Click += new System.EventHandler(this.btnPullIn_Click);
            // 
            // PnlTop
            // 
            this.PnlTop.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PnlTop.Controls.Add(this.txtFilter);
            this.PnlTop.Controls.Add(this.radLabel8);
            this.PnlTop.Controls.Add(this.grpPersonal);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(979, 143);
            this.PnlTop.TabIndex = 0;
            // 
            // txtFilter
            // 
            this.txtFilter.AcceptsReturn = true;
            this.txtFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilter.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(147, 106);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(250, 23);
            this.txtFilter.TabIndex = 5;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // radLabel8
            // 
            this.radLabel8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.ForeColor = System.Drawing.Color.Black;
            this.radLabel8.Location = new System.Drawing.Point(28, 106);
            this.radLabel8.Name = "radLabel8";
            // 
            // 
            // 
            this.radLabel8.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 18);
            this.radLabel8.Size = new System.Drawing.Size(112, 18);
            this.radLabel8.TabIndex = 4;
            this.radLabel8.Text = "Search Name : ";
            // 
            // grpPersonal
            // 
            this.grpPersonal.Location = new System.Drawing.Point(12, 12);
            this.grpPersonal.Name = "grpPersonal";
            // 
            // grpPersonal.Panel
            // 
            this.grpPersonal.Panel.Controls.Add(this.rdbPullIn);
            this.grpPersonal.Panel.Controls.Add(this.rdbPullOut);
            this.grpPersonal.Panel.Controls.Add(this.cmbSalesRepName);
            this.grpPersonal.Panel.Controls.Add(this.kryptonLabel3);
            this.grpPersonal.Size = new System.Drawing.Size(955, 82);
            this.grpPersonal.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.grpPersonal.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.grpPersonal.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.grpPersonal.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.grpPersonal.StateCommon.Border.Rounding = 3;
            this.grpPersonal.StateCommon.Border.Width = 1;
            this.grpPersonal.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.grpPersonal.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPersonal.StateNormal.Back.Color1 = System.Drawing.Color.Transparent;
            this.grpPersonal.StateNormal.Border.Color1 = System.Drawing.Color.Black;
            this.grpPersonal.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.grpPersonal.StateNormal.Border.Rounding = 3;
            this.grpPersonal.StateNormal.Border.Width = 1;
            this.grpPersonal.TabIndex = 1;
            this.grpPersonal.Values.Heading = "Customer Details";
            // 
            // rdbPullIn
            // 
            this.rdbPullIn.AutoSize = true;
            this.rdbPullIn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPullIn.Location = new System.Drawing.Point(540, 16);
            this.rdbPullIn.Name = "rdbPullIn";
            this.rdbPullIn.Size = new System.Drawing.Size(73, 22);
            this.rdbPullIn.TabIndex = 9;
            this.rdbPullIn.TabStop = true;
            this.rdbPullIn.Text = "PullIn";
            this.rdbPullIn.UseVisualStyleBackColor = true;
            this.rdbPullIn.CheckedChanged += new System.EventHandler(this.rdbPullIn_CheckedChanged);
            // 
            // rdbPullOut
            // 
            this.rdbPullOut.AutoSize = true;
            this.rdbPullOut.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPullOut.Location = new System.Drawing.Point(440, 16);
            this.rdbPullOut.Name = "rdbPullOut";
            this.rdbPullOut.Size = new System.Drawing.Size(85, 22);
            this.rdbPullOut.TabIndex = 8;
            this.rdbPullOut.TabStop = true;
            this.rdbPullOut.Text = "PullOut";
            this.rdbPullOut.UseVisualStyleBackColor = true;
            this.rdbPullOut.CheckedChanged += new System.EventHandler(this.rdbPullOut_CheckedChanged);
            // 
            // cmbSalesRepName
            // 
            this.cmbSalesRepName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSalesRepName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalesRepName.DropDownWidth = 250;
            this.cmbSalesRepName.Location = new System.Drawing.Point(156, 16);
            this.cmbSalesRepName.Name = "cmbSalesRepName";
            this.cmbSalesRepName.Size = new System.Drawing.Size(244, 21);
            this.cmbSalesRepName.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalesRepName.TabIndex = 7;
            this.cmbSalesRepName.SelectedIndexChanged += new System.EventHandler(this.cmbSalesRepName_SelectedIndexChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 17);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(137, 20);
            this.kryptonLabel3.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.Values.Text = "SalesRep Name :";
            // 
            // FrmCustomerAssignedList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(979, 488);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmCustomerAssignedList";
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
            this.Text = "Customer Assigned List";
            this.Load += new System.EventHandler(this.FrmCustomerAssignedList_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonal.Panel)).EndInit();
            this.grpPersonal.Panel.ResumeLayout(false);
            this.grpPersonal.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPersonal)).EndInit();
            this.grpPersonal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbSalesRepName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox grpPersonal;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbSalesRepName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private System.Windows.Forms.RadioButton rdbPullOut;
        private System.Windows.Forms.RadioButton rdbPullIn;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPullIn;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPullOut;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotalHeader;
        private System.Windows.Forms.Label lblTotal;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    }
}

