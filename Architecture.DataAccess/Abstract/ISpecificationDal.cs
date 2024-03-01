using System;
using Architecture.Core.DataAccess;
using Architecture.Core.DataAccess.EntityFramework.Abstract.Abstract;
using Architecture.Entities.Concrete;

namespace Architecture.DataAccess.Abstract
{
	public interface ISpecificationDal : IRepositoryBase<Specification>
    {
		void AddSpecifications(int productId, List<Specification> specifications);
	}
}

