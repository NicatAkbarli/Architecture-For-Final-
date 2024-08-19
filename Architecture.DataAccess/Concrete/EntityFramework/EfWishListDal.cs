using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Architecture.DataAccess.Abstract;
using Architecture.Entities.Concrete;
using Architecture.Core.DataAccess.EntityFramework.Concrete;

namespace Architecture.DataAccess.Concrete.EntityFramework
{
    public class EfWishListDal : EfRepositoryBase<WishList, AppDbContext>, IWishListDal
    {
        private readonly AppDbContext _context;

        public EfWishListDal(AppDbContext context) 
        {
            _context = context;
        }

        public void Add(WishList entity)
        {
            _context.WishLists.Add(entity);
            _context.SaveChanges();
        }

        public List<WishList> GetUserWishList(int id)
        {
            return _context.WishLists
                .Where(x => x.UserId == id)
                .Include(x => x.Product)
                .ToList();
        }
    }
}
