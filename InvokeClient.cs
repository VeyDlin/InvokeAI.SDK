using InvokeAI.SDK.App;
using InvokeAI.SDK.Boards;
using InvokeAI.SDK.Images;
using InvokeAI.SDK.Models;
using InvokeAI.SDK.Queue;
using InvokeAI.SDK.Utilities;

namespace InvokeAI.SDK;


public class InvokeClient {
    public string host { get; set; }
    public UtilitiesApi utilities { get; private set; }
    public ModelsApi models { get; private set; }
    public ImagesApi images { get; private set; }
    public BoardsApi boards { get; private set; }
    public AppApi app { get; private set; }
    public QueueApi queue { get; private set; }



    public InvokeClient(string host = "http://127.0.0.1:9090") {
        this.host = host;

        utilities = new(host);
        models = new(host);
        images = new(host);
        boards = new(host);
        app = new(host);
        queue = new(host);
    }
}
