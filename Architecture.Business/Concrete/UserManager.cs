using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Business.Abstract;
using Architecture.Core.Utilities.Results.Abstract;
using Architecture.Core.Utilities.Results.Concrete.ErrorResults;
using Architecture.Core.Utilities.Results.Concrete.SuccessResults;
using Architecture.Core.Utilities.Security.Hashing;
using Architecture.Core.Utilities.Security.Jwt;
using Architecture.DataAccess.Abstract;
using Architecture.Entities.Commands;
using Architecture.Entities.Concrete;
using Architecture.Entities.Dtos.AuthDtos;
using Architecture.Entities.Dtos.UserDtos;
using AutoMapper;
using MassTransit;

namespace Architecture.Business.Concrete
{
    public class UserManager : IUserService
    {
        
    private readonly IUserDal _userDal;
   private readonly IMapper _mapper;
      private readonly IPublishEndpoint _publishEndpoint;
        public UserManager(IUserDal userDal, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _userDal = userDal;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

            public Task<List<UserInfoDto>> GetAllUsers()
            {
                throw new NotImplementedException();
            }

        public IDataResult<UserOrderDto> GetUserOrders(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<UserWishListDto> GetUserWishListById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<LoginUserDto> Login(LoginDto loginDto)
    {
      

        var user = _userDal.GetUserByEmail(loginDto.Email);

        var response = new LoginUserDto()
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            // Roles = user.UserRoles.Select(x => x.Role).Select(x => x.RoleName).ToArray(),
            Roles = new string[]{"Admin","User"},
            Token = Token.CreateToken(user, new string[]{"Admin","User"})
        };
        return new SuccessDataResult<LoginUserDto>(response);
    }

    public IResult Register(RegisterDto registerDto)
    {
        var mapp = _mapper.Map<User>(registerDto);
        byte[] passwordHash, passwordSalt;
        PasswordHashing.HashPassword(registerDto.Password, out passwordHash, out passwordSalt);
        mapp.PasswordHash = passwordHash;
        mapp.PasswordSalt = passwordSalt;
        mapp.DeactiveTime = DateTime.Now;
        mapp.ConfirmationToken = Guid.NewGuid().ToString();

        SendEmailCommand sendEmail = new();
        sendEmail.Email = registerDto.Email;
        sendEmail.FirstName = "Salam";
        sendEmail.LastName = "Salam";
        sendEmail.Token = Guid.NewGuid().ToString();
        _publishEndpoint.Publish<SendEmailCommand>(sendEmail);

        _userDal.Add(mapp);
        return new SuccessResult();
    }

    public IResult ResetPassword(string email)
    {
        throw new NotImplementedException();
    }

    public IResult VerifyEmail(string token, string Email)
    {
        throw new NotImplementedException();
    }

    public IResult VerifyResetPassword(VerifyResetPasswordDto resetPasswordDto)
    {
        throw new NotImplementedException();
    }

    #region Business rules
    private IResult CheckIsUserActive(LoginDto loginDto)
    {
        var res = _userDal.Get(x => x.Email == loginDto.Email);
        if (res == null)
            return new ErrorResult();

        return new SuccessResult();
    }

    private IResult CheckUserPassword(LoginDto loginDto)
    {
        var res = _userDal.Get(x => x.Email == loginDto.Email);
        bool pass = PasswordHashing.VerifyPassword(loginDto.Password, res.PasswordHash, res.PasswordSalt);
        if (!pass)
            return new ErrorResult();

        return new SuccessResult();
    }
    #endregion

    }
}