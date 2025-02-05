namespace InvokeAI.SDK.Models;


public class Model {
    public required string key { get; set; }
    public required string hash { get; set; }
    public required string path { get; set; }
    public required string name { get; set; }
    public required string @base { get; set; }
    public string? description { get; set; }
    public required string source { get; set; }
    public required string source_type { get; set; }
    public string? source_api_response { get; set; }
    public string? cover_image { get; set; }
    public required string type { get; set; }
}