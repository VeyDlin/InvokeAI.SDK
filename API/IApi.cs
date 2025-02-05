using HeyRed.Mime;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Buffers.Text;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace InvokeAI.SDK;


public class IApi {
    static private HttpClient client { get; } = new HttpClient();
    public string host { get; private set; }






    public IApi(string host) {
        this.host = host;
    }





    public async Task<T> GetAsync<T>(string apiPath, int versoin, NameValueCollection? prams = null) {
        var url = QueryString(apiPath, versoin, prams);
        var response = await client.GetAsync(url);
        return await FromResponseAsync<T>(response);
    }





    public async Task<T> DeleteAsync<T>(string apiPath, int versoin, NameValueCollection? prams = null) {
        var url = QueryString(apiPath, versoin, prams);
        var response = await client.DeleteAsync(url);
        return await FromResponseAsync<T>(response);
    }





    public async Task<T> UploadAsync<T>(string apiPath, int versoin, string name, byte[] fileBytes, NameValueCollection? prams = null) {
        var url = QueryString(apiPath, versoin, prams);

        using var content = new MultipartFormDataContent();
        var byteArrayContent = new ByteArrayContent(fileBytes);

        var fileType = MimeGuesser.GuessMimeType(fileBytes);
        byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(fileType);

        content.Add(byteArrayContent, name, name);

        var response = await client.PostAsync(url, content);

        return await FromResponseAsync<T>(response);
    }





    public async Task<T> PostAsync<T>(string apiPath, int versoin, JObject? data = null, NameValueCollection? prams = null) {
        var url = QueryString(apiPath, versoin, prams);
        var response = await client.PostAsync(url, ToStringContent(data));
        return await FromResponseAsync<T>(response);
    }





    public async Task<T> PostAsync<T>(string apiPath, int versoin, string data, NameValueCollection? prams = null) {
        var url = QueryString(apiPath, versoin, prams);
        var response = await client.PostAsync(url, ToStringContent(data));
        return await FromResponseAsync<T>(response);
    }





    public async Task<T> PutAsync<T>(string apiPath, int versoin, JObject? data = null, NameValueCollection? prams = null) {
        var url = QueryString(apiPath, versoin, prams);
        var response = await client.PutAsync(url, ToStringContent(data));
        return await FromResponseAsync<T>(response);
    }





    public async Task<T> PutAsync<T>(string apiPath, int versoin, string data, NameValueCollection? prams = null) {
        var url = QueryString(apiPath, versoin, prams);
        var response = await client.PutAsync(url, ToStringContent(data));
        return await FromResponseAsync<T>(response);
    }





    private StringContent ToStringContent(JObject? data) {
        if (data is null) {
            return new("");
        }
        return new StringContent(data.ToString(), Encoding.UTF8, "application/json");
    }





    private StringContent ToStringContent(string? data) {
        if (data is null) {
            return new("");
        }
        return new StringContent(data, Encoding.UTF8, "application/json");
    }





    public string QueryString(string apiPath, int version, NameValueCollection? prams = null) {
        var baseUrl = $"{host}/api/v{version}/{apiPath}";

        if (prams is null || prams.Count == 0) {
            return baseUrl;
        }

        var queryString = string.Join("&", prams.AllKeys
            .Where(key => prams.GetValues(key) != null) 
            .SelectMany(key => prams.GetValues(key)!.Where(value => value != null)
            .Select(value => $"{Uri.EscapeDataString(key!)}={Uri.EscapeDataString(value)}")));

        return string.IsNullOrEmpty(queryString) ? baseUrl : $"{baseUrl}?{queryString}";
    }





    private async Task<T> FromResponseAsync<T>(HttpResponseMessage response) {
        string jsonString = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) {
            throw new Exception($"Server status: {response.StatusCode}; Info: {jsonString}");
        }
        return JsonConvert.DeserializeObject<T>(jsonString)!;
    }
}
