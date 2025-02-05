namespace InvokeAI.SDK.GraphBuilder.Nodes;


public class LoraSelector : INode {
    public override string type => "lora_selector";
    public bool is_intermediate { get; set; } = true;
    public bool use_cache { get; set; } = true;
    public required Lora lora { get; set; }
    public required double weight { get; set; }

    public class Lora {
        public string key { get; set; } = "-";
        public string hash { get; set; } = "-";
        public required string name { get; set; }
        public string @base { get; set; } = BaseModel.sd1;
        public string type { get; set; } = ModelType.lora;
    }

    public readonly struct BaseModel {
        public static readonly string sd1 = "sd-1";
        public static readonly string sd2 = "sd-2";
        public static readonly string sd3 = "sd-2";
        public static readonly string sdxl = "sdxl";
    }

    public readonly struct ModelType {
        public static readonly string lora = "lora";
    }
}