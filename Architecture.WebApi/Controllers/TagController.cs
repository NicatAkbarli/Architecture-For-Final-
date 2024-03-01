using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Business.Abstract;
using Architecture.Entities.Concrete;
using Architecture.Entities.Dtos.TagDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Architecture.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

    

         [HttpPost("create")]
        public IActionResult Create([FromBody] TagCreateDto tagCreate)
        {
            var result = _tagService.CreateTag(tagCreate);
            return Ok(result);
        }

        
        [HttpPut("update/{id}")]
        public IActionResult Update(int id,[FromBody] TagUpdateDto categoryUpdate)
        {
            var result = _tagService.UpdateTag(id, categoryUpdate);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _tagService.DeleteTag(id);
            return Ok(result);
        }


    }
}