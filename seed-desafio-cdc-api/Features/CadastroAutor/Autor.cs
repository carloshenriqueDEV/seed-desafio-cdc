using seed_desafio_cdc_api.Validations;

namespace seed_desafio_cdc_api.Features.CadastroAutor
{
    public class Autor
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Descricao { get; private set; }
        public DateTime RegistradoEm { get; private set; }

        public Autor( string nome, string email, string descricao)
        {
            Nome = nome;
            Email = email;
            Descricao = descricao;
            RegistradoEm = DateTime.Now;
        }
    }
}
