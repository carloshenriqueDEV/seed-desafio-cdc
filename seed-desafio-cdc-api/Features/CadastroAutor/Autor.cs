using seed_desafio_cdc_api.Features.CadastroLivro;

namespace seed_desafio_cdc_api.Features.CadastroAutor
{
    public class Autor
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Descricao { get; private set; }
        public DateTime RegistradoEm { get; private set; }
        public ICollection<Livro> Livros { get; private set; } = new List<Livro>();

        public Autor(string nome, string email, string descricao)
        {
            Validacoes(nome, email, descricao);

            Nome = nome;
            Email = email;
            Descricao = descricao;
            RegistradoEm = DateTime.Now;
        }

        protected Autor()
        {
            // Construtor vazio para EF
        }

        private void Validacoes(string nome, string email, string descricao)
        {
            NomeValido(nome);
            EmailValido(email);
            DescricaoValida(descricao);
        }

        private void EmailValido(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("O campo email é obrigatório.");
            }

            if (!email.Contains("@"))
            {
                throw new Exception("O campo email deve ser um endereço de email válido.");
            }
        }

        private void NomeValido(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new Exception("O campo nome é obrigatório.");
            }
        }

        private void DescricaoValida(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
            {
                throw new Exception("O campo descrição é obrigatório.");
            }
            if (descricao.Length > 400)
            {
                throw new Exception("O campo descrição deve ter no máximo 400 caracteres.");
            }
        }

    }
}
