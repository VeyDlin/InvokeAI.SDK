using InvokeAI.SDK.GraphBuilder;
using InvokeAI.SDK.GraphBuilder.Nodes;

namespace InvokeAI.SDK.Presets;


public class TextToImageSD1 {
    public required string model { get; set; }
    public required string modelKey { get; set; }
    public required string modelHash { get; set; }
    public required string positivePrompt { get; set; }
    public required string negativePrompt { get; set; }
    public required int height { get; set; }
    public required int width { get; set; }
    public required long seed { get; set; }
    public required double cfg { get; set; }
    public required string scheduler { get; set; }
    public required int steps { get; set; }
    public required bool fp32 { get; set; }
    public string? vae { get; set; }
    public List<(string name, double weight)>? loras { get; set; }



    public string BuildJson() {
        var builder = new Builder(Guid.NewGuid().ToString());

        var mainModelLoader = builder.AddNode(new MainModelLoader() {
            model = new() {
                key = modelKey,
                hash = modelHash,
                @base = MainModelLoader.BaseModel.sd1,
                name = model
            }
        });

        var positivePrompt = builder.AddNode(new Prompt() {
            prompt = this.positivePrompt
        });

        var negativePrompt = builder.AddNode(new Prompt() {
            prompt = this.negativePrompt
        });

        var noise = builder.AddNode(new Noise() {
            height = height,
            width = width,
            seed = seed
        });

        var denoiseLatents = builder.AddNode(new DenoiseLatents() {
            cfg_scale = cfg,
            scheduler = scheduler.ToLower(),
            steps = steps
        });

        var latentsToImage = builder.AddNode(new LatentsToImage() {
            fp32 = fp32
        });

        var saveImage = builder.AddNode(new SaveImage() {
            is_intermediate = false
        });


        // VAE
        if (vae is not null) {
            var vaeLoader = builder.AddNode(new VaeLoader() {
                vae_model = new() {
                    base_model = VaeLoader.BaseModel.sd1,
                    model_name = vae
                }
            });

            builder.Connect(vaeLoader, "vae", latentsToImage, "vae");
        } else {
            builder.Connect(mainModelLoader, "vae", latentsToImage, "vae");
        }

        // Model Loader
        INode lastConnection = mainModelLoader;
        if (loras is not null) {
            foreach (var lora in loras) {

                var loraLoader = builder.AddNode(new LoraLoader() {
                    lora = new() {
                        base_model = LoraLoader.BaseModel.sd1,
                        model_name = lora.name
                    },
                    weight = lora.weight
                });

                builder.Connect(lastConnection, "unet", loraLoader, "unet");
                builder.Connect(lastConnection, "clip", loraLoader, "clip");

                lastConnection = loraLoader;
            }
        }
        builder.Connect(lastConnection, "unet", denoiseLatents, "unet");
        builder.Connect(lastConnection, "clip", new() {
            (positivePrompt, "clip"),
            (negativePrompt, "clip")
        });


        // Prompt
        builder.Connect(positivePrompt, "conditioning", denoiseLatents, "positive_conditioning");
        builder.Connect(negativePrompt, "conditioning", denoiseLatents, "negative_conditioning");

        // Noise
        builder.Connect(noise, "noise", denoiseLatents, "noise");

        // Denoise Latents
        builder.Connect(denoiseLatents, "latents", latentsToImage, "latents");

        // Latents To Image
        builder.Connect(latentsToImage, "image", saveImage, "image");


        return builder.BuildJson();
    }
}
