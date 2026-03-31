using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EvoluirEducação.Models;

[Table("Turma")]
public partial class Turma
{
    [Key]
    public Guid IdTurma { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Turno { get; set; } = null!;

    public int Capacidade { get; set; }

    public Guid? IdCurso { get; set; }

    [InverseProperty("IdTurmaNavigation")]
    [JsonIgnore]
    public virtual ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

    [ForeignKey("IdCurso")]
    [InverseProperty("Turmas")]
    [JsonIgnore]
    public virtual Curso? IdCursoNavigation { get; set; }
}
