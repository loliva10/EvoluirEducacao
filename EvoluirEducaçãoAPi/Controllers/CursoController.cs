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

    /// <summary>
    /// Lista todos os cursos cadastrados.
    /// </summary>
    /// <returns>
    /// Retorna 200 com a lista de cursos. Em caso de erro, retorna 400 .
    /// </returns>

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

    /// <summary>
    /// Busca um curso pelo ID.
    /// </summary>
    /// <param name="id">Identificador único do curso.</param>
    /// <returns>
    /// Retorna 200 com o curso encontrado.
    /// Em caso de erro, retorna 400.
    /// </returns>
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

    /// <summary>
    /// Cadastra um novo curso.
    /// </summary>
    /// <param name="curso">Objeto contendo os dados do curso.</param>
    /// <returns>
    /// Retorna 201 com o curso criado. Em caso de erro, retorna 400 .
    /// </returns>
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

    /// <summary>
    /// Atualiza os dados de um curso existente.
    /// </summary>
    /// <param name="id">Identificador do curso.</param>
    /// <param name="curso">Objeto com os novos dados do curso.</param>
    /// <returns>
    /// Retorna 204 indicando sucesso na atualização.
    /// Em caso de erro, retorna 400.
    /// </returns>

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

    /// Remove um curso pelo ID.
    /// </summary>
    /// <param name="id">Identificador único do curso.</param>
    /// <returns>
    /// Retorna 204 se removido com sucesso. Em caso de erro, retorna 400.
    /// </returns>
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