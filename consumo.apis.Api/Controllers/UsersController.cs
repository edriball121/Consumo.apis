using consumo.apis.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace consumo.apis.Api.Controllers;

/// <summary>
/// Controlador para gestionar operaciones de Usuarios
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IGetUsersUseCase _getUsersUseCase;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IGetUsersUseCase getUsersUseCase, ILogger<UsersController> logger)
    {
        _getUsersUseCase = getUsersUseCase;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene todos los usuarios
    /// </summary>
    /// <returns>Lista de usuarios</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<object>>> GetAllUsers()
    {
        try
        {
            _logger.LogInformation("Obteniendo todos los usuarios");
            var users = await _getUsersUseCase.ExecuteAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todos los usuarios");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "Error al obtener los usuarios", error = ex.Message });
        }
    }

    /// <summary>
    /// Obtiene un usuario por su ID
    /// </summary>
    /// <param name="id">ID del usuario</param>
    /// <returns>El usuario solicitado</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<object>> GetUserById(int id)
    {
        try
        {
            _logger.LogInformation("Obteniendo usuario con ID: {UserId}", id);
            var user = await _getUsersUseCase.ExecuteByIdAsync(id);
            
            if (user == null)
                return NotFound(new { message = $"Usuario con ID {id} no encontrado" });

            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el usuario con ID: {UserId}", id);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "Error al obtener el usuario", error = ex.Message });
        }
    }
}
