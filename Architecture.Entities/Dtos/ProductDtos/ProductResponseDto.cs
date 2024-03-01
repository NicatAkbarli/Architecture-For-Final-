﻿using System;
namespace Architecture.Entities.Dtos.ProductDtos
{
	public class ProductResponseDto
	{
		public int PageSize { get; set; }
		public int CurrentSize { get; set; }
		public List<ProductDto> Products { get; set; }
	}
}

