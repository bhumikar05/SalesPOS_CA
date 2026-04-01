namespace POS
{
    partial class FrmInActiveCustomer
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
            this.dgvInActiveCustomer = new System.Windows.Forms.DataGridView();
            this.btnActiveCustomer = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.lblSearchCustomerName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TotalBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChkSelectCustomer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInActiveCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInActiveCustomer
            // 
            this.dgvInActiveCustomer.AllowUserToAddRows = false;
            this.dgvInActiveCustomer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvInActiveCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInActiveCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInActiveCustomer.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInActiveCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInActiveCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInActiveCustomer.ColumnHeadersHeight = 29;
            this.dgvInActiveCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ChkSelectCustomer,
            this.Customer,
            this.Phone,
            this.Email,
            this.TotalBalance});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInActiveCustomer.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInActiveCustomer.GridColor = System.Drawing.SystemColors.Control;
            this.dgvInActiveCustomer.Location = new System.Drawing.Point(18, 55);
            this.dgvInActiveCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.dgvInActiveCustomer.MultiSelect = false;
            this.dgvInActiveCustomer.Name = "dgvInActiveCustomer";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInActiveCustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInActiveCustomer.RowHeadersVisible = false;
            this.dgvInActiveCustomer.RowHeadersWidth = 15;
            this.dgvInActiveCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInActiveCustomer.Size = new System.Drawing.Size(877, 447);
            this.dgvInActiveCustomer.TabIndex = 3;
            // 
            // btnActiveCustomer
            // 
            this.btnActiveCustomer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnActiveCustomer.Location = new System.Drawing.Point(757, 506);
            this.btnActiveCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnActiveCustomer.Name = "btnActiveCustomer";
            this.btnActiveCustomer.OverrideDefault.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnActiveCustomer.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.btnActiveCustomer.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnActiveCustomer.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnActiveCustomer.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnActiveCustomer.OverrideDefault.Border.Rounding = 3;
            this.btnActiveCustomer.OverrideDefault.Border.Width = 1;
            this.btnActiveCustomer.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnActiveCustomer.OverrideFocus.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.btnActiveCustomer.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.btnActiveCustomer.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnActiveCustomer.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnActiveCustomer.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnActiveCustomer.OverrideFocus.Border.Rounding = 3;
            this.btnActiveCustomer.OverrideFocus.Border.Width = 1;
            this.btnActiveCustomer.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveCustomer.Size = new System.Drawing.Size(138, 24);
            this.btnActiveCustomer.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnActiveCustomer.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnActiveCustomer.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnActiveCustomer.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnActiveCustomer.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnActiveCustomer.StateCommon.Border.Rounding = 3;
            this.btnActiveCustomer.StateCommon.Border.Width = 1;
            this.btnActiveCustomer.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveCustomer.StateDisabled.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnActiveCustomer.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.btnActiveCustomer.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveCustomer.StateNormal.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnActiveCustomer.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.btnActiveCustomer.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnActiveCustomer.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnActiveCustomer.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnActiveCustomer.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveCustomer.StatePressed.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnActiveCustomer.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.btnActiveCustomer.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveCustomer.StateTracking.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnActiveCustomer.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.btnActiveCustomer.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.DimGray;
            this.btnActiveCustomer.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveCustomer.TabIndex = 8;
            this.btnActiveCustomer.Values.Text = "Active Customer";
            this.btnActiveCustomer.Click += new System.EventHandler(this.btnActiveCustomer_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.AcceptsReturn = true;
            this.txtFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilter.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(214, 21);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(307, 23);
            this.txtFilter.TabIndex = 9;
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
            this.radLabel8.RootElement.ControlBounds = new System.Drawing.Rectangle(28, 106, 100, 18);
            this.radLabel8.Size = new System.Drawing.Size(112, 18);
            this.radLabel8.TabIndex = 4;
            this.radLabel8.Text = "Search Name : ";
            // 
            // lblSearchCustomerName
            // 
            this.lblSearchCustomerName.Location = new System.Drawing.Point(18, 21);
            this.lblSearchCustomerName.Margin = new System.Windows.Forms.Padding(2);
            this.lblSearchCustomerName.Name = "lblSearchCustomerName";
            this.lblSearchCustomerName.Size = new System.Drawing.Size(192, 20);
            this.lblSearchCustomerName.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblSearchCustomerName.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblSearchCustomerName.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCustomerName.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblSearchCustomerName.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblSearchCustomerName.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCustomerName.TabIndex = 10;
            this.lblSearchCustomerName.Values.Text = "Search CustomerName :";
            // 
            // TotalBalance
            // 
            this.TotalBalance.HeaderText = "TotalBalance";
            this.TotalBalance.MinimumWidth = 6;
            this.TotalBalance.Name = "TotalBalance";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Phone";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            // 
            // Customer
            // 
            this.Customer.HeaderText = "Customer";
            this.Customer.MinimumWidth = 6;
            this.Customer.Name = "Customer";
            // 
            // ChkSelectCustomer
            // 
            this.ChkSelectCustomer.HeaderText = "SelectCustomer";
            this.ChkSelectCustomer.MinimumWidth = 6;
            this.ChkSelectCustomer.Name = "ChkSelectCustomer";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // FrmInActiveCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 540);
            this.Controls.Add(this.lblSearchCustomerName);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnActiveCustomer);
            this.Controls.Add(this.dgvInActiveCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmInActiveCustomer";
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
            this.Text = "InActive Customer";
            this.Load += new System.EventHandler(this.FrmInActiveCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInActiveCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.DataGridView dgvInActiveCustomer;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnActiveCustomer;
        private System.Windows.Forms.TextBox txtFilter;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblSearchCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChkSelectCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalBalance;
    }
}

