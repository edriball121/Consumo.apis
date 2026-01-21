using consumo.apis.Application.DTOs;
using consumo.apis.Domain.Ports;

namespace consumo.apis.Application.UseCases;

/// <summary>
/// Implementación del caso de uso para obtener usuarios
/// </summary>
public class GetUsersUseCase : IGetUsersUseCase
{
    private readonly IUserRepository _userRepository;

    public GetUsersUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> ExecuteAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Name = u.Name,
            Username = u.Username,
            Email = u.Email,
            Phone = u.Phone,
            Website = u.Website
        });
    }

    public async Task<UserDto?> ExecuteByIdAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Username = user.Username,
            Email = user.Email,
            Phone = user.Phone,
            Website = user.Website
        };
    }
}
