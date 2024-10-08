using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Entities.Abstract;

namespace Architecture.Entities.Concrete;

public class Product : BaseEntity, IEntity
{
    public List<Order> Orders { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PhotoUrl { get; set; }
    public string SeoUrl { get; set; }
    
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public decimal Discount { get; set; }
    public int ShopId { get; set; }
    public Shop Shop { get; set; }
    public int Quantity { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DiscountStartDate { get; set; }
    public DateTime DiscountEndtDate { get; set; }
    public List<Advertisement> Advertisements { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Specification> Specifications { get; set; }
}

