using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Business.Abstract;
using Architecture.Core.Utilities.Results.Concrete.SuccessResults;
using Architecture.Entities.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody]CategoryCreateDto addCategoryDto)
    {
       var res = _categoryService.CreateCategory(addCategoryDto); 
        return Ok(res);
    }
    

       [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetCategories();
            return Ok(result);
        }

        [HttpGet("featured")]
        public IActionResult GetHomeFeatured()
        {
            var result = _categoryService.GetHomeCagories();
            return Ok(result);
        }


        [HttpGet("navbar")]
        public IActionResult GetNavbarLower()
        {
            var result = _categoryService.GetNavbarCategories();
            return Ok(result);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CategoryCreateDto categoryCreate)
        {
            var result = _categoryService.CreateCategory(categoryCreate);
            return Ok(result);
        }

        // sitename/api/category/12
        [HttpPut("update/{id}")]
        public IActionResult Update(int id,[FromBody] CategoryUpdateDto categoryUpdate)
        {
            var result = _categoryService.UpdateCategory(id, categoryUpdate);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            return Ok(result);
        }

}
