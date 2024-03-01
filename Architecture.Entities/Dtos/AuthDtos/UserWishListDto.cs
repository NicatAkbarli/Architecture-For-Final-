

using Architecture.Entities.Dtos.WishlistDtos;

namespace Architecture.Entities.Dtos.AuthDtos
{
    public class UserWishListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<WishlistItemDto> WishLists { get; set; }
    }
}