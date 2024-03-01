using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Architecture.Core.DataAccess.EntityFramework.Concrete;
using Architecture.DataAccess.Abstract;
using Architecture.DataAccess.Concrete.EntityFramework;
using Architecture.Entities.Concrete;
using Architecture.Entities.Dtos.ProductDtos;

namespace Architecture.DataAccess.Concrete.PosgresSql;

public class PlProductDal : IProductDal
{
    public void Add(Product entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Product entity)
    {
        throw new NotImplementedException();
    }

    public Product Get(Expression<Func<Product, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAll(Expression<Func<Product, bool>>? filter = null)
    {
        throw new NotImplementedException();
    }

    public Product GetProduct(int id)
    {
        throw new NotImplementedException();
    }

    public void RemoveProductQuantity(List<ProductDecrementDto> productDecrement)
    {
        throw new NotImplementedException();
    }

    public void Update(Product entity)
    {
        throw new NotImplementedException();
    }
}
