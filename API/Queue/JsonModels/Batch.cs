namespace InvokeAI.SDK.Queue.JsonModels;


public class Batch {
    public required string batch_id { get; set; }
    public required Graph graph { get; set; }
    public required int runs { get; set; }
    public required List<List<dynamic>> data { get; set; }
}
