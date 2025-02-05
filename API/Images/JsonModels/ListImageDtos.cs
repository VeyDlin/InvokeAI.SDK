namespace InvokeAI.SDK.Images.JsonModels;


public class ListImageDtos {
    public required List<ImageDto> items { get; set; }
    public required int offset { get; set; }
    public required int limit { get; set; }
    public required int total { get; set; }
}
