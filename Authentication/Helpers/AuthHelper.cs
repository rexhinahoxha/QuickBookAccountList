using Authentication.Model;
using Intuit.Ipp.OAuth2PlatformClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Web;

namespace Authentication.Helper
{
    public class AuthHelper
    {
        
        // Creates a new authorization URL using the OAuth2 class.       
        public static string GetAuthorizationURL(params OidcScopes[] scopes)
        {
            // Initialize the OAuth2Client 
            if (LocalAuth.Client == null || LocalAuth.Tokens == null)
            {
                LocalAuth.Initialize();
            }

            // ignoring the null warning from the compiler
#pragma warning disable CS8602

            // reading the authorization url based
            return LocalAuth.Client.GetAuthorizationURL(scopes.ToList());
        }

        
        // Checks the passed <paramref name="queryString"/>.
        // If the query was successful, the function returns true and sets the Token values.
        // Otherwise the function returns false or throws an exception when <paramref name="suppressErrors"/> is false.
        public static bool CheckQueryParamsAndSet(string queryString, bool suppressErrors = true)
        {
            // Parse the query string into a
            // NameValueCollection for easy access
            // to each parameter.
            NameValueCollection query = HttpUtility.ParseQueryString(queryString);

            // Make sure the required query
            // parameters exist.
            if (query["code"] != null && query["realmId"] != null)
            {

                // Use the OAuth2Client to get a new
                // access token from the quickbook.
                TokenResponse responce = LocalAuth.Client.GetBearerTokenAsync(query["code"]).Result;

                // Set the token values 
                LocalAuth.Tokens.AccessToken = responce.AccessToken;
                LocalAuth.Tokens.RefreshToken = responce.RefreshToken;
                LocalAuth.Tokens.RealmId = query["realmId"];

                return true;
            }
            else
            {

                // Is the caller chooses to suppress
                // errors return false instead
                // of throwing an exception.
                if (suppressErrors)
                {
                    return false;
                }
                else
                {
                    throw new InvalidDataException(
                        $"The 'code' or 'realmId' was not present in the query parameters '{query}'."
                    );
                }
            }
        }

        // write down the tokens into the target JSON file to be written.
        public static void WriteTokensAsJson(AuthToken authTokens, string path = ".\\Tokens.json")
        {
            string serialized = System.Text.Json.JsonSerializer.Serialize(authTokens, new JsonSerializerOptions()
            {
                WriteIndented = true,
            });

            // Create the parent directory
            // to avoid possible conflicts.
            Directory.CreateDirectory(new FileInfo(path).Directory.FullName);

            // Write the string to the path.
            File.WriteAllText(path, serialized);
        }

    }
}
