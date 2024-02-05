using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Entities.Concrete;

public class BaseEntity
{
    public int Id { get; set; } 
    public DateTime CreatedDate { get; set; }
}
