using Authentication.Helper;
using Authentication.Model;
using AuthenticationWebApp.Controllers;
using AuthenticationWebApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows.Forms;

namespace AccountWinForm
{
    public partial class CompaniesForm : Form
    {
        //using this boolean as a 'key'
        // to show which object i will return
        // to the data source
        private bool isCompany = false;
        public CompaniesForm()
        {
            InitializeComponent();            
            this.isCompany = false;
        }

        public DataTable GetDataSource()
        {
            DataTable dt = new DataTable();

            // get token from the local auth class
            if (LocalAuth.Tokens != null)
            {
                try
                {
                    AuthHelper.WriteTokensAsJson(LocalAuth.Tokens);
                    ReceiverController controller = new ReceiverController();
                    if (isCompany)
                    {
                        CompanyObject obj = new CompanyObject();
                        obj = controller.GetCompanyInfo();
                        dt = ConvertToDataTable(obj.CompanyInfo);
                    }
                    else
                    {
                        AccountsList obj2 = new AccountsList();
                        obj2 = controller.GetAccountList();
                        dt = ConvertToDataTable(obj2.QueryResponse.Account);
                    }

                }
            

            catch (Exception ex)
            {
                
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else
        {
        // Handle the case where token is null.
        Console.WriteLine("Tokens are null.");
         }          

            return dt;
        }

        #region convert objects to data table
        public static DataTable ConvertToDataTable<T>(List<T> objectsList)
        {
            DataTable dataTable = new DataTable();
            try
            {
                var properties = typeof(T).GetProperties();
                // Create columns
                foreach (var property in properties)
                {
                    dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
                }
                // Populate rows 
                foreach (var obj in objectsList)
                {
                    DataRow row = dataTable.NewRow();

                    // Set values for each column 
                    foreach (var property in properties)
                    {
                        row[property.Name] = property.GetValue(obj) ?? DBNull.Value;
                    }
                    dataTable.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }
            
            return dataTable;
        }
        public static DataTable ConvertToDataTable<T>(T obj)
        {
            DataTable dataTable = new DataTable();

            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    dataTable.Columns.Add(property.Name, property.PropertyType);
                }

                DataRow row = dataTable.NewRow();
                foreach (PropertyInfo property in properties)
                {
                    row[property.Name] = property.GetValue(obj);
                }
                dataTable.Rows.Add(row);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }

            return dataTable;
        }
        #endregion
        public void FillGrid()
        {
            accountsGrid.DataSource = GetDataSource();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            this.isCompany = true;
            FillGrid();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.isCompany = false;
            FillGrid();
        }
    }
}
