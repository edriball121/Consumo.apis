namespace consumo.apis.Domain.Ports;

/// <summary>
/// Puerto de entrada para consumir datos de Comments desde JSONPlaceholder
/// </summary>
public interface ICommentRepository
{
    Task<IEnumerable<Entities.Comment>> GetCommentsByPostIdAsync(int postId);
    Task<Entities.Comment?> GetCommentByIdAsync(int id);
}
