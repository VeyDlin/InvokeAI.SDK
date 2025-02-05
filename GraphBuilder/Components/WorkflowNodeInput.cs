namespace InvokeAI.SDK.GraphBuilder.Components;


public class WorkflowNodeInput {
    public required string name { get; set; }
    public required string label { get; set; }
    public dynamic? value { get; set; }
}
