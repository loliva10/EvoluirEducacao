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

        public Aluno BuscarPorId(Guid id)
        {
            return _context.Alunos.Find(id)!;
        }

        public void Cadastrar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        public void Deletar(Aluno aluno)
        {
           // Aluno AlunoBuscado = _context.Alunos.Find(IdAluno.ToString())!;
            //if (AlunoBuscado != null)
           // {
            _context.Alunos.Remove(aluno);
           // }
            _context.SaveChanges();
        }

        public List<Aluno> Listar()
        {
            return _context.Alunos.OrderBy(con => con.Nome).ToList();
        }
    }
}
