using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIFizyo.Data;
using APIFizyo.Model;


namespace APIFizyo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinsiyetController : ControllerBase
    {
        private readonly APIFizyoDBContext _context;

        public CinsiyetController(APIFizyoDBContext context)
        {
            _context = context;
        }

        // GET: api/Cinsiyet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cinsiyet>>> GetCinsiyetler()
        {
            return await _context.Cinsiyetler.ToListAsync();
        }

        // GET: api/Cinsiyet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cinsiyet>> GetCinsiyet(int id)
        {
            var cinsiyet = await _context.Cinsiyetler.FindAsync(id);

            if (cinsiyet == null)
            {
                return NotFound();
            }

            return cinsiyet;
        }

        // GET: api/Cinsiyet/5
        [HttpGet("GetCinsiyet/{adı}")]
        public async Task<ActionResult<Cinsiyet>> GetCinsiyet(string adı)
        {

            Cinsiyet cinsiyet = await _context.Cinsiyetler.FirstOrDefaultAsync(a => a.CinsiyetAdı == adı);
            if (cinsiyet == null)
            {
                return NotFound();
            }

            return cinsiyet;
        }



        // PUT: api/Cinsiyet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCinsiyet(int id, Cinsiyet cinsiyet)
        {
            if (id != cinsiyet.CinsiyetID)
            {
                return BadRequest();
            }

            _context.Entry(cinsiyet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinsiyetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cinsiyet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cinsiyet>> PostCinsiyet(Cinsiyet cinsiyet)
        {
            _context.Cinsiyetler.Add(cinsiyet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCinsiyet", new { id = cinsiyet.CinsiyetID }, cinsiyet);
        }

        // DELETE: api/Cinsiyet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinsiyet(int id)
        {
            var cinsiyet = await _context.Cinsiyetler.FindAsync(id);
            if (cinsiyet == null)
            {
                return NotFound();
            }

            _context.Cinsiyetler.Remove(cinsiyet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CinsiyetExists(int id)
        {
            return _context.Cinsiyetler.Any(e => e.CinsiyetID == id);
        }
    }
}
