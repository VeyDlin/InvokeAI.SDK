using InvokeAI.SDK.Images.JsonModels;
using System.Collections.Specialized;

namespace InvokeAI.SDK.Images;



public class ImagesApi : IApi {
    public enum ImageOrigin { Internal, External }
    public enum Categories { General, Mask, Control, User, Other }




    public ImagesApi(string host) : base(host) { }





    public async Task<ImageDto> GetImageDto(string imageName) {
        return await GetAsync<ImageDto>($"images/i/{imageName}", 1);
    }





    public async Task<ListImageDtos> ListImageDtos(int offset = 0, int limit = 10, string? boardId = null, bool? isIntermediate = null, ImageOrigin? imageOrigin = null, Categories? categories = null) {
        var prams = new NameValueCollection {
            ["offset"] = offset.ToString(),
            ["limit"] = limit.ToString(),
            ["is_intermediate"] = isIntermediate?.ToString().ToLower(),
            ["image_origin"] = imageOrigin?.ToString().ToLower(),
            ["categories"] = categories?.ToString().ToLower(),
            ["board_id"] = boardId?.ToString().ToLower(),
        };

        return await GetAsync<ListImageDtos>("images/", 1, prams);
    }





    public async Task<string> DeleteImage(string imageName) {
        return await DeleteAsync<string>($"images/i/{imageName}", 1);
    }





    public async Task<ImageUpload> Upload(byte[] image, Categories category = Categories.General, bool isIntermediate = false, string? boardId = null, string? sessionId = null, bool cropVisible = false) {
        var prams = new NameValueCollection {
            ["image_category"] = category.ToString().ToLower(),
            ["is_intermediate"] = isIntermediate.ToString().ToLower(),
            ["board_id"] = boardId?.ToString(),
            ["session_id"] = sessionId?.ToString(),
            ["crop_visible"] = cropVisible.ToString().ToLower(),
        };

        return await UploadAsync<ImageUpload>($"images/upload", 1, "file", image, prams);
    }
}