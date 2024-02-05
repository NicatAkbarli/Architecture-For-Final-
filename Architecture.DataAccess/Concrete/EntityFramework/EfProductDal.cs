using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.DataAccess.EntityFramework.Concrete;
using Architecture.DataAccess.Abstract;
using Architecture.Entities.Concrete;

namespace Architecture.DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfRepositoryBase<Product, AppDbContext>, IProductDal
{
    
}
