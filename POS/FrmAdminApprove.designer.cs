namespace POS
{
    partial class FrmAdminApprove
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
            this.pnlRequest = new System.Windows.Forms.Panel();
            this.rdbCurrentInvoice = new System.Windows.Forms.RadioButton();
            this.rdbNumberOfDays = new System.Windows.Forms.RadioButton();
            this.rdbAllow = new System.Windows.Forms.RadioButton();
            this.txtNumberOfDays = new System.Windows.Forms.TextBox();
            this.txtAllow = new System.Windows.Forms.TextBox();
            this.btnApprove = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pnlRequest.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRequest
            // 
            this.pnlRequest.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRequest.Controls.Add(this.rdbCurrentInvoice);
            this.pnlRequest.Controls.Add(this.rdbNumberOfDays);
            this.pnlRequest.Controls.Add(this.rdbAllow);
            this.pnlRequest.Controls.Add(this.txtNumberOfDays);
            this.pnlRequest.Controls.Add(this.txtAllow);
            this.pnlRequest.Location = new System.Drawing.Point(14, 12);
            this.pnlRequest.Name = "pnlRequest";
            this.pnlRequest.Size = new System.Drawing.Size(391, 120);
            this.pnlRequest.TabIndex = 0;
            this.pnlRequest.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRequest_Paint);
            // 
            // rdbCurrentInvoice
            // 
            this.rdbCurrentInvoice.AutoSize = true;
            this.rdbCurrentInvoice.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCurrentInvoice.Location = new System.Drawing.Point(14, 86);
            this.rdbCurrentInvoice.Name = "rdbCurrentInvoice";
            this.rdbCurrentInvoice.Size = new System.Drawing.Size(123, 20);
            this.rdbCurrentInvoice.TabIndex = 4;
            this.rdbCurrentInvoice.TabStop = true;
            this.rdbCurrentInvoice.Text = "Only This Time";
            this.rdbCurrentInvoice.UseVisualStyleBackColor = true;
            // 
            // rdbNumberOfDays
            // 
            this.rdbNumberOfDays.AutoSize = true;
            this.rdbNumberOfDays.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNumberOfDays.Location = new System.Drawing.Point(14, 49);
            this.rdbNumberOfDays.Name = "rdbNumberOfDays";
            this.rdbNumberOfDays.Size = new System.Drawing.Size(132, 20);
            this.rdbNumberOfDays.TabIndex = 2;
            this.rdbNumberOfDays.TabStop = true;
            this.rdbNumberOfDays.Text = "Number Of Days";
            this.rdbNumberOfDays.UseVisualStyleBackColor = true;
            this.rdbNumberOfDays.CheckedChanged += new System.EventHandler(this.rdbNumberOfDays_CheckedChanged);
            // 
            // rdbAllow
            // 
            this.rdbAllow.AutoSize = true;
            this.rdbAllow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAllow.Location = new System.Drawing.Point(14, 12);
            this.rdbAllow.Name = "rdbAllow";
            this.rdbAllow.Size = new System.Drawing.Size(184, 20);
            this.rdbAllow.TabIndex = 0;
            this.rdbAllow.TabStop = true;
            this.rdbAllow.Text = "How Many Time Allowes";
            this.rdbAllow.UseVisualStyleBackColor = true;
            this.rdbAllow.CheckedChanged += new System.EventHandler(this.rdbAllow_CheckedChanged);
            // 
            // txtNumberOfDays
            // 
            this.txtNumberOfDays.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumberOfDays.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNumberOfDays.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumberOfDays.Location = new System.Drawing.Point(204, 47);
            this.txtNumberOfDays.Name = "txtNumberOfDays";
            this.txtNumberOfDays.Size = new System.Drawing.Size(92, 22);
            this.txtNumberOfDays.TabIndex = 3;
            this.txtNumberOfDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumberOfDays.Visible = false;
            this.txtNumberOfDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberOfDays_KeyPress);
            // 
            // txtAllow
            // 
            this.txtAllow.BackColor = System.Drawing.SystemColors.Control;
            this.txtAllow.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAllow.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllow.Location = new System.Drawing.Point(204, 10);
            this.txtAllow.Name = "txtAllow";
            this.txtAllow.Size = new System.Drawing.Size(92, 22);
            this.txtAllow.TabIndex = 1;
            this.txtAllow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAllow.Visible = false;
            this.txtAllow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAllow_KeyPress);
            // 
            // btnApprove
            // 
            this.btnApprove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApprove.Location = new System.Drawing.Point(14, 138);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnApprove.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnApprove.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnApprove.OverrideDefault.Border.Rounding = 3;
            this.btnApprove.OverrideDefault.Border.Width = 1;
            this.btnApprove.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnApprove.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnApprove.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnApprove.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnApprove.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnApprove.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnApprove.OverrideFocus.Border.Rounding = 3;
            this.btnApprove.OverrideFocus.Border.Width = 1;
            this.btnApprove.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnApprove.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnApprove.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.Size = new System.Drawing.Size(100, 30);
            this.btnApprove.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnApprove.StateCommon.Border.Rounding = 3;
            this.btnApprove.StateCommon.Border.Width = 1;
            this.btnApprove.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnApprove.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnApprove.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnApprove.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnApprove.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnApprove.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnApprove.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnApprove.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnApprove.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnApprove.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnApprove.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnApprove.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnApprove.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnApprove.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnApprove.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Values.Text = "Approve";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // FrmAdminApprove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(430, 193);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.pnlRequest);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmAdminApprove";
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
            this.Text = "Admin Request Approve";
            this.Load += new System.EventHandler(this.FrmAdminApprove_Load);
            this.pnlRequest.ResumeLayout(false);
            this.pnlRequest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.Panel pnlRequest;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnApprove;
        private System.Windows.Forms.TextBox txtNumberOfDays;
        private System.Windows.Forms.TextBox txtAllow;
        private System.Windows.Forms.RadioButton rdbAllow;
        private System.Windows.Forms.RadioButton rdbNumberOfDays;
        private System.Windows.Forms.RadioButton rdbCurrentInvoice;
    }
}

