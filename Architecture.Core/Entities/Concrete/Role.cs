using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Entities.Abstract;

namespace Architecture.Core.Entities.Concrete;

public class Role : IEntity
{
    public int Id { get; set; }
    public string RoleName { get; set; }
}
