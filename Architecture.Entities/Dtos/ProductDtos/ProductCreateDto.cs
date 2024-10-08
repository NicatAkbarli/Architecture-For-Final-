﻿using System;
using Architecture.Entities.Dtos;
using Architecture.Entities.Dtos.SpecificationDtos;

namespace Architecture.Entities.Dtos.ProductDtos
{
	public class ProductCreateDto
	{
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int ShopId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<SpecificationCreateDto> Specifications { get; set; }
    }
}

