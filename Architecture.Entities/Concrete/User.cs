using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Entities.Abstract;
using Architecture.Core.Entities.Concrete;

namespace Architecture.Entities.Concrete;

public class User : BaseUser, IEntity
{
    public List<Order> Orders { get; set; }
    public string FirstName { get; set; }
    public int ShopId { get; set; }
    public string LastName { get; set; }
      public ICollection<Shop> Shops { get; set; }
    public List<Follower> Followers { get; set; }
    public List<Comment> Comments { get; set; }
}
