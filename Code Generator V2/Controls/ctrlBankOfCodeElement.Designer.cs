namespace Code_Generator_V2.Controls
{
    partial class ctrlBankOfCodeElement
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCodeTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCodeTitle
            // 
            this.lblCodeTitle.AutoSize = true;
            this.lblCodeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodeTitle.Location = new System.Drawing.Point(17, 7);
            this.lblCodeTitle.Name = "lblCodeTitle";
            this.lblCodeTitle.Size = new System.Drawing.Size(79, 18);
            this.lblCodeTitle.TabIndex = 0;
            this.lblCodeTitle.Text = "Code Title ";
            this.lblCodeTitle.Click += new System.EventHandler(this.lblCodeTitle_Click);
            // 
            // ctrlBankOfCodeElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.lblCodeTitle);
            this.Name = "ctrlBankOfCodeElement";
            this.Size = new System.Drawing.Size(283, 34);
            this.Click += new System.EventHandler(this.ctrlBankOfCodeElement_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodeTitle;
    }
}
