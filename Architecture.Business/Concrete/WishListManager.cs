using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Business.Abstract;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Core.Utilities.Results.Concrete.ErrorResults;
using Architecture.Core.Utilities.Results.Concrete.SuccessResults;
using Architecture.DataAccess.Abstract;
using Architecture.Entities.Concrete;
using Architecture.Entities.Dtos.WishlistDtos;
using AutoMapper;


namespace Architecture.Business.Concrete
{
    public class WishListManager : IWishListService
    {
        private readonly IWishListDal _wishListDal;
        private readonly IMapper _mapper;
        public WishListManager(IWishListDal wishListDal, IMapper mapper)
        {
            _wishListDal = wishListDal;
            _mapper = mapper;
        }

        public IResult AddWishlist(int userId, WishListAddItemDto addItem)
        {
            var map = _mapper.Map<WishList>(addItem);
            map.CreatedDate = DateTime.Now;
            map.UserId = userId;
            _wishListDal.Add(map);
            return new SuccessResult();
        }

        public IDataResult<List<WishlistItemDto>> GetUserWishlist(int id)
        {
            var list = _wishListDal.GetUserWishList(id);
            if (!list.Any())
            {
                List<WishlistItemDto> emptyList = new();
                return new ErrorDataResult<List<WishlistItemDto>>(emptyList);
            }
            var mapList = _mapper.Map<List<WishlistItemDto>>(list);
            return new SuccessDataResult<List<WishlistItemDto>>(mapList);
       
        }
    }
}