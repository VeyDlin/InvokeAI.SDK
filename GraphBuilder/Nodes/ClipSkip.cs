namespace InvokeAI.SDK.GraphBuilder.Nodes;


public class ClipSkip : INode {
    public override string type => "clip_skip";
    public required int skipped_layers { get; set; }
    public bool is_intermediate { get; set; } = true;
    public bool use_cache { get; set; } = true;
}