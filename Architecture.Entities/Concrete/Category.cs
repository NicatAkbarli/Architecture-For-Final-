using Architecture.Core.Entities.Abstract;

namespace Architecture.Entities.Concrete;

public class Category : BaseEntity, IEntity
{
   
    public string CategoryName { get; set; }
    public string SeoUrl { get; set; }
    public string Description { get; set; }
}
