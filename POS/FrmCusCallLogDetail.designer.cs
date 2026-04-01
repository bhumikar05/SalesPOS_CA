namespace POS
{
    partial class FrmLogDetail
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
            this.dgInvDetail = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblErrorMsg = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusCallLog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgInvDetail
            // 
            this.dgInvDetail.AllowUserToAddRows = false;
            this.dgInvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgInvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CusCallLog});
            this.dgInvDetail.Location = new System.Drawing.Point(12, 51);
            this.dgInvDetail.Name = "dgInvDetail";
            this.dgInvDetail.RowHeadersVisible = false;
            this.dgInvDetail.Size = new System.Drawing.Size(506, 219);
            this.dgInvDetail.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgInvDetail.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgInvDetail.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgInvDetail.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.dgInvDetail.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.dgInvDetail.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.White;
            this.dgInvDetail.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgInvDetail.StateCommon.HeaderRow.Content.Color1 = System.Drawing.Color.Black;
            this.dgInvDetail.TabIndex = 342;
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Location = new System.Drawing.Point(423, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnClose.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnClose.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClose.OverrideDefault.Border.Rounding = 3;
            this.btnClose.OverrideDefault.Border.Width = 1;
            this.btnClose.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnClose.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnClose.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClose.OverrideFocus.Border.Rounding = 3;
            this.btnClose.OverrideFocus.Border.Width = 1;
            this.btnClose.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Size = new System.Drawing.Size(95, 36);
            this.btnClose.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.btnClose.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.btnClose.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClose.StateCommon.Border.Rounding = 3;
            this.btnClose.StateCommon.Border.Width = 1;
            this.btnClose.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnClose.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnClose.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnClose.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnClose.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnClose.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnClose.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.TabIndex = 341;
            this.btnClose.Values.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = false;
            this.lblErrorMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblErrorMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblErrorMsg.Location = new System.Drawing.Point(0, 288);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(535, 34);
            this.lblErrorMsg.StateCommon.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // CusCallLog
            // 
            this.CusCallLog.HeaderText = "CusCallLog";
            this.CusCallLog.Name = "CusCallLog";
            this.CusCallLog.ReadOnly = true;
            // 
            // FrmLogDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 322);
            this.ControlBox = false;
            this.Controls.Add(this.lblErrorMsg);
            this.Controls.Add(this.dgInvDetail);
            this.Controls.Add(this.btnClose);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmLogDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.StateCommon.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.StateCommon.Header.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.StateCommon.Header.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.Text = "CusCallLogDetail";
            this.Load += new System.EventHandler(this.FrmLogDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgInvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgInvDetail;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lblErrorMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CusCallLog;
    }
}

