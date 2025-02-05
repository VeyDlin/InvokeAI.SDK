namespace InvokeAI.SDK.Queue.JsonModels;


public class Edge {
    public required EdgePoint source { get; set; }
    public required EdgePoint destination { get; set; }
}