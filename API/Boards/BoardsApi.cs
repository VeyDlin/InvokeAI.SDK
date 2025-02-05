namespace InvokeAI.SDK.Boards;


public class BoardsApi : IApi {
    public BoardsApi(string host) : base(host) { }





    //public async Task<dynamic> ListBoards(bool all = true, int offset = 0, int limit = 1) {
    //    return await GetAsync("boards", new Dictionary<string, string> {
    //        ["all"] = all.ToString(),
    //        ["offset"] = offset.ToString(),
    //        ["limit"] = limit.ToString()
    //    });
    //}
}
