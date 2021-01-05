
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
            this.Information = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
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
            // Information
            // 
            this.Information.AutoSize = true;
            this.Information.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Information.Location = new System.Drawing.Point(0, 2);
            this.Information.MaximumSize = new System.Drawing.Size(435, 0);
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(432, 75);
            this.Information.TabIndex = 2;
            this.Information.Text = "INFORMATION: this help text is to see what happens if I type a lot in here, let\'s" +
    " type more and see what happens, lorem ipsum etc. etc.";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Information);
            this.panel1.Location = new System.Drawing.Point(12, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 149);
            this.panel1.TabIndex = 3;
            // 
            // HelpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 236);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DataType);
            this.Controls.Add(this.HelpName);
            this.Name = "HelpWindow";
            this.Text = "Help";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DataType;
        private System.Windows.Forms.Label HelpName;
        private System.Windows.Forms.Label Information;
        private System.Windows.Forms.Panel panel1;
    }
}