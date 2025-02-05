namespace InvokeAI.SDK.GraphBuilder.Components;


public class WorkflowNode {
    public required string id { get; set; }
    public required string type { get; set; }
    public required WorkflowNodeData data { get; set; }
    public required Position position { get; set; }
}