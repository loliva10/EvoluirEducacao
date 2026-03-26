namespace EvoluirEducação.Interfaces;

public interface ITurmaRepository
{
    List<Turma> Listar();

    void Cadastrar(Turma Turma);

    void Deletar(Guid idTurma);

    void Atualizar(Guid id, Turma turma);

    Turma BuscarPorId(Guid id);
}
