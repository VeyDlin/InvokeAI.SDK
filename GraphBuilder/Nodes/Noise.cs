namespace InvokeAI.SDK.GraphBuilder.Nodes;


public class Noise : INode {
    public override string type => "noise";
    public required long seed { get; set; }
    public required int width { get; set; }
    public required int height { get; set; }
    public bool use_cpu { get; set; } = true;
    public bool is_intermediate { get; set; } = true;
    public bool use_cache { get; set; } = false;
}