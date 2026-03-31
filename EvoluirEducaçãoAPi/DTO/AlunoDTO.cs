using System.ComponentModel.DataAnnotations;

namespace EvoluirEducação.DTO
{
    public class AlunoDTO
    {

        [Required(ErrorMessage = "O nome do Aluno é obrigatorio")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A matricula do Aluno é obrigatorio")]
        public string? Matricula { get; set; }

        [Required(ErrorMessage = "A foto do Aluno é obrigatorio")]
        public IFormFile? Foto { get; set; }
        [Required(ErrorMessage = "A foto do Aluno é obrigatorio")]
        public Guid? idTurma { get; set; }

        public Guid? idCurso { get; set; }

        [Required(ErrorMessage = "O contato do Aluno é obrigatorio")]
        public int Contato { get; set; }
    }
}
