using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Entities.Abstract;

namespace Architecture.Entities.Concrete;

public class Follower : BaseEntity, IEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int ShopId { get; set; }
    public Shop Shop { get; set; }
    public bool IsNotificated { get; set; }
}
