using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIFizyo.Data;
using APIFizyo.Model;

namespace APIFizyo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedeniBilgiController : ControllerBase
    {
        private readonly APIFizyoDBContext _context;

        public MedeniBilgiController(APIFizyoDBContext context)
        {
            _context = context;
        }

        // GET: api/MedeniBilgiler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedeniBilgi>>> GetMedeniBilgiler()
        {
            return await _context.MedeniBilgiler.ToListAsync();
        }

        // GET: api/MedeniBilgiler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedeniBilgi>> GetMedeniBilgilerByID(int id)
        {
            var medeniBilgiler = await _context.MedeniBilgiler.FindAsync(id);

            if (medeniBilgiler == null)
            {
                return NotFound();
            }

            return medeniBilgiler;
        }




        [HttpGet("MedeniBilgilerFiltreli")]
        public async Task<ActionResult<IEnumerable<MedeniBilgi>>> MedeniBilgilerFiltreli(int? çocukSayısı, int? medeniDurumID)

        {
            List<MedeniBilgi> medeniBilgi = await _context.MedeniBilgiler.ToListAsync();

            List<MedeniBilgi> x = medeniBilgi.
            Where(a =>
                      (a.MedeniDurumID == medeniDurumID || medeniDurumID == null)
                      &&
                      (a.ÇocukSayısı == çocukSayısı || çocukSayısı == null)
                     
                  ).ToList();
            return x;


        }







        [HttpGet("GetMedeniBilgiByAdı/{adı}")]
        public async Task<ActionResult<IEnumerable<MedeniBilgi>>> GetMedeniBilgiByAdı(string adı)
        {

           List <MedeniBilgi> medeniBilgi = await _context.MedeniBilgiler.Where(a => a.MedeniDurum.MedeniDurumAdı == adı).ToListAsync();
            if (medeniBilgi == null)
            {
                return NotFound();
            }

            return medeniBilgi;
        }











        // PUT: api/MedeniBilgiler/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedeniBilgiler(int id, MedeniBilgi medeniBilgi)
        {
            if (id != medeniBilgi.KullanıcıID)
            {
                return BadRequest();
            }

            _context.Entry(medeniBilgi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedeniBilgilerExists(id))
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

        // POST: api/MedeniBilgiler
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedeniBilgi>> PostMedeniBilgiler(MedeniBilgi medeniBilgi)
        {
            _context.MedeniBilgiler.Add(medeniBilgi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedeniBilgiler", new { id = medeniBilgi.KullanıcıID }, medeniBilgi);
        }

        // DELETE: api/MedeniBilgiler/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedeniBilgiler(int id)
        {
            var medeniBilgiler = await _context.MedeniBilgiler.FindAsync(id);
            if (medeniBilgiler == null)
            {
                return NotFound();
            }

            _context.MedeniBilgiler.Remove(medeniBilgiler);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedeniBilgilerExists(int id)
        {
            return _context.MedeniBilgiler.Any(e => e.KullanıcıID == id);
        }

    }
}
