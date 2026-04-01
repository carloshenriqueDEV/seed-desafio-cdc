using Microsoft.AspNetCore.Mvc;
using seed_desafio_cdc_api.Features.CadastroLivro;
using seed_desafio_cdc_api.Infrastructure.Data;

namespace seed_desafio_cdc_api.Features.CadastroCategoria
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType<NovaCategoriaResponse>(201)]
        public IActionResult CadastrarCategoria(NovaCategoriaRequest novaCategoriaRequest)
        {
            var novaCategoria = novaCategoriaRequest.ToModel();

            _context.Add(novaCategoria);

            _context.SaveChanges();

            return Created("", new NovaCategoriaResponse(novaCategoria.Id, novaCategoria.Nome));
        }
    }
}
