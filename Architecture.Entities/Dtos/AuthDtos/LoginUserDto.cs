using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Entities.Dtos.AuthDtos;

public class LoginUserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string[] Roles { get; set; }
    public string Token { get; set; }
}
