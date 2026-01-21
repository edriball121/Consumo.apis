using consumo.apis.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace consumo.apis.Api.Controllers;

/// <summary>
/// Controlador para gestionar operaciones de Comentarios
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly IGetCommentsUseCase _getCommentsUseCase;
    private readonly ILogger<CommentsController> _logger;

    public CommentsController(IGetCommentsUseCase getCommentsUseCase, ILogger<CommentsController> logger)
    {
        _getCommentsUseCase = getCommentsUseCase;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene todos los comentarios de un post
    /// </summary>
    /// <param name="postId">ID del post</param>
    /// <returns>Lista de comentarios del post</returns>
    [HttpGet("post/{postId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<object>>> GetCommentsByPostId(int postId)
    {
        try
        {
            _logger.LogInformation("Obteniendo comentarios del post: {PostId}", postId);
            var comments = await _getCommentsUseCase.ExecuteByPostIdAsync(postId);
            return Ok(comments);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener comentarios del post: {PostId}", postId);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "Error al obtener los comentarios", error = ex.Message });
        }
    }

    /// <summary>
    /// Obtiene un comentario por su ID
    /// </summary>
    /// <param name="id">ID del comentario</param>
    /// <returns>El comentario solicitado</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<object>> GetCommentById(int id)
    {
        try
        {
            _logger.LogInformation("Obteniendo comentario con ID: {CommentId}", id);
            var comment = await _getCommentsUseCase.ExecuteByIdAsync(id);
            
            if (comment == null)
                return NotFound(new { message = $"Comentario con ID {id} no encontrado" });

            return Ok(comment);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el comentario con ID: {CommentId}", id);
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "Error al obtener el comentario", error = ex.Message });
        }
    }
}
