using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIFizyo.Data;
using APIFizyo.Model;

namespace APIFizyo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HesapController : ControllerBase
    {
        private readonly APIFizyoDBContext _context;

        public HesapController(APIFizyoDBContext context)
        {
            _context = context;
        }

        // GET: api/Hesap
        [HttpGet("TümHesaplarıGetir")]
        public async Task<ActionResult<IEnumerable<Hesap>>> TümHesaplarıGetir()
        {
            return await _context.Hesaplar.ToListAsync();
        }

        // GET: api/Hesap/5
        [HttpGet("HesapGetirByID/{id}")]
        public async Task<ActionResult<Hesap>> HesapGetirByID(int id)
        {
            var hesap = await _context.Hesaplar.FindAsync(id);

            if (hesap == null)
            {
                return NotFound();
            }

            return hesap;
        }

        // PUT: api/Hesap/5
        [HttpPut("HesapGüncelle/{id}")]
        public async Task<IActionResult> HesapGüncelle(int id, Hesap hesap)
        {
            if (id != hesap.HesapID)
            {
                return BadRequest();
            }

            _context.Entry(hesap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HesapExists(id))
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

        // POST: api/HesapEkle
        [HttpPost("HesapEkle")]
        public async Task<ActionResult<Hesap>> HesapEkle(Hesap hesap)
        {
            _context.Hesaplar.Add(hesap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHesap", new { id = hesap.HesapID }, hesap);
        }

        // DELETE: api/Hesap/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> HesapSil(int id)
        {
            var hesap = await _context.Hesaplar.FindAsync(id);
            if (hesap == null)
            {
                return NotFound();
            }

            _context.Hesaplar.Remove(hesap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/HesapFiltreli/
        [HttpGet("HesapFiltreli")]

        public async Task<ActionResult<IEnumerable<Hesap>>> HesapFiltreli(int? HesapID, int? BankaID , int? KullanıcıID, string HesapAdı, string HesapSahibiTamAdı, string IBAN, string HesapNo, string ŞubeKodu)
        {


            return await _context.Hesaplar.Include(a=>a.Kullanıcı).Include(b=>b.Banka).
                Where(x=>
                (x.HesapID == HesapID || HesapID == null)
                &&
                (x.BankaID == BankaID || BankaID == null)
                &&
                (x.KullanıcıID == KullanıcıID || KullanıcıID == null)
                &&
                (x.HesapSahibiTamAdı == HesapSahibiTamAdı || HesapSahibiTamAdı == null)
                &&
                (x.IBAN == IBAN || IBAN == null)
                &&
                (x.HesapNo == HesapNo || HesapNo == null)
                &&
                (x.ŞubeKodu == ŞubeKodu || ŞubeKodu == null)
                ).ToListAsync();
        }



        [HttpGet("HesapByTamAd")]

        public async Task<ActionResult<IEnumerable<Hesap>>> HesapByTamAd(string Ad)
        {
            return await _context.Hesaplar.Include(a => a.Kullanıcı).Include(b => b.Banka).
                Where(x =>
                (x.HesapSahibiTamAdı.Contains(Ad))
                ).ToListAsync();
        }



        private bool HesapExists(int id)
        {
            return _context.Hesaplar.Any(e => e.HesapID == id);
        }


    }
}
