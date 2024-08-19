using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Architecture.Business.Abstract;
using Architecture.Entities.Dtos.WishlistDtos;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Core.Utilities.Results.Concrete.SuccessResults;
using Architecture.Core.Utilities.Results.Concrete.ErrorResults;

namespace Architecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class WishlistController : ControllerBase
    {
        private readonly IWishListService _wishListService;

        public WishlistController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }

        private int GetCurrentUserId()
        {
            
            return int.Parse(HttpContext.User.FindFirst("userId")?.Value ?? "0");
        }

       
        [HttpGet]
        public IActionResult GetUserWishlist()
        {
            var userId = GetCurrentUserId();
            var result = _wishListService.GetUserWishlist(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        
        [HttpPost]
        public IActionResult AddWishlist([FromBody] WishListAddItemDto addItem)
        {
            var userId = GetCurrentUserId();
            var result = _wishListService.AddWishlist(userId, addItem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
