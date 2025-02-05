namespace InvokeAI.SDK.GraphBuilder.Components;


public class WorkflowEdge {
    public required string id { get; set; }
    public required string source { get; set; }
    public required string target { get; set; }
    public required string type { get; set; }
    public required string sourceHandle { get; set; }
    public required string targetHandle { get; set; }
}