using System;
using Architecture.Core.DataAccess.EntityFramework.Concrete;
using Architecture.DataAccess.Abstract;
using Architecture.Entities.Concrete;
using Architecture.Entities.Enums;


namespace Architecture.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfRepositoryBase<Order, AppDbContext>, IOrderDal
    {
        public void AddRange(int userId, List<Order> orders)
        {
            using var context = new AppDbContext();
            var res = orders.Select(x => { x.AppUserId = userId; x.CreatedDate = DateTime.Now; x.OrderNumber = Guid.NewGuid().ToString().Substring(0, 18); x.OrderEnum = OrderEnum.OnPending; return x; }).ToList();
            context.AddRangeAsync(res);
            context.SaveChanges();
        }
    }
}

