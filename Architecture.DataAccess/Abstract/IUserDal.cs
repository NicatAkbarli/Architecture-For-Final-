using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.DataAccess.EntityFramework.Abstract;
using Architecture.Entities.Concrete;

namespace Architecture.DataAccess.Abstract;

public interface IUserDal : IRepositoryBase<User>
{
    User GetUserByEmail(string email);
}
