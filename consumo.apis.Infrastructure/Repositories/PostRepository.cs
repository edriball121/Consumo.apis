using consumo.apis.Domain.Entities;
using consumo.apis.Domain.Ports;
using consumo.apis.Infrastructure.HttpClients;

namespace consumo.apis.Infrastructure.Repositories;

/// <summary>
/// Implementación del repositorio de Posts (Adaptador que consume JSONPlaceholder)
/// </summary>
public class PostRepository : IPostRepository
{
    private readonly JsonPlaceholderClient _jsonPlaceholderClient;

    public PostRepository(JsonPlaceholderClient jsonPlaceholderClient)
    {
        _jsonPlaceholderClient = jsonPlaceholderClient;
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        var posts = await _jsonPlaceholderClient.GetAllPostsAsync();
        return posts ?? Enumerable.Empty<Post>();
    }

    public async Task<Post?> GetPostByIdAsync(int id)
    {
        return await _jsonPlaceholderClient.GetPostByIdAsync(id);
    }

    public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId)
    {
        var posts = await _jsonPlaceholderClient.GetPostsByUserIdAsync(userId);
        return posts ?? Enumerable.Empty<Post>();
    }
}
