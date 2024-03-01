using System;
using Architecture.Entities.Dtos.OrderDtos;

namespace Architecture.Entities.Dtos.UserDtos
{
	public class UserOrderDto
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<OrderUserDto> Orders { get; set; }
    }
}