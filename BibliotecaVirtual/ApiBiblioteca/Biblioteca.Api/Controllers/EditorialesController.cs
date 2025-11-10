using Biblioteca.Businesss.Services;
using Biblioteca.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialesController(IEditorialService editorialService, ILogger<EditorialesController> logger) : ControllerBase
    {
        private readonly IEditorialService _editorialService = editorialService;
        private readonly ILogger<EditorialesController> _logger = logger;

        [HttpPost]
        public async Task<ActionResult<EditorialResponseDto>> CreateEditorial([FromBody] CreateEditorialDto editorialCreateDto)
        {
            try
            {
                _logger.LogInformation("Creando la nueva editorial: {Nombre}", editorialCreateDto.Nombre);
                var editorial = await _editorialService.CrearEditorialAsync(editorialCreateDto);
                return CreatedAtAction(nameof(GetEditorialById), new { id = editorial.Id }, editorial);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear editorial");
                return StatusCode(500, new { message = "Error interno del servidor" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EditorialResponseDto>> GetEditorialById(int id)
        {
            try
            {
                var editorial = await _editorialService.ObtenerEditorialPorIdAsync(id);
                return Ok(editorial);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EditorialResponseDto>>> GetAllEditorials()
        {
            var editoriales = await _editorialService.ObtenerTodasLasEditorialesAsync();
            return Ok(editoriales);
        }
    }
}
