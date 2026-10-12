using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using DevForge.Application.Interfaces;
using DevForge.Domain.Entities;
using DevForge.Application.Features.RetosDev.DTOs;

namespace DevForge.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RetosDevController : ControllerBase
{
    private readonly IRetoDevRepository _repository;
    private readonly IValidator<CreateRetoDevRequestDto> _createValidator;
    private readonly IValidator<UpdateRetoDevRequestDto> _updateValidator;

    public RetosDevController(
        IRetoDevRepository repository,
        IValidator<CreateRetoDevRequestDto> createValidator,
        IValidator<UpdateRetoDevRequestDto> updateValidator)
    {
        _repository = repository;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpGet]
    public async Task<IActionResult> GetRetos()
    {
        var retos = await _repository.GetAllAsync();
        var response = retos.Select(r => new RetoDevResponseDto
        {
            Id = r.Id,
            Titulo = r.Titulo,
            Descripcion = r.Descripcion
        });

        return Ok(response);
    }

    // GET: api/retosdev/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRetoById(int id)
    {
        var reto = await _repository.GetByIdAsync(id);
        if (reto == null)
        {
            return NotFound(new { mensaje = $"El reto con ID {id} no fue encontrado." });
        }

        var response = new RetoDevResponseDto
        {
            Id = reto.Id,
            Titulo = reto.Titulo,
            Descripcion = reto.Descripcion
        };

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CrearReto([FromBody] CreateRetoDevRequestDto request)
    {
        var validationResult = await _createValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var nuevoReto = new RetoDev
        {
            Titulo = request.Titulo,
            Descripcion = request.Descripcion
        };

        var retoCreado = await _repository.AddAsync(nuevoReto);
        
        var response = new RetoDevResponseDto
        {
            Id = retoCreado.Id,
            Titulo = retoCreado.Titulo,
            Descripcion = retoCreado.Descripcion
        };

        return CreatedAtAction(nameof(GetRetoById), new { id = response.Id }, response);
    }

    // PUT: api/retosdev/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarReto(int id, [FromBody] UpdateRetoDevRequestDto request)
    {
        var validationResult = await _updateValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var retoExistente = await _repository.GetByIdAsync(id);
        if (retoExistente == null)
        {
            return NotFound(new { mensaje = $"El reto con ID {id} no fue encontrado para actualizar." });
        }

        retoExistente.Titulo = request.Titulo;
        retoExistente.Descripcion = request.Descripcion;

        await _repository.UpdateAsync(retoExistente);

        return NoContent(); // HTTP 204: Actualización exitosa sin contenido de retorno
    }

    // DELETE: api/retosdev/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarReto(int id)
    {
        var retoExistente = await _repository.GetByIdAsync(id);
        if (retoExistente == null)
        {
            return NotFound(new { mensaje = $"El reto con ID {id} no fue encontrado para eliminar." });
        }

        await _repository.DeleteAsync(retoExistente);

        return NoContent(); // HTTP 204: Eliminación exitosa
    }
}