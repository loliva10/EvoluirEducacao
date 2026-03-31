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

        public void Atualizar(Guid id, Turma turma)
        {
            var turmaBuscado = _context.Turmas.Find(id);

            if (turmaBuscado != null)
            {
                turmaBuscado.Turno = String.IsNullOrWhiteSpace(turma.Turno) ? turmaBuscado.Turno : turma.Turno;
                turmaBuscado.Capacidade = turma.Capacidade;
                turmaBuscado.Nome = String.IsNullOrWhiteSpace(turma.Nome) ? turmaBuscado.Nome : turma.Nome;



                _context.Turmas.Update(turmaBuscado);
                _context.SaveChanges();

            }
        }

        public Turma BuscarPorId(Guid id)
        {
            return _context.Turmas.Find(id)!;
        }

        public void Cadastrar(Turma turma)
        {
            _context.Turmas.Add(turma);
            _context.SaveChanges();
        }

        public void Deletar(Guid idTurma)
        {
            Turma turmaBuscado = _context.Turmas.Find(idTurma.ToString())!;
            if (turmaBuscado != null)
            {
                _context.Turmas.Remove(turmaBuscado);
            }
            _context.SaveChanges();
        }

        public List<Turma> Listar()
        {
            return _context.Turmas.OrderBy(con => con.Nome).ToList();
        }
    }
}
