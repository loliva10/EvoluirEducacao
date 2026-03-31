using System;
using System.Collections.Generic;
using EvoluirEducação.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoluirEducação.BdContextEvoluir;

public partial class EvoluirContext : DbContext
{
    public EvoluirContext()
    {
    }

    public EvoluirContext(DbContextOptions<EvoluirContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Turma> Turmas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EvoluirEducacao;Trusted_Connection=True;TrustServerCertificate =True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.IdAluno).HasName("PK__Aluno__8092FCB3E2381E55");

            entity.Property(e => e.IdAluno).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdTurmaNavigation).WithMany(p => p.Alunos).HasConstraintName("FK__Aluno__IdTurma__6477ECF3");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__Curso__085F27D6A0F95B16");

            entity.Property(e => e.IdCurso).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Turma>(entity =>
        {
            entity.HasKey(e => e.IdTurma).HasName("PK__Turma__C1ECFFC92F1ACE2F");

            entity.Property(e => e.IdTurma).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Turmas).HasConstraintName("FK__Turma__IdCurso__60A75C0F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
