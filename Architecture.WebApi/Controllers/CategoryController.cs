using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Business.Abstract;
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
       var res =  _categoryServicee.CreateCategory(addCategoryDto);
        return Ok(res);
    }
}
