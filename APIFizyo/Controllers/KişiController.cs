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
    public class KişiController : ControllerBase
    {
        private readonly APIFizyoDBContext _context;

        public KişiController(APIFizyoDBContext context)
        {
            _context = context;
        }

        // GET: api/Kişi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kişi>>> GetKişiler()
        {
            return await _context.Kişiler.ToListAsync();
        }

        // GET: api/Kişi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kişi>> GetKişi(int id)
        {
            var kişi = await _context.Kişiler.FindAsync(id);

            if (kişi == null)
            {
                return NotFound();
            }

            return kişi;
        }



        // PUT: api/Kişi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKişi(int id, Kişi kişi)
        {
            if (id != kişi.KişiID)
            {
                return BadRequest();
            }

            _context.Entry(kişi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KişiExists(id))
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

        // POST: api/Kişi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kişi>> PostKişi(Kişi kişi)
        {
            _context.Kişiler.Add(kişi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKişi", new { id = kişi.KişiID }, kişi);
        }

        // DELETE: api/Kişi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKişi(int id)
        {
            var kişi = await _context.Kişiler.FindAsync(id);
            if (kişi == null)
            {
                return NotFound();
            }

            _context.Kişiler.Remove(kişi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KişiExists(int id)
        {
            return _context.Kişiler.Any(e => e.KişiID == id);
        }



        [HttpGet("KişilerFiltreli")]
        public async Task<ActionResult<IEnumerable<Kişi>>> KişilerFiltreli(string AdVeİkinciAd, string Soyad, int? İlID, int? Yaş, int? CinsiyetID)

        {
            List<Kişi> Kişiler =await _context.Kişiler.Include(a => a.Kullanıcı).ThenInclude(a=>a.Rol).Include(a => a.Cinsiyet).Include(a => a.İl).ToListAsync();

            List<Kişi> x = Kişiler.
            Where(a =>
                      (a.Cinsiyet.CinsiyetID == CinsiyetID || CinsiyetID == null)
                      &&
                      (a.İl.İlID == İlID || İlID == null)
                      &&
                      (a.Yaş == Yaş || Yaş == null)
                      &&
                      (a.AdVeİkinciAd == AdVeİkinciAd || AdVeİkinciAd == null)
                      &&
                      (a.Soyad == Soyad || Soyad == null)
                  ).ToList();
            return x;


        }


    }
}
