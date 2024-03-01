using System;
using Architecture.Core.DataAccess;
using Architecture.Core.DataAccess.EntityFramework.Abstract.Abstract;
using Architecture.Entities.Concrete;


namespace Architecture.DataAccess.Abstract
{
	public interface IOrderDal : IRepositoryBase<Order>
    {
		void AddRange(int userId, List<Order> orders);
	}
}

