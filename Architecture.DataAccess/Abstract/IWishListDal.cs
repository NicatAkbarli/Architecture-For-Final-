using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.DataAccess.EntityFramework.Abstract.Abstract;
using Architecture.Entities.Concrete;

namespace Architecture.DataAccess.Abstract
{
    public interface IWishListDal  : IRepositoryBase<WishList>
    {
       
        List<WishList> GetUserWishList(int id);
    }
}