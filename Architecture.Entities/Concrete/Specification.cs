using System;
using Architecture.Core.Entities.Abstract;

namespace Architecture.Entities.Concrete
{
	public class Specification : BaseEntity, IEntity
    {
		public string Key { get; set; }
		public string Value { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}

