namespace InvokeAI.SDK.GraphBuilder.Nodes;


public class LoraLoader : INode {
    public override string type => "lora_loader";
    public bool is_intermediate { get; set; } = true;
    public bool use_cache { get; set; } = true;
    public required Lora lora { get; set; }
    public required double weight { get; set; }

    public class Lora {
        public required string model_name { get; set; }
        public required string base_model { get; set; }
    }

    public readonly struct BaseModel {
        public static readonly string sd1 = "sd-1";
    }
}