namespace InvokeAI.SDK.GraphBuilder.Nodes;


public abstract class INode {
    public abstract string type { get; }
    public string id { get; }

    private static long IdCounter = 0;


    public INode() {
        id = CreateId(type);
    }


    public static string CreateId(string type) {
        return $"{type}_{GetId()}";
    }


    private static long GetId() {
        return IdCounter++;
    }
}
