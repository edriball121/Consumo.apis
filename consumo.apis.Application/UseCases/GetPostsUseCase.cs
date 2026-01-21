using consumo.apis.Application.DTOs;
using consumo.apis.Domain.Ports;

namespace consumo.apis.Application.UseCases;

/// <summary>
/// Implementación del caso de uso para obtener posts
/// </summary>
public class GetPostsUseCase : IGetPostsUseCase
{
    private readonly IPostRepository _postRepository;

    public GetPostsUseCase(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<IEnumerable<PostDto>> ExecuteAsync()
    {
        var posts = await _postRepository.GetAllPostsAsync();
        return posts.Select(p => new PostDto
        {
            UserId = p.UserId,
            Id = p.Id,
            Title = p.Title,
            Body = p.Body
        });
    }

    public async Task<PostDto?> ExecuteByIdAsync(int id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);
        if (post == null) return null;

        return new PostDto
        {
            UserId = post.UserId,
            Id = post.Id,
            Title = post.Title,
            Body = post.Body
        };
    }

    public async Task<IEnumerable<PostDto>> ExecuteByUserIdAsync(int userId)
    {
        var posts = await _postRepository.GetPostsByUserIdAsync(userId);
        return posts.Select(p => new PostDto
        {
            UserId = p.UserId,
            Id = p.Id,
            Title = p.Title,
            Body = p.Body
        });
    }
}
