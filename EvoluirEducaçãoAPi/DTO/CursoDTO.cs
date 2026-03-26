using System.ComponentModel.DataAnnotations;

namespace EvoluirEducação.DTO
{
    public class CursoDTO
    {
        [Required(ErrorMessage = "A duracao do curso é obrigatorio")]
        public string? Duracao { get; set; }

        [Required(ErrorMessage = "A carga horaria do curso é obrigatorio")]
        public string? CargaHoraria { get; set; }

        [Required(ErrorMessage = "O norme do Curso é obrigatorio")]
        public string? Nome { get; set; }

    }
}
