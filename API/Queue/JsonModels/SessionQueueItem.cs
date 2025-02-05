namespace InvokeAI.SDK.Api.Queue.JsonModels;


public class SessionQueueItem {
    public required int item_id { get; set; }
    public required string status { get; set; }
    public required int priority { get; set; }
    public required string batch_id { get; set; }
    public required string session_id { get; set; }
    public required string error { get; set; }
    public required DateTime created_at { get; set; }
    public required DateTime updated_at { get; set; }
    public required DateTime started_at { get; set; }
    public required DateTime completed_at { get; set; }
    public required string queue_id { get; set; }
    public required List<dynamic> field_values { get; set; }
    public required Session session { get; set; }
}