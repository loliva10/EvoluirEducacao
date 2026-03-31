using System.ComponentModel.DataAnnotations;

namespace EvoluirEducação.DTO
{
    public class TurmaDTO
    {
        [Required(ErrorMessage = "O Turno da Turma é obrigatorio")]
        public string? Turno { get; set; }

        [Required(ErrorMessage = "A Capacidade da turma é obrigatorio")]
        public int Capacidade { get; set; }

        [Required(ErrorMessage = "O Nome da Turma é obrigatorio")]
        public string? Nome { get; set; }

    }
}
