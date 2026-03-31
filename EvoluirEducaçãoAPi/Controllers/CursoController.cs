using EvoluirEducação.DTO;
using EvoluirEducação.Interfaces;
using EvoluirEducação.Models;
using EvoluirEducação.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoluirEducação.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CursoController : ControllerBase
{
    private readonly ICursoRepository _cursoRepository;

    public CursoController(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_cursoRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_cursoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPost]
    public IActionResult Cadastrar(CursoDTO curso)
    {
        try
        {
            var novoCurso = new Curso
            {
                Periodo = curso.Periodo!,
                CargaHoraria = curso.CargaHoraria!,
                Nome = curso.Nome!,
                Duracao = curso.Duracao!,
            };
            _cursoRepository.Cadastrar(novoCurso);
            return StatusCode(201, novoCurso);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, CursoDTO curso)
    {
        try
        {
            var tipoContatoAtualizado = new Curso
            {
                Periodo = curso.Periodo!,
                CargaHoraria = curso.CargaHoraria!,
                Nome = curso.Nome!,
                Duracao = curso.Duracao!,
            };
            _cursoRepository.Atualizar(id, tipoContatoAtualizado);
            return StatusCode(204, tipoContatoAtualizado);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            var curso = _cursoRepository.BuscarPorId(id);
            _cursoRepository.Deletar(curso);
            return StatusCode(204);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

}