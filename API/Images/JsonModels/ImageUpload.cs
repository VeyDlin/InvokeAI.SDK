namespace InvokeAI.SDK.Images.JsonModels;


public class ImageUpload {
    public required string image_name { get; set; }
    public required string image_url { get; set; }
    public required string thumbnail_url { get; set; }
    public required string image_origin { get; set; }
    public required string image_category { get; set; }
    public required int width { get; set; }
    public required int height { get; set; }
    public string? created_at { get; set; }
    public string? updated_at { get; set; }
    public string? deleted_at { get; set; }
    public required bool is_intermediate { get; set; }
    public string? session_id { get; set; }
    public string? node_id { get; set; }
    public required bool starred { get; set; }
    public required bool has_workflow { get; set; }
    public string? board_id { get; set; }
}