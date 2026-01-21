using consumo.apis.Domain.Entities;
using consumo.apis.Domain.Ports;
using consumo.apis.Infrastructure.HttpClients;

namespace consumo.apis.Infrastructure.Repositories;

/// <summary>
/// Implementación del repositorio de Users (Adaptador que consume JSONPlaceholder)
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly JsonPlaceholderClient _jsonPlaceholderClient;

    public UserRepository(JsonPlaceholderClient jsonPlaceholderClient)
    {
        _jsonPlaceholderClient = jsonPlaceholderClient;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var users = await _jsonPlaceholderClient.GetAllUsersAsync();
        return users ?? Enumerable.Empty<User>();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _jsonPlaceholderClient.GetUserByIdAsync(id);
    }
}
