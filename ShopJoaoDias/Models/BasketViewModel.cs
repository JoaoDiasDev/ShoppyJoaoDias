using Entities;

namespace ShopJoaoDias.Models
{
    public class BasketViewModel
    {
        public BasketDO BasketDO { get; set; } = new BasketDO();
        public List<BasketDO> BasketList { get; set; } = new List<BasketDO>();
    }
}
