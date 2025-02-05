namespace InvokeAI.SDK.GraphBuilder.Components;


public class BatchRoot {
    public bool prepend { get; set; } = false;
    public required Batch batch { get; set; }
}