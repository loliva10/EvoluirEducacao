using EvoluirEducação.BdContextEvoluir;
using EvoluirEducação.Interfaces;
using EvoluirEducação.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoluirEducação.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly EvoluirContext _context;

        public AlunoRepository(EvoluirContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Atualiza os dados de um aluno existente no banco.
        /// Campos nulos ou vazios não sobrescrevem os valores existentes.
        /// </summary>
        /// <param name="id">ID do aluno a ser atualizado.</param>
        /// <param name="aluno">Objeto <see cref="Aluno"/> contendo os novos dados.</param>
        public void Atualizar(Guid id, Aluno aluno)
        {
            var alunoBuscado = _context.Alunos.Find(id);

            if (alunoBuscado != null)
            {
                alunoBuscado.Contato = aluno.Contato;
                alunoBuscado.Foto = String.IsNullOrWhiteSpace(aluno.Foto) ? alunoBuscado.Foto : aluno.Foto;
                alunoBuscado.Nome = String.IsNullOrWhiteSpace(aluno.Nome) ? alunoBuscado.Nome : aluno.Nome;
                alunoBuscado.Matricula = String.IsNullOrWhiteSpace(aluno.Matricula) ? alunoBuscado.Matricula : aluno.Matricula;


                _context.Alunos.Update(alunoBuscado);
                _context.SaveChanges();

            }
        }

        /// <summary>
        /// Busca um aluno pelo seu ID.
        /// </summary>
        /// <param name="id">ID do aluno a ser buscado.</param>
        /// <returns>O <see cref="Aluno"/> correspondente ao ID informado.</returns>

        public Aluno BuscarPorId(Guid id)
        {
            return _context.Alunos.Find(id)!;
        }

        /// <summary>
        /// Cadastra um novo aluno no banco de dados.
        /// </summary>
        /// <param name="aluno">Objeto <see cref="Aluno"/> a ser adicionado.</param>
        public void Cadastrar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        /// <summary>
        /// Remove um aluno do banco de dados.
        /// </summary>
        /// <param name="aluno">Objeto <see cref="Aluno"/> a ser removido.</param>

        public void Deletar(Aluno aluno)
        {
           // Aluno AlunoBuscado = _context.Alunos.Find(IdAluno.ToString())!;
            //if (AlunoBuscado != null)
           // {
            _context.Alunos.Remove(aluno);
           // }
            _context.SaveChanges();
        }
        /// <summary>
        /// Retorna todos os alunos cadastrados, ordenados pelo nome.
        /// </summary>
        /// <returns>Lista de <see cref="Aluno"/> ordenada pelo nome.</returns>
        public List<Aluno> Listar()
        {
            return _context.Alunos.OrderBy(con => con.Nome).ToList();
        }
    }
}
