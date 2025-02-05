namespace InvokeAI.SDK.GraphBuilder.Nodes;


public class SaveImage : INode {
    public override string type => "save_image";
    public bool is_intermediate { get; set; } = true;
    public bool use_cache { get; set; } = false;
}