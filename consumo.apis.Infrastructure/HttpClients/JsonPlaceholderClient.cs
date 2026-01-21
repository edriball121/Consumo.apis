using consumo.apis.Domain.Entities;
using System.Text.Json;

namespace consumo.apis.Infrastructure.HttpClients;

/// <summary>
/// Cliente HTTP para consumir JSONPlaceholder API
/// </summary>
public class JsonPlaceholderClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://jsonplaceholder.typicode.com";
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public JsonPlaceholderClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(BaseUrl);
    }

    public async Task<IEnumerable<Post>?> GetAllPostsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/posts");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Post>>(json, JsonOptions);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Error fetching posts: {ex.Message}", ex);
        }
    }

    public async Task<Post?> GetPostByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/posts/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Post>(json, JsonOptions);
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Post>?> GetPostsByUserIdAsync(int userId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/posts?userId={userId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Post>>(json, JsonOptions);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Error fetching posts by user: {ex.Message}", ex);
        }
    }

    public async Task<IEnumerable<User>?> GetAllUsersAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/users");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<User>>(json, JsonOptions);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Error fetching users: {ex.Message}", ex);
        }
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/users/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(json, JsonOptions);
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Comment>?> GetCommentsByPostIdAsync(int postId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/comments?postId={postId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Comment>>(json, JsonOptions);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Error fetching comments: {ex.Message}", ex);
        }
    }

    public async Task<Comment?> GetCommentByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/comments/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Comment>(json, JsonOptions);
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }
}
