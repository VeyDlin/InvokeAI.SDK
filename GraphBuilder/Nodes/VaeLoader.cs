namespace InvokeAI.SDK.GraphBuilder.Nodes;


public class VaeLoader : INode {
    public override string type => "vae_loader";
    public bool is_intermediate { get; set; } = true;
    public bool use_cache { get; set; } = true;
    public required VaeModel vae_model { get; set; }

    public class VaeModel {
        public required string model_name { get; set; }
        public required string base_model { get; set; }
    }

    public readonly struct BaseModel {
        public static readonly string sd1 = "sd-1";
    }
}



