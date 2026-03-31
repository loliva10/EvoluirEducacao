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
        /// <summary>
        /// Cadastra um novo curso no banco de dados.
        /// </summary>
        /// <param name="curso">Objeto a ser cadastrado.</param>

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

        /// <summary>
        /// Busca um curso pelo seu ID.
        /// </summary>
        /// <param name="id">ID do curso a ser buscado.</param>
        /// <returns>Objeto encontrado ou null se não existir.</returns>
        public Curso BuscarPorId(Guid id)
        {
            return _context.Cursos.Find(id)!;
        }

        /// <summary>
        /// Cadastra um novo curso no banco de dados.
        /// </summary>
        /// <param name="curso">Objeto a ser cadastrado.</param>
        public void Cadastrar(Curso curso)
        {
            _context.Cursos.Add(curso);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deleta um curso existente.
        /// </summary>
        /// <param name="idCurso">Objeto a ser deletado.</param>
        public void Deletar(Curso idCurso)
        {

            _context.Cursos.Remove(idCurso);
            _context.SaveChanges();

        }

        /// <summary>
        /// Lista todos os cursos cadastrados, ordenados pelo nome.
        /// </summary>
        /// <returns>Lista de objetos.</returns>
        public List<Curso> Listar()
        {
            return _context.Cursos.OrderBy(con => con.Nome).ToList();
        }
    }
}
