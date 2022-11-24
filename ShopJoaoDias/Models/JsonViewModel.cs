using Entities;

namespace ShopJoaoDias.Models
{
    public class JsonViewModel
    {
        public UserDO User { get; set; } = new UserDO();
        public List<BasketDO> BasketList { get; set; } = new List<BasketDO>();
        public List<WishlistDO> WishListDoList { get; set; } = new List<WishlistDO>();
        public WishlistDO WishlistDO { get; set; } = new WishlistDO();
    }
}
