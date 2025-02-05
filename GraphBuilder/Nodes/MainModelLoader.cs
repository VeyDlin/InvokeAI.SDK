namespace InvokeAI.SDK.GraphBuilder.Nodes;


public class MainModelLoader : INode {
    public override string type => "main_model_loader";
    public bool is_intermediate { get; set; } = true;
    public bool use_cache { get; set; } = true;
    public required Model model { get; set; }

    public class Model {
        public string key { get; set; } = "-";
        public string hash { get; set; } = "-";
        public required string name { get; set; }
        public string @base { get; set; } = BaseModel.sd1;
        public string type { get; set; } = ModelType.main;
    }

    public readonly struct BaseModel {
        public static readonly string sd1 = "sd-1";
    }

    public readonly struct ModelType {
        public static readonly string main = "main";
    }
}