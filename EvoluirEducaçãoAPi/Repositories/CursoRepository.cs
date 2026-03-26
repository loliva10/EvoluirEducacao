using EvoluirEducação.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EvoluirEducação.Repositories
{
    public class CursoRepository : ICursoRepository
    {

        private readonly EvoluirEducaçãoContext _Context;

        public CursoRepository(EvoluirEducaçãoContext context)
        {
            _Context = context;
        }
        public void Atualizar(Guid id, Curso curso)
        {
            var CursoBuscado = _context.Cursos.Find(id);

            if (CursoBuscado != null)
            {
                CursoBuscado.Duracao = String.IsNullOrWhiteSpace(curso.Duracao) ? CursoBuscado.Duracao : curso.Duracao;
                CursoBuscado.CargaHoraria = String.IsNullOrWhiteSpace(curso.CargaHoraria) ? CursoBuscado.CargaHoraria : curso.CargaHoraria;
                CursoBuscado.Nome = String.IsNullOrWhiteSpace(curso.Nome) ? CursoBuscado.Nome : curso.Nome;

                _context.Contatos.Update(CursoBuscado);
                _context.SaveChanges();

            }
        }

        public Curso BuscarPorId(Guid id)
        {
            return _context.Cursos.Find(id)!;
        }

        public void Cadastrar(Curso curso)
        {
            _context.Alunos.Add(curso);
            _context.SaveChanges();
        }

        public void Deletar(Guid idCurso)
        {
            Curso cursoBuscado = _context.Alunos.Find(idCurso.ToString())!;
            if (cursoBuscado != null)
            {
                _context.Cursos.Remove(cursoBuscado);
            }
            _context.SaveChanges();

        }

        public List<Curso> Listar()
        {
            return _context.Cursos.OrderBy(con => con.Nome).ToList();
        }
    }
}
