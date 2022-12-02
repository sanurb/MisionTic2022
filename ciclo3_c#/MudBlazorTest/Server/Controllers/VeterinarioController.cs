using Microsoft.AspNetCore.Mvc;

namespace MudBlazorTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        private readonly DataContext _context;

        public VeterinarioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Veterinario>>> GetVeterinarios()
        {
            var veterinarios = await _context.Veterinarios.ToListAsync();
            return Ok(veterinarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Veterinario>>> GetSingleVeterinario(int id)
        {
            var veterinario = await _context.Veterinarios
                .FirstOrDefaultAsync(v => v.PersonaId == id);
            if (veterinario == null)
            {
                return NotFound("Lo sentimos, no hay veterinario aqui. :/");
            }
            return Ok(veterinario);
        }

        [HttpPost]
        public async Task<ActionResult<List<Veterinario>>> CreateVeterinario(Veterinario veterinario)
        {
            _context.Veterinarios.Add(veterinario);
            await _context.SaveChangesAsync();

            return Ok(await GetDbVeterinarios());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Veterinario>>> UpdateVeterinario(Veterinario veterinario, int id)
        {
            var dbVeterinario = await _context.Veterinarios
                .FirstOrDefaultAsync(v => v.PersonaId == id);
            if (dbVeterinario == null)
                return NotFound("Lo sentimos, no hay veterinario aqui. :/");

            dbVeterinario.TarjetaProfesional = veterinario.TarjetaProfesional;
            dbVeterinario.Nombres = veterinario.Nombres;
            dbVeterinario.Apellidos = veterinario.Apellidos;
            dbVeterinario.Telefono = veterinario.Telefono;

            await _context.SaveChangesAsync();

            return Ok(await GetDbVeterinarios());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Veterinario>>> DeleteSuperHero(int id)
        {
            var dbVeterinario = await _context.Veterinarios
                .FirstOrDefaultAsync(v => v.PersonaId == id);
            if (dbVeterinario == null)
                return NotFound("Lo sentimos, no hay veterinario aqui. :/");

            _context.Veterinarios.Remove(dbVeterinario);
            await _context.SaveChangesAsync();

            return Ok(await GetDbVeterinarios());
        }

        private async Task<List<Veterinario>> GetDbVeterinarios()
        {
            return await _context.Veterinarios.ToListAsync();
        }
    }

}
