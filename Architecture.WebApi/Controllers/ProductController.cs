using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Business.Abstract;
using Architecture.Entities.Dtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace Architecture.WebApi.Controllers
{
   
[ApiController]
[Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("create")]
        public IActionResult CreateProduct([FromBody] ProductCreateDto productCreate )
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value;
           
            var result = _productService.CreateProduct(productCreate);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateProduct([FromBody] ProductUpdateDto productUpdate)
        {
            var result = _productService.UpdateProduct(productUpdate);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetProductById(int id)
        {
            var result = _productService.GetProductById(id);
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAllProducts(int? page=1)
        {
            var result = _productService.GetAllProdcuts(page.Value);
            return Ok(result.Data);
        }

        [HttpGet("featured")]
        public IActionResult GetFeaturedProducts()
        {
            var result = _productService.GetFeaturedProducts();
            return Ok(result);
        }

        [HttpGet("recent")]
        public IActionResult GetRecentProducts()
        {
            var result = _productService.GetRecentProduct();
            return Ok(result.Data);
        }

        [HttpGet("filter")]
        public IActionResult FilterProducts([FromQuery] int categoryId, [FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var result = _productService.FilterProduct(categoryId, minPrice, maxPrice);
            return Ok(result);
        }


        [HttpDelete("delete/{id}")]
        public IActionResult RemoveProduct(int id)
        {
            var result = _productService.RemoveProduct(id);
            return Ok(result);
        }
    
    }
}