
namespace TyTrainer
{
    partial class InfoWindow
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
            this.PanelInformation = new System.Windows.Forms.Panel();
            this.LabelHotkey = new System.Windows.Forms.Label();
            this.LabelSupportInfo = new System.Windows.Forms.LinkLabel();
            this.PanelInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelInformation
            // 
            this.PanelInformation.AutoScroll = true;
            this.PanelInformation.Controls.Add(this.LabelHotkey);
            this.PanelInformation.Controls.Add(this.LabelSupportInfo);
            this.PanelInformation.Location = new System.Drawing.Point(12, 12);
            this.PanelInformation.Name = "PanelInformation";
            this.PanelInformation.Size = new System.Drawing.Size(460, 337);
            this.PanelInformation.TabIndex = 0;
            // 
            // LabelHotkey
            // 
            this.LabelHotkey.AutoSize = true;
            this.LabelHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.LabelHotkey.Location = new System.Drawing.Point(5, 125);
            this.LabelHotkey.Name = "LabelHotkey";
            this.LabelHotkey.Size = new System.Drawing.Size(114, 25);
            this.LabelHotkey.TabIndex = 2;
            this.LabelHotkey.Text = "Hotkey List:";
            // 
            // LabelSupportInfo
            // 
            this.LabelSupportInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSupportInfo.LinkArea = new System.Windows.Forms.LinkArea(84, 40);
            this.LabelSupportInfo.Location = new System.Drawing.Point(3, 5);
            this.LabelSupportInfo.Name = "LabelSupportInfo";
            this.LabelSupportInfo.Size = new System.Drawing.Size(419, 120);
            this.LabelSupportInfo.TabIndex = 1;
            this.LabelSupportInfo.TabStop = true;
            this.LabelSupportInfo.Text = "Support Information:\r\nCreator: PhoenixAki\r\nDiscord Tag: Phoenix#0353\r\nGitHub Link" +
    ":\r\nhttps://github.com/PhoenixAki/Ty2Trainer";
            this.LabelSupportInfo.UseCompatibleTextRendering = true;
            this.LabelSupportInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenLink);
            // 
            // InfoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.PanelInformation);
            this.Name = "InfoWindow";
            this.Text = "Form1";
            this.PanelInformation.ResumeLayout(false);
            this.PanelInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelInformation;
        private System.Windows.Forms.LinkLabel LabelSupportInfo;
        private System.Windows.Forms.Label LabelHotkey;
    }
}