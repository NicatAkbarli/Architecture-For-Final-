using System;
using AutoMapper;
using Architecture.Business.Abstract;
using Architecture.Core.Utilities.Business;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Core.Utilities.Results.Concrete.ErrorResults;
using Architecture.Core.Utilities.Results.Concrete.SuccessResults;
using Architecture.DataAccess.Abstract;
using Architecture.Entities.Concrete;
using Architecture.Entities.Dtos.OrderDtos;
using Architecture.Entities.Dtos.ProductDtos;
using Architecture.Entities.Dtos.UserDtos;
using Architecture.Entities.Enums;

namespace Architecture.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public OrderManager(IOrderDal orderDal, IMapper mapper, IProductService productService)
        {
            _orderDal = orderDal;
            _mapper = mapper;
            _productService = productService;
        }

        public IResult ChangeOrderStatus(string orderNumber, OrderEnum orderStatus)
        {
            var order = _orderDal.Get(x => x.OrderNumber == orderNumber);
            order.OrderEnum = orderStatus;
            _orderDal.Update(order);
            return new SuccessResult();
        }

        public IResult CreateOrder(int userId, List<OrderCreateDto> orderCreate)
        {
            var productIds = orderCreate.Select(x => x.ProductId).ToList();
            var quantity = orderCreate.Select(x => x.Quantity).ToList();
         
            var mapper = _mapper.Map<List<Order>>(orderCreate);
            _orderDal.AddRange(userId, mapper);
            var productOrder = orderCreate.Select(x => new ProductDecrementDto
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList();
            _productService.ProductOrder(productOrder);
            return new SuccessResult();
        }

        public IDataResult<OrderUserDto> GetOrderStatusByProductId(int userId, int productId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<UserOrderDto> GetUserOrderById(int userId)
        {
            throw new NotImplementedException();
        }

        private IResult IsProductInStock(List<int> productIds)
        {
            var product = _productService.CheckProductStock(productIds);
            if (product.Data)
            {
                return new SuccessResult();
            }
            return new ErrorResult();

        }
    }
}

