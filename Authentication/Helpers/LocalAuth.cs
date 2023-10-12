using Authentication.Model;
using Intuit.Ipp.OAuth2PlatformClient;
using System.Text.Json;

namespace Authentication.Helper
{
    public static class LocalAuth
    {
        public static AuthToken? Tokens { get; set; } = null;
        public static OAuth2Client? Client { get; set; } = null;

        // writing a method to take the information from Token stored into the file's properties
        public static void Initialize(string path = "C:\\Users\\User\\source\\repos\\TaskSln\\Authentication\\Token.jsonc")
        {
            // we can deserialize again when we want to read or write the data.
            Tokens = JsonSerializer.Deserialize<AuthToken>(File.ReadAllText(path), new JsonSerializerOptions()
            {
                ReadCommentHandling = JsonCommentHandling.Skip
            }) ?? new();

            // In the case that the data failed to deserialize, the ClientId
            // and ClientSecret might be null, so to be sure we can add if clause 
            if (!string.IsNullOrEmpty(Tokens.ClientId) && !string.IsNullOrEmpty(Tokens.ClientSecret))
            {
                Client = new(Tokens.ClientId, Tokens.ClientSecret, Tokens.RedirectUrl, Tokens.Environment);
            }
            else
            {
                throw new InvalidDataException(
                    "The ClientId or ClientSecret is null or empty."
                   
                );
            }
        }
    }
}
