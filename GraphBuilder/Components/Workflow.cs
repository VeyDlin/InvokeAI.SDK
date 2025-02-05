namespace InvokeAI.SDK.GraphBuilder.Components;


public class Workflow {
    public required string name { get; set; }
    public required string author { get; set; }
    public required string description { get; set; }
    public required string version { get; set; }
    public required string contact { get; set; }
    public required string tags { get; set; }
    public required string notes { get; set; }
    public required List<WorkflowNode> nodes { get; set; }
    public required List<WorkflowEdge> edges { get; set; }
    public List<ExposedField>? exposedFields { get; set; }
    public dynamic? meta { get; set; }



    public ExposedField? GetExposedField(string labelOrName) {
        if (labelOrName is null) {
            return null;
        }

        foreach (var field in exposedFields!) {
            var inputs = nodes.Where(x => x.id == field.nodeId).First().data.inputs;

            var anyInput = inputs.Where(x => 
                x.Value.label.ToLower() == labelOrName.ToLower() || 
                x.Value.name.ToLower() == labelOrName.ToLower() ||
                x.Value.name.ToLower().Replace("_", " ") == labelOrName.ToLower()
            );
            if (anyInput.Any() && anyInput.First().Value.name == field.fieldName) {
                return field;
            }
        }

        return null;
    }
}