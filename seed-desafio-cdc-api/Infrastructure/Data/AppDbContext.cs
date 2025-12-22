using Microsoft.EntityFrameworkCore;
using seed_desafio_cdc_api.Features.CadastroAutor;

namespace seed_desafio_cdc_api.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAutorRepository
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }

        public bool EmailJaCadastrado(string email)
        {
           return this.Autores.Any(u => u.Email == email);
        }
    }
}
