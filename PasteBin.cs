using System;
using System.Configuration;
using System.Net.Http;
using System.Web;

public static class PasteBin
{
    private const string _pasteBinUrl = "https://pastebin.com/api/api_post.php";
    private static string _apiKey = ConfigurationManager.AppSettings["PasteBinApiKey"];

    /// <summary>
    /// Posts the specified text to Pastebin, with a default name.
    /// </summary>
    /// <param name="text">The text to post.</param>
    /// <returns>The URL of the posted text.</returns>
    public static async Task<string> Create(string text)
    {
        return await Create("My Paste", text);
    }

    /// <summary>
    /// Posts the specified text to Pastebin.
    /// </summary>
    /// <param name="name">The name of the paste.</param>
    /// <param name="text">The text to post.</param>
    /// <returns>The URL of the posted text.</returns>
    public static async Task<string> Create(string name, string text)
    {
        //Task<string> pasteBinUrl;
        if (_apiKey == null)
        {
            throw new ConfigurationErrorsException("PasteBinApiKey is not set in the App.config file.");
        }

        // Create the request.
        HttpClient client = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _pasteBinUrl);
        request.Content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("api_dev_key", _apiKey),
            new KeyValuePair<string, string>("api_option", "paste"),
            new KeyValuePair<string, string>("api_paste_code", text),
            new KeyValuePair<string, string>("api_paste_name", name),
            new KeyValuePair<string, string>("api_paste_format", "text"),
            new KeyValuePair<string, string>("api_paste_private", "1"),
            new KeyValuePair<string, string>("api_paste_expire_data", "1D")
        });

        HttpResponseMessage response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}