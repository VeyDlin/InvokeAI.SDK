using Newtonsoft.Json.Linq;

namespace InvokeAI.SDK.GraphBuilder.Components;


public class Graph {
    public required string id { get; set; }
    public required Dictionary<string, JObject> nodes { get; set; }
    public required List<Edge> edges { get; set; }
}