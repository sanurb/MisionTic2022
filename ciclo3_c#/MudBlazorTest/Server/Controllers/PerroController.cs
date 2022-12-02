using Microsoft.AspNetCore.Mvc;

namespace MudBlazorTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerroController : Controller
    {
        private readonly DataContext _context;

        public PerroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Perro>>> GetPerros()
        {
            var perros = await _context.Perros.Include(p => p.Propietario).ToListAsync();
            return Ok(perros);
        }

        [HttpGet("propietarios")]
        public async Task<ActionResult<List<Propietario>>> GetPropietarios()
        {
            var propietarios = await _context.Propietarios.ToListAsync();
            return Ok(propietarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Perro>> GetSinglePerro(int id)
        {
            var perro = await _context.Perros
                .Include(p => p.Propietario) // Si no realizamos el include el Propietario seria Null
                .FirstOrDefaultAsync(p => p.PerroId == id);
            if (perro == null)
            {
                return NotFound("Lo siento, ese perro no esta aqui :/");
            }

            return Ok(perro);
        }

        [HttpPost]
        public async Task<ActionResult<List<Perro>>> CreatePerro(Perro perro)
        {
            perro.Propietario = null;
            _context.Perros.Add(perro);
            await _context.SaveChangesAsync();

            return Ok(await GetDbPerros());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Perro>>> UpdatePerro(Perro perro, int id)
        {
            var dbPerro = await _context.Perros
                .Include(p => p.Propietario)
                .FirstOrDefaultAsync(p => p.PerroId == id);
            if (dbPerro == null)
                return NotFound("Lo siento, pero no hay perro para ti. :/");

            dbPerro.Nombre = perro.Nombre;
            dbPerro.Color = perro.Color;
            dbPerro.Raza = perro.Raza;
            dbPerro.Sexo = perro.Sexo;
            dbPerro.PropietarioId = perro.PropietarioId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbPerros());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Perro>>> DeletePerro(int id)
        {
            var dbPerro = await _context.Perros
                .Include(p => p.Propietario)
                .FirstOrDefaultAsync(p => p.PerroId == id);
            if (dbPerro == null)
                return NotFound("Lo siento, pero no hay perro para ti. :/");

            _context.Perros.Remove(dbPerro);
            await _context.SaveChangesAsync();

            return Ok(await GetDbPerros());
        }

        private async Task<List<Perro>> GetDbPerros()
        {
            return await _context.Perros.Include(p => p.Propietario).ToListAsync();
        }


    }
}

