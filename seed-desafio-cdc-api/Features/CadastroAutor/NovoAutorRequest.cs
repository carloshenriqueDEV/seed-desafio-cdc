using seed_desafio_cdc_api.Validations;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace seed_desafio_cdc_api.Features.CadastroAutor
{
    public record NovoAutorRequest
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [NotNull]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo email deve ser um endereço de email válido.")]
        [EmailAlreadyExists]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório.")]
        [MaxLength(400, ErrorMessage = "O campo descrição deve ter no máximo 400 caracteres.")]
        public string Descricao { get; set; }

        public Autor ToModel()
        {
            return new Autor(Nome, Email, Descricao);
        }
    }
}
