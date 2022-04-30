using APIFizyo.Data;
using APIFizyo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFizyo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly APIFizyoDBContext _context;

        public KullaniciController(APIFizyoDBContext context)
        {
            _context = context;
        }


        // GET: api/TümKullanıcılarıGetir
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kullanıcı>>> TümKullanıcılarıGetir()
        {

            return await _context.Kullanıcılar.ToListAsync();
        }


        // GET: api/seçiliKullanıcıyıGetir
        [HttpGet("seçiliKullanıcıyıGetir/{id}")]
        public async Task<ActionResult<Kullanıcı>> seçiliKullanıcıyıGetir(int id)
        {

            return await _context.Kullanıcılar.FindAsync(id);
        }

        // GET: api/KullanıcılarByRol

        [HttpGet("KullanıcılarByRol/{id}")]
        public async Task<ActionResult<IEnumerable<Kullanıcı>>> KullanıcılarByRol(int id)
        {

            return await _context.Kullanıcılar.Where(a => a.RolID == id).ToListAsync();
        }


        // GET: api/KullanıcılarByRolAdı
        [HttpGet("KullanıcılarByRolAdı/{Adı}")]
        public async Task<ActionResult<IEnumerable<Kullanıcı>>> KullanıcılarByRolAdı(string Adı)
        {

            return await _context.Kullanıcılar.Include(a => a.Rol).Where(a => a.Rol.RolAdı == Adı).ToListAsync();
        }

        // POST: api/Kullanıcı        
        [HttpPost]
        public async Task<ActionResult> KullanıcıEkle(Kullanıcı kullanıcı)
        {
            _context.Kullanıcılar.Add(kullanıcı);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // PUT: api/Kullanıcı/5       
        [HttpPut("{id}")]
        public async Task<ActionResult<Kullanıcı>> KullanıcıGüncelle(int id, Kullanıcı kullanıcı)
        {
            _context.Entry(kullanıcı).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.Kullanıcılar.FindAsync(id);
        }

        // DELETE: api/Kullanıcı/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> KullanıcıSil(int id)
        {
            Kullanıcı kullanıcı = await _context.Kullanıcılar.FindAsync(id);

            if (kullanıcı == null)
            {
                return NotFound();
            }

            _context.Remove(kullanıcı);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        // GET: api/KullanıcılarFiltreli
        [HttpGet("KullanıcılarFiltreli")]
        public 
            async Task<ActionResult<IEnumerable<Kullanıcı>>> KullanıcılarFiltreli(string EpostaUzantı, string RolAdı, int? limit)
        {

            return await _context.Kullanıcılar.Include(a => a.Rol).
                Where(a =>
                        (a.Rol.RolAdı == RolAdı || RolAdı == null)
                        &&
                        (a.Eposta.Contains(EpostaUzantı) || EpostaUzantı == null)
                        &&
                        (a.Şifre.Length > limit || limit == null)
                     )
                      .ToListAsync();
        }

        // GET: api/KullaniciVarmi
        [HttpGet("KullaniciVarmi")]
        public async Task<ActionResult<bool>> KullaniciVarmi(string Eposta, string Sifre)
        {
            return await _context.Kullanıcılar.AnyAsync(a=>a.Eposta==Eposta&&a.Şifre==Sifre);
        }
    }
}
