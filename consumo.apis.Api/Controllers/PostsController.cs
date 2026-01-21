using consumo.apis.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace consumo.apis.Api.Controllers;

/// <summary>
/// Controlador para gestionar operaciones de Posts
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IGetPostsUseCase _getPostsUseCase;
    private readonly ILogger<PostsController> _logger;

    public PostsController(IGetPostsUseCase getPostsUseCase, ILogger<PostsController> logger)
    {
        _getPostsUseCase = getPostsUseCase;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene todos los posts
    /// </summary>
    /// <returns>Lista de posts</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<object>>> GetAllPosts()
    {
        try
        {
            _logger.LogInformation("Obteniendo todos los posts");
            var posts = await _getPostsUseCase.ExecuteAsync();
            return Ok(posts);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todos los posts");
            return StatusCode(StatusCodes.Status500InternalServerError, 
                new { message = "Error al obtener los posts", error = ex.Message });
        }
    }

    /// <summary>
    /// Obtiene un post por su ID
    /// </summary>
    /// <param name="id">ID del post</param>
    /// <returns>El post solicitado</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<object>> GetPostById(int id)
    {
        try
        {
            _logger.LogInformation("Obteniendo post con ID: {PostId}", id);
            var post = await _getPostsUseCase.ExecuteByIdAsync(id);
            
            if (post == null)
                return NotFound(new { message = $"Post con ID {id} no encontrado" });

            return Ok(post);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el post con ID: {PostId}", id);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "Error al obtener el post", error = ex.Message });
        }
    }

    /// <summary>
    /// Obtiene todos los posts de un usuario
    /// </summary>
    /// <param name="userId">ID del usuario</param>
    /// <returns>Lista de posts del usuario</returns>
    [HttpGet("user/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<object>>> GetPostsByUserId(int userId)
    {
        try
        {
            _logger.LogInformation("Obteniendo posts del usuario: {UserId}", userId);
            var posts = await _getPostsUseCase.ExecuteByUserIdAsync(userId);
            return Ok(posts);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener posts del usuario: {UserId}", userId);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "Error al obtener los posts del usuario", error = ex.Message });
        }
    }
}
