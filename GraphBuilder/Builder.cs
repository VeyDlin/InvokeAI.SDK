using InvokeAI.SDK.GraphBuilder.Components;
using InvokeAI.SDK.GraphBuilder.Nodes;
using InvokeAI.SDK.Helpers;
using Newtonsoft.Json;

namespace InvokeAI.SDK.GraphBuilder;


public class Builder {
    public BatchRoot root { get; private set; }
    public int runs { get => root.batch.runs; set => root.batch.runs = value; }
    public string name { get => root.batch.graph.id; set => root.batch.graph.id = value; }



    public Builder(string name, int runs = 1) {
        root = new BatchRoot() {
            prepend = false,
            batch = new() {
                graph = new() {
                    id = name,
                    nodes = new(),
                    edges = new()
                },
                runs = runs
            }
        };
    }



    public T AddNode<T>(T node) where T : INode {
        root.batch.AddNode(node);
        return node;
    }



    public void Connect(INode sourceNode, string sourceField, INode destinationNode, string destinationField) {
        root.batch.graph.edges.Add(new() {
            source = new() {
                node_id = sourceNode.id,
                field = sourceField
            },
            destination = new() {
                node_id = destinationNode.id,
                field = destinationField
            }
        });
    }



    public void Connect(INode sourceNode, string sourceField, List<(INode node, string field)> destinations) {
        foreach (var destination in destinations) {
            Connect(sourceNode, sourceField, destination.node, destination.field);
        }
    }



    public void Connect(List<(INode sourceNode, string sourceField, INode destinationNode, string destinationField)> connections) {
        foreach (var connection in connections) {
            Connect(connection.sourceNode, connection.sourceField, connection.destinationNode, connection.destinationField);
        }
    }



    public string BuildJson() {
        return JsonConvert.SerializeObject(
            root,
            new JsonSerializerSettings() {
                ContractResolver = new IgnorePropertiesResolver(),
                Formatting = Formatting.Indented
            }
        );
    }
}
