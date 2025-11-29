using CoolBottlesAPI.Data;
using CoolBottlesAPI.Models.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoolBottlesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromoCodesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public PromoCodesController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetPromoCodes() =>
            Ok(await _db.PromoCodes.ToListAsync());

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePromo(PromoCode promo)
        {
            _db.PromoCodes.Add(promo);
            await _db.SaveChangesAsync();
            return Ok(promo);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePromo(int id, PromoCode updated)
        {
            var promo = await _db.PromoCodes.FindAsync(id);
            if (promo == null) return NotFound();

            promo.Code = updated.Code;
            promo.Value = updated.Value;
            promo.Type = updated.Type;
            promo.Expiration = updated.Expiration;
            promo.Active = updated.Active;

            await _db.SaveChangesAsync();
            return Ok(promo);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePromo(int id)
        {
            var promo = await _db.PromoCodes.FindAsync(id);
            if (promo == null) return NotFound();

            _db.PromoCodes.Remove(promo);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
