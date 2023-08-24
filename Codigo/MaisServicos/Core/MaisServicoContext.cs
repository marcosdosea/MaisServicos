using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class MaisServicoContext : DbContext
{
    public MaisServicoContext()
    {
    }

    public MaisServicoContext(DbContextOptions<MaisServicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Areadeatuacao> Areadeatuacaos { get; set; }

    public virtual DbSet<Avaliacao> Avaliacaos { get; set; }

    public virtual DbSet<Orcamento> Orcamentos { get; set; }

    public virtual DbSet<Servico> Servicos { get; set; }

    public virtual DbSet<Servicocontratado> Servicocontratados { get; set; }

    public virtual DbSet<Solicitum> Solicita { get; set; }

    public virtual DbSet<Templatecontrato> Templatecontratos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=mydb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Areadeatuacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("areadeatuacao");

            entity.HasIndex(e => e.Nome, "idxNome");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");

            entity.HasMany(d => d.IdServicoContratados).WithMany(p => p.IdAreaDeAtuacaos)
                .UsingEntity<Dictionary<string, object>>(
                    "Areadeatuacaopossuiserviçocontratado",
                    r => r.HasOne<Servicocontratado>().WithMany()
                        .HasForeignKey("IdServicoContratado")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_AreaDeAtuação_has_ServiçoContratado_ServiçoContratado1"),
                    l => l.HasOne<Areadeatuacao>().WithMany()
                        .HasForeignKey("IdAreaDeAtuacao")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_AreaDeAtuação_has_ServiçoContratado_AreaDeAtuação1"),
                    j =>
                    {
                        j.HasKey("IdAreaDeAtuacao", "IdServicoContratado").HasName("PRIMARY");
                        j.ToTable("areadeatuacaopossuiserviçocontratado");
                        j.HasIndex(new[] { "IdAreaDeAtuacao" }, "fk_AreaDeAtuação_has_ServiçoContratado_AreaDeAtuação1_idx");
                        j.HasIndex(new[] { "IdServicoContratado" }, "fk_AreaDeAtuação_has_ServiçoContratado_ServiçoContratad_idx");
                        j.IndexerProperty<int>("IdAreaDeAtuacao").HasColumnName("idAreaDeAtuacao");
                        j.IndexerProperty<int>("IdServicoContratado").HasColumnName("idServicoContratado");
                    });
        });

        modelBuilder.Entity<Avaliacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("avaliacao");

            entity.HasIndex(e => e.IdServicoContratado, "fk_Avaliacao_ServicoContratado1_idx");

            entity.HasIndex(e => e.IdUsuario, "fk_Avaliacao_Usuario1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataAvaliacao)
                .HasColumnType("datetime")
                .HasColumnName("dataAvaliacao");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .HasColumnName("descricao");
            entity.Property(e => e.IdServicoContratado).HasColumnName("idServicoContratado");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NotaAvaliacao)
                .HasColumnType("enum('1','2','3','4','5')")
                .HasColumnName("notaAvaliacao");

            entity.HasOne(d => d.IdServicoContratadoNavigation).WithMany(p => p.Avaliacaos)
                .HasForeignKey(d => d.IdServicoContratado)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Avaliacao_ServicoContratado1");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Avaliacaos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Avaliacao_Usuario1");
        });

        modelBuilder.Entity<Orcamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orcamento");

            entity.HasIndex(e => e.IdUsuario, "fk_Orcamento_Usuario1_idx");

            entity.HasIndex(e => e.IdSolicita, "fk_Orçamento_Solicita1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .HasColumnName("descricao");
            entity.Property(e => e.IdSolicita).HasColumnName("idSolicita");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdSolicitaNavigation).WithMany(p => p.Orcamentos)
                .HasForeignKey(d => d.IdSolicita)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Orçamento_Solicita1");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Orcamentos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Orcamento_Usuario1");
        });

        modelBuilder.Entity<Servico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("servico");

            entity.HasIndex(e => e.IdAreaDeAtuacao, "fk_Serviço_AreaDeAtuação1_idx");

            entity.HasIndex(e => e.Nome, "idxNome");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .HasColumnName("descricao");
            entity.Property(e => e.IdAreaDeAtuacao).HasColumnName("idAreaDeAtuacao");
            entity.Property(e => e.Nome)
                .HasColumnType("datetime")
                .HasColumnName("nome");

            entity.HasOne(d => d.IdAreaDeAtuacaoNavigation).WithMany(p => p.Servicos)
                .HasForeignKey(d => d.IdAreaDeAtuacao)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Serviço_AreaDeAtuação1");

            entity.HasMany(d => d.IdServicoContratados).WithMany(p => p.IdServicos)
                .UsingEntity<Dictionary<string, object>>(
                    "Servicopossuiservicocontratado",
                    r => r.HasOne<Servicocontratado>().WithMany()
                        .HasForeignKey("IdServicoContratado")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_Serviço_has_ServiçoContratado_ServiçoContratado1"),
                    l => l.HasOne<Servico>().WithMany()
                        .HasForeignKey("IdServico")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_Serviço_has_ServiçoContratado_Serviço1"),
                    j =>
                    {
                        j.HasKey("IdServico", "IdServicoContratado").HasName("PRIMARY");
                        j.ToTable("servicopossuiservicocontratado");
                        j.HasIndex(new[] { "IdServico" }, "fk_Serviço_has_ServiçoContratado_Serviço1_idx");
                        j.HasIndex(new[] { "IdServicoContratado" }, "fk_Serviço_has_ServiçoContratado_ServiçoContratado1_idx");
                        j.IndexerProperty<int>("IdServico").HasColumnName("idServico");
                        j.IndexerProperty<int>("IdServicoContratado").HasColumnName("idServicoContratado");
                    });
        });

        modelBuilder.Entity<Servicocontratado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("servicocontratado");

            entity.HasIndex(e => e.IdUsuario, "fk_ServicoContratado_Usuario1_idx");

            entity.HasIndex(e => e.IdOrçamento, "fk_ServiçoContratado_Orçamento1_idx");

            entity.HasIndex(e => e.IdTemplateContrato, "fk_ServiçoContratado_TemplateContrato1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdOrçamento).HasColumnName("idOrçamento");
            entity.Property(e => e.IdTemplateContrato).HasColumnName("idTemplateContrato");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdOrçamentoNavigation).WithMany(p => p.Servicocontratados)
                .HasForeignKey(d => d.IdOrçamento)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ServiçoContratado_Orçamento1");

            entity.HasOne(d => d.IdTemplateContratoNavigation).WithMany(p => p.Servicocontratados)
                .HasForeignKey(d => d.IdTemplateContrato)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ServiçoContratado_TemplateContrato1");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Servicocontratados)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_ServicoContratado_Usuario1");
        });

        modelBuilder.Entity<Solicitum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("solicita");

            entity.HasIndex(e => e.IdUsuario, "fk_Solicita_Usuario1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataSolicitacao)
                .HasColumnType("datetime")
                .HasColumnName("dataSolicitacao");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .HasColumnName("descricao");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Solicita)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Solicita_Usuario1");
        });

        modelBuilder.Entity<Templatecontrato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("templatecontrato");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Login, "idxLogin");

            entity.HasIndex(e => e.Nome, "idxNome");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(40)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(9)
                .HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .HasMaxLength(28)
                .HasColumnName("cidade");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("cpf");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(18)
                .HasColumnName("estado");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.NumeroDaCasa).HasColumnName("numeroDaCasa");
            entity.Property(e => e.Rua)
                .HasMaxLength(50)
                .HasColumnName("rua");
            entity.Property(e => e.Senha)
                .HasMaxLength(20)
                .HasColumnName("senha");
            entity.Property(e => e.Telefone)
                .HasMaxLength(11)
                .HasColumnName("telefone");

            entity.HasMany(d => d.IdServicos).WithMany(p => p.IdUsuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "Usuariopossuiservico",
                    r => r.HasOne<Servico>().WithMany()
                        .HasForeignKey("IdServico")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_Usuario_has_Servico_Servico1"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_Usuario_has_Servico_Usuario1"),
                    j =>
                    {
                        j.HasKey("IdUsuario", "IdServico").HasName("PRIMARY");
                        j.ToTable("usuariopossuiservico");
                        j.HasIndex(new[] { "IdServico" }, "fk_Usuario_has_Servico_Servico1_idx");
                        j.HasIndex(new[] { "IdUsuario" }, "fk_Usuario_has_Servico_Usuario1_idx");
                        j.IndexerProperty<int>("IdUsuario").HasColumnName("idUsuario");
                        j.IndexerProperty<int>("IdServico").HasColumnName("idServico");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
