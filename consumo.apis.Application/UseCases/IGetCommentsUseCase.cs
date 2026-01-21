using consumo.apis.Application.DTOs;

namespace consumo.apis.Application.UseCases;

/// <summary>
/// Caso de uso para obtener comentarios
/// </summary>
public interface IGetCommentsUseCase
{
    Task<IEnumerable<CommentDto>> ExecuteByPostIdAsync(int postId);
    Task<CommentDto?> ExecuteByIdAsync(int id);
}
