using System.Net.Http.Json;

namespace MyBlazorApp.Services;

public sealed class ApiService(HttpClient httpClient)
{
    public Task<T?> GetAsync<T>(string requestUri, CancellationToken cancellationToken = default) =>
        httpClient.GetFromJsonAsync<T>(requestUri, cancellationToken);

    public Task<HttpResponseMessage> PostAsync<T>(
        string requestUri,
        T content,
        CancellationToken cancellationToken = default) =>
        httpClient.PostAsJsonAsync(requestUri, content, cancellationToken);
}