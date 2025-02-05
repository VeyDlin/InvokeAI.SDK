namespace InvokeAI.SDK.Images.JsonModels;


public class ImageDto {
    public required string image_name { get; set; }
    public required string image_url { get; set; }
    public required string thumbnail_url { get; set; }
    public required string image_origin { get; set; }
    public required string image_category { get; set; }
    public required int width { get; set; }
    public required int height { get; set; }
    public required DateTime created_at { get; set; }
    public required DateTime updated_at { get; set; }
    public required bool is_intermediate { get; set; }
    public required string session_id { get; set; }
    public required string node_id { get; set; }
    public required bool starred { get; set; }
}
