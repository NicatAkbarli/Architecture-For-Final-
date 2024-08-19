using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Business.Abstract;
using Architecture.Entities.Dtos.OrderDtos;
using Architecture.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace Architecture.WebApi.Controllers
{
  [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _appUserService;
        public OrderController(IOrderService orderService, IUserService appUserService)
        {
            _orderService = orderService;
            _appUserService = appUserService;
        }

        
        [HttpPost("create")]
        public IActionResult OrderProduct([FromBody]List<OrderCreateDto> orderCreate)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = Convert.ToInt32(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value);
            var res =_orderService.CreateOrder(userId, orderCreate);

            return Ok(res);
        }

        
        [HttpGet("userorder")]
        public IActionResult OrderUser()
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = Convert.ToInt32(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value);
            var userOrder = _appUserService.GetUserOrders(userId);
            return Ok(userOrder);
        }

        
        [HttpGet("get/{ordernumber}")]
        public IActionResult OrderUser(string ordernumber)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var userId = Convert.ToInt32(jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid").Value);
            return Ok();
        }

        [HttpPut("status/{orderNumber}")]
        public IActionResult OrderChangeStatus(string orderNumber,[FromBody] OrderEnum order)
        {
            var res = _orderService.ChangeOrderStatus(orderNumber, order);
            return Ok(res);
        }


    }
}
