using EvoluirEducação.DTO;
using EvoluirEducação.Interfaces;
using EvoluirEducação.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoluirEducação.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {

        private readonly ITurmaRepository _turmaRepository;

        public TurmaController(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        /// <summary>
        /// Lista todas as turmas cadastradas.
        /// </summary>
        /// <returns>
        /// Retorna 200 com a lista de turmas.
        /// Em caso de erro, retorna 400.
        /// </returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_turmaRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
        /// <summary>
        /// Busca uma turma pelo ID.
        /// </summary>
        /// <param name="id">Identificador único da turma.</param>
        /// <returns>
        /// Retorna 200 com a turma encontrada.
        /// Em caso de erro, retorna 400.
        /// </returns>

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_turmaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Cadastra uma nova turma.
        /// </summary>
        /// <param name="turma">Objeto contendo os dados da turma.</param>
        /// <returns>
        /// Retorna 201 com a turma criada. Em caso de erro, retorna 400.
        /// </returns>

        [HttpPost]
        public IActionResult Cadastrar(TurmaDTO turma)
        {
            try
            {
                var novaTurma = new Turma
                {
                    Turno = turma.Turno!,
                    Capacidade = turma.Capacidade!,
                    Nome = turma.Nome!, 

                };
                _turmaRepository.Cadastrar(novaTurma);
                return StatusCode(201, novaTurma);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
        /// <summary>
        /// Atualiza os dados de uma turma existente.
        /// </summary>
        /// <param name="id">Identificador da turma.</param>
        /// <param name="turma">Objeto com os novos dados da turma.</param>
        /// <returns>
        /// Retorna 204indicando sucesso na atualização. Em caso de erro, retorna 400.
        /// </returns>

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, TurmaDTO turma)
        {
            try
            {
                var novaTurma = new Turma
                {
                    Turno = turma.Turno!,
                    Capacidade = turma.Capacidade!,
                    Nome = turma.Nome!,
                };
                _turmaRepository.Atualizar(id, novaTurma);
                return StatusCode(204, novaTurma);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Remove uma turma pelo ID.
        /// </summary>
        /// <param name="id">Identificador único da turma.</param>
        /// <returns>
        /// Retorna 204 se removida com sucesso.
        /// Em caso de erro, retorna 400.
        /// </returns>

        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _turmaRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
