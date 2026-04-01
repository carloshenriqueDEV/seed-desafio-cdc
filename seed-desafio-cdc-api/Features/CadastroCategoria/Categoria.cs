using seed_desafio_cdc_api.Features.CadastroLivro;

namespace seed_desafio_cdc_api.Features.CadastroCategoria
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public virtual ICollection<Livro> Livros { get; private set; } = new List<Livro>();

        public Categoria(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) { 
                throw new Exception("Nome da categoria não pode ser nulo ou em branco.");
            }

            Nome = nome;
        }

        protected Categoria()
        {
            //Construtor vazio para EF
        }
    }
}
