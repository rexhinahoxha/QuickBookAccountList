namespace AccountWinForm
{
    partial class MainForm
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
            btnLogin = new C1.Win.Input.C1Button();
            btnView = new C1.Win.Input.C1Button();
            c1TextBox1 = new C1.Win.Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)btnLogin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1TextBox1).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new System.Drawing.Point(141, 185);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(224, 37);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Log In to Quick Book";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnView
            // 
            btnView.Location = new System.Drawing.Point(433, 185);
            btnView.Name = "btnView";
            btnView.Size = new System.Drawing.Size(224, 36);
            btnView.TabIndex = 1;
            btnView.Text = "View Company List";
            btnView.Click += btnView_Click;
            // 
            // c1TextBox1
            // 
            c1TextBox1.Location = new System.Drawing.Point(182, 96);
            c1TextBox1.Name = "c1TextBox1";
            c1TextBox1.ReadOnly = true;
            c1TextBox1.Size = new System.Drawing.Size(435, 28);
            c1TextBox1.TabIndex = 2;
            c1TextBox1.Value = "This is a Demo App on the company get list accounts ";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(835, 319);
            Controls.Add(c1TextBox1);
            Controls.Add(btnView);
            Controls.Add(btnLogin);
            Name = "MainForm";
            Text = "Company Info List";
            ((System.ComponentModel.ISupportInitialize)btnLogin).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnView).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1TextBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private C1.Win.Input.C1Button btnLogin;
        private C1.Win.Input.C1Button btnView;
        private C1.Win.Input.C1TextBox c1TextBox1;
    }
}