namespace seed_desafio_cdc_api.Features.CadastroLivro
{
    public record LivroDetails(
        int Id,
        string Titulo,
        string Resumo,
        string Sumario,
        decimal Preco,
        int NumeroDePaginas,
        string Isbn,
        DateTime Publicacao,
        int CategoriaId,
        string Categoria,
        int AutorId,
        string Autor
    ){}
}
