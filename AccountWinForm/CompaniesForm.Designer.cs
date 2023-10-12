
namespace AccountWinForm
{
    partial class CompaniesForm
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
            c1CommandHolder1 = new C1.Win.Command.C1CommandHolder();
            c1CommandMenu1 = new C1.Win.Command.C1CommandMenu();
            c1CommandLink2 = new C1.Win.Command.C1CommandLink();
            c1ThemeController1 = new C1.Win.Themes.C1ThemeController();
            accountsGrid = new C1.Win.FlexGrid.C1FlexGrid();
            btnCompany = new C1.Win.Input.C1Button();
            btnAccount = new C1.Win.Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)c1CommandHolder1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)c1ThemeController1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)accountsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCompany).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnAccount).BeginInit();
            SuspendLayout();
            // 
            // c1CommandHolder1
            // 
            c1CommandHolder1.Commands.Add(c1CommandMenu1);
            c1CommandHolder1.Owner = this;
            // 
            // c1CommandMenu1
            // 
            c1CommandMenu1.CommandLinks.AddRange(new C1.Win.Command.C1CommandLink[] { c1CommandLink2 });
            c1CommandMenu1.HideNonRecentLinks = false;
            c1CommandMenu1.Name = "c1CommandMenu1";
            c1CommandMenu1.ShortcutText = "";
            c1CommandMenu1.Text = "New Command";
            c1ThemeController1.SetTheme(c1CommandMenu1, "(default)");
            // 
            // c1CommandLink2
            // 
            c1CommandLink2.Text = "New Command";
            // 
            // accountsGrid
            // 
            accountsGrid.ColumnInfo = "10,1,0,0,0,-1,Columns:";
            accountsGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            accountsGrid.Location = new System.Drawing.Point(0, 140);
            accountsGrid.Name = "accountsGrid";
            accountsGrid.Size = new System.Drawing.Size(873, 449);
            accountsGrid.TabIndex = 0;
            // 
            // btnCompany
            // 
            btnCompany.Location = new System.Drawing.Point(21, 42);
            btnCompany.Name = "btnCompany";
            btnCompany.Size = new System.Drawing.Size(181, 32);
            btnCompany.TabIndex = 1;
            btnCompany.Text = "Load Company Data";
            btnCompany.Click += btnCompany_Click;
            // 
            // btnAccount
            // 
            btnAccount.Location = new System.Drawing.Point(690, 36);
            btnAccount.Name = "btnAccount";
            btnAccount.Size = new System.Drawing.Size(169, 38);
            btnAccount.TabIndex = 2;
            btnAccount.Text = "Load Account Data";
            btnAccount.Click += btnAccount_Click;
            // 
            // CompaniesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(873, 589);
            Controls.Add(btnAccount);
            Controls.Add(btnCompany);
            Controls.Add(accountsGrid);
            ForeColor = System.Drawing.Color.FromArgb(45, 45, 45);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "CompaniesForm";
            Text = "Companies Info View";
            c1ThemeController1.SetTheme(this, "(default)");
            ((System.ComponentModel.ISupportInitialize)c1CommandHolder1).EndInit();
            ((System.ComponentModel.ISupportInitialize)c1ThemeController1).EndInit();
            ((System.ComponentModel.ISupportInitialize)accountsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCompany).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnAccount).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private C1.Win.Command.C1CommandHolder c1CommandHolder1;
        private C1.Win.Command.C1CommandMenu c1CommandMenu1;
        private C1.Win.Command.C1CommandLink c1CommandLink2;
        private C1.Win.Themes.C1ThemeController c1ThemeController1;
        private C1.Win.FlexGrid.C1FlexGrid accountsGrid;
        private C1.Win.Input.C1Button btnAccount;
        private C1.Win.Input.C1Button btnCompany;
    }
}

