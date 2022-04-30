using APIFizyo.Data;
using APIFizyo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFizyo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedeniDurumController : ControllerBase
    {
        private readonly APIFizyoDBContext _context;

        public MedeniDurumController(APIFizyoDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedeniDurum>>> TümMedeniDurumlarıGetir()
        {
            return await _context.MedeniDurumlar.ToListAsync();
        }

        [HttpGet("seçiliMedeniDurumGetir/{id}")]
        public async Task<ActionResult<MedeniDurum>> seçiliMedeniDurumGetir(int id)
        {

            return await _context.MedeniDurumlar.FindAsync(id);
        }


        [HttpPost]
        public async Task<ActionResult> MedeniDurumEkle(MedeniDurum medenidurum)
        {
            _context.MedeniDurumlar.Add(medenidurum);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<MedeniDurum>> MedeniDurumGüncelle(int id, MedeniDurum medenidurum)
        {
            _context.Entry(medenidurum).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.MedeniDurumlar.FindAsync(id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> MedeniDurumSil(int id)
        {
            MedeniDurum medenidurum = await _context.MedeniDurumlar.FindAsync(id);

            if (medenidurum == null)
            {
                return NotFound();
            }

            _context.Remove(medenidurum);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet("MedeniDurumlarFiltreli")]
        public
            async Task<ActionResult<IEnumerable<MedeniDurum>>> MedeniDurumlarFiltreli(string MedeniDurumAdı)
        {

            return await _context.MedeniDurumlar.Where(a => a.MedeniDurumAdı == MedeniDurumAdı).ToListAsync();
        }
    }
}
