namespace POS
{
    partial class FrmPaymentAll
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
            this.lblErrorMsg = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.btnImport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblselectfilepath = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = false;
            this.lblErrorMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblErrorMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblErrorMsg.Location = new System.Drawing.Point(0, 152);
            this.lblErrorMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(698, 43);
            this.lblErrorMsg.StateCommon.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnImport
            // 
            this.btnImport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnImport.Location = new System.Drawing.Point(565, 55);
            this.btnImport.Name = "btnImport";
            this.btnImport.OverrideDefault.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.OverrideDefault.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.OverrideDefault.Border.Color1 = System.Drawing.Color.Silver;
            this.btnImport.OverrideDefault.Border.Color2 = System.Drawing.Color.Silver;
            this.btnImport.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnImport.OverrideDefault.Border.Rounding = 3;
            this.btnImport.OverrideDefault.Border.Width = 1;
            this.btnImport.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnImport.OverrideFocus.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.OverrideFocus.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.OverrideFocus.Border.Color1 = System.Drawing.Color.Silver;
            this.btnImport.OverrideFocus.Border.Color2 = System.Drawing.Color.Silver;
            this.btnImport.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnImport.OverrideFocus.Border.Rounding = 3;
            this.btnImport.OverrideFocus.Border.Width = 1;
            this.btnImport.OverrideFocus.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.OverrideFocus.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Size = new System.Drawing.Size(121, 43);
            this.btnImport.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateCommon.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateCommon.Border.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateCommon.Border.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnImport.StateCommon.Border.Rounding = 3;
            this.btnImport.StateCommon.Border.Width = 1;
            this.btnImport.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.StateDisabled.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateDisabled.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateDisabled.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.StateDisabled.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.StateNormal.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateNormal.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateNormal.Border.Color1 = System.Drawing.Color.Silver;
            this.btnImport.StateNormal.Border.Color2 = System.Drawing.Color.Silver;
            this.btnImport.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnImport.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.StateNormal.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.StatePressed.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StatePressed.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.StateTracking.Back.Color1 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateTracking.Back.Color2 = System.Drawing.Color.CornflowerBlue;
            this.btnImport.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnImport.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnImport.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.TabIndex = 353;
            this.btnImport.Values.Text = "Browse";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.Location = new System.Drawing.Point(37, 71);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(522, 27);
            this.txtFilePath.TabIndex = 355;
            // 
            // lblselectfilepath
            // 
            this.lblselectfilepath.Location = new System.Drawing.Point(37, 42);
            this.lblselectfilepath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblselectfilepath.Name = "lblselectfilepath";
            this.lblselectfilepath.Size = new System.Drawing.Size(164, 24);
            this.lblselectfilepath.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblselectfilepath.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblselectfilepath.StateCommon.ShortText.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblselectfilepath.StateNormal.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblselectfilepath.StateNormal.ShortText.Color2 = System.Drawing.Color.Black;
            this.lblselectfilepath.StateNormal.ShortText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblselectfilepath.TabIndex = 357;
            this.lblselectfilepath.Values.Text = "Select File Path:";
            // 
            // FrmPaymentAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 195);
            this.Controls.Add(this.lblselectfilepath);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lblErrorMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPaymentAll";
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
            this.Text = "Payment All";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPaymentAll_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lblErrorMsg;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnImport;
        private System.Windows.Forms.TextBox txtFilePath;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblselectfilepath;
    }
}

