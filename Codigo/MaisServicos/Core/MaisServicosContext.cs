using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Core;

public partial class MaisServicosContext : DbContext
{
    public MaisServicosContext()
    {
    }

    public MaisServicosContext(DbContextOptions<MaisServicosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Areadeatuacao> Areadeatuacaos { get; set; }

    public virtual DbSet<Avaliacao> Avaliacaos { get; set; }

    public virtual DbSet<Orcamento> Orcamentos { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Servico> Servicos { get; set; }

    public virtual DbSet<Servicocontratado> Servicocontratados { get; set; }

    public virtual DbSet<Solicitarorcamento> Solicitarorcamentos { get; set; }

    public virtual DbSet<Templatecontrato> Templatecontratos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            /*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                    => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=V!tor2154;database=MaisServicos");*/
        }
    } 


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Areadeatuacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("areadeatuacao");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nome, "idxNome");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Avaliacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("avaliacao");

            entity.HasIndex(e => e.IdPessoa, "fk_Avaliacao_Pessoa1_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.Descricao)
                .HasMaxLength(1000)
                .HasColumnName("descricao");
            entity.Property(e => e.IdPessoa)
                .HasColumnType("int(11)")
                .HasColumnName("idPessoa");
            entity.Property(e => e.Nota)
                .HasColumnType("enum('1','2','3','4','5')")
                .HasColumnName("nota");

            entity.HasOne(d => d.IdPessoaNavigation).WithMany(p => p.Avaliacaos)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Avaliacao_Pessoa1");
        });

        modelBuilder.Entity<Orcamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orcamento");

            entity.HasIndex(e => e.IdSolicita, "fk_Orcamento_Solicita1_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.Descricao)
                .HasMaxLength(1000)
                .HasColumnName("descricao");
            entity.Property(e => e.IdSolicita)
                .HasColumnType("int(11)")
                .HasColumnName("idSolicita");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdSolicitaNavigation).WithMany(p => p.Orcamentos)
                .HasForeignKey(d => d.IdSolicita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Orcamento_Solicita1");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pessoa");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nome, "idxNome");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Bairro)
                .HasMaxLength(50)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
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
                .HasMaxLength(2)
                .HasColumnName("estado");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");
            entity.Property(e => e.Rua)
                .HasMaxLength(50)
                .HasColumnName("rua");
            entity.Property(e => e.Telefone)
                .HasMaxLength(11)
                .HasColumnName("telefone");
            entity.Property(e => e.TipoPessoa)
                .HasDefaultValueSql("'cliente'")
                .HasColumnType("enum('cliente','prestador','admin')")
                .HasColumnName("tipoPessoa");
        });

        modelBuilder.Entity<Servico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("servico");

            entity.HasIndex(e => e.IdAreaDeAtuacao, "fk_Servico_AreaDeAtuacao1_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nome, "idxNome");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(1000)
                .HasColumnName("descricao");
            entity.Property(e => e.IdAreaDeAtuacao)
                .HasColumnType("int(11)")
                .HasColumnName("idAreaDeAtuacao");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdAreaDeAtuacaoNavigation).WithMany(p => p.Servicos)
                .HasForeignKey(d => d.IdAreaDeAtuacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Servico_AreaDeAtuacao1");

            entity.HasMany(d => d.Ids).WithMany(p => p.IdServicos)
                .UsingEntity<Dictionary<string, object>>(
                    "Servicoservicocontratado",
                    r => r.HasOne<Servicocontratado>().WithMany()
                        .HasForeignKey("IdServicoContratado", "IdOrcamentoServicoContratado")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Servico_has_ServicoContratado_ServicoContratado1"),
                    l => l.HasOne<Servico>().WithMany()
                        .HasForeignKey("IdServico")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Servico_has_ServicoContratado_Servico1"),
                    j =>
                    {
                        j.HasKey("IdServico", "IdServicoContratado", "IdOrcamentoServicoContratado").HasName("PRIMARY");
                        j.ToTable("servicoservicocontratado");
                        j.HasIndex(new[] { "IdServico" }, "fk_Servico_has_ServicoContratado_Servico1_idx");
                        j.HasIndex(new[] { "IdServicoContratado", "IdOrcamentoServicoContratado" }, "fk_Servico_has_ServicoContratado_ServicoContratado1_idx");
                        j.IndexerProperty<int>("IdServico")
                            .HasColumnType("int(11)")
                            .HasColumnName("idServico");
                        j.IndexerProperty<int>("IdServicoContratado")
                            .HasColumnType("int(11)")
                            .HasColumnName("idServicoContratado");
                        j.IndexerProperty<int>("IdOrcamentoServicoContratado")
                            .HasColumnType("int(11)")
                            .HasColumnName("idOrcamentoServicoContratado");
                    });
        });

        modelBuilder.Entity<Servicocontratado>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdOrcamento }).HasName("PRIMARY");

            entity.ToTable("servicocontratado");

            entity.HasIndex(e => e.IdAvaliacao, "fk_ServicoContratado_Avaliacao1_idx");

            entity.HasIndex(e => e.IdOrcamento, "fk_ServicoContratado_Orcamento1_idx");

            entity.HasIndex(e => e.IdPessoa, "fk_ServicoContratado_Pessoa1_idx");

            entity.HasIndex(e => e.IdTemplateContrato, "fk_ServicoContratado_TemplateContrato1_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdOrcamento)
                .HasColumnType("int(11)")
                .HasColumnName("idOrcamento");
            entity.Property(e => e.IdAvaliacao)
                .HasColumnType("int(11)")
                .HasColumnName("idAvaliacao");
            entity.Property(e => e.IdPessoa)
                .HasColumnType("int(11)")
                .HasColumnName("idPessoa");
            entity.Property(e => e.IdTemplateContrato)
                .HasColumnType("int(11)")
                .HasColumnName("idTemplateContrato");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdAvaliacaoNavigation).WithMany(p => p.Servicocontratados)
                .HasForeignKey(d => d.IdAvaliacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ServicoContratado_Avaliacao1");

            entity.HasOne(d => d.IdOrcamentoNavigation).WithMany(p => p.Servicocontratados)
                .HasForeignKey(d => d.IdOrcamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ServicoContratado_Orcamento1");

            entity.HasOne(d => d.IdPessoaNavigation).WithMany(p => p.Servicocontratados)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ServicoContratado_Pessoa1");

            entity.HasOne(d => d.IdTemplateContratoNavigation).WithMany(p => p.Servicocontratados)
                .HasForeignKey(d => d.IdTemplateContrato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ServicoContratado_TemplateContrato1");
        });

        modelBuilder.Entity<Solicitarorcamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("solicitarorcamento");

            entity.HasIndex(e => e.IdPessoa, "fk_Solicita_Pessoa_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.Descricao)
                .HasMaxLength(1000)
                .HasColumnName("descricao");
            entity.Property(e => e.IdPessoa)
                .HasColumnType("int(11)")
                .HasColumnName("idPessoa");

            entity.HasOne(d => d.IdPessoaNavigation).WithMany(p => p.Solicitarorcamentos)
                .HasForeignKey(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Solicita_Pessoa");
        });

        modelBuilder.Entity<Templatecontrato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("templatecontrato");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Arquivo)
                .HasColumnType("blob")
                .HasColumnName("arquivo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
