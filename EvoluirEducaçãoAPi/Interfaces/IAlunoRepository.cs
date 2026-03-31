using EvoluirEducação.Models;

namespace EvoluirEducação.Interfaces;

public interface IAlunoRepository
{
    List<Aluno> Listar();

    void Cadastrar(Aluno aluno);

    void Deletar(Aluno IdAluno);

    void Atualizar(Guid id, Aluno aluno);

    Aluno BuscarPorId(Guid id);


}
