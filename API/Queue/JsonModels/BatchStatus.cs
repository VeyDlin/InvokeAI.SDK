namespace InvokeAI.SDK.Queue.JsonModels;


public class BatchStatus {
    public required string queue_id { get; set; }
    public required string batch_id { get; set; }
    public required int pending { get; set; }
    public required int in_progress { get; set; }
    public required int completed { get; set; }
    public required int failed { get; set; }
    public required int canceled { get; set; }
    public required int total { get; set; }
}