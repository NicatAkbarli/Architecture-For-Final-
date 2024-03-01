using System;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Entities.Dtos.OrderDtos;
using Architecture.Entities.Dtos.UserDtos;
using Architecture.Entities.Enums;

namespace Architecture.Business.Abstract
{
	public interface IOrderService
	{
		IResult CreateOrder(int userId, List<OrderCreateDto> orderCreate);
		IResult ChangeOrderStatus(string orderNumber, OrderEnum orderStatus);
		IDataResult<UserOrderDto> GetUserOrderById(int userId);
		IDataResult<OrderUserDto> GetOrderStatusByProductId(int userId, int productId);
	}
}

