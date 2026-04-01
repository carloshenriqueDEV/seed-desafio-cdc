using seed_desafio_cdc_api.Validations;
using System.ComponentModel.DataAnnotations;

namespace seed_desafio_cdc_api.Features.CadastroCategoria
{
    public record NovaCategoriaRequest
     ([Required]
      [ItsUnique(EntityName = "Categoria", PropertyName = "Nome", ErrorMessage = "O nome da categoria deve ser único.")]
      string Nome
    )
    {
        public Categoria ToModel()
        {
            return new Categoria(Nome);
        }
    }
}
