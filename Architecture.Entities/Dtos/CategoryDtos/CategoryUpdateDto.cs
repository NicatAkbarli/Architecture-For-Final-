﻿using System;
namespace Architecture.Entities.Dtos.CategoryDtos
{
	public class CategoryUpdateDto
	{
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; }
        public bool IsNavbar { get; set; }
        public bool IsFeatured { get; set; }
        public string PhotoUrl { get; set; }
        public CategoryUpdateDto()
        {
            CreatedDate = DateTime.Now;
        }
    }
}

