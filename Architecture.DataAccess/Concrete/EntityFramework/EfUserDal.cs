using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.DataAccess.EntityFramework.Concrete;
using Architecture.DataAccess.Abstract;
using Architecture.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Architecture.DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfRepositoryBase<User, AppDbContext>, IUserDal
{
    public User GetUserByEmail(string email)
    {
        // Error burda idi.
        using var context = new AppDbContext();
        return context.Users.FirstOrDefault(u => u.Email == email);
    }
}
