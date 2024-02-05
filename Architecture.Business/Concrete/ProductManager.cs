using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.DataAccess.Abstract;

namespace Architecture.Business.Concrete
{
    public class ProductManager
    {
        
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

   
    }
}