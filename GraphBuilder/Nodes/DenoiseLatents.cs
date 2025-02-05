namespace InvokeAI.SDK.GraphBuilder.Nodes;


public class DenoiseLatents : INode {
    public override string type => "denoise_latents";
    public bool is_intermediate { get; set; } = true;
    public bool use_cache { get; set; } = true;
    public required double cfg_scale { get; set; }
    public double cfg_rescale_multiplier { get; set; } = 0;
    public required string scheduler { get; set; }
    public required int steps { get; set; }
    public double denoising_start { get; set; } = 0;
    public double denoising_end { get; set; } = 1;
}
