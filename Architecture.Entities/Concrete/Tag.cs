using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Entities.Abstract;

namespace Architecture.Entities.Concrete
{
    public class Tag : BaseEntity,IEntity
    {
        public string TagName { get; set; }
        public Product Product { get; set; }
        public string ProductId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsFeatured { get; set; }
    }
}