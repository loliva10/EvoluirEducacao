using EvoluirEducação.DTO;
using EvoluirEducação.Interfaces;
using EvoluirEducação.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoluirEducação.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlunoController : ControllerBase
{

    private readonly IAlunoRepository _AlunoRepository;

    public AlunoController(IAlunoRepository alunoRepository)
    {
        _AlunoRepository = alunoRepository;
    }
    /// <summary>
    /// Lista todos os alunos cadastrados.
    /// </summary>
    /// <returns>
    /// Retorna a lista de alunos. Em caso de erro, retorna status 400 com a mensagem de erro.
    /// </returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_AlunoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Cadastra um novo aluno.
    /// </summary>
    /// <param name="aluno">Objeto contendo os dados do aluno, incluindo nome, contato, matrícula e foto.</param>
    /// <returns>
    /// Retorna o aluno cadastrado.
    /// </returns>
    [HttpPost]
    public IActionResult Cadastrar([FromForm] AlunoDTO aluno)
    {
        if (String.IsNullOrEmpty(aluno.Nome))
        {
            return BadRequest("O nome obrigatórios");
        }
        Aluno novoAluno = new Aluno();
        if (aluno.Foto != null && aluno.Foto.Length > 0)
        {
            var extensao = Path.GetExtension(aluno.Foto.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            if (!Directory.Exists(caminhoPasta))
            {
                Directory.CreateDirectory(caminhoPasta);
            }

            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);
            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                aluno.Foto.CopyToAsync(stream);
            }

            novoAluno.Foto = nomeArquivo;
        }
        novoAluno.Nome = aluno.Nome;
        novoAluno.Contato = aluno.Contato;
        novoAluno.Matricula = aluno.Matricula!;
        try
        {
            _AlunoRepository.Cadastrar(novoAluno);
            return Ok(novoAluno);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Remove um aluno pelo ID.
    /// </summary>
    /// <param name="id">Identificador único do aluno.</param>
    /// <returns>
    /// Retorna 204 se removido com sucesso.
    /// Retorna 404 se o aluno não for encontrado.
    /// Retorna 400 em caso de erro.
    /// </returns>

    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id )
    {
        var AlunoBuscado = _AlunoRepository.BuscarPorId(id);
        if (AlunoBuscado == null)
        {
            return NotFound("Contato não encontrado");
        }
        var PastaRelativa = "wwwroot/imagens";
        var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), PastaRelativa);

        if (!string.IsNullOrEmpty(AlunoBuscado.Foto))
        {
            var caminho = Path.Combine(caminhoPasta, AlunoBuscado.Foto);
            if (System.IO.File.Exists(caminho))
            {
                System.IO.File.Delete(caminho);
            }
        }
        try
        {
            _AlunoRepository.Deletar(AlunoBuscado);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Atualiza os dados de um aluno existente.
    /// </summary>
    /// <param name="id">Identificador do aluno.</param>
    /// <param name="aluno">Objeto com os novos dados do aluno.</param>
    /// <returns>
    /// Retorna 200 com o aluno atualizado.
    /// Retorna 404 se o aluno não for encontrado.
    /// Retorna 400 em caso de erro.
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(Guid id, [FromForm] AlunoDTO aluno)
    {
        var alunoBuscado = _AlunoRepository.BuscarPorId(id);
        if (alunoBuscado == null)
        {
            return NotFound("aluno não encontrado");
        }
        if (aluno.Foto != null && aluno.Foto.Length > 0)
        {
            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);
            if (!String.IsNullOrEmpty(alunoBuscado.Foto))
            {
                var caminhoAntigo = Path.Combine(caminhoPasta, alunoBuscado.Foto);
                if (System.IO.File.Exists(caminhoAntigo))
                {
                    System.IO.File.Delete(caminhoAntigo);
                }
            }

            var extensao = Path.GetExtension(aluno.Foto.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            if (!Directory.Exists(caminhoPasta))
            {
                Directory.CreateDirectory(caminhoPasta);
            }
            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);
            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await aluno.Foto.CopyToAsync(stream);
            }
            alunoBuscado.Foto = nomeArquivo;
        }
        try
        {
            _AlunoRepository.Atualizar(id, alunoBuscado);
            return Ok(alunoBuscado);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Busca um aluno pelo ID.
    /// </summary>
    /// <param name="id">Identificador único do aluno.</param>
    /// <returns>
    /// Retorna 200 com o aluno encontrado.
    /// Retorna 400 em caso de erro.
    /// </returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_AlunoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
