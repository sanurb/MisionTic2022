using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MudBlazorTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriaController : ControllerBase
    {
        private readonly DataContext _context;
        public HistoriaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Propietario>>> GetHistorias()
        {
            var historias = await _context.Historias.ToListAsync();
            return Ok(historias);
        }
    }
}
