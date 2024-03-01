using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Business.Abstract;
using Architecture.Entities.Dtos.AuthDtos;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _authService;

    public AuthController(IUserService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult RegisterUser([FromBody] RegisterDto registerDto)
    {
        var user = _authService.Register(registerDto);

        if (user.Success)
        {
            return Ok(user);
        }

        return BadRequest(user);
    }

    [HttpPost("login")]
    public IActionResult LoginUser([FromBody] LoginDto loginDto)
    {
        var login = _authService.Login(loginDto);
        return Ok(login);
    }
}
