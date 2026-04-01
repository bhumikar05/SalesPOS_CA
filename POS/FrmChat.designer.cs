namespace POS
{
    partial class FrmChat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.pnlSaleRepList = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvSalesRepList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesRepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLoginUserName = new System.Windows.Forms.Label();
            this.pnlReceiveName = new System.Windows.Forms.Panel();
            this.txtGroupStatus = new System.Windows.Forms.TextBox();
            this.txtReceiverID = new System.Windows.Forms.TextBox();
            this.lblReceiverName = new System.Windows.Forms.Label();
            this.pnlMainMessage = new System.Windows.Forms.Panel();
            this.pnlMessageList = new System.Windows.Forms.Panel();
            this.pnlGroupAnnounncementMessage = new System.Windows.Forms.Panel();
            this.dgvListMessage = new System.Windows.Forms.DataGridView();
            this.ReceiverMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SenderMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGroupAnnounncementMessage = new System.Windows.Forms.TextBox();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.brnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlSaleRepList.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesRepList)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlReceiveName.SuspendLayout();
            this.pnlMainMessage.SuspendLayout();
            this.pnlMessageList.SuspendLayout();
            this.pnlGroupAnnounncementMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMessage)).BeginInit();
            this.pnlMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSaleRepList
            // 
            this.pnlSaleRepList.BackColor = System.Drawing.Color.White;
            this.pnlSaleRepList.Controls.Add(this.panel3);
            this.pnlSaleRepList.Controls.Add(this.panel2);
            this.pnlSaleRepList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSaleRepList.Location = new System.Drawing.Point(0, 0);
            this.pnlSaleRepList.Name = "pnlSaleRepList";
            this.pnlSaleRepList.Size = new System.Drawing.Size(274, 419);
            this.pnlSaleRepList.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.dgvSalesRepList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(274, 376);
            this.panel3.TabIndex = 15;
            // 
            // dgvSalesRepList
            // 
            this.dgvSalesRepList.AllowUserToAddRows = false;
            this.dgvSalesRepList.AllowUserToDeleteRows = false;
            this.dgvSalesRepList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesRepList.BackgroundColor = System.Drawing.Color.Gray;
            this.dgvSalesRepList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesRepList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesRepList.ColumnHeadersHeight = 30;
            this.dgvSalesRepList.ColumnHeadersVisible = false;
            this.dgvSalesRepList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SalesRepName,
            this.UserType});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesRepList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesRepList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesRepList.GridColor = System.Drawing.Color.Tan;
            this.dgvSalesRepList.Location = new System.Drawing.Point(0, 0);
            this.dgvSalesRepList.MultiSelect = false;
            this.dgvSalesRepList.Name = "dgvSalesRepList";
            this.dgvSalesRepList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesRepList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalesRepList.RowHeadersVisible = false;
            this.dgvSalesRepList.RowHeadersWidth = 20;
            this.dgvSalesRepList.RowTemplate.Height = 35;
            this.dgvSalesRepList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesRepList.Size = new System.Drawing.Size(274, 376);
            this.dgvSalesRepList.TabIndex = 0;
            this.dgvSalesRepList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesRepList_CellDoubleClick);
            this.dgvSalesRepList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvSalesRepList_MouseClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // SalesRepName
            // 
            this.SalesRepName.FillWeight = 214.3575F;
            this.SalesRepName.HeaderText = "SalesRepName";
            this.SalesRepName.Name = "SalesRepName";
            this.SalesRepName.ReadOnly = true;
            // 
            // UserType
            // 
            this.UserType.HeaderText = "UserType";
            this.UserType.Name = "UserType";
            this.UserType.ReadOnly = true;
            this.UserType.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.lblLoginUserName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 43);
            this.panel2.TabIndex = 0;
            // 
            // lblLoginUserName
            // 
            this.lblLoginUserName.AutoSize = true;
            this.lblLoginUserName.BackColor = System.Drawing.Color.Gray;
            this.lblLoginUserName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginUserName.ForeColor = System.Drawing.Color.White;
            this.lblLoginUserName.Location = new System.Drawing.Point(84, 8);
            this.lblLoginUserName.Name = "lblLoginUserName";
            this.lblLoginUserName.Size = new System.Drawing.Size(0, 18);
            this.lblLoginUserName.TabIndex = 0;
            // 
            // pnlReceiveName
            // 
            this.pnlReceiveName.BackColor = System.Drawing.Color.FloralWhite;
            this.pnlReceiveName.Controls.Add(this.txtGroupStatus);
            this.pnlReceiveName.Controls.Add(this.txtReceiverID);
            this.pnlReceiveName.Controls.Add(this.lblReceiverName);
            this.pnlReceiveName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReceiveName.Location = new System.Drawing.Point(0, 0);
            this.pnlReceiveName.Name = "pnlReceiveName";
            this.pnlReceiveName.Size = new System.Drawing.Size(670, 43);
            this.pnlReceiveName.TabIndex = 0;
            // 
            // txtGroupStatus
            // 
            this.txtGroupStatus.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGroupStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroupStatus.Location = new System.Drawing.Point(609, 7);
            this.txtGroupStatus.Name = "txtGroupStatus";
            this.txtGroupStatus.Size = new System.Drawing.Size(58, 21);
            this.txtGroupStatus.TabIndex = 2;
            this.txtGroupStatus.Visible = false;
            // 
            // txtReceiverID
            // 
            this.txtReceiverID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReceiverID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiverID.Location = new System.Drawing.Point(546, 7);
            this.txtReceiverID.Name = "txtReceiverID";
            this.txtReceiverID.Size = new System.Drawing.Size(58, 21);
            this.txtReceiverID.TabIndex = 1;
            this.txtReceiverID.Visible = false;
            // 
            // lblReceiverName
            // 
            this.lblReceiverName.AutoSize = true;
            this.lblReceiverName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblReceiverName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverName.ForeColor = System.Drawing.Color.Black;
            this.lblReceiverName.Location = new System.Drawing.Point(18, 10);
            this.lblReceiverName.Name = "lblReceiverName";
            this.lblReceiverName.Size = new System.Drawing.Size(0, 18);
            this.lblReceiverName.TabIndex = 0;
            // 
            // pnlMainMessage
            // 
            this.pnlMainMessage.Controls.Add(this.pnlMessageList);
            this.pnlMainMessage.Controls.Add(this.pnlReceiveName);
            this.pnlMainMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainMessage.Location = new System.Drawing.Point(274, 0);
            this.pnlMainMessage.Name = "pnlMainMessage";
            this.pnlMainMessage.Size = new System.Drawing.Size(670, 419);
            this.pnlMainMessage.TabIndex = 18;
            // 
            // pnlMessageList
            // 
            this.pnlMessageList.Controls.Add(this.pnlGroupAnnounncementMessage);
            this.pnlMessageList.Controls.Add(this.pnlMessage);
            this.pnlMessageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessageList.Location = new System.Drawing.Point(0, 43);
            this.pnlMessageList.Name = "pnlMessageList";
            this.pnlMessageList.Size = new System.Drawing.Size(670, 376);
            this.pnlMessageList.TabIndex = 19;
            // 
            // pnlGroupAnnounncementMessage
            // 
            this.pnlGroupAnnounncementMessage.Controls.Add(this.dgvListMessage);
            this.pnlGroupAnnounncementMessage.Controls.Add(this.txtGroupAnnounncementMessage);
            this.pnlGroupAnnounncementMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGroupAnnounncementMessage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlGroupAnnounncementMessage.Location = new System.Drawing.Point(0, 0);
            this.pnlGroupAnnounncementMessage.Name = "pnlGroupAnnounncementMessage";
            this.pnlGroupAnnounncementMessage.Size = new System.Drawing.Size(670, 312);
            this.pnlGroupAnnounncementMessage.TabIndex = 8;
            // 
            // dgvListMessage
            // 
            this.dgvListMessage.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgvListMessage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListMessage.ColumnHeadersVisible = false;
            this.dgvListMessage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceiverMessage,
            this.SenderMessage});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListMessage.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvListMessage.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvListMessage.Location = new System.Drawing.Point(0, 0);
            this.dgvListMessage.Name = "dgvListMessage";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgvListMessage.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvListMessage.RowHeadersVisible = false;
            this.dgvListMessage.Size = new System.Drawing.Size(670, 309);
            this.dgvListMessage.TabIndex = 10;
            // 
            // ReceiverMessage
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.ReceiverMessage.DefaultCellStyle = dataGridViewCellStyle5;
            this.ReceiverMessage.HeaderText = "ReceiverMessage";
            this.ReceiverMessage.Name = "ReceiverMessage";
            this.ReceiverMessage.Width = 332;
            // 
            // SenderMessage
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.SenderMessage.DefaultCellStyle = dataGridViewCellStyle6;
            this.SenderMessage.HeaderText = "SenderMessage";
            this.SenderMessage.Name = "SenderMessage";
            this.SenderMessage.Width = 332;
            // 
            // txtGroupAnnounncementMessage
            // 
            this.txtGroupAnnounncementMessage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtGroupAnnounncementMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGroupAnnounncementMessage.Location = new System.Drawing.Point(0, 0);
            this.txtGroupAnnounncementMessage.Multiline = true;
            this.txtGroupAnnounncementMessage.Name = "txtGroupAnnounncementMessage";
            this.txtGroupAnnounncementMessage.Size = new System.Drawing.Size(670, 312);
            this.txtGroupAnnounncementMessage.TabIndex = 9;
            this.txtGroupAnnounncementMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGroupAnnounncementMessage_KeyPress);
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.Color.FloralWhite;
            this.pnlMessage.Controls.Add(this.brnSend);
            this.pnlMessage.Controls.Add(this.txtMessage);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMessage.Location = new System.Drawing.Point(0, 312);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(670, 64);
            this.pnlMessage.TabIndex = 3;
            // 
            // brnSend
            // 
            this.brnSend.BackColor = System.Drawing.Color.FloralWhite;
            this.brnSend.FlatAppearance.BorderSize = 0;
            this.brnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnSend.Image = global::POS.Properties.Resources.Send_Message;
            this.brnSend.Location = new System.Drawing.Point(600, 14);
            this.brnSend.Name = "brnSend";
            this.brnSend.Size = new System.Drawing.Size(59, 37);
            this.brnSend.TabIndex = 1;
            this.brnSend.UseVisualStyleBackColor = false;
            this.brnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Location = new System.Drawing.Point(8, 9);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(586, 47);
            this.txtMessage.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FrmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(944, 419);
            this.Controls.Add(this.pnlMainMessage);
            this.Controls.Add(this.pnlSaleRepList);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmChat";
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
            this.Text = "Chat Master";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmChat_FormClosing);
            this.Load += new System.EventHandler(this.FrmChatApp_Load);
            this.pnlSaleRepList.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesRepList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlReceiveName.ResumeLayout(false);
            this.pnlReceiveName.PerformLayout();
            this.pnlMainMessage.ResumeLayout(false);
            this.pnlMessageList.ResumeLayout(false);
            this.pnlGroupAnnounncementMessage.ResumeLayout(false);
            this.pnlGroupAnnounncementMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMessage)).EndInit();
            this.pnlMessage.ResumeLayout(false);
            this.pnlMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.Panel pnlSaleRepList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLoginUserName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlReceiveName;
        private System.Windows.Forms.Label lblReceiverName;
        private System.Windows.Forms.DataGridView dgvSalesRepList;
        private System.Windows.Forms.TextBox txtReceiverID;
        private System.Windows.Forms.Panel pnlMainMessage;
        private System.Windows.Forms.Panel pnlMessageList;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesRepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.Button brnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtGroupStatus;
        private System.Windows.Forms.Panel pnlGroupAnnounncementMessage;
        private System.Windows.Forms.TextBox txtGroupAnnounncementMessage;
        private System.Windows.Forms.DataGridView dgvListMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiverMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn SenderMessage;
    }
}

