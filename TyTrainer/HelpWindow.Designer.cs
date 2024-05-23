
namespace TyTrainer
{
    partial class HelpWindow
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
            this.DataType = new System.Windows.Forms.Label();
            this.HelpName = new System.Windows.Forms.Label();
            this.LabelInformation = new System.Windows.Forms.Label();
            this.PanelInformation = new System.Windows.Forms.Panel();
            this.PanelInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataType
            // 
            this.DataType.AutoSize = true;
            this.DataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataType.Location = new System.Drawing.Point(12, 45);
            this.DataType.Name = "DataType";
            this.DataType.Size = new System.Drawing.Size(130, 25);
            this.DataType.TabIndex = 0;
            this.DataType.Text = "DATA TYPE:";
            // 
            // HelpName
            // 
            this.HelpName.AutoSize = true;
            this.HelpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpName.Location = new System.Drawing.Point(12, 9);
            this.HelpName.Name = "HelpName";
            this.HelpName.Size = new System.Drawing.Size(81, 25);
            this.HelpName.TabIndex = 1;
            this.HelpName.Text = "NAME: ";
            // 
            // LabelInformation
            // 
            this.LabelInformation.AutoSize = true;
            this.LabelInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInformation.Location = new System.Drawing.Point(0, 2);
            this.LabelInformation.MaximumSize = new System.Drawing.Size(435, 0);
            this.LabelInformation.Name = "LabelInformation";
            this.LabelInformation.Size = new System.Drawing.Size(432, 75);
            this.LabelInformation.TabIndex = 2;
            this.LabelInformation.Text = "INFORMATION: this help text is to see what happens if I type a lot in here, let\'s" +
    " type more and see what happens, lorem ipsum etc. etc.";
            // 
            // PanelInformation
            // 
            this.PanelInformation.AutoScroll = true;
            this.PanelInformation.Controls.Add(this.LabelInformation);
            this.PanelInformation.Location = new System.Drawing.Point(12, 75);
            this.PanelInformation.Name = "PanelInformation";
            this.PanelInformation.Size = new System.Drawing.Size(456, 149);
            this.PanelInformation.TabIndex = 3;
            // 
            // HelpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 236);
            this.Controls.Add(this.PanelInformation);
            this.Controls.Add(this.DataType);
            this.Controls.Add(this.HelpName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HelpWindow";
            this.Text = "Help";
            this.PanelInformation.ResumeLayout(false);
            this.PanelInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DataType;
        private System.Windows.Forms.Label HelpName;
        private System.Windows.Forms.Label LabelInformation;
        private System.Windows.Forms.Panel PanelInformation;
    }
}