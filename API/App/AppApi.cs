using Version = InvokeAI.SDK.App.JsonModels.Version;

namespace InvokeAI.SDK.App;


public class AppApi : IApi {
    public AppApi(string host) : base(host) { }





    public async Task<Version> Version() {
        return await GetAsync<Version>("app/version", 1);
    }
}
