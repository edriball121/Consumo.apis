using consumo.apis.Application.DTOs;

namespace consumo.apis.Application.UseCases;

/// <summary>
/// Caso de uso para obtener posts
/// </summary>
public interface IGetPostsUseCase
{
    Task<IEnumerable<PostDto>> ExecuteAsync();
    Task<PostDto?> ExecuteByIdAsync(int id);
    Task<IEnumerable<PostDto>> ExecuteByUserIdAsync(int userId);
}
