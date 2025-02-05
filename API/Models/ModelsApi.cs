using System;
using System.Buffers.Text;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web;

namespace InvokeAI.SDK.Models;


public class ModelsApi : IApi {
    public enum BaseModels {
        [Description("sd-1")]
        SD1,
        [Description("sd-2")]
        SD2,
        [Description("sd-3")]
        SD3,
        [Description("sdxl")]
        SDXL,
        [Description("sdxl-refiner")]
        SDXLRefiner,
        [Description("flux")]
        Flux,
        [Description("any")]
        Any
    }

    public enum ModelType {
        [Description("main")]
        Main,
        [Description("vae")]
        VAE,
        [Description("lora")]
        LoRA,
        [Description("embedding")]
        Embedding,
        [Description("controlnet")]
        Controlnet,
        [Description("t2i_adapter")]
        T2IAdapter,
        [Description("onnx")]
        Onnx,
        [Description("ip_adapter")]
        IPAdapter,
        [Description("clip_vision")]
        ClipVision
    }



    public ModelsApi(string host) : base(host) { }




    public async Task<Models> ListModels(List<BaseModels>? baseModels = null, List<string>? name = null, List<ModelType>? type = null, List<string>? format = null) {
        var prams = new NameValueCollection();

        void AddParams<T>(List<T>? items, string paramName, Func<T, string>? converter = null) {
            if (items is not null) {
                foreach (var item in items) {
                    prams.Add(paramName, converter?.Invoke(item) ?? item?.ToString());
                }
            }
        }

        AddParams(baseModels, "base_models", Utils.GetDescription);
        AddParams(name, "model_name");
        AddParams(type, "model_type", Utils.GetDescription);
        AddParams(format, "model_format");

        return await GetAsync<Models>("models/", 2, prams);
    }
}
