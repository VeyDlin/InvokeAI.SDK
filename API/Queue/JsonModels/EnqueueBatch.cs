namespace InvokeAI.SDK.Queue.JsonModels;


public class EnqueueBatch {
    public required string queue_id { get; set; }
    public required int enqueued { get; set; }
    public required int requested { get; set; }
    public required Batch batch { get; set; }
    public required int priority { get; set; }
}