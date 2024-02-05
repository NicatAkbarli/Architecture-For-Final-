using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Entities.Abstract;

namespace Architecture.Entities.Concrete;

public class CommentPhoto : BaseEntity, IEntity
{
    public string PhotoUrl { get; set; }
    public int CommentId { get; set; }
    public Comment Comment { get; set; }
}
