namespace seed_desafio_cdc_api.Features.CadastroAutor
{
    public record NovoAutorResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public static NovoAutorResponse ToResponse(Autor autor)
        {
            return new NovoAutorResponse
            {
                Id = autor.Id,
                Nome = autor.Nome
            };
        }
        
    }
}
