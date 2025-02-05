namespace InvokeAI.SDK.GraphBuilder.Nodes;


public class Prompt : INode {
    public override string type => "compel";
    public required string prompt { get; set; }
    public bool is_intermediate { get; set; } = true;
    public bool use_cache { get; set; } = true;

}
