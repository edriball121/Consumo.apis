using consumo.apis.Domain.Entities;
using consumo.apis.Domain.Ports;
using consumo.apis.Infrastructure.HttpClients;

namespace consumo.apis.Infrastructure.Repositories;

/// <summary>
/// Implementación del repositorio de Comments (Adaptador que consume JSONPlaceholder)
/// </summary>
public class CommentRepository : ICommentRepository
{
    private readonly JsonPlaceholderClient _jsonPlaceholderClient;

    public CommentRepository(JsonPlaceholderClient jsonPlaceholderClient)
    {
        _jsonPlaceholderClient = jsonPlaceholderClient;
    }

    public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
    {
        var comments = await _jsonPlaceholderClient.GetCommentsByPostIdAsync(postId);
        return comments ?? Enumerable.Empty<Comment>();
    }

    public async Task<Comment?> GetCommentByIdAsync(int id)
    {
        return await _jsonPlaceholderClient.GetCommentByIdAsync(id);
    }
}
