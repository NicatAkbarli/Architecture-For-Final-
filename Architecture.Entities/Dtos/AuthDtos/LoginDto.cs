using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Entities.Dtos.AuthDtos;

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
