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
