
namespace Denklik.UI.MainMenu
{
    partial class KontrolPaneli
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
            this.pnlKontrolPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlKontrolPanel
            // 
            this.pnlKontrolPanel.Location = new System.Drawing.Point(12, 12);
            this.pnlKontrolPanel.Name = "pnlKontrolPanel";
            this.pnlKontrolPanel.Size = new System.Drawing.Size(980, 580);
            this.pnlKontrolPanel.TabIndex = 9;
            // 
            // KontrolPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 604);
            this.ControlBox = false;
            this.Controls.Add(this.pnlKontrolPanel);
            this.Name = "KontrolPaneli";
            this.Text = "KontrolPaneli";
            this.Load += new System.EventHandler(this.KontrolPaneli_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlKontrolPanel;
    }
}