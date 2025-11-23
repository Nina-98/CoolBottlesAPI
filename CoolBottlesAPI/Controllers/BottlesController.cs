using CoolBottlesAPI.Data;
using CoolBottlesAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoolBottlesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BottlesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BottlesController(AppDbContext db) => _db = db;

        // Public: Get all bottles
        [HttpGet]
        public async Task<IActionResult> GetBottles() =>
            Ok(await _db.Bottles.ToListAsync());

        // Admin: Add bottle
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBottle(Bottle bottle)
        {
            _db.Bottles.Add(bottle);
            await _db.SaveChangesAsync();
            return Ok(bottle);
        }

        // Admin: Delete bottle
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBottle(int id)
        {
            var bottle = await _db.Bottles.FindAsync(id);
            if (bottle == null) return NotFound();

            _db.Bottles.Remove(bottle);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
