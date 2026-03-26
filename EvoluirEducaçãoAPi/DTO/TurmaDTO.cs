using System.ComponentModel.DataAnnotations;

namespace EvoluirEducação.DTO
{
    public class TurmaDTO
    {
        [Required(ErrorMessage = "O Turno da Turma é obrigatorio")]
        public string? Turno { get; set; }

        [Required(ErrorMessage = "O periodo da Turma é obrigatorio")]
        public string? Periodo { get; set; }

        [Required(ErrorMessage = "A Capacidade da turma é obrigatorio")]
        public string? Capacidade { get; set; }

        [Required(ErrorMessage = "O Nome da Turma é obrigatorio")]
        public string? Nome { get; set; }

    }
}
