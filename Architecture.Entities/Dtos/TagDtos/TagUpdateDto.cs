using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Entities.Dtos.TagDtos
{
    public class TagUpdateDto
    {
         public string TagName { get; set; }
        public DateTime CreatedDate { get; }
        public bool IsFeatured { get; set; }
        public TagUpdateDto()
        {
            CreatedDate = DateTime.Now;
        }
    }
}