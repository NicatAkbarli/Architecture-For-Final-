using Architecture.DataAccess.Concrete.EntityFramework;
using Architecture.Entities.Concrete;
using Architecture.Entities.Dtos.ShopDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
public class ShopController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ShopController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Shop
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShopDto>>> GetShops()
    {
        var shops = await _context.Shops.Include(s => s.User).ToListAsync();
        var shopDtos = _mapper.Map<List<ShopDto>>(shops);
        return Ok(shopDtos);
    }

    // GET: api/Shop/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ShopDto>> GetShop(int id)
    {
        var shop = await _context.Shops.Include(s => s.User).FirstOrDefaultAsync(s => s.Id == id);
        if (shop == null)
        {
            return NotFound();
        }
        var shopDto = _mapper.Map<ShopDto>(shop);
        return Ok(shopDto);
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ShopDto>> AddShop([FromBody] ShopDto newShopDto)
    {
        if (newShopDto == null || string.IsNullOrWhiteSpace(newShopDto.ShopName))
        {
            return BadRequest("Shop is invalid.");
        }

        // Kullanıcıyı veritabanında bul
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == newShopDto.UserId);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        var newShop = _mapper.Map<Shop>(newShopDto);
        // User'ı Shop'a atayın
        newShop.User = user;

        _context.Shops.Add(newShop);
        await _context.SaveChangesAsync();

        var createdShopDto = _mapper.Map<ShopDto>(newShop);
        return CreatedAtAction(nameof(GetShop), new { id = newShop.Id }, createdShopDto);
    }





    // PUT: api/Shop/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateShop(int id, [FromBody] ShopDto updatedShopDto)
    {
        if (updatedShopDto == null || string.IsNullOrWhiteSpace(updatedShopDto.ShopName))
        {
            return BadRequest("Shop is invalid.");
        }

        var existingShop = await _context.Shops.FindAsync(id);
        if (existingShop == null)
        {
            return NotFound();
        }

        _mapper.Map(updatedShopDto, existingShop);

        _context.Entry(existingShop).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Shop/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShop(int id)
    {
        var shop = await _context.Shops.FindAsync(id);
        if (shop == null)
        {
            return NotFound();
        }

        _context.Shops.Remove(shop);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
