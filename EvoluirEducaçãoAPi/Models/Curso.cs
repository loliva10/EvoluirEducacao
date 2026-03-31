using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EvoluirEducação.Models;

[Table("Curso")]
public partial class Curso
{
    [Key]
    public Guid IdCurso { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    public int Duracao { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Periodo { get; set; } = null!;

    public int CargaHoraria { get; set; }

    [InverseProperty("IdCursoNavigation")]
    [JsonIgnore]
    public virtual ICollection<Turma> Turmas { get; set; } = new List<Turma>();
}
