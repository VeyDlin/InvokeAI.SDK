namespace InvokeAI.SDK.Api.Queue.JsonModels;


public class CursorPaginatedResults {
    public required int limit { get; set; }
    public required bool has_more { get; set; }
    public required List<Item> items { get; set; }
}



public class Item {
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
    public required List<FieldValue> field_values { get; set; }
}



public class FieldValue {
    public required string node_path { get; set; }
    public required string field_name { get; set; }
    public required string value { get; set; }
}
