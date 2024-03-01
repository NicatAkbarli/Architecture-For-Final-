using System;
namespace Architecture.Entities.Dtos.ProductDtos
{
	public class ProductOrderDto
	{
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

