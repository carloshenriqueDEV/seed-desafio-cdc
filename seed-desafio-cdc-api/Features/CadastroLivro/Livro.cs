using seed_desafio_cdc_api.Features.CadastroAutor;
using seed_desafio_cdc_api.Features.CadastroCategoria;

namespace seed_desafio_cdc_api.Features.CadastroLivro
{
    public class Livro
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Resumo { get; private set; }
        public string Sumario { get; private set; }
        public decimal Preco { get; private set; }
        public int NumeroDePaginas { get; private set; }
        public string Isbn { get; private set; }
        public DateTime Publicacao { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }
        public int AutorId { get; set; }
        public Autor Autor { get; private set; }

        protected Livro()
        {
            // Construtor vazio para EF
        }

        public Livro(string titulo, string resumo, string sumario, decimal preco, int numeroDePaginas, string isbn, DateTime publicacao, int categoriaId, int autorId)
        {
            Validacoes(titulo, resumo, sumario, preco, numeroDePaginas, isbn, publicacao, categoriaId, autorId);

            Titulo = titulo;
            Resumo = resumo;
            Sumario = sumario;
            Preco = preco;
            NumeroDePaginas = numeroDePaginas;
            Isbn = isbn;
            Publicacao = publicacao;
            CategoriaId = categoriaId;
            AutorId = autorId;
        }

        private void Validacoes(string titulo, string resumo, string sumario, decimal preco, int numeroDePaginas, string isbn, DateTime publicacao, int categoriaId, int autorId)
        {
            TituloValido(titulo);
            ResumoValido(resumo);
            PrecoValido(preco);
            NumeroDePaginasValido(numeroDePaginas);
            IsbnValido(isbn);
            PublicacaoValida(publicacao);
            CategoriaValida(categoriaId);
            AutorValido(autorId);
        }

        private void AutorValido(int autorId)
        {
            if(autorId == 0)
            {
                throw new ArgumentException("O campo autor é obrigatório.");
            }
        }

        private void CategoriaValida(int categoriaId)
        {
            if (categoriaId == 0)
            {
                throw new ArgumentException("O campo categoria é obrigatório.");
            }
        }

        private void PublicacaoValida(DateTime publicacao)
        {
            if(publicacao > DateTime.Now)
            {
                throw new ArgumentException("O campo publicação deve ser uma data futura.");
            }
        }

        private void IsbnValido(string isbn)
        {
            if(string.IsNullOrEmpty(isbn))
            {
                throw new ArgumentException("O campo ISBN é obrigatório.");
            }
        }

        private void NumeroDePaginasValido(int numeroDePaginas)
        {
            if(numeroDePaginas < 100)
            {
                throw new ArgumentException("O campo número de páginas deve ser no mínimo 100.");
            }
        }

        private void PrecoValido(decimal preco)
        {
            if(preco < 20)
            {
                throw new ArgumentException("O campo preço deve ser no mínimo 20.");
            }
        }

        private void ResumoValido(string resumo)
        {
            if (string.IsNullOrEmpty(resumo)) { 
                throw new ArgumentException("O campo resumo é obrigatório");
            }

            if(resumo.Length <= 500)
            {
                throw new ArgumentException("O campo resumo deve conter no máximo 500 caracteres");
            }
        }

        private void TituloValido(string titulo)
        {
            if(string.IsNullOrEmpty(titulo))
            {
                throw new ArgumentException("O campo título é obrigatório");           
            }
        }
    }
}
