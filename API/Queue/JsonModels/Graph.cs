namespace InvokeAI.SDK.Queue.JsonModels;


public class Graph {
    public required string id { get; set; }
    public required dynamic nodes { get; set; }
    public required List<Edge> edges { get; set; }
}