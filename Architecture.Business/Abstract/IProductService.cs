using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Entities.Dtos.CartDtos;
using Architecture.Entities.Dtos.ProductDtos;

namespace Architecture.Business.Abstract
{
    public interface IProductService
    {
        
		IResult CreateProduct(ProductCreateDto productCreate);
		IResult UpdateProduct(ProductUpdateDto productUpdate);
		IResult RemoveProduct(int id);
		IDataResult<ProductDetailDto> GetProductById(int id);
		IDataResult<List<ProductDetailDto>> GetProductsById(List<CartItemDto> cartItems);
        IDataResult<List<ProductFeaturedDto>> GetFeaturedProducts();
		IDataResult<List<ProductRecentDto>> GetRecentProduct();
		IDataResult<List<ProductFilterDto>> FilterProduct(int categoryId, decimal minPrice, decimal maxPrice);
		IDataResult<ProductResponseDto> GetAllProdcuts(int currentPage);
		IDataResult<bool> CheckProductStock(List<int> ids);
		IResult ProductOrder(List<ProductDecrementDto> productDecrement);
	
    }
}