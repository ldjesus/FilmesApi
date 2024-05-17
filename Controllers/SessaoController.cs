using AutoMapper;
using FilmesApi.Data.Dto;
using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { id = sessao.Id }, sessao);

        }

        [HttpGet]
        public IEnumerable<ReadSessaoDto> RecuperaSessoes([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            var listaSessoes = _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
            return listaSessoes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(x => x.Id == id);
            if (sessao == null) return NotFound();
            var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
            return Ok(sessaoDto);

        }

        //[HttpPut("{id}")]
        //public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto SessaoDto)
        //{
        //    var Sessao = _context.Sessaos.FirstOrDefault(x => x.Id == id);

        //    if (Sessao == null)
        //        return NotFound();
        //    _mapper.Map(SessaoDto, Sessao);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeletaSessao(int id)
        //{
        //    var Sessao = _context.Sessaos.FirstOrDefault(x => x.Id == id);
        //    if (Sessao == null) return NotFound();
        //    _context.Remove(Sessao);
        //    _context.SaveChanges();
        //    return NoContent();
        //}
    }
}
