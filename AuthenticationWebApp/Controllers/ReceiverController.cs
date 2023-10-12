using AuthenticationWebApp;
using Authentication.Model;
using AuthenticationWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Authentication.Helper;
using AuthenticationWebApp.Model;

namespace AuthenticationWebApp.Controllers
{
    public class ReceiverController : Controller
    {

        string baseURL = "https://sandbox-quickbooks.api.intuit.com";
        public IActionResult Index()
        {
            // Get the current query string
            // from current page.
            string query = Request.QueryString.Value ?? "";

            // Use the the shared helper library
            // to validate the query parameters
            // and write the output file.
            if (AuthHelper.CheckQueryParamsAndSet(query) && LocalAuth.Tokens != null)
            {
                AuthHelper.WriteTokensAsJson(LocalAuth.Tokens, ".\\NewTokens.json");

                // Direct the view to the
                // ReceiverViewModel to report
                // a success message.
                return View(new ReceiverViewModel("Success!"));
            }
            else
            {

                // Otherwise direct the view to the
                // ReceiverViewModel to report a
                // failure message.
                return View(new ReceiverViewModel("Authentication failed."));
            }
        }

        public  async Task<ActionResult> GetCompanyInfoAsync()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string token = LocalAuth.Tokens.AccessToken;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string apiUrl = "https://sandbox-quickbooks.api.intuit.com/v3/company/4620816365349007240/companyinfo/4620816365349007240";
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var myDeserializedClass = JsonConvert.DeserializeObject<CompanyObject>(content);

                        Console.WriteLine("Response content: " + content);
                        return Ok(myDeserializedClass);

                    }
                    else
                    {
                        Console.WriteLine("Request failed with status code: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }
            return Ok();
        }

        public CompanyObject GetCompanyInfo()
        {
            var myDeserializedClass = new CompanyObject();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string token = LocalAuth.Tokens.AccessToken;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string apiUrl = "https://sandbox-quickbooks.api.intuit.com/v3/company/4620816365349007240/companyinfo/4620816365349007240";
                    HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        myDeserializedClass = JsonConvert.DeserializeObject<CompanyObject>(content);

                        Console.WriteLine("Response content: " + content);
                        return myDeserializedClass;

                    }
                    else
                    {
                        Console.WriteLine("Request failed with status code: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }
            return myDeserializedClass;
        }


        public AccountsList GetAccountList()
        {
            var myDeserializedClass = new AccountsList();
            try 
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string token = LocalAuth.Tokens.AccessToken;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // Base URL
                    string baseUrl = "https://sandbox-quickbooks.api.intuit.com";

                    // Parameter value
                    string parameterValue = "select * from Account where Metadata.CreateTime > '2014-12-31'";
                    string parameterValue2 = "69";

                    // Construct the complete URL with the parameter
                    string apiUrl = $"{baseUrl}/v3/company/4620816365349007240/query?query={parameterValue}&minorversion={parameterValue2}";

                    HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        myDeserializedClass = JsonConvert.DeserializeObject<AccountsList>(content);
                        Console.WriteLine("Response content: " + content);
                        return myDeserializedClass;

                    }
                    else
                    {
                        Console.WriteLine("Request failed with status code: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }
            return myDeserializedClass;
        }
    }
}
