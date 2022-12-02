using Microsoft.AspNetCore.Mvc;

namespace MudBlazorTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropietarioController : ControllerBase
    {
        private readonly DataContext _context;
        public PropietarioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Propietario>>> GetPropietarios()
        {
            var propietarios = await _context.Propietarios.ToListAsync();
            return Ok(propietarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Propietario>> GetSinglePropietario(int id)
        {
            var propietario = await _context.Propietarios
                .FirstOrDefaultAsync(p => p.PersonaId == id);
            if (propietario == null)
            {
                return NotFound("Lo siento, ese propietario no esta aqui :/");
            }

            return Ok(propietario);
        }

        [HttpPost]
        public async Task<ActionResult<List<Propietario>>> CreatePropietario(Propietario propietario)
        {
            _context.Propietarios.Add(propietario);
            await _context.SaveChangesAsync();

            return Ok(await GetDbPropietarios());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Propietario>>> UpdateVeterinario(Propietario propietario, int id)
        {
            var dbPropietario = await _context.Propietarios
                .FirstOrDefaultAsync(p => p.PersonaId == id);
            if (dbPropietario == null)
                return NotFound("Lo sentimos, no existe ese propietario aqui. :/");

            dbPropietario.Nombres = propietario.Nombres;
            dbPropietario.Apellidos = propietario.Apellidos;
            dbPropietario.Telefono = propietario.Telefono;
            dbPropietario.Direccion = propietario.Direccion;


            await _context.SaveChangesAsync();

            return Ok(await GetDbPropietarios());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Propietario>>> DeleteVeterinario(int id)
        {
            var dbPropietario = await _context.Propietarios
                .FirstOrDefaultAsync(v => v.PersonaId == id);
            if (dbPropietario == null)
                return NotFound("Lo sentimos, no existe ese propietario aqui. :/");

            _context.Propietarios.Remove(dbPropietario);
            await _context.SaveChangesAsync();

            return Ok(await GetDbPropietarios());
        }

        private async Task<List<Propietario>> GetDbPropietarios()
        {
            return await _context.Propietarios.ToListAsync();
        }
    }
}
