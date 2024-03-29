﻿using System;
using Architecture.Entities.Dtos.SpecificationDtos;

namespace Architecture.Entities.Dtos.ProductDtos
{
	public class ProductDetailDto
	{
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string PhotoUrl { get; set; }
        public List<SpecificationListDto> Specifications { get; set; }
    }
}

