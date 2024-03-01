using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.DataAccess.EntityFramework.Abstract;
using Architecture.Core.DataAccess.EntityFramework.Abstract.Abstract;
using Architecture.Entities.Concrete;
using Architecture.Entities.Dtos.ProductDtos;

namespace Architecture.DataAccess.Abstract;

public interface IProductDal : IRepositoryBase<Product>
{
    
		Product GetProduct(int id);
		void RemoveProductQuantity(List<ProductDecrementDto> productDecrement);
	
}
