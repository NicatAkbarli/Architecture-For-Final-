using System;
using Architecture.Core.DataAccess.EntityFramework.Concrete;
using Architecture.DataAccess.Abstract;
using Architecture.Entities.Concrete;


namespace Architecture.DataAccess.Concrete.EntityFramework
{
     public class  EfSpecificationDal : EfRepositoryBase<Specification, AppDbContext>, ISpecificationDal
    {
                public void AddSpecifications(int productId, List<Specification> specifications)
                {
                    using var context = new AppDbContext();
                    List<Specification> res = specifications.Select(x => { x.ProductId = productId; x.CreatedDate = DateTime.Now; return x; }).ToList();

                    context.Specifications.AddRange(res);
                    context.SaveChanges();
                }
    }
}

