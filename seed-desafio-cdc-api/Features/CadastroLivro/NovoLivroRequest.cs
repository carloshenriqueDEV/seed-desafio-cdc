using seed_desafio_cdc_api.Validations;
using System.ComponentModel.DataAnnotations;

namespace seed_desafio_cdc_api.Features.CadastroLivro
{
    public record NovoLivroRequest(
        [Required]
        [ItsUnique(EntityName = "Livro", PropertyName = "Titulo", ErrorMessage = "O título do livro deve ser único.")]
        string Titulo,
        [Required]
        [MaxLength(500, ErrorMessage = "O campo resumo deve ter no máximo 500 caracteres.")]
        string Resumo,
        string Sumario,
        [Required]
        [Range(20, double.MaxValue, ErrorMessage = "O campo preço deve ser no mínimo 20.")]
        decimal Preco,
        [Required]
        [Range(100, int.MaxValue, ErrorMessage = "O campo número de páginas deve ser no mínimo 100.")]
        int NumeroDePaginas,
        [ItsUnique(EntityName = "Livro", PropertyName = "Isbn", ErrorMessage = "O Isbn deve ser único")]
        string Isbn,
        [Required]
        DateTime Publicacao,
        [Range(1, int.MaxValue, ErrorMessage = "O campo categoria é obrigatório.")]
        int CategoriaId,
        [Range (1, int.MaxValue, ErrorMessage = "O campo autor é obrigatório.")]
        int AutorId
        )
    {
        public Livro ToModel()
        {
            return new Livro(Titulo, Resumo, Sumario, Preco, NumeroDePaginas, Isbn, Publicacao, CategoriaId, AutorId);
        }
    }
}
