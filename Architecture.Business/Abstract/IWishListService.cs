using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Entities.Dtos.WishlistDtos;


namespace Architecture.Business.Abstract
{
    public interface IWishListService
    {
        IDataResult<List<WishlistItemDto>> GetUserWishlist(int id);
        IResult AddWishlist(int userId , WishListAddItemDto addItem);
    }
    
}