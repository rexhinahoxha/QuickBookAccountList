namespace AccountWinForm
{
    partial class LogInForm
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
            WebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)WebView).BeginInit();
            SuspendLayout();
            // 
            // WebView
            // 
            WebView.AllowExternalDrop = true;
            WebView.CreationProperties = null;
            WebView.DefaultBackgroundColor = System.Drawing.Color.White;
            WebView.Dock = System.Windows.Forms.DockStyle.Fill;
            WebView.Location = new System.Drawing.Point(0, 0);
            WebView.Name = "WebView";
            WebView.Size = new System.Drawing.Size(800, 450);
            WebView.TabIndex = 0;
            WebView.ZoomFactor = 1D;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(WebView);
            Name = "LogInForm";
            Text = "LogInForm";
            FormClosing += LogInForm_FormClosing;
            Load += LogInForm_Load;
            ((System.ComponentModel.ISupportInitialize)WebView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 WebView;
    }
}