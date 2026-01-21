namespace consumo.apis.Domain.Ports;

/// <summary>
/// Puerto de entrada para consumir datos de Users desde JSONPlaceholder
/// </summary>
public interface IUserRepository
{
    Task<IEnumerable<Entities.User>> GetAllUsersAsync();
    Task<Entities.User?> GetUserByIdAsync(int id);
}
