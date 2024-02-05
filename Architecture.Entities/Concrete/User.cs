using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Entities.Abstract;
using Architecture.Core.Entities.Concrete;

namespace Architecture.Entities.Concrete;

public class User : BaseUser, IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Follower> Followers { get; set; }
    public List<Comment> Comments { get; set; }
}
