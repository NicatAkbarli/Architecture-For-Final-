﻿using System;
namespace Architecture.Entities.Dtos.ProductDtos
{
	public class ProductDto
	{
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string PhotoUrl { get; set; }
    }
}

