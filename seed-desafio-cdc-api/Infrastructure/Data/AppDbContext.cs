using Microsoft.EntityFrameworkCore;
using seed_desafio_cdc_api.Features;
using seed_desafio_cdc_api.Features.CadastroAutor;
using seed_desafio_cdc_api.Features.CadastroCategoria;
using seed_desafio_cdc_api.Features.CadastroLivro;
using System.Linq.Dynamic.Core;

namespace seed_desafio_cdc_api.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAutorRepository, ICategoriaRepository, ILivroRepositorio
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasIndex(u => u.Nome)
                .IsUnique()
                .HasDatabaseName("Index_Unique_Categoria_Nome");

            modelBuilder.Entity<Autor>()
                .HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("Index_Unique_Autor_Email");

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.Property(l => l.Titulo)
                    .IsRequired();

                entity.HasIndex(l => l.Titulo)
                    .IsUnique()
                    .HasDatabaseName("Index_Unique_Livro_Titulo");

                entity.Property(l => l.Preco)
                    .HasColumnType("Decimal(5,2)")
                    .IsRequired();

                entity.Property(l => l.Isbn)
                    .IsRequired();

                entity.HasIndex(l => l.Isbn)
                    .IsUnique()
                    .HasDatabaseName("Index_Unique_Livro_Isbn");

                entity.HasOne(l => l.Categoria)
                     .WithMany(c => c.Livros)
                     .HasForeignKey(l => l.CategoriaId)
                     .IsRequired()
                     .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.Autor)
                    .WithMany(a => a.Livros)
                    .HasForeignKey(l => l.AutorId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.ToTable(t =>
                {
                    t.HasCheckConstraint("CK_Livro_Preco", $"[{nameof(Livro.Preco)}] >= 20");
                    t.HasCheckConstraint("CK_Livro_Paginas", $"[{nameof(Livro.NumeroDePaginas)}] >= 100");
                });

            });

        }

        #region Integridade de dados
        public bool EUnico(string entityName, string propertyName, object value)
        {
            var dbSet = this.GetType().GetProperty(entityName)?.GetValue(this) as IQueryable<object>;

            if (dbSet == null)
            {
                throw new InvalidOperationException($"Entidade '{entityName}' não encontrada no contexto.");
            }

            return dbSet.Any(e => EF.Property<object>(e, propertyName).Equals(value)) == false;
        }

        #endregion

        public List<Categoria> ObterCategorias()
        {
            return this.Categorias.ToList();
        }

        public List<Autor> ObterAutores()
        {
            return this.Autores
                .AsNoTracking()
                .ToList();
        }

        public List<Livro> ObterLivros()
        {
            return this.Livros
                .AsNoTracking()
                .Include(l => l.Autor)
                .Include(l => l.Categoria)
                .ToList();
        }
    }
}
