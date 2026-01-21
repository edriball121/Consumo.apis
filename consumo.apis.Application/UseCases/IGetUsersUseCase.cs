using consumo.apis.Application.DTOs;

namespace consumo.apis.Application.UseCases;

/// <summary>
/// Caso de uso para obtener usuarios
/// </summary>
public interface IGetUsersUseCase
{
    Task<IEnumerable<UserDto>> ExecuteAsync();
    Task<UserDto?> ExecuteByIdAsync(int id);
}
