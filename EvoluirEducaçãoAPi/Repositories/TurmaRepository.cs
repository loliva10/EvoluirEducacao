using EvoluirEducação.BdContextEvoluir;
using EvoluirEducação.Interfaces;
using EvoluirEducação.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoluirEducação.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {

        private readonly EvoluirContext _context;

        public TurmaRepository(EvoluirContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Atualiza uma turma existente com base no seu ID.
        /// </summary>
        /// <param name="id">ID da turma a ser atualizada.</param>
        /// <param name="turma">Objeto contendo os dados atualizados.</param>

        public void Atualizar(Guid id, Turma turma)
        {
            var turmaBuscado = _context.Turmas.Find(id);

            if (turmaBuscado != null)
            {
                turmaBuscado.Turno = String.IsNullOrWhiteSpace(turma.Turno) ? turmaBuscado.Turno : turma.Turno;
                turmaBuscado.Capacidade = turma.Capacidade;
                turmaBuscado.Nome = String.IsNullOrWhiteSpace(turma.Nome) ? turmaBuscado.Nome : turma.Nome;
                turmaBuscado.IdCurso = turma.IdCurso;



                _context.Turmas.Update(turmaBuscado);
                _context.SaveChanges();

            }
        }

        /// <summary>
        /// Busca uma turma pelo seu ID.
        /// </summary>
        /// <param name="id">ID da turma a ser buscada.</param>
        /// <returns>Objeto encontrado ou null se não existir.</returns>

        public Turma BuscarPorId(Guid id)
        {
            return _context.Turmas.Find(id)!;
        }

        /// <summary>
        /// Cadastra uma nova turma no banco de dados.
        /// </summary>
        /// <param name="turma">Objeto a ser cadastrado.</param>
        public void Cadastrar(Turma turma)
        {
            _context.Turmas.Add(turma);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deleta uma turma existente pelo seu ID.
        /// </summary>
        /// <param name="idTurma">ID da turma a ser deletada.</param>

        public void Deletar(Guid idTurma)
        {
            Turma turmaBuscado = _context.Turmas.Find(idTurma)!;
            if (turmaBuscado != null)
            {
                _context.Turmas.Remove(turmaBuscado);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Lista todas as turmas cadastradas, ordenadas pelo nome.
        /// </summary>
        /// <returns>Lista de objetos.</returns>
        public List<Turma> Listar()
        {
            return _context.Turmas.OrderBy(con => con.Nome).ToList();
        }
    }
}
