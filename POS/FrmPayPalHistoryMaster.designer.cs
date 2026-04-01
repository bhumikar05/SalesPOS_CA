namespace POS
{
    partial class FrmPayPalHistoryMaster
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
            this.dgvPayPalList = new System.Windows.Forms.DataGridView();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.lblTotalPaidAmount = new System.Windows.Forms.Label();
            this.lblpaid = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgHistory = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentMethodType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSearch = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transaction_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View_Invoice = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayPalList)).BeginInit();
            this.pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPayPalList
            // 
            this.dgvPayPalList.AllowUserToAddRows = false;
            this.dgvPayPalList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dgvPayPalList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPayPalList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayPalList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPayPalList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPayPalList.ColumnHeadersHeight = 30;
            this.dgvPayPalList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Transaction_ID,
            this.payer_name,
            this.email_address,
            this.Total_Balance,
            this.View_Invoice});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPayPalList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPayPalList.GridColor = System.Drawing.SystemColors.Control;
            this.dgvPayPalList.Location = new System.Drawing.Point(38, 75);
            this.dgvPayPalList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPayPalList.MultiSelect = false;
            this.dgvPayPalList.Name = "dgvPayPalList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPayPalList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPayPalList.RowHeadersVisible = false;
            this.dgvPayPalList.RowHeadersWidth = 15;
            this.dgvPayPalList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayPalList.Size = new System.Drawing.Size(1080, 529);
            this.dgvPayPalList.TabIndex = 34;
            this.dgvPayPalList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPayPalList_CellContentClick);
            // 
            // pnlHistory
            // 
            this.pnlHistory.Controls.Add(this.lblTotalPaidAmount);
            this.pnlHistory.Controls.Add(this.lblpaid);
            this.pnlHistory.Controls.Add(this.btnclose);
            this.pnlHistory.Controls.Add(this.panel8);
            this.pnlHistory.Controls.Add(this.panel7);
            this.pnlHistory.Controls.Add(this.panel6);
            this.pnlHistory.Controls.Add(this.panel5);
            this.pnlHistory.Controls.Add(this.dgHistory);
            this.pnlHistory.Location = new System.Drawing.Point(271, 164);
            this.pnlHistory.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(754, 366);
            this.pnlHistory.TabIndex = 319;
            // 
            // lblTotalPaidAmount
            // 
            this.lblTotalPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPaidAmount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalPaidAmount.Location = new System.Drawing.Point(630, 330);
            this.lblTotalPaidAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPaidAmount.Name = "lblTotalPaidAmount";
            this.lblTotalPaidAmount.Size = new System.Drawing.Size(94, 20);
            this.lblTotalPaidAmount.TabIndex = 351;
            this.lblTotalPaidAmount.Text = "0";
            // 
            // lblpaid
            // 
            this.lblpaid.AutoSize = true;
            this.lblpaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpaid.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblpaid.Location = new System.Drawing.Point(471, 330);
            this.lblpaid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpaid.Name = "lblpaid";
            this.lblpaid.Size = new System.Drawing.Size(151, 20);
            this.lblpaid.TabIndex = 350;
            this.lblpaid.Text = "Total PaidAmount :";
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
            this.btnclose.Location = new System.Drawing.Point(614, 22);
            this.btnclose.Margin = new System.Windows.Forms.Padding(4);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(107, 37);
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
            this.panel8.Location = new System.Drawing.Point(7, 360);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(737, 6);
            this.panel8.TabIndex = 231;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(744, 10);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 356);
            this.panel7.TabIndex = 230;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(7, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(747, 10);
            this.panel6.TabIndex = 229;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(7, 366);
            this.panel5.TabIndex = 228;
            // 
            // dgHistory
            // 
            this.dgHistory.AllowUserToAddRows = false;
            this.dgHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHistory.ColumnHeadersHeight = 29;
            this.dgHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.RefNumber,
            this.PaymentMethodType,
            this.PayAmount});
            this.dgHistory.Location = new System.Drawing.Point(39, 67);
            this.dgHistory.Margin = new System.Windows.Forms.Padding(4);
            this.dgHistory.Name = "dgHistory";
            this.dgHistory.RowHeadersVisible = false;
            this.dgHistory.RowHeadersWidth = 51;
            this.dgHistory.Size = new System.Drawing.Size(682, 247);
            this.dgHistory.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgHistory.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgHistory.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgHistory.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.dgHistory.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.dgHistory.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgHistory.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgHistory.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.Black;
            this.dgHistory.TabIndex = 227;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // RefNumber
            // 
            this.RefNumber.HeaderText = "RefNumber";
            this.RefNumber.MinimumWidth = 6;
            this.RefNumber.Name = "RefNumber";
            this.RefNumber.ReadOnly = true;
            // 
            // PaymentMethodType
            // 
            this.PaymentMethodType.HeaderText = "PaymentMethodType";
            this.PaymentMethodType.MinimumWidth = 6;
            this.PaymentMethodType.Name = "PaymentMethodType";
            this.PaymentMethodType.ReadOnly = true;
            // 
            // PayAmount
            // 
            this.PayAmount.HeaderText = "PayAmount";
            this.PayAmount.MinimumWidth = 6;
            this.PayAmount.Name = "PayAmount";
            this.PayAmount.ReadOnly = true;
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(38, 27);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(89, 24);
            this.lblSearch.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblSearch.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblSearch.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblSearch.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblSearch.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.TabIndex = 343;
            this.lblSearch.Values.Text = "Search :";
            // 
            // txtFilter
            // 
            this.txtFilter.AcceptsReturn = true;
            this.txtFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilter.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(133, 28);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(312, 27);
            this.txtFilter.TabIndex = 342;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Transaction_ID
            // 
            this.Transaction_ID.HeaderText = "Transaction ID";
            this.Transaction_ID.MinimumWidth = 6;
            this.Transaction_ID.Name = "Transaction_ID";
            this.Transaction_ID.Visible = false;
            // 
            // payer_name
            // 
            this.payer_name.HeaderText = "Payer Name";
            this.payer_name.MinimumWidth = 6;
            this.payer_name.Name = "payer_name";
            // 
            // email_address
            // 
            this.email_address.HeaderText = "Email Address";
            this.email_address.MinimumWidth = 6;
            this.email_address.Name = "email_address";
            this.email_address.Visible = false;
            // 
            // Total_Balance
            // 
            this.Total_Balance.HeaderText = "Total Balance";
            this.Total_Balance.MinimumWidth = 6;
            this.Total_Balance.Name = "Total_Balance";
            // 
            // View_Invoice
            // 
            this.View_Invoice.HeaderText = "View_Invoice";
            this.View_Invoice.MinimumWidth = 6;
            this.View_Invoice.Name = "View_Invoice";
            this.View_Invoice.Text = "View_Invoice";
            this.View_Invoice.ToolTipText = "View_Invoice";
            this.View_Invoice.UseColumnTextForLinkValue = true;
            // 
            // FrmPayPalHistoryMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 651);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.pnlHistory);
            this.Controls.Add(this.dgvPayPalList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPayPalHistoryMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateActive.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateActive.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateActive.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateActive.Header.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.StateActive.Header.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StateInactive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateInactive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateInactive.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateInactive.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.StateInactive.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateInactive.Header.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.StateInactive.Header.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text = "PayPal History Master";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPayPalHistoryMaster_FormClosing);
            this.Load += new System.EventHandler(this.FrmPayPalHistoryMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayPalList)).EndInit();
            this.pnlHistory.ResumeLayout(false);
            this.pnlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.DataGridView dgvPayPalList;
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Label lblTotalPaidAmount;
        private System.Windows.Forms.Label lblpaid;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentMethodType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblSearch;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transaction_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn payer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_Balance;
        private System.Windows.Forms.DataGridViewLinkColumn View_Invoice;
    }
}

