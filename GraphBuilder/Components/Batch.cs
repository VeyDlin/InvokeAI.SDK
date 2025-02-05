using InvokeAI.SDK.Models;
using Newtonsoft.Json.Linq;

namespace InvokeAI.SDK.GraphBuilder.Components;


public class Batch {
    public required Graph graph { get; set; }
    public Workflow? workflow { get; set; } = null;
    public int runs { get; set; } = 1;



    public JObject AddNode(dynamic node) {
        var jnode = JObject.FromObject(node);
        graph.nodes.Add(jnode["id"].ToString(), jnode);
        return jnode;
    }



    public IEnumerable<JObject> FindNode(Func<WorkflowNode, bool> predicate) {
        var ids = workflow!.nodes.Where(predicate).Select(x => x.id);
        return graph.nodes          
            .Where(kvp => ids.Contains(kvp.Key))
            .Select(kvp => kvp.Value);
    }



    public void DeleteNode(Func<JObject, bool> predicate) {
        var deleteNodes = graph.nodes
            .Where(x => predicate(x.Value))
            .Select(x => x.Key);
        
        // Delete nodes
        graph.nodes = graph.nodes
            .Where(x => !predicate(x.Value))
            .ToDictionary();

        // Delete edges
        graph.edges = graph.edges
            .Where(x => !deleteNodes.Contains(x.source.node_id) && !deleteNodes.Contains(x.destination.node_id))
            .ToList();
    }



    public IEnumerable<Edge> FindEdge(Func<Source, Destination, bool> predicate) {
        return graph.edges.Where(x => predicate(x.source, x.destination));
    }



    public void Connect(dynamic sourceNode, string sourceField, dynamic destinationNode, string destinationField) {
        ConnectManual(sourceNode.id, sourceField, destinationNode.id, destinationField);
    }



    public void ConnectManual(string sourceNodeId, string sourceField, string destinationNodeId, string destinationField) {
        graph.edges.Add(new() {
            source = new() {
                node_id = sourceNodeId,
                field = sourceField
            },
            destination = new() {
                node_id = destinationNodeId,
                field = destinationField
            }
        });
    }



    public void SetGraphFieldFromExposed(string labelOrName, dynamic val) {
        try {
            var field = workflow!.GetExposedField(labelOrName)!;
            var node = graph.nodes[field.nodeId];
            node[field.fieldName] = JToken.FromObject(val);
        } catch (Exception ex) {
            throw new Exception($"Error set graph field '{labelOrName}': {ex.Message}");
        }
    }



    public static Batch FromWorkflow(Workflow workflow) {
        var nodes = workflow.nodes.Select(node => {
            var obj = new JObject();
            obj["id"] = node.id;
            obj["type"] = node.data.type;
            obj["is_intermediate"] = node.data.isIntermediate;
            obj["use_cache"] = node.data.useCache;

            foreach (var input in node.data.inputs.Values) {
                if (input.value is not null) {
                    obj[input.name] = input.value;
                }
            }
            return obj;
        }).ToDictionary(obj => obj["id"]!.ToString(), obj => obj);

        var edges = workflow.edges.Select(edge => {
            return new Edge() {
                source = new() {
                    node_id = edge.source,
                    field = edge.sourceHandle
                },
                destination = new() {
                    node_id = edge.target,
                    field = edge.targetHandle
                }
            };
        }).ToList();

        return new Batch() {
            graph = new Graph() {
                id = Guid.NewGuid().ToString(),
                nodes = nodes,
                edges = edges
            },
            workflow = workflow
        };
    }



    public void UpdateModelsHash(List<Model> models) {
        var paths = new Dictionary<string, string>() {
            { "main_model_loader", "model"},
            { "sdxl_model_loader", "model"},
            { "lora_selector", "lora"},
            { "controlnet", "control_model"},
        };

        foreach (var node in graph.nodes) {
            var type = node.Value["type"]!.ToString();

            if (paths.ContainsKey(type)) {
                string path = paths[type];
                var name = node.Value[path]!["name"]!.ToString();

                var model = models.Where(x => x.name == name).ToList();
                if (model.Any()) {
                    graph.nodes[node.Key][path]!["key"] = model[0].key;
                    graph.nodes[node.Key][path]!["hash"] = model[0].hash;
                } else {
                    throw new Exception($"UpdateM hash for model '{name}' error: model not found");
                }
            }
        }
    }
}