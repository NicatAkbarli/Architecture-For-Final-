using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.DataAccess.EntityFramework.Concrete;
using Architecture.DataAccess.Abstract;
using Architecture.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Architecture.DataAccess.Concrete.EntityFramework
{
    public class EfWishListDal: EfRepositoryBase<WishList, AppDbContext>, IWishListDal
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public List<WishList> GetUserWishList(int id)
        {
            using var context = new AppDbContext();
            var result = context.wishLists.Where(x=>x.UserId == id).Include(x=>x.Product).ToList();
            return result;
        }
    }
}