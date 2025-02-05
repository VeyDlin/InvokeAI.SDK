namespace InvokeAI.SDK.GraphBuilder.Nodes;


public class LatentsToImage : INode {
    public override string type => "l2i";
    public required bool fp32 { get; set; }
    public bool is_intermediate { get; set; } = true;
    public bool use_cache { get; set; } = true;
}