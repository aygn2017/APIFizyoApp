using APIFizyo.Data;
using APIFizyo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFizyo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresController : ControllerBase
    {
        private readonly APIFizyoDBContext _context;

        public AdresController(APIFizyoDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adres>>> TümKullanıcılarıGetir()
        {

            return await _context.Adresler.ToListAsync();
        }

        // GET: api/seçiliAdresiGetir
        [HttpGet("seçiliAdresiGetir/{id}")]
        public async Task<ActionResult<Adres>> seçiliAdresiGetir(int id)
        {

            return await _context.Adresler.FindAsync(id);
        }


        [HttpPost]
        public async Task<ActionResult> AdresEkle(Adres adres)
        {
            _context.Adresler.Add(adres);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Adres>> AdresGüncelle(int id, Adres adres)
        {
            _context.Entry(adres).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.Adresler.FindAsync(id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> AdresSil(int id)
        {
            Adres adres= await _context.Adresler.FindAsync(id);

            if (adres == null)
            {
                return NotFound();
            }

            _context.Remove(adres);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("AdreslerByİlçe/{id}")]
        public async Task<ActionResult<IEnumerable<Adres>>> AdreslerByİlçe(int id)
        {

            return await _context.Adresler.Where(a => a.İlçeID == id).ToListAsync();
        }

        // GET: api/KullanıcılarByRolAdı
        [HttpGet("AdreslerByİlçeAdı/{Adı}")]
        public async Task<ActionResult<IEnumerable<Adres>>> AdreslerByİlçeAdı(string Adı)
        {

            return await _context.Adresler.Include(a => a.İlçe).Where(a => a.İlçe.İlçeAdı == Adı).ToListAsync();
        }


        [HttpGet("AdreslerByPostaKodu")]
        public async Task<ActionResult<IEnumerable<Adres>>> AdreslerByPostaKodu(string postakodu)
        {

            return await _context.Adresler.Where(a=>a.PostaKodu== postakodu).ToListAsync();
        }

        [HttpGet("AdreslerFiltreli")]
        public
    async Task<ActionResult<IEnumerable<Adres>>> AdreslerFiltreli(string AdresAdı, int? İlçeID)
        {

            return await _context.Adresler.Include(a => a.İlçe).
                Where(a =>
                        (a.İlçe.İlçeID == İlçeID || İlçeID == null)&&(a.AdresAdı == AdresAdı || AdresAdı == null)).ToListAsync();
        }

    }
}
