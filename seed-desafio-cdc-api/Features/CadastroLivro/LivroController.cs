using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using seed_desafio_cdc_api.Infrastructure.Data;

namespace seed_desafio_cdc_api.Features.CadastroLivro
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LivroController(AppDbContext appContext)
        {
            _context = appContext;
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<LivroResponse>>(200)]
        public ActionResult<IEnumerable<LivroResponse>> ObterLivros()
        {
            return Created("", _context.ObterLivros()
                 .Select(l => new LivroResponse(
                     l.Id,
                     l.Titulo)));
        }

        [HttpGet]
        [ProducesResponseType<LivroDetails>(200)]
        public ActionResult<LivroDetails> ObterLivro([FromQuery] int id)
        {
            var livro = _context.ObterLivros()
                .Where(l => l.Id == id)
                .Select(l => new LivroDetails(
                    l.Id,
                    l.Titulo,
                    l.Resumo,
                    l.Sumario,
                    l.Preco,
                    l.NumeroDePaginas,
                    l.Isbn,
                    l.Publicacao,
                    l.CategoriaId,
                    l.Categoria.Nome,
                    l.AutorId,
                    l.Autor.Nome))
                .FirstOrDefault();

            if (livro is null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        [HttpPost]
        [ProducesResponseType<LivroResponse>(201)]
        public ActionResult<LivroResponse> NovoLivro([FromBody] NovoLivroRequest request)
        {
            var livro = request.ToModel();
            _context.Livros.Add(livro);
            _context.SaveChanges();


            return Created("", _context.Livros
                .AsNoTracking()
                .Where(l => l.Id == livro.Id)
                .Select(l => new LivroResponse(
                    l.Id,
                    l.Titulo))
                .FirstOrDefault());
        }
    }
}
