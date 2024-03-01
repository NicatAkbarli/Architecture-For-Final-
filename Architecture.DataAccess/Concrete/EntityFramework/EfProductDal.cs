using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.DataAccess.EntityFramework.Concrete;
using Architecture.DataAccess.Abstract;
using Architecture.Entities.Concrete;
using Architecture.Entities.Dtos.ProductDtos;
using Microsoft.EntityFrameworkCore;

namespace Architecture.DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfRepositoryBase<Product, AppDbContext>, IProductDal
{
        public Product GetProduct(int id)
        {
            using var context = new AppDbContext();
            var product = context.Products.Include(x => x.Category).Include(x => x.Specifications).SingleOrDefault(x => x.Id == id);
            return product;
        }

        public void RemoveProductQuantity(List<ProductDecrementDto> productDecrement)
        {
            using var context = new AppDbContext();
            for (int i = 0; i < productDecrement.Count; i++)
            {
                var product = context.Products.FirstOrDefault(x=>x.Id == productDecrement[i].ProductId);
                product.Quantity -= productDecrement[i].Quantity;
                context.SaveChanges();
            }

}

}
