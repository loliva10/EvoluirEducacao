using EvoluirEducação.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EvoluirEducação.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {

        private readonly EvoluirEducaçãoContext _Context;

        public TurmaRepository(EvoluirEducaçãoContext context)
        {
            _Context = context;
        }

        public void Atualizar(Guid id, Turma turma)
        {
            var turmaBuscado = _context.Turmas.Find(id);

            if (turmaBuscado != null)
            {
                turmaBuscado.Turno = String.IsNullOrWhiteSpace(turma.Turno) ? turmaBuscado.Turno : turma.Turno;
                turmaBuscado.Periodo = String.IsNullOrWhiteSpace(turma.Periodo) ? turmaBuscado.Periodo : turma.Periodo;
                turmaBuscado.Capacidade = String.IsNullOrWhiteSpace(turma.Capacidade) ? turmaBuscado.Capacidade : turma.Capacidade;
                turmaBuscado.Nome = String.IsNullOrWhiteSpace(turma.Nome) ? turmaBuscado.Nome : turma.Nome;



                _context.Turmas.Update(turmaBuscado);
                _context.SaveChanges();

            }

        public Turma BuscarPorId(Guid id)
        {
            return _context.Turmas.Find(id)!;
        }

        public void Cadastrar(Turma Turma)
        {
            _context.Turmas.Add(contato);
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
