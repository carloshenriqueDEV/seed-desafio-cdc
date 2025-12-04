using Microsoft.AspNetCore.Mvc;
using seed_desafio_cdc_api.Infrastructure.Data;

namespace seed_desafio_cdc_api.Features.CadastroAutor
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AutorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<NovoAutorResponse> NovoAutor([FromBody] NovoAutorRequest request)
        {
            var autor = request.ToModel();

            _context.Autores.Add(autor);

            _context.SaveChanges();

            return Ok(NovoAutorResponse.ToResponse(autor));
        }
    }
}
