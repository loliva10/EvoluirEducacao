using EvoluirEducação.BdContextEvoluir;
using EvoluirEducação.Interfaces;
using EvoluirEducação.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoluirEducação.Repositories
{
    public class CursoRepository : ICursoRepository
    {

        private readonly EvoluirContext _context;

        public CursoRepository(EvoluirContext context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, Curso curso)
        {
            var CursoBuscado = _context.Cursos.Find(id);

            if (CursoBuscado != null)
            {
                CursoBuscado.Duracao = curso.Duracao;
                CursoBuscado.CargaHoraria = curso.CargaHoraria;
                CursoBuscado.Nome = String.IsNullOrWhiteSpace(curso.Nome) ? CursoBuscado.Nome : curso.Nome;

                _context.Cursos.Update(CursoBuscado);
                _context.SaveChanges();

            }
        }

        public Curso BuscarPorId(Guid id)
        {
            return _context.Cursos.Find(id)!;
        }

        public void Cadastrar(Curso curso)
        {
            _context.Cursos.Add(curso);
            _context.SaveChanges();
        }

        public void Deletar(Curso idCurso)
        {

            _context.Cursos.Remove(idCurso);
            _context.SaveChanges();

        }

        public List<Curso> Listar()
        {
            return _context.Cursos.OrderBy(con => con.Nome).ToList();
        }
    }
}
