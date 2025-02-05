using InvokeAI.SDK.Queue.JsonModels;

namespace InvokeAI.SDK.Api.Queue.JsonModels;


public class Session {
    public required string id { get; set; }
    public required Graph graph { get; set; }
    public required Graph execution_graph { get; set; }
    public required List<string> executed { get; set; }
    public required List<string> executed_history { get; set; }
    public required dynamic results { get; set; }
    public required dynamic errors { get; set; }
    public required dynamic prepared_source_mapping { get; set; }
    public required dynamic source_prepared_mapping { get; set; }
}