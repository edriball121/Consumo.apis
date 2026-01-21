using consumo.apis.Application.DTOs;
using consumo.apis.Domain.Ports;

namespace consumo.apis.Application.UseCases;

/// <summary>
/// Implementación del caso de uso para obtener comentarios
/// </summary>
public class GetCommentsUseCase : IGetCommentsUseCase
{
    private readonly ICommentRepository _commentRepository;

    public GetCommentsUseCase(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<IEnumerable<CommentDto>> ExecuteByPostIdAsync(int postId)
    {
        var comments = await _commentRepository.GetCommentsByPostIdAsync(postId);
        return comments.Select(c => new CommentDto
        {
            PostId = c.PostId,
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            Body = c.Body
        });
    }

    public async Task<CommentDto?> ExecuteByIdAsync(int id)
    {
        var comment = await _commentRepository.GetCommentByIdAsync(id);
        if (comment == null) return null;

        return new CommentDto
        {
            PostId = comment.PostId,
            Id = comment.Id,
            Name = comment.Name,
            Email = comment.Email,
            Body = comment.Body
        };
    }
}
