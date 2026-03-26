namespace EvoluirEducação.Interfaces;

public interface IAlunoRepository
{
    List<Aluno> Listar();

    void Cadastrar(Aluno aluno);

    void Deletar(Guid IdAluno);

    void Atualizar(Guid id, Aluno aluno);

    Aluno BuscarPorId(Guid id);


}
