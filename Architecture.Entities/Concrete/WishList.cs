using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Entities.Abstract;

namespace Architecture.Entities.Concrete
{
    public class WishList : BaseEntity,IEntity
    {
     public int ProductId { get; set; }
     public Product Product { get; set; }
     public int UserId { get; set; }
     public User User { get; set; }
 
    }
}