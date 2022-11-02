using Entities;

namespace ShopJoaoDias.Models
{
    public class BasketViewModel
    {
        public BasketDO BasketDO { get; set; } = new BasketDO();
        public List<BasketDO> BasketList { get; set; } = new List<BasketDO>();

        public List<AddressDO> AddressList { get; set; } = new List<AddressDO>();
        public AddressDO Address { get; set; } = new AddressDO();
        public List<ShippingDO> ShippingList { get; set; } = new List<ShippingDO>();
        public ShippingDO Shipping { get; set; } = new ShippingDO();
        public List<PaymentDO> PaymentList { get; set; } = new List<PaymentDO>();
        public PaymentDO Payment { get; set; } = new PaymentDO();
    }
}
