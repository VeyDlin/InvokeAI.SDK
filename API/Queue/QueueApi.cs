using InvokeAI.SDK.Api.Queue.JsonModels;
using InvokeAI.SDK.Queue.JsonModels;
using System.Collections.Specialized;

namespace InvokeAI.SDK.Queue;



public class QueueApi : IApi {
    public string queueId { get; set; }





    public QueueApi(string host, string queueId = "default") : base(host) {
        this.queueId = queueId;
    }





    public async Task<CursorPaginatedResults> List(int limit = 50, string? status = null, string? cursor = null, int priority = 0) {
        var prams = new NameValueCollection {
            ["limit"] = limit.ToString(),
            ["priority"] = priority.ToString(),
            ["status"] = status,
            ["cursor"] = cursor,

        };

        return await GetAsync<CursorPaginatedResults>($"queue/{queueId}/list", 1, prams!);
    }





    public async Task<EnqueueBatch> EnqueueBatch(dynamic data) {
        return await PostAsync<EnqueueBatch>($"queue/{queueId}/enqueue_batch", 1, data);
    }





    public async Task<EnqueueBatch> EnqueueBatch(string data) {
        return await PostAsync<EnqueueBatch>($"queue/{queueId}/enqueue_batch", 1, data);
    }





    public async Task<BatchStatus> GetBatchStatus(string batchId) {
        return await GetAsync<BatchStatus>($"queue/{queueId}/b/{batchId}/status", 1);
    }





    public async Task<SessionQueueItem> GetQueueItem(string itemId) {
        return await GetAsync<SessionQueueItem>($"queue/{queueId}/i/{itemId}", 1);
    }





    public async Task<Clear> Clear() {
        return await PutAsync<Clear>($"queue/{queueId}/clear", 1);
    }
}
