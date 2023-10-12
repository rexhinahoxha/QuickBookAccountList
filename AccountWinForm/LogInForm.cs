using Authentication.Helper;
using Intuit.Ipp.OAuth2PlatformClient;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountWinForm
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            this.InitializeComponent();

        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            // Initialize the WebView2 control
            // and begin the authorization
            // process inside the WebView2 control.
            this.RunAuthorization();
        }

        public async void RunAuthorization()
        {
            //  initialize the OAuth2 client 
            LocalAuth.Initialize();

            // Initialize the WebView2 control.
            await WebView.EnsureCoreWebView2Async(null);

            // Navigate the WebView2 control to
            // a generated authorization URL.
            WebView.CoreWebView2.Navigate(AuthHelper.GetAuthorizationURL(OidcScopes.Accounting));

        }


        private void LogInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // When the user closes the form we
            // assume that the operation has
            // completed with success or failure.


            string query = WebView.Source.Query;

            // Use the the shared helper library
            // to validate the query parameters
            // and write the output file.
            if (AuthHelper.CheckQueryParamsAndSet(query) == true && LocalAuth.Tokens != null)
            {
                AuthHelper.WriteTokensAsJson(LocalAuth.Tokens);
            }
            else
            {
                MessageBox.Show("Quickbooks Online failed to authenticate.");

            }
        }
    }
}
