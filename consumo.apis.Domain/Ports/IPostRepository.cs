namespace consumo.apis.Domain.Ports;

/// <summary>
/// Puerto de entrada para consumir datos de Posts desde JSONPlaceholder
/// </summary>
public interface IPostRepository
{
    Task<IEnumerable<Entities.Post>> GetAllPostsAsync();
    Task<Entities.Post?> GetPostByIdAsync(int id);
    Task<IEnumerable<Entities.Post>> GetPostsByUserIdAsync(int userId);
}
