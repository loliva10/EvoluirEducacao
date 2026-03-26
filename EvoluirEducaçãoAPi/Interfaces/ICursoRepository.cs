namespace EvoluirEducação.Interfaces;

public interface ICursoRepository
{
    List<Curso> Listar();

    void Cadastrar(Curso curso);

    void Deletar(Guid idCurso);

    void Atualizar(Guid id, Curso curso);

    Curso BuscarPorId(Guid id);

}
