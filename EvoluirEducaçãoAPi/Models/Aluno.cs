using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EvoluirEducação.Models;

[Table("Aluno")]
public partial class Aluno
{
    [Key]
    public Guid IdAluno { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string Matricula { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string Foto { get; set; } = null!;

    public int Contato { get; set; }

    public Guid? IdTurma { get; set; }

    [ForeignKey("IdTurma")]
    [InverseProperty("Alunos")]
    [JsonIgnore]
    public virtual Turma? IdTurmaNavigation { get; set; }
}
