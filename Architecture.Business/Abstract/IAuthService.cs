using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Entities.Dtos.AuthDtos;

namespace Architecture.Business.Abstract
{
    public interface IAuthService
    {
        
    IResult Register(RegisterDto registerDto);
    IDataResult<LoginUserDto> Login(LoginDto loginDto);
    IResult VerifyEmail(string token, string Email);
    IResult ResetPassword(string email);
    // IResult ChangePassword(ChangePasswordDto changePasswordDto);
    IResult VerifyResetPassword(VerifyResetPasswordDto resetPasswordDto);

    }
}