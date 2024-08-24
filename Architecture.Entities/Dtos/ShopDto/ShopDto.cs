using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Entities.Dtos.ShopDto
{
    public class ShopDto
    {

        public int UserId { get; set; }
        public string BannerUrl { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsVerified { get; set; }
        public string? ShopName { get; set; }
    }
}