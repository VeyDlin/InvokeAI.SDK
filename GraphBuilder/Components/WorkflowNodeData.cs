namespace InvokeAI.SDK.GraphBuilder.Components;


public class WorkflowNodeData {
    public required string id { get; set; }
    public required string version { get; set; }
    public required string label { get; set; }
    public required string notes { get; set; }
    public required string type { get; set; }
    public required Dictionary<string, WorkflowNodeInput> inputs { get; set; }
    public required bool isOpen { get; set; }
    public required bool isIntermediate { get; set; }
    public required bool useCache { get; set; }
}